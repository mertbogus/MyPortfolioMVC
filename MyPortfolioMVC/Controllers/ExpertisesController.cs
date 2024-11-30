using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class ExpertisesController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            ViewBag.Updatemsg= TempData["Updatemsg"] as string;
            var expertises = db.TblExpertises.ToList();
            return View(expertises);
        }
        [HttpGet]
        public ActionResult CreateExpertises()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExpertises(TblExpertis expertis)
        {
            db.TblExpertises.Add(expertis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExpertises(int id)
        {
            var value = db.TblExpertises.Find(id);
            db.TblExpertises.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExpertises(int id)
        {
            var expertises = db.TblExpertises.Find(id);
            return View(expertises);

        }

        [HttpPost]

        public ActionResult UpdateExpertises(TblExpertis model)
        {
            var expertises = db.TblExpertises.Find(model.ExpertiseId);
            expertises.Title = model.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}