using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.CORE.Abstracts
{
   public interface IRepository<T>
        where T:class,new()
      
    {
        void Add(T model);
        T GetById(int id);
        void Delete(int id);
        void Update(T model);
        List<T> GetList();
        IEnumerable<T> Where(Expression<Func<T, bool>> lamda);
        IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lamda);
        T GetObject(Expression<Func<T, bool>> lamda);
    }
}
