using Confluent.Kafka;
using ECommerce.OrderService.Data;
using ECommerce.OrderService.Kafka;
using ECommerce.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderDbContext orderDbContext, IKafkaProducer producer) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            return Ok(await orderDbContext.Orders.ToListAsync());
        }
        [HttpPost("create-order")]
        public async Task<ActionResult> CreateOrder(Order model)
        {
            model.OrderDate = DateTime.Now;
            await orderDbContext.Orders.AddAsync(model);
            await orderDbContext.SaveChangesAsync();
            await producer.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = model.Id.ToString(),
                Value = JsonConvert.SerializeObject(model)
            });
            return Ok();
        }

    }
}
