using E_Shop.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Repositories
{
    public interface IBaseRepository<T> where T : BaseObject
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
