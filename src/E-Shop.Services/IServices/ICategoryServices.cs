using E_Shop.Dtos.CategoryDtos;
using E_Shop.Models;
using E_Shop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Services.IServices
{
    public interface ICategoryServices
    {
        ServiceResponse<CategoryDto> GetCategoryById(long id);
        ServiceResponse<CategoryDto> UpdateCategory(CategoryDto categoryDto,long id);
        ServiceResponse<CategoryDto> DeleteCategory(long id);
        ServiceResponse<List<CategoryDto>> GetALLCategories();
        ServiceResponse<CategoryDto> SaveCategory(CategoryDto categoryDto);

    }
}
