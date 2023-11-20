using mvcmodelfirstproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace mvcmodelfirstproject.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        public ActionResult Index()
        {
            return View(db.calisanSet.ToList());
        }
        Model1Container db = new Model1Container();
        // GET: Calisan

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(calisan calisan)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {
                    con.calisanSet.Add(calisan);
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
            var result = db.calisanSet.Where(x => x.calisanNo == id).FirstOrDefault();
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(int id, calisan calisan)
        {
            try
            {
                db.Entry(calisan).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.calisanSet.Where(x => x.calisanNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, calisan calisan)
        {
            try
            {
                calisan = db.calisanSet.Where(x => x.calisanNo == id).FirstOrDefault();
                db.calisanSet.Remove(calisan);
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