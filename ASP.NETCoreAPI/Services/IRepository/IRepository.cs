using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Services.IRepository
{
   public interface IRepository<T>:IDisposable
        where T:class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> predicate);


    }
}
