using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Services
{
    public class CategoriesService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> GetById(byte id)
        {
            return await _context.Categories
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Categories
                          .SingleOrDefaultAsync(c => c.Name == name);
        }

        public Task<bool> IsvalidCategory(byte id)
        {
            return _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
