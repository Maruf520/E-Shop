using AutoMapper;
using E_Shop.Dtos.BrandDtos;
using E_Shop.Dtos.CategoryDtos;
using E_Shop.Dtos.ProductDtos;
using E_Shop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Api
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category,CategoryDto>();
            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
