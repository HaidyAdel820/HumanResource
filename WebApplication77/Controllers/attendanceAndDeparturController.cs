using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication77.Models;

namespace WebApplication77.Controllers
{
    public class attendanceAndDeparturController : Controller
    {
        // GET: attendanceAndDepartur
        public ActionResult Index()
        {
                 
            HumanResourceEntities humanResource = new HumanResourceEntities();
           var query = humanResource.EmployeEndanceAndDeparture.ToList();
            return View(query);
        }
        [HttpGet]
        public ActionResult create()
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            return View();
        }
        [HttpPost]
        public ActionResult create(EmployeEndanceAndDeparture emp)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
         var Query2 = humanResource.EmployeEndanceAndDeparture.FirstOrDefault(a => a.Id == emp.Id);
            if (Query2 != null)
            {
                humanResource.EmployeEndanceAndDeparture.Add(Query2);
                humanResource.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var Query = humanResource.EmployeEndanceAndDeparture.FirstOrDefault(a => a.Id == id);
            if (Query != null)
            {
                return View();
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Edit(EmployeEndanceAndDeparture employe)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var Query = humanResource.EmployeEndanceAndDeparture.FirstOrDefault(a => a.Id == employe.Id);
            if (Query != null)
            {
                humanResource.EmployeEndanceAndDeparture.Remove(Query);
                humanResource.EmployeEndanceAndDeparture.Add(employe);
                return View();
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var Query = humanResource.EmployeEndanceAndDeparture.FirstOrDefault(a => a.Id == id);
            if (Query != null)
            {
                humanResource.EmployeEndanceAndDeparture.Remove(Query);
                humanResource.SaveChanges();
                return View();
            }
            return RedirectToAction("index");
        }
    }
}