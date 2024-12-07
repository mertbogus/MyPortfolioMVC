using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MyPortfolioMVC.Controllers
{
    public class AboutController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }

        public ActionResult DeleteAbout(int id)
        {
            var abouts = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(abouts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(TblAbout model)
        {
            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "image\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.ImageUrl = "/image/" + model.ImageFile.FileName;
            }

            if (model.CVFile != null)
            {
                string fileExtension = System.IO.Path.GetExtension(model.CVFile.FileName).ToLower();
                if (fileExtension == ".pdf")
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "CV\\";
                    var fileName = Path.Combine(saveLocation, model.CVFile.FileName);
                    model.CVFile.SaveAs(fileName);
                    model.CvUrl = "/CV/" + model.CVFile.FileName;
                }

            }
            db.TblAbouts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var abouts = db.TblAbouts.Find(id);
            return View(abouts);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout model)
        {
            var abouts = db.TblAbouts.Find(model.AboutId);
            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "image\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.ImageUrl = "/image/" + model.ImageFile.FileName;
            }

            if (model.CVFile != null)
            {
                string fileExtension = System.IO.Path.GetExtension(model.CVFile.FileName).ToLower();
                if (fileExtension == ".pdf")
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "CV\\";
                    var fileName = Path.Combine(saveLocation, model.CVFile.FileName);
                    model.CVFile.SaveAs(fileName);
                    model.CvUrl = "/CV/" + model.CVFile.FileName;
                }

            }

            abouts.Title =model.Title;
            abouts.Description =model.Description;  
            abouts.CvUrl = model.CvUrl;
            abouts.ImageUrl = model.CvUrl;
            db.TblAbouts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
