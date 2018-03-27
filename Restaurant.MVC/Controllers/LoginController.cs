using Restaurant.BLL.Validations;
using Restaurant.DAL.Entities;
using Restaurant.REPO.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Restaurant.MVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitofWork _uow;

        public LoginController(IUnitofWork uow)
        {
            _uow = uow;
        }
        // GET: Admin/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost][AllowAnonymous][ValidateAntiForgeryToken]
        public ActionResult Login(Yonetim model)
        {
            var validator = new LoginValidator(_uow).Validate(model);
            if (validator.IsValid)
            {
                var result = _uow.GetRepo<Yonetim>().Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.Email, false);
                    return Redirect("/Admin");
                }
            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }

            return View();
        }
    }
}