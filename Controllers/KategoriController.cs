using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkIslemler.Models;

namespace EntityFrameworkIslemler.Controllers
{
    public class KategoriController : Controller
    {
        private SatisContext db = new SatisContext();

        //
        // GET: /Kategori/

        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }

        //
        // GET: /Kategori/Details/5

        public ActionResult Details(int id = 0)
        {
            Kategori kategori = db.Kategoriler.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // GET: /Kategori/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kategori/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        //
        // GET: /Kategori/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kategori kategori = db.Kategoriler.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // POST: /Kategori/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        //
        // GET: /Kategori/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kategori kategori = db.Kategoriler.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // POST: /Kategori/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}