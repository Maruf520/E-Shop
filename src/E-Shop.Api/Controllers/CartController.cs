using E_Shop.Dtos.CartDtos;
using E_Shop.Models.Carts;
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
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private const string UniqueCartIdSessionKey = "UniqueCartId";
        private readonly IHttpContextAccessor httpContext;
        public CartController(ICartService cartService, IHttpContextAccessor httpContext)
        {
            this.cartService = cartService;
            this.httpContext = httpContext;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCart(CreateCartDto createCartDto)
        {
            var cart = cartService.AddItemToCart(createCartDto, UniqueCartId());
            return Ok(cart);
        }
        protected string UniqueCartId()
        {
            if (!string.IsNullOrWhiteSpace(httpContext.HttpContext.Session.GetString(UniqueCartIdSessionKey)))
            {
                return httpContext.HttpContext.Session.GetString(UniqueCartIdSessionKey);
            }
            else
            {
                var uniqueId = Guid.NewGuid().ToString();
                httpContext.HttpContext.Session.SetString(UniqueCartIdSessionKey, uniqueId);
                return httpContext.HttpContext.Session.GetString(UniqueCartIdSessionKey);
            }
        }

    }
}
