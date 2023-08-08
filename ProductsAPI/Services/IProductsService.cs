using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts(byte categoryId = 0);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetByCategory(string category);
        Task<Product> Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);

    }
}
