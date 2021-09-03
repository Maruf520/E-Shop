using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Dtos.CartDtos
{
    public class CreateCartDto
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
