﻿using Restaurant.BLL.Services.Abstract;
using Restaurant.REPO.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services.Concrete
{
   public class MasalarService:IMasalarService
    {
        private readonly IUnitofWork _uow;
        public MasalarService(IUnitofWork uow)
        {
            _uow = uow;
        }
    }
}
