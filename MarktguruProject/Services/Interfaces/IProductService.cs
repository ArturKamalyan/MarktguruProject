using MarktguruProject.DomainModels;

namespace MarktguruProject.Services.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(Product product);
        Task EditAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Product?>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
    }
}
