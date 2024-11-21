using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MyPortfolioMVC.Models;

namespace MyPortfolioMVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
            
    {
        MyPortfofioDb6Entities db=new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultBanner()
        {
            var value = db.TblBanners.Where(x => x.IsShown == true).ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultExpertise()
        {
            var values = db.TblExpertises.ToList();
            return PartialView(values);

        }

        public PartialViewResult DefaultExperience()
        {
            var values=db.TblExperiences.ToList();
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
    }
}