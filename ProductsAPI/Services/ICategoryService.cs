namespace ProductsAPI.Services
{
    public interface ICategoryService
    {
        Task<Category> GetByName(string name);
        Task<Category> GetById(byte id);
        Task<bool> IsvalidCategory(byte id);
    }
}
