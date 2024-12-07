using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var testimonials = db.TblTestimonials.ToList();
            return View(testimonials);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var testimonials = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(testimonials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial model)
        {
            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "image\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.ImageUrl = "/image/" + model.ImageFile.FileName;
            }
            db.TblTestimonials.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonials = db.TblTestimonials.Find(id);
            return View(testimonials);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial model)
        {
            var testimonials = db.TblTestimonials.Find(model.TestimonialId);
            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "image\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.ImageUrl = "/image/" + model.ImageFile.FileName;
                testimonials.ImageUrl = model.ImageUrl;
            }
            
            testimonials.NameSurname = model.NameSurname;
            testimonials.Title=model.Title;
            testimonials.Comments = model.Comments;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}