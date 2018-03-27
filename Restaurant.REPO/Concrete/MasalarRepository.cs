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
   public class MasalarRepository:EFRepositoryBase<Masalar,ProjectContext>,IMasalarRepository
    {
        public MasalarRepository(DbContext Context):base(Context)
        {

        }
    }
}
