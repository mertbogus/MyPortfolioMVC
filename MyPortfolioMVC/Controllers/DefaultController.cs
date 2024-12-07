using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MyPortfolioMVC.Models;
using Newtonsoft.Json.Linq;

namespace MyPortfolioMVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller

    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultBanner()
        {
            var value = db.TblBanners.Where(x => x.IsShown == true).ToList();
            var social = db.TblSocialMedias.ToList();
            return PartialView(Tuple.Create(value,social));
        }

        public PartialViewResult DefaultExpertise()
        {
            var values = db.TblExpertises.ToList();
            return PartialView(values);

        }

        public PartialViewResult DefaultExperience()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEducation()
        {
            var values = db.TblEducations.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjects()
        {
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        [HttpGet]

        public PartialViewResult SendMessage()
        {
            var value= db.TblContacts.ToList();
            var social=db.TblSocialMedias.ToList();
            return PartialView(Tuple.Create(value, social));
        }

        [HttpPost]

        public ActionResult SendMessage(TblMessage model)
        {
            model.IsRead = false;
            db.TblMessages.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultTestimonial()
        {
            var values=db.TblTestimonials.ToList();
            return PartialView(values);
        }
    }
}