using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehber.Models;

namespace TelefonRehber.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        TelefonRehberEntities2 db = new TelefonRehberEntities2();
        // GET: Departman
        public ActionResult Index()
        {
            var deger = db.Admins.ToList();
            return View(deger);
        }

        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admins d1)
        {
            db.Admins.Add(d1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminGetir(int id)
        {
            var admin = db.Admins.Find(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Guncelle(Admins c2)
        {
            var admin = db.Admins.Find(c2.AdminId);
            admin.UserName = c2.UserName;
            admin.Password = c2.Password;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}