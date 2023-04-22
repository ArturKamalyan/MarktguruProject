using MarktguruProject.Entities;
using MarktguruProject.Repositories.Interfaces;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace MarktguruProject.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> Products = new();
        private int _nextId = 1;

        public async Task AddAsync(Product product)
        {
            var existingProduct = Products.Find(x => x.Name.Equals(product.Name));
            if (existingProduct != null)
                product.Name = $"{product.Name} {(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))}";

            product.Id = _nextId++;
            product.DateCreated = DateTime.Now;
            Products.Add(product);

            await Task.CompletedTask;
        }      
        public async Task EditAsync(Product product)
        {
            var index = Products.FindIndex(e => e.Id == product.Id);
            if (index >= 0)
                Products[index] = product;

            await Task.CompletedTask;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                Products.Remove(product);
                return true;
            }

            return false;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(Products);
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await Task.FromResult(Products.FirstOrDefault(p => p.Id == id));
        }
    }
}
