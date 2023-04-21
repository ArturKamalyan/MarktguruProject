using MarktguruProject.DomainModels;
using MarktguruProject.Repositories.Interfaces;
using MarktguruProject.Services.Interfaces;

namespace MarktguruProject.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            product.DateCreated = DateTime.Now;
            await this._productRepository.AddAsync(product.ToEntity());
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var list = await this._productRepository.GetAllAsync();
            return list.Select(x => new Product(x)).ToList();
        }

    }
}
