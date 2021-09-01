using E_Shop.Dtos.BrandDtos;
using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Services.IServices
{
    public interface IbrandService
    {
        ServiceResponse<BrandDto> GetBrandById(long id);
        ServiceResponse<BrandDto> SaveBrand(BrandDto brandDto);
        ServiceResponse<BrandDto> UpdateBrand(BrandDto brandDto);
        ServiceResponse<BrandDto> DeleteBrand(long id);
        ServiceResponse<List<BrandDto>> GetAllBrand();
    }
}
