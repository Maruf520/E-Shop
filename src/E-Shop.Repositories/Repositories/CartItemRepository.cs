using E_Shop.Models;
using E_Shop.Models.Carts;
using E_Shop.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Repositories.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        private readonly E_StoreDbContext context;

        public CartItemRepository(E_StoreDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<CartItem> FindCartItemsByCartId(long id)
        {
            var cartitem = context.CartItem.Where(x => x.CartId == id).Include(c => c.Product);
            return cartitem;
        }
    }
}
