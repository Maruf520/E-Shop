using E_Shop.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Models.Products
{
    public class Brand : BaseObject
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescripotion { get; set; }
        public string MetaKeyWords { get; set; }
        public BrnadStatus BrnadStatus { get; set; }
    }
}
