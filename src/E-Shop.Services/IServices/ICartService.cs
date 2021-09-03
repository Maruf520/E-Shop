using E_Shop.Dtos.CartDtos;
using E_Shop.Models;
using E_Shop.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Services.IServices
{
    public interface ICartService
    {
        ServiceResponse<CartItemDto> AddItemToCart(CreateCartDto createCartDto, string uniqueCartId);
        ServiceResponse<CartItemDto> RemoveItemFromCart(long id);
        Cart GetCart(string uniqueid);
        Decimal GetCartTotal();


    }
}
