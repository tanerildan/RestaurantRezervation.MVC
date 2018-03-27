using Restaurant.CORE.Concretes;
using Restaurant.DAL.Context;
using Restaurant.DAL.Entities;
using Restaurant.REPO.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.REPO.Concrete
{
   public class AdminRepository:EFRepositoryBase<Yonetim,ProjectContext>,IAdminRepository
    {
        public AdminRepository(DbContext Context):base(Context)
        {

        }
    }
}
