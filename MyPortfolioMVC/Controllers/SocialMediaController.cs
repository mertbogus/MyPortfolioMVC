using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var socials = db.TblSocialMedias.ToList();
            return View(socials);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia model)
        {
            db.TblSocialMedias.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var values = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia model)
        {
            var value = db.TblSocialMedias.Find(model.SocialMediaId);
            value.Name = model.Name;
            value.Url = model.Url;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}