using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class BannerController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var banners = db.TblBanners.ToList();
            return View(banners);
        }

        public ActionResult DeleteBanner(int id)
        {
            var banners = db.TblBanners.Find(id);
            db.TblBanners.Remove(banners);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBanner(TblBanner model)
        {
            model.IsShown = false;
            db.TblBanners.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var banners = db.TblBanners.Find(id);
            return View(banners);
        }

        [HttpPost]
        public ActionResult UpdateBanner(TblBanner banner)
        {
            var banners = db.TblBanners.Find(banner.BannerId);
            banners.Title = banner.Title;
            banners.Description = banner.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShownBanner(int id)
        {
            var values = db.TblBanners.Find(id);
            values.IsShown = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NoShownBanner(int id)
        {
            var values = db.TblBanners.Find(id);
            values.IsShown = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}