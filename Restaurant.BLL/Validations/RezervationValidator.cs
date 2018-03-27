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
   public class RezervationValidator:AbstractValidator<Rezervasyon>
    {
        private readonly IUnitofWork _uow;
        public RezervationValidator(IUnitofWork uow)
        {
            _uow = uow;
            RuleFor(x => x.MusteriAd).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.MusteriSoyad).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.MusteriTel).NotEmpty().WithMessage("Bu alan boş geçilemez");


        }
    }
}
