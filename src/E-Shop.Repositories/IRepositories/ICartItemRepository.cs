using E_Shop.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Repositories.IRepositories
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        IEnumerable<CartItem> FindCartItemsByCartId(long id);
    }
}
