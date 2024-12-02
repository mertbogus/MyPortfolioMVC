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
        MyPortfofioDb6Entities db=new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var socials = db.TblSocialMedias.ToList();
            return View(socials);
        }
    }
}