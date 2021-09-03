using E_Shop.Models.Products;
using E_Shop.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Models.Carts
{
    public class CartItem : BaseObject
    {
        public long CartId { get; set; }
        public Cart Cart { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
