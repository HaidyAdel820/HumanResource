using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication77.Models;

namespace WebApplication77.Controllers
{
    public class OfficialHolidaysController : Controller
    {
        // GET: OfficialHolidays
        public ActionResult Index()
        {
            HumanResourceEntities human = new HumanResourceEntities();
           var lst = human.OfficialHolidays.ToList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult create()
        {
          HumanResourceEntities human = new HumanResourceEntities();
           
            return View();
        }
        [HttpPost]
        public ActionResult create(OfficialHolidays holidays)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var Query1 = human.OfficialHolidays.FirstOrDefault(a => a.Id == holidays.Id);
            if (Query1 != null)
            {
                human.OfficialHolidays.Add(holidays);
                human.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit( int id)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var Query1 = human.OfficialHolidays.FirstOrDefault(a => a.Id == id);
            if (Query1 != null)
            {
                return View();
            }
            return RedirectToAction("index");

        }
        [HttpPost]
        public ActionResult Edit(OfficialHolidays holidays)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var Query1 = human.OfficialHolidays.FirstOrDefault(a => a.Id == holidays.Id);
            if (Query1 != null)
            {
                human.OfficialHolidays.Remove(Query1);
                human.OfficialHolidays.Add(holidays);
                human.SaveChanges();
                return RedirectToAction("index");

            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete( int id)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var lst = human.OfficialHolidays.FirstOrDefault(a=>a.Id == id);
            if (lst != null)
            {
                human.OfficialHolidays.Remove(lst);
                human.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}