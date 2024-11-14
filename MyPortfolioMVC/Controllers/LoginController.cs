﻿using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolioMVC.Controllers
{
    public class LoginController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            var value = db.TblAdmins.FirstOrDefault(x=>x.Email==model.Email && x.Password==model.Password);
            if (value == null)
            {
                ModelState.AddModelError("", "Email veya Şifre Hatalı.");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(value.Email,false);
            Session["nameSurname"]= value.Name + " " + value.Surname;
            return RedirectToAction("Index","Category");

            
        }
    }
}