using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class EducationController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var educatione = db.TblEducations.ToList();
            return View(educatione);
        }

        public ActionResult DeleteEducation(int id)
        {
            var education = db.TblEducations.Find(id);
            db.TblEducations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(TblEducation model)
        {
            db.TblEducations.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var educations=db.TblEducations.Find(id);
            return View(educations);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation model)
        {
            var education = db.TblEducations.Find(model.EducatıonId);
            education.SchoolName = model.SchoolName;
            education.Department = model.Department;
            education.Description = model.Description;
            education.StartDate = model.StartDate;
            education.EndDate = model.EndDate;
            education.Degree=model.Degree;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}