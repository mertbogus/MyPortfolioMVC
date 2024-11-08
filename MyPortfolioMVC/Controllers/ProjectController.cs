using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();

        private void CategoryDropDown()
        {
            var categoryList = db.TblCategories.ToList();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
        }
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            //Ilist IEnumerable ICollection List Araştır
            CategoryDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject model)
        {
            CategoryDropDown();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.TblProjects.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var values=db.TblProjects.Find(id);
            return View(id);
        }


        [HttpPost]
        public ActionResult UpdateProject(TblProject model)
        {
            CategoryDropDown();
            var values = db.TblProjects.Find(model.ProjectId);
            values.Name = model.Name;
            values.ImageUrl = model.ImageUrl;
            values.Description = model.Description;
            values.CategoryId = model.CategoryId;
            values.GithubUrl = model.GithubUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}