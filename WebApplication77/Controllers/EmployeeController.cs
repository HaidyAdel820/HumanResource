using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication77.Models;

namespace WebApplication77.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var lst = human.Employee.ToList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Employee emp)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            //human.Employee.FirstOrDefault(a => a.Id == emp.Id);
            if (ModelState.IsValid)
            {
                human.Employee.Add(emp);
                human.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id )
        {

            HumanResourceEntities humanResource = new HumanResourceEntities();
            var lst = humanResource.UserSystem.FirstOrDefault(a => a.Id == id);
            if (lst != null)
            {
                
                return View(lst);
            }

            return RedirectToAction("index");
        }
         [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            HumanResourceEntities humanResource = new HumanResourceEntities();
            var Query = humanResource.Employee.FirstOrDefault(a => a.Id == emp.Id);
            if (Query != null)
            {
                humanResource.Employee.Remove(Query);
                humanResource.Employee.Add(emp);
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
            var lst2 = humanResource.Employee.FirstOrDefault(a => a.Id == id);
            if (lst2 != null)
            {
                humanResource.Employee.Remove(lst2);
                humanResource.SaveChanges();
                return View(lst2);
            }

            return RedirectToAction("index");
        }

    }
}   