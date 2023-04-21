using MarktguruProject.Entities;
using MarktguruProject.Repositories.Interfaces;
using System.Xml;

namespace MarktguruProject.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> Products = new();
        private int _nextId = 1;

        public async Task AddAsync(Product product)
        {
            product.Id = _nextId++;
            Products.Add(product);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(Products);
        }
    }
}
