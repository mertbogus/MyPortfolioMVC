using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class ContactController : Controller
    {
        MyPortfofioDb6Entities db = new MyPortfofioDb6Entities();
        public ActionResult Index()
        {
            var contacts = db.TblContacts.ToList();
            return View(contacts);
        }

        public ActionResult DeleteContact(int id)
        {
            var contacts = db.TblContacts.Find(id);
            db.TblContacts.Remove(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(TblContact contacts)
        {
            db.TblContacts.Add(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contacts = db.TblContacts.Find(id);
            return View(contacts);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact conttacts)
        {
            var contact = db.TblContacts.Find(conttacts.ContactId);
            contact.Phone = conttacts.Phone;
            contact.Email = conttacts.Email;
            db.TblContacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}