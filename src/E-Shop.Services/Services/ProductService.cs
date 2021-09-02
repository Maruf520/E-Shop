using AutoMapper;
using E_Shop.Dtos.ProductDtos;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public ServiceResponse<ProductDto> SaveProduct(ProductDto productDto)
        {
            ServiceResponse<ProductDto> response = new();
            try
            {
                var product = mapper.Map<Product>(productDto);
                productRepository.Insert(product);
                response.Data = productDto;
                response.Messages.Add("Created");
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

        public ServiceResponse<ProductDto> UpdateProduct(ProductDto productDto)
        {
            ServiceResponse<ProductDto> response = new();
            var productToUpdate = productRepository.GetById(productDto.Id);
            if(productToUpdate == null)
            {
                response.Messages.Add("Product not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var productToMap = mapper.Map<Product>(productDto);
            productRepository.Update(productToMap);
            response.Data = productDto;
            response.Messages.Add("Updated");
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        public ServiceResponse<ProductDto> DeleteProduct(long id)
        {
            ServiceResponse<ProductDto> response = new();
            var product = productRepository.GetById(id);
            if(product == null)
            {
                response.Messages.Add("Product  Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            productRepository.Delete(id);
            response.Messages.Add("Deleted");
            response.StatusCode = System.Net.HttpStatusCode.OK;
            var productToDelete = mapper.Map<ProductDto>(product);
            response.Data = productToDelete;
            return response;
        }

        public ServiceResponse<ProductDto> GetProductById(long id)
        {
            ServiceResponse<ProductDto> response = new();
            var product = productRepository.GetById(id);
            if(product == null)
            {
                response.Messages.Add("Product Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var productToMap = mapper.Map<ProductDto>(product);
            response.Data = productToMap;
            response.Messages.Add("Single Product");
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        public ServiceResponse<List<ProductDto>> GetAllProduct()
        {
            ServiceResponse<List<ProductDto>> response = new();
            var product = productRepository.GetAll();
            if(product == null)
            {
                response.Messages.Add("Product Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var productToMap = mapper.Map<List<ProductDto>>(product);
            response.Data = productToMap;
            response.Messages.Add("All Produtcs");
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}
