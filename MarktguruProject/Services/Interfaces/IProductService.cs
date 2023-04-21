using MarktguruProject.DomainModels;

namespace MarktguruProject.Services.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(Product product);
    }
}
