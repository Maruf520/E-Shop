using E_Shop.Dtos.BrandDtos;
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
    public class BrandController : ControllerBase
    {
        private readonly IbrandService brandService;
        public BrandController(IbrandService brandService)
        {
            this.brandService = brandService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateBrand(BrandDto brandDto)
        {
            var brand = brandService.SaveBrand(brandDto);
            return Ok(brand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var brand = brandService.GetBrandById(id);
            return Ok(brand);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> UpdateBrand(BrandDto brandDto)
        {
            var brand = brandService.UpdateBrand(brandDto);
            return Ok(brand);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBrand(long id)
        {
            var brand = brandService.DeleteBrand(id);
            return Ok(brand);
        }
    }
}
