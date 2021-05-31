using MuseumProject.Models;
using MuseumProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;

namespace MuseumProject.Controllers
{
    public class HomeController : Controller
    {
        Context _context = new Context();
        IndexViewModel model = new IndexViewModel();

        public HomeController()
        {
            model.Admin = _context.Admin.FirstOrDefault(x => x.Id == 1);
            model.Category = _context.Category.ToList();
            model.Collection = _context.Collection.OrderByDescending(x => x.AddDate).ToList();

        }

        public ActionResult Index()
        {
            return View(model);
        }

        [HttpPost]
        public JsonResult ContactForm(Message message)
        {

            if (message.Mail != null && message.MessageText != null && message.Name != null)
            {
                message.MessageDate = DateTime.Now;
                _context.Message.Add(message);
                _context.SaveChanges();
                return Json(1);
            }
            else
                return Json(0);
        }

        public ActionResult About()
        {
            return View(model.Admin);
        }

        public ActionResult Collection(int? id, int page=1)
        {
            if (id != null)
            {
                var list = model.Collection.Where(x => x.CategoryId == id).ToList().ToPagedList(page, 6);
                ViewBag.Heading = model.Category.Where(x => x.Id == id).FirstOrDefault().Name;
                return View(list);
            }
            ViewBag.Heading = "Tüm Eserler";
            return View(model.Collection.ToList().ToPagedList(page,6));
        }
    }
}