using Restaurant.CORE.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Restaurant.CORE.Concretes
{
   public class EFRepositoryBase<T,TContext>:IRepository<T>,IDisposable
        where T:class,new()
       where TContext:DbContext
    {
        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;

        public EFRepositoryBase(DbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T model)
        {
            _dbSet.Add(model);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Delete(int id)
        {
            var model = _dbSet.Find(id);
            _dbSet.Remove(model);
        }

        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public List<T> GetList()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lamda)
        {
            return _dbSet.Where(lamda).AsEnumerable();
        }

        public IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lamda)
        {
            return _dbSet.Where(lamda).AsQueryable();
        }

        public T GetObject(Expression<Func<T, bool>> lamda)
        {
            return _dbSet.FirstOrDefault(lamda);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_disposed == false)
                {
                    Dispose();
                    _disposed = true;
                }
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
