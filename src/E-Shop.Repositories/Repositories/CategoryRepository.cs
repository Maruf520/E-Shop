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
/*        public void DeleteAsync(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }*/

        public Category FindCategoryById(long id)
        {
            var category = context.Categories.Find(id);
            return category;
        }

        public List<Category> GetAllAsync()
        {
            var allCategory = context.Categories;
            return allCategory.ToList();

        }

/*        public void SaveAsync(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }*/

        public void UpdateAsync(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }
    }
}
