using Mango.Services.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mango.Services.ProductAPI.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            seedProduct(modelBuilder);
        }


        private void seedProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                CategoryName = "TV",
                Description = "Smart TV 47 inch Samsung",
                ImageURL = "TestImageUrl",
                Price = 25,
                Name = "Samsung 47 inch"
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 2,
                CategoryName = "Console",
                Description = "XBOX Series X|S Microsoft Gaming Console",
                ImageURL = "TestImageUrl",
                Name = "XBOX Series X",
                Price =25,
            });
        }
    }
}
