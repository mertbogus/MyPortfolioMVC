using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        // GET: Experience
        public ActionResult Index()
        {
            var experiences = db.TblExperiences.ToList();
            return View(experiences);
        }

        public ActionResult DeleteExperience(int id)
        {
            var experiences = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(experiences);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExperience(TblExperience experience)
        {
            db.TblExperiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var experience = db.TblExperiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperience model)
        {
            var experience = db.TblExperiences.Find(model.ExperienceId);
            experience.CompanyName  = model.CompanyName;
            experience.Title = model.Title;
            experience.Description = model.Description;
            experience.StartDate = model.StartDate;
            experience.EndDate = model.EndDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}