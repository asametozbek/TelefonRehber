using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehber.Models;

namespace TelefonRehber.Controllers
{
    public class CalisanlarController : Controller
    {
        TelefonRehberEntities2 db = new TelefonRehberEntities2();
        // GET: Calisanlar
        public ActionResult Index()
        {
            var degerler = db.Calisanlar.ToList();

            return View(degerler);
        }


        public ActionResult CalisanlarListe()
        {
            var degerler = db.Calisanlar.ToList();

            return View(degerler);
        }

        public ActionResult Detay(int id)
        {
            var calisan = db.Calisanlar.Find(id);
            //return View("CalisanGetir", calisan);
            List<SelectListItem> degerler = (from i in db.Departmanlar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.departmanAd,
                                                 Value = i.departmanId.ToString()
                                             }).ToList();
            List<SelectListItem> yntci = (from a in db.Calisanlar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = a.yöneticiMi.ToString(),
                                              Value = a.yöneticiMi.ToString()
                                          }).ToList();
            ViewBag.ynt = yntci;
            ViewBag.dgr = degerler;
            return View("Detay", calisan);

        }

        public ActionResult CalisanEkle()
        {

            List<SelectListItem> yntci = (from a in db.Calisanlar.ToList()
                                          select new SelectListItem

                                          {
                                              Text = a.calisanAd,
                                              Value = a.yöneticiMi.ToString()
                                          }).ToList();
            ViewBag.ynt = yntci;



            List<SelectListItem> degerler = (from i in db.Departmanlar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.departmanAd,
                                                 Value = i.departmanId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult CalisanEkle(Calisanlar c1)
        {

            var ktg = db.Departmanlar.Where(m => m.departmanId == c1.Departmanlar.departmanId).FirstOrDefault();
            c1.Departmanlar = ktg;

            db.Calisanlar.Add(c1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CalisanSil(int id)
        {
            var calisan = db.Calisanlar.Find(id);
            db.Calisanlar.Remove(calisan);
            db.SaveChanges();
            return RedirectToAction("CalisanlarListe","Calisanlar");
        }

        public ActionResult CalisanGetir(int id)
        {
            var calisan = db.Calisanlar.Find(id);

            List<SelectListItem> yntci = (from a in db.Calisanlar.ToList()
                                          select new SelectListItem

                                          {
                                              Text = a.yöneticiBilgiler,
                                              Value = a.yöneticiBilgiler
                                          }).ToList();
            ViewBag.ynt = yntci;


            List<SelectListItem> degerler = (from i in db.Departmanlar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.departmanAd,
                                                 Value = i.departmanId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("CalisanGetir", calisan);
        }

        public ActionResult Guncelle(Calisanlar c2)
        {



            //var calisan = db.departmanlar.Where(m => m.departmanId == c2.departmanlar.departmanId).FirstOrDefault();
            //c2.departmanlar = ktg;


            var calisan = db.Calisanlar.Find(c2.calisanId);
            calisan.calisanAd = c2.calisanAd;
            calisan.calisanSoyad = c2.calisanSoyad;
            calisan.telefon = c2.telefon;
            //calisan.departmanId = c2.departmanId;

            var ktg = db.Departmanlar.Where(m => m.departmanId == c2.Departmanlar.departmanId).FirstOrDefault();
            calisan.departman = ktg.departmanId;

         


            calisan.yöneticiBilgiler = c2.yöneticiBilgiler;
            calisan.yöneticiMi = c2.yöneticiMi;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}