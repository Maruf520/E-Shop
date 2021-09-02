using E_Shop.Dtos.ProductDtos;
using E_Shop.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        {
            var product = productService.SaveProduct(productDto);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Update(ProductDto product)
        {
            var productToUpdate = productService.UpdateProduct(product);
            return Ok(productToUpdate);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var product = productService.GetAllProduct();
            return Ok(product);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var product = productService.DeleteProduct(id);
            return Ok(product);
        }
    }
}
