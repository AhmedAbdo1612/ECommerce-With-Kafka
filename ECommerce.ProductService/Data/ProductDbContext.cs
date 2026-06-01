using Bogus;
using ECommerce.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductService.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
        
            var productId = 1;

            var productFaker = new Faker<Product>().UseSeed(1337)
              
                .RuleFor(p => p.Id, f => productId++)

                .RuleFor(p => p.Name, f => f.Commerce.ProductName())

                .RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(5, 500), 2))

                .RuleFor(p => p.Quantity, f => f.Random.Number(1, 150));
            for (int i = 0; i < 20; i++)
            {
                modelBuilder.Entity<Product>().HasData(productFaker.Generate());
            }
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>().HasData
        }
    }
}
