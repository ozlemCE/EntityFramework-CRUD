using EntityFrameworkIslemler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkIslemler.Controllers
{
    public class UrunController : Controller
    {
        //
        // GET: /Urun/
        SatisContext db = new SatisContext();
        public ActionResult Index()
        {
            List<Urun> urunler = db.Urunler.ToList();
            return View(urunler);
        }


        public ActionResult Detay(int id)
        {
            //urun bilgilerini veritabanından alan sorgu
            Urun urun = (from u in db.Urunler where u.Id == id select u).FirstOrDefault();
            return View(urun);
        }

        public ActionResult Duzenle(int id)
        {
            var kategoriler = db.Kategoriler.ToList().Select(k => new SelectListItem
            {
                Selected = false,
                Text = k.Adi,
                Value = k.Id.ToString()

            }).ToList();

            ViewBag.Kategoriler = kategoriler;
            Urun urun = (from u in db.Urunler where u.Id == id select u).FirstOrDefault();
            return View(urun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Urun urun)
        {
            var result = db.Urunler.SingleOrDefault(b => b.Id == urun.Id);
            if (result != null)
            {
                result.KategoriId = urun.KategoriId;
                result.Ad = urun.Ad;
                result.Fiyat = urun.Fiyat;
                result.Stok = urun.Stok;

                db.SaveChanges();
            }
            return RedirectToAction("Index", "Urun", new { id = urun.Id });

        }

        public ActionResult YeniUrun()
        {
            var kategoriler = db.Kategoriler.ToList().Select(k => new SelectListItem
                {
                    Selected = false,
                    Text = k.Adi,
                    Value = k.Id.ToString()
                }).ToList();
            //kategorileri viewe gonderiyoruz.
            ViewBag.Kategoriler = kategoriler;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniUrun(Urun urun)
        {
            db.Urunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index", "Urun", new { id = urun.Id });
        }


        public ActionResult UrunSil(int id)
        {
            var urun = (from u in db.Urunler where u.Id == id select u).FirstOrDefault();
          return View(urun);
        }

       [HttpPost,ActionName("UrunSil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilmeMetodu(Urun urun)
        {
            var silUrun = (from u in db.Urunler where u.Id == urun.Id select u).FirstOrDefault();

            db.Urunler.Remove(silUrun);
            db.SaveChanges();
            return RedirectToAction("Index","Urun");
        }
    }
}
