using MarktguruProject.Entities;
using System.Xml;

namespace MarktguruProject.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

    }
}
