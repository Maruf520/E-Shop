using E_Shop.Dtos.CategoryDtos;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices categoryService;
        public CategoryController(ICategoryServices categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> SaveCategory(CategoryDto categoryDto)
        {
            var category = categoryService.SaveCategory(categoryDto);
            return Ok(category);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto, long id)
        {
            var categoryToUpdate = categoryService.UpdateCategory(categoryDto, id);
            return Ok(categoryToUpdate);
        }
        [HttpGet("allcategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = categoryService.GetALLCategories();
            return Ok(category);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var category = categoryService.DeleteCategory(id);
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(long id)
        {
            var category = categoryService.GetCategoryById(id);
            return Ok(category);
        }
    }
}
