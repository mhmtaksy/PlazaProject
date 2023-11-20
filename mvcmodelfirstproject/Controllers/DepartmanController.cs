using mvcmodelfirstproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace mvcmodelfirstproject.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        public ActionResult Index()
        {
            return View(db.departmanSet.ToList());
        }
        Model1Container db = new Model1Container();
        // GET: Departman

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(departman departman)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {
                    con.departmanSet.Add(departman);
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
            var result = db.departmanSet.Where(x => x.departmanNo == id).FirstOrDefault();
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(int id, departman departman)
        {
            try
            {
                db.Entry(departman).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.departmanSet.Where(x => x.departmanNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, departman departman)
        {
            try
            {
                departman = db.departmanSet.Where(x => x.departmanNo == id).FirstOrDefault();
                db.departmanSet.Remove(departman);
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