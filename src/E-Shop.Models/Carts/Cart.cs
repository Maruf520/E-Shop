using E_Shop.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Models.Carts
{
    public class Cart : BaseObject
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public string UniqueCartId { get; set; }
        public CartStatus CartStatus { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
