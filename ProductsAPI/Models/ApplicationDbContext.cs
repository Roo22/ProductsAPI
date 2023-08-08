using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ProductsAPI.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set; }
        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //string imageUrl =
            //    "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80";

            //byte[] imageBytes;
            //using (HttpClient client = new HttpClient())
            //{
            //    imageBytes = await client.GetByteArrayAsync(imageUrl);
            //}
            //builder.Entity<Category>()
            //    .HasData(
            //     new Category { Id = 1, Name = "Category 1" },
            //     new Category { Id = 2, Name = "Category 2" }
            //    );
            //builder.Entity<Product>()
            //    .HasData(
            //    new Product
            //    {
            //        ProductId = 1,
            //        name = "Product 1",
            //        description = "This Product 1 description",
            //        Price = 35,
            //        Duration = 5000,
            //        Image = imageBytes,
            //        CreatedDate = DateTime.Now,
            //        StartDate = DateTime.Now.AddDays(1),
            //        CategoryId = 1,
            //        UserId = 1,
            //    },
            //    new Product
            //    {
            //        ProductId = 2,
            //        name = "Product 2",
            //        description = "This Product 2 description",
            //        Price = 50,
            //        Duration = 2000,
            //        Image = imageBytes,
            //        CreatedDate = DateTime.Now,
            //        StartDate = DateTime.Now.AddDays(2),
            //        CategoryId = 2,
            //        UserId = 1
            //    }
            //    );
        }
    }
}
