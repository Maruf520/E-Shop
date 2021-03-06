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
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        private readonly E_StoreDbContext context;

        public CategoryRepository(E_StoreDbContext context): base(context)
        {
            this.context = context;
        }
    }
}
