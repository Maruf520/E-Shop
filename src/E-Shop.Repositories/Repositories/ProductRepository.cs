using E_Shop.Models;
using E_Shop.Models.Products;
using E_Shop.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Repositories.Repositories
{
    public class ProductRepository : BaseRepository<Product>,IProductRepository
    {
        private readonly E_StoreDbContext context;
        public ProductRepository(E_StoreDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
