using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication77.Models;

namespace WebApplication77.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Index()
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var lst =humanResource.EmployeeSetting.ToList();

            return View(lst);
        }
        [HttpGet]
        public ActionResult create()
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            List<WeekDays> weeks = new List<WeekDays>()
            {
                new WeekDays(){id = 1 , name = "Saturday"},
                new WeekDays(){id = 2 , name = "Sunday"},
                new WeekDays(){id = 3 , name = "Monday"},
            };
            List<WeekDay2> weekDay2s = new List<WeekDay2>()
            {
                new WeekDay2(){ idWeekDay = 1 , name ="Saturday"},
                new WeekDay2(){ idWeekDay = 2, name ="Sunday"},
                new WeekDay2(){ idWeekDay = 3 , name ="Monday"},
            };
            SelectList sl = new SelectList(weeks, "id", "name");
            ViewBag.id = sl;

            SelectList sll = new SelectList(weekDay2s, "idWeekDay", "name");
            ViewBag.idWeekDay = sll;
            return View();
        }
        [HttpPost]
        public ActionResult create(EmployeeSetting emp)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var query1 = humanResource.EmployeeSetting.FirstOrDefault(a => a.Id == emp.Id);
            if (query1 != null)
            {
                return View();

            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var query1 = humanResource.EmployeeSetting.FirstOrDefault(a => a.Id == id);
            if (query1 != null)
            {
                return View();

            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Edit(EmployeeSetting employee)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var query1 = humanResource.EmployeeSetting.FirstOrDefault(a => a.Id == employee.Id);
            if (query1 != null)
            {
                humanResource.EmployeeSetting.Remove(query1);
                humanResource.EmployeeSetting.Add(employee);
                humanResource.SaveChanges();
                return View();

            }
            return RedirectToAction("index");
        }
    }
}