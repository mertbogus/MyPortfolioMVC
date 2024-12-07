using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfofioDb6Entities db=new MyPortfofioDb6Entities();
        public ActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpricts()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            var email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);

            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbar()
        {
            var email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);
            var message = db.TblMessages.Where(x => x.IsRead == false).Take(3).ToList();
            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;
            return PartialView(message);
        }

        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }
    }
}