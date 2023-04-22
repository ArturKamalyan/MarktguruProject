using FluentValidation.AspNetCore;
using MarktguruProject.DTOModels;
using MarktguruProject.Services.Interfaces;
using MarktguruProject.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarktguruProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductList>>> GetList()
        {
            var list = await this._productService.GetAllAsync();
            return list.Select(x => new ProductList(x)).ToList();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDetails>> Get(int id)
        {
            var product = await this._productService.GetByIdAsync(id);
            return product == null ? NotFound() : new ProductDetails(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add([FromBody] ProductDetails product)
        {
            var validator = new ProductValidator().Validate(product);
            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            await this._productService.AddAsync(product.ToModel());
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Edit([FromBody] ProductDetails product)
        {
            var validator = new ProductValidator().Validate(product);
            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            var existingProduct = await this._productService.GetByIdAsync(product.Id);
            if (existingProduct == null)
                return NotFound();

            product.DateCreated = existingProduct.DateCreated;
            await this._productService.EditAsync(product.ToModel());
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            return (await this._productService.DeleteAsync(id)) ? Ok() : NotFound();
        }
    }
}
