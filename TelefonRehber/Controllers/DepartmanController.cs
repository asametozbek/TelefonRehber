using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehber.Models;

namespace TelefonRehber.Controllers
{
    public class DepartmanController : Controller
    {
        TelefonRehberEntities2 db = new TelefonRehberEntities2();
        // GET: Departman
        public ActionResult Index()
        {
            var deger= db.Departmanlar.ToList();
            return View(deger);
        }

        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departmanlar d1)
        {
            db.Departmanlar.Add(d1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = db.Departmanlar.Find(id);
            db.Departmanlar.Remove(departman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = db.Departmanlar.Find(id);
            return View(departman);
        }
        [HttpPost]
        public ActionResult Guncelle(Departmanlar c2)
        {
            var departman = db.Departmanlar.Find(c2.departmanId);
            departman.departmanAd = c2.departmanAd;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}