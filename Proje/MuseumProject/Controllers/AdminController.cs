using MuseumProject.Models;
using MuseumProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MuseumProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context _context = new Context();
        IndexViewModel model = new IndexViewModel();

        public AdminController()
        {
            model.Category = _context.Category.ToList();
            model.Collection = _context.Collection.OrderByDescending(x => x.AddDate).ToList();
            model.Message = _context.Message.OrderByDescending(x => x.MessageDate).ToList();
        }

        [OverrideAuthorization]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost, OverrideAuthorization]
        public ActionResult Login(string userName, string password)
        {

            var activeAdmin = _context.Admin.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (activeAdmin != null)
            {
                Session["admin"] = activeAdmin.UserName;
                FormsAuthentication.SetAuthCookie(activeAdmin.UserName, false);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }


        public ActionResult Index()
        {
            return View(model);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("admin");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Message()
        {
            return View(model);

        }

        public ActionResult DeleteMessage(int id)
        {
            var message = _context.Message.Where(x => x.Id == id).FirstOrDefault();
            _context.Message.Remove(message);
            _context.SaveChanges();
            TempData["AllMessage"] = "Mesaj başarıyla silindi";
            return RedirectToAction("Message", "Admin");
        }

        public ActionResult DeleteCollection(int id)
        {
            var collection = _context.Collection.Where(x => x.Id == id).FirstOrDefault();
            _context.Collection.Remove(collection);
            _context.SaveChanges();
            TempData["Collection"] = "İçerik başarıyla silindi.";
            return RedirectToAction("Index");
        }

        public ActionResult AddCollection()
        {
            AddCollectionViewModel addModel = new AddCollectionViewModel();
            addModel.SelectedCategory = new SelectList(model.Category, "Id", "Name");
            return View(addModel);
        }

        [HttpPost]
        public ActionResult AddCollection(AddCollectionViewModel addModel)
        {
            if (ModelState.IsValid)
            {
                addModel.Collection.AddDate = DateTime.Now;
                _context.Collection.Add(addModel.Collection);
                _context.SaveChanges();
                TempData["Collection"] = "İçerik başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            else
                return View(addModel);

        }

    }
}