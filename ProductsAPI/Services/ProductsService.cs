using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;

        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(byte categoryId = 0)
        {
            return await _context.Products
                .Where(p=>p.CategoryId == categoryId || categoryId ==0)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(string category)
        {
            return await _context.Products
                  .Where(p => p.Category.Name == category)
                  .Include(p => p.Category)
                  .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public Product Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

      
    }
}
