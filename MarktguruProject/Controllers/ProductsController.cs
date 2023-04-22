using FluentValidation.AspNetCore;
using MarktguruProject.DTOModels;
using MarktguruProject.Repositories.Interfaces;
using MarktguruProject.Services.Interfaces;
using MarktguruProject.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
    }
}
