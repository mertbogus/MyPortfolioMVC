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
    }


}