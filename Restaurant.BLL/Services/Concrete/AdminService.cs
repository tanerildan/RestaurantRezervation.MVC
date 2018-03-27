using Restaurant.BLL.Services.Abstract;
using Restaurant.REPO.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services.Concrete
{
  public class AdminService:IAdminService
    {
        private readonly IUnitofWork _uow;
        public AdminService(IUnitofWork uow)
        {
            _uow = uow;
        }
    }
}
