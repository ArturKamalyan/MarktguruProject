﻿using MarktguruProject.DTOModels;
using MarktguruProject.Repositories.Interfaces;
using MarktguruProject.Services.Interfaces;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetList()
        {
            var list = await this._productService.GetAllAsync();
            return list.Select(x => new Product(x)).ToList();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add([FromBody] Product product)
        {
            await this._productService.AddAsync(product.ToModel());
            return Ok();
        }
    }
}
