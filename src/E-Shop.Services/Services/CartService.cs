using AutoMapper;
using E_Shop.Dtos.CartDtos;
using E_Shop.Models;
using E_Shop.Models.Carts;
using E_Shop.Repositories.IRepositories;
using E_Shop.Services.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        private IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly ICartItemRepository cartItemRepository;

        public CartService(
            ICartRepository cartRepository,
            IMapper mapper,
            IProductRepository productRepository,
            ICartItemRepository cartItemRepository
            )
        {
            this.mapper = mapper;
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
            this.productRepository = productRepository;
        }
        public ServiceResponse<CartItemDto> AddItemToCart(CreateCartDto createCartDto, string uniqueCartId)
        {
            ServiceResponse<CartItemDto> response = new();
            var cart = GetCart(uniqueCartId);
            if(cart != null)
            {

                var allCartItems  = cartItemRepository.GetAll();
                var existingCartItems = cartItemRepository.FindCartItemsByCartId(cart.Id).FirstOrDefault(x => x.Product.Id == createCartDto.ProductId);
                if(existingCartItems != null)
                {
                    existingCartItems.Quantity++;
                    cartItemRepository.Update(existingCartItems);
                    var cartItemsToMap = mapper.Map<CartItemDto>(existingCartItems);
                    response.Data = cartItemsToMap;
                    response.Messages.Add("Updated");
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    return response;
                }
                else
                {
                    var product = productRepository.GetById(createCartDto.ProductId);
                    if (product != null)
                    {
                        var cartItems = new CartItem()
                        {
                            CartId = cart.Id,
                            ProductId = product.Id,
                            Cart = cart,
                            Product = product,
                            Quantity = 1,

                        };
                        var cartItemsToMap = mapper.Map<CartItemDto>(cartItems);
                        cartItemRepository.Insert(cartItems);
                        response.Data = cartItemsToMap;
                        response.Messages.Add("Created");
                        response.StatusCode = System.Net.HttpStatusCode.Created;
                        return response;
                    }
                }
                 
            }
            else
            {
                var product = productRepository.GetById(createCartDto.ProductId);
                if(product != null)
                {
                    var newCart = new Cart()
                    {
                        UniqueCartId = uniqueCartId,
                        CreateDate = DateTime.Now,
                        CartStatus = CartStatus.Active
                    };
                    cartRepository.Insert(newCart);
                    var newCartItems = new CartItem()
                    {
                        CartId = newCart.Id,
                        Cart = newCart,
                        ProductId = product.Id,
                        Product = product,
                        Quantity = 1
                    };
                    cartItemRepository.Insert(newCartItems);
                    response.Messages.Add("Created");
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    var cartItemToMap = mapper.Map<CartItemDto>(newCartItems);
                    response.Data = cartItemToMap;
                }
            }
            return response;
        }

        public Cart GetCart(string uniqueCartId)
        {
            var cart = cartRepository.GetAll().Where(x=>x.UniqueCartId==uniqueCartId).FirstOrDefault();
            return cart;
            
        }

        public decimal GetCartTotal()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<CartItemDto> RemoveItemFromCart(long id)
        {
            throw new NotImplementedException();
        }

    }
}
