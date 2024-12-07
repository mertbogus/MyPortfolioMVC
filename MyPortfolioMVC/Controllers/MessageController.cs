using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class MessageController : Controller
    {
        MyPortfofioDb6Entities db=new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var values = db.TblMessages.Where(x => x.IsRead == false).ToList();
            return View(values);
        }

        public ActionResult MessageDetail(int id)
        {
            var value = db.TblMessages.Find(id);
            var currentTime = DateTime.Now;
            value.Date = currentTime;
            value.IsRead = true;
            db.SaveChanges();
            return PartialView(value);
        }

        [HttpGet]
        public ActionResult MakeMessageRead()
        {
            var values = db.TblMessages.Where(x => x.IsRead == true).ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = db.TblMessages.Find(id);
            db.TblMessages.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}