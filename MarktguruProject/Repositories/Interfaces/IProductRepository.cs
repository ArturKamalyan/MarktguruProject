using MarktguruProject.Entities;
using System.Xml;

namespace MarktguruProject.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task EditAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
    }
}
