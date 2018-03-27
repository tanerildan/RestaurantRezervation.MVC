using Restaurant.BLL.Validations;
using Restaurant.DAL.Entities;
using Restaurant.REPO.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitofWork _uow;
        public HomeController(IUnitofWork uow)
        {
            _uow = uow;
        }

        public ActionResult AnaSayfa()
        {
            ViewBag.Masalar = MasaDoldur();
            ViewBag.RezervasyonBasSaati = SaatDoldur();
            return View();
        }

        private List<SelectListItem> MasaDoldur()
        {
            string[] masalar = { "MasaA", "MasaB", "MasaC", "MasaD" };
            List<SelectListItem> masa = new List<SelectListItem>();

            foreach (string item in masalar)
            {
                masa.Add(new SelectListItem()
                {
                    Text = item.ToString(),
                    Value = item.ToString()
                });
            }
            return masa;
        }

        private List<SelectListItem> SaatDoldur()
        {
            IEnumerable<int> startHours = Enumerable.Range(11, 12);
            List<SelectListItem> baslangicSaatler = new List<SelectListItem>();
            foreach (var item in startHours)
            {
                baslangicSaatler.Add(new SelectListItem() { Text = item.ToString() + ":00", Value = item.ToString() });
            }

            return baslangicSaatler;
        }

        // GET: Home
        public ActionResult Rezervasyon(string Masalar, int BaslangicSaati)
        {
            int masaId = _uow.GetRepo<Masalar>().Where(x => x.BaslangicSaati == BaslangicSaati && x.MasaAdi == Masalar)
                .FirstOrDefault().ID;
            int varmi = _uow.GetRepo<Masalar>().Where(x => x.Rezervemi == true && x.ID == masaId).Count();
            if (Convert.ToBoolean(varmi))
            {
                TempData["Msg"] = "seçtiğiniz masa dolu!";
                return RedirectToAction("Anasayfa");
            }
            else
            {
                TempData["MasaId"] = masaId;
                TempData["RezBaslangicSaati"] = BaslangicSaati;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rezervasyon(Rezervasyon model)
        {
            var validator = new RezervationValidator(_uow).Validate(model);
            if (validator.IsValid)
            {
                MasaKontrol(model.MasaId);

                _uow.GetRepo<Rezervasyon>().Add(model);
                var masa = _uow.GetRepo<Masalar>().GetById(model.MasaId);
                masa.Rezervemi = true;
                masa.Tarih = DateTime.Now;

                if (_uow.Commit() > 0)
                    ViewBag.Msg = "işlem başarılı";
            }
            else
            {
                validator.Errors.ToList().ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            return View();
        }

        private void MasaKontrol(int id)
        {
            var masa = _uow.GetRepo<Masalar>().GetById(id);
            if (masa.Tarih < DateTime.Now)
                masa.Rezervemi = false; 

        }
    }
}