using AutoMapper;
using E_Shop.Dtos.BrandDtos;
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
    public class BrandService : IbrandService
    {
        private readonly IBrandReoisitory brandRepository;
        private readonly IMapper mapper;
        public BrandService(IBrandReoisitory brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public ServiceResponse<BrandDto> DeleteBrand(long id)
        {
            ServiceResponse<BrandDto> response = new();
            var brand = brandRepository.GetById(id);

            if (brand == null)
            {
                response.Messages.Add("Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            brandRepository.Delete(id);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            var brandToMap = mapper.Map<BrandDto>(brand);
            response.Data = brandToMap;
            response.Messages.Add("Deleted");
            return response;
        }

        public ServiceResponse<List<BrandDto>> GetAllBrand()
        {
            ServiceResponse<List<BrandDto>> response = new();
            List<BrandDto> brandDtos = new();
            var brand = brandRepository.GetAll();
            if (brand == null)
            {
                response.Messages.Add("Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var brandToMap = mapper.Map<List<BrandDto>>(brand);
            response.Data = brandToMap;
            response.Messages.Add("All Brands");
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        public ServiceResponse<BrandDto> GetBrandById(long id)
        {
            ServiceResponse<BrandDto> response = new ServiceResponse<BrandDto>();
            var brand = brandRepository.GetById(id);
            if(brand == null)
            {
                response.Messages.Add("Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var brandToMap = mapper.Map<BrandDto>(brand);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.Messages.Add("Brand");
            response.Data = brandToMap;
            return response;
        }

        public ServiceResponse<BrandDto> SaveBrand(BrandDto brandDto)
        {
            ServiceResponse<BrandDto> response = new();
            try
            {
                var brandToMap = mapper.Map<Brand>(brandDto);
                brandRepository.Insert(brandToMap);
                response.Data = brandDto;
                response.StatusCode = System.Net.HttpStatusCode.Created;
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

        public ServiceResponse<BrandDto> UpdateBrand(BrandDto brandDto)
        {
            ServiceResponse<BrandDto> response = new();
            var brand = brandRepository.GetById(brandDto.Id);
            
            if(brand == null)
            {
                response.Messages.Add("Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var brandToMap = mapper.Map<Brand>(brandDto);
            brandRepository.Update(brandToMap);
            response.Data = brandDto;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}
