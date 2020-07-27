using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehber.Models;

namespace TelefonRehber.Controllers
{
    public class HomeController : Controller
    {


        TelefonRehberEntities2 db = new TelefonRehberEntities2();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDepartman()
        {
            db.Configuration.ProxyCreationEnabled = false;//önemli
            List<Departmanlar> clist = db.Departmanlar.ToList();
            return Json(clist, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DENEME()
        {
            return View();

        }
        public ActionResult Login()
        {
            return View();

        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admins objUser)
        {
            if (ModelState.IsValid)
            {
               
                    var obj = db.Admins.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["AdminId"] = obj.AdminId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("CalisanlarListe","Calisanlar");
                    }
                
            }
            return RedirectToAction("Login","Home");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["AdminId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}