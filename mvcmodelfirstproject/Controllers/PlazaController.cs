using mvcmodelfirstproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;


namespace mvcmodelfirstproject.Controllers
{
    public class PlazaController : Controller
    {
        Model1Container db = new Model1Container();
        // GET: Plaza
        public ActionResult Index()
        {
            return View(db.plazaSet.ToList());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(plaza plaza)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {
                    con.plazaSet.Add(plaza);
                    con.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = db.plazaSet.Where(x => x.plazaNo == id).FirstOrDefault();
            return View(result);
            
        }
        [HttpPost]
        public ActionResult Edit(int id,plaza plaza)
        {
            try
            {
                db.Entry(plaza).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = db.plazaSet.Where(x => x.plazaNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, plaza plaza)
        {
            try
            {
                plaza = db.plazaSet.Where(x => x.plazaNo == id).FirstOrDefault();
                db.plazaSet.Remove(plaza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }     }
        }
}