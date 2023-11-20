using mvcmodelfirstproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace mvcmodelfirstproject.Controllers
{
    public class FirmaController : Controller
    {
        // GET: Firma
        public ActionResult Index()
        {
            return View(db.firmaSet.ToList());
        }
       
        Model1Container db = new Model1Container();
        // GET: Firma
        
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(firma firma)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {
                    con.firmaSet.Add(firma);
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
            var result = db.firmaSet.Where(x => x.firmaNo == id).FirstOrDefault();
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(int id, firma firma)
        {
            try
            {
                db.Entry(firma).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.firmaSet.Where(x => x.firmaNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, firma firma)
        {
            try
            {
                firma = db.firmaSet.Where(x => x.firmaNo == id).FirstOrDefault();
                db.firmaSet.Remove(firma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}