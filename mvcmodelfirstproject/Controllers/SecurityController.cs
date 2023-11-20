using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvcmodelfirstproject.Models;

namespace mvcmodelfirstproject.Controllers
{

    
    public class SecurityController : Controller
    {
        Model1Container db = new Model1Container();
        // GET: Kullanici
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanicilar)
        {
            var userlogin = db.Kullanicilars.FirstOrDefault(x => x.kullaniciAdi == kullanicilar.kullaniciAdi && x.Sifre == kullanicilar.Sifre);
            if(userlogin != null)
            {
                FormsAuthentication.SetAuthCookie(userlogin.kullaniciAdi, false);
                return RedirectToAction("Index","User");
            }
            else
            {
                ViewBag.Message = "Kullanici Adi veya Sifre yanlis";
                return View();
            }           
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}