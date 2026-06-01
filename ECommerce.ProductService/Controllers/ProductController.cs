using ECommerce.ProductService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ProductDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await  context.Products.SingleOrDefaultAsync(x => x.Id == id);
            return product is null ? Ok() : Ok(product);
        }
    }
}
