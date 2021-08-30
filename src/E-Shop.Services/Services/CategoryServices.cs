using AutoMapper;
using E_Shop.Dtos.CategoryDtos;
using E_Shop.Models;
using E_Shop.Models.Products;
using E_Shop.Repositories.IRepositories;
using E_Shop.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Services.Services
{
   
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public ServiceResponse<CategoryDto> DeleteCategory(long id)
        {
            ServiceResponse<CategoryDto> response = new ServiceResponse<CategoryDto>();
            var category = categoryRepository.FindCategoryById(id);
            if(category == null)
            {
                response.Messages.Add("Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var categoryToMap = mapper.Map<CategoryDto>(category);
             categoryRepository.Delete(id);
            response.Data = categoryToMap;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        public ServiceResponse<List<CategoryDto>> GetALLCategories()
        {
            ServiceResponse<List<CategoryDto>> response = new();
            List<CategoryDto> categoryDtos = new();
            
            var allCategory = categoryRepository.GetAll();
            var categoryList = mapper.Map<List<CategoryDto>>(allCategory);

            if (allCategory == null)
            {
                response.Messages.Add("No Category Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            response.Data = categoryList;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        public ServiceResponse<CategoryDto> GetCategoryById(long id)
        {
            ServiceResponse<CategoryDto> response = new();
            var category = categoryRepository.GetById(id);
            if(category == null)
            {
                response.Messages.Add("Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var getCategory = mapper.Map<CategoryDto>(category);
            response.Data = getCategory;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
            
           
        }

        public ServiceResponse<CategoryDto> SaveCategory(CategoryDto categoryDto)
        {
            ServiceResponse<CategoryDto> response = new();
            try
            {
                var category = mapper.Map<Category>(categoryDto);
                categoryRepository.Insert(category);
                response.Messages.Add("Category Saved");
                response.StatusCode = System.Net.HttpStatusCode.Created;
                response.Data = categoryDto;
                return response;
            }
            catch(Exception e)
            {
                var error = e.ToString();
                response.Messages.Add(error);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }


        }

        public ServiceResponse<CategoryDto> UpdateCategory(CategoryDto categoryDto, long id)
        {
            ServiceResponse<CategoryDto> response = new();
            var category = categoryRepository.FindCategoryById(id);
            if(category == null)
            {
                response.Messages.Add("category not found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var categoryToMap = mapper.Map<Category>(categoryDto);
            categoryRepository.UpdateAsync(categoryToMap);
            response.Messages.Add("Category Updated");
            response.Data = categoryDto;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}
