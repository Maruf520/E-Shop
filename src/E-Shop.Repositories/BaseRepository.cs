using E_Shop.Models;
using E_Shop.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseObject
    {
        private readonly E_StoreDbContext context;
        private DbSet<T> entities;
        public BaseRepository(E_StoreDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void Delete(long id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("entities");
            }
            T entity = entities.Find(id);
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(long id)
        {
            T entity = entities.Find(id);
            return entity;
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
