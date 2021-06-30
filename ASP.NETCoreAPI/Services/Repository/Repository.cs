using ASP.NETCoreAPI.DAL;
using ASP.NETCoreAPI.Models;
using ASP.NETCoreAPI.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace ASP.NETCoreAPI.Services.Repository
{
    public class Repository<T> : IRepository<T>
          where T : class
    {

        protected readonly  AppDbContext _context;
        private bool disposed = false;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
                disposed = true;
            }
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> entityList = _context.Set<T>().ToList();
            //IEnumerable<T> entityList = Enumerable.Empty<T>();

            return entityList;
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();

        }

        public T GetById(int id)
        {
            return _context.Find<T>(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        public void Save() => _context.SaveChanges();


        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();

        }
    }
}
