using Bogus;
using ECommerce.Shared.Models;

namespace ECommerce.OrderService.Data
{
    public static class DataSeed
    {
        public static void Seed(OrderDbContext dbcontext)
        {
            if (dbcontext.Orders.Any()) return;
            try
            {
                var orderId = 1;
                var orderFaker = new Faker<Order>().UseSeed(1337)
                    .RuleFor(o => o.Id, f =>0)

                .RuleFor(o => o.ProductId, f => f.Random.Number(1, 20))


                .RuleFor(o => o.CustomerName, f => f.Name.FullName())

                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 5))


                .RuleFor(o => o.OrderDate, f => f.Date.Past(6));
                dbcontext.Orders.AddRange(orderFaker.Generate(20));
                dbcontext.SaveChanges();
                Console.WriteLine("\nData seeding success\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
