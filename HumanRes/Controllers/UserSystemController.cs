using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication77.Models;

namespace WebApplication77.Controllers
{
    public class UserSystemController : Controller
    {
        // GET: UserSystem
        public ActionResult Index()
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();

            var lst = humanResource.UserSystem.ToList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(UserSystem user)
        {

            if (ModelState.IsValid)
            {
                HumanResourceEntities humanResource = new HumanResourceEntities();
                humanResource.UserSystem.Add(user);
                humanResource.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var lst = humanResource.UserSystem.FirstOrDefault(a => a.Id == id);
            if (lst != null)
            {
                ViewBag.initialValue = lst.Email;
                return View(lst);
            }

            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Edit(UserSystem user)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var Query = humanResource.UserSystem.FirstOrDefault(a => a.Id == user.Id);
            if (Query != null)
            {
                Query.Password = user.Password;
                Query.Id = user.Id;
                Query.UserName = user.UserName;
                Query.FullName = user.FullName;
                Query.Email = user.Email;
                humanResource.SaveChanges();

            }
            else
            {
                return View();
            }

            return RedirectToAction("index");
        }
        [HttpGet]

        public ActionResult Delete(int id)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var lst = humanResource.UserSystem.FirstOrDefault(a => a.Id == id);
            if (lst != null)
            {
                humanResource.UserSystem.Remove(lst);
                humanResource.SaveChanges();
                return View(lst);
            }

            return RedirectToAction("index");
        }
        public ActionResult checkEmail(string Email, string initialValue)
        {
            if (initialValue == Email)
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var query1 = humanResource.UserSystem.FirstOrDefault(a => a.Email == Email);
            if (query1 == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpGet]
        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(string Email , string password)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var query = humanResource.UserSystem.FirstOrDefault(a => a.Email == Email && a.Password == password );
            if (query != null)
            {

                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
            
        }
    }
}