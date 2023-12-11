using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication77.Models;

namespace WebApplication77.Controllers
{
    public class UsergroupController : Controller
    {
        // GET: Usergroup
        public ActionResult Index()
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var lst =  human.Usergroup.ToList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult create()
        {
            HumanResourceEntities human = new HumanResourceEntities();
            return View();
        }
        [HttpPost]
        public ActionResult create(Usergroup user)
        {
            HumanResourceEntities human = new HumanResourceEntities();
          var query =  human.Usergroup.FirstOrDefault(a => a.Id == user.Id);
            if (query != null)
            {
                human.Usergroup.Add(query);
                human.SaveChanges();
                return View();
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var query = human.Usergroup.FirstOrDefault(a => a.Id == id);
            if (query != null)
            {
                return View();
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Edit(Usergroup usrs)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var query = human.Usergroup.FirstOrDefault(a => a.Id == usrs.Id);
            if (query != null)
            {
                human.Usergroup.Remove(query);
                human.Usergroup.Add(usrs);
                human.SaveChanges();
                return View();
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var query = human.Usergroup.FirstOrDefault(a => a.Id == id);
            if (query != null)
            {
                human.Usergroup.Remove(query);
                human.SaveChanges();
                return View();
            }
            return RedirectToAction("index");
        }
    }

}