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
    [Authorize]
    public class AdminHomeController : Controller
    {
        private readonly IUnitofWork _uow;
        public AdminHomeController(IUnitofWork uow)
        {
            _uow = uow;
        }
        // GET: Admin/AdminHome

        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }


        public ActionResult GetRezervations()
        {
          var model =  _uow.GetRepo<Rezervasyon>().GetList();
            return View(model);
        }


        public ActionResult Sil(int id)
        {
            int masaId = _uow.GetRepo<Rezervasyon>().GetById(id).MasaId;
            _uow.GetRepo<Rezervasyon>().Delete(id);
            var model = _uow.GetRepo<Masalar>().GetById(masaId).Rezervemi = false;
            _uow.Commit();
                
            return RedirectToAction("GetRezervations");
        }
    }
}