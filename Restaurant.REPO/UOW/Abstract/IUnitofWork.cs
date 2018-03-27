using Restaurant.CORE.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.REPO.UOW.Abstract
{
   public interface IUnitofWork:IDisposable
    {
        int Commit();
        IRepository<T> GetRepo<T>() where T:class,new();
        void Dispose(bool disposing);

    }
}
