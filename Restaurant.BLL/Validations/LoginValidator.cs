using FluentValidation;
using Restaurant.DAL.Entities;
using Restaurant.REPO.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Validations
{
  public  class LoginValidator:AbstractValidator<Yonetim>
    {
        private readonly IUnitofWork _uow;
        public LoginValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu bölüm boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu bölüm boş geçilemez");
        }
    }
}
