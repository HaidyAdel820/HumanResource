using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication77.Models;

namespace WebApplication77.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        // GET: EmployeeSalary
        public ActionResult Index()
        {

            List<Month> months = new List<Month>()
            {
                new Month(){ MonthId = 1 , MonthName = "jan"},
                new Month(){ MonthId = 2 , MonthName = "feb"},
                new Month(){ MonthId = 3 , MonthName = "marth"},
                new Month(){ MonthId = 4 , MonthName = "jan"},
            };
            List<year> years = new List<year>()
            {

            };
            for (int i = 1990; i < 2023; i++)
            {

                years.Add(new year() { yearid = i });
            }

            SelectList sl = new SelectList(months, "MonthId", "MonthName");
            ViewBag.MonthId = sl;

            SelectList ssl = new SelectList(years, "yearid", "yearid");
            ViewBag.yearid = ssl;


            HumanResourceEntities human = new HumanResourceEntities();
            //var lst = human.EmployeeSalary.Select(a=> new { a.Section,a.Salary,a.absence,a.Presence,a.ExtraHours,a.ExtraDiscount,a.Discount,a.ExtraTotal,a.Name}).Where()
            var result = from e in human.Employee
                         join s in human.EmployeeSalary
                         on e.Id equals s.Emp_Id
                         select new
                         {
                             s.Id,
                             s.Emp_Id,
                             s.Section,
                             e.Salary,
                             s.absence,
                             s.Presence,
                             s.ExtraHours,
                             s.ExtraDiscount,
                             s.Discount,
                             s.ExtraTotal,
                             e.Name
                         };
            List<EmpSalaryData> lstEmpSalaryData = new List<EmpSalaryData>();
           
            foreach (var item in result)
            {
                EmpSalaryData obj = new EmpSalaryData();
                obj.Section = item.Section;
                lstEmpSalaryData.Add(obj);
                
            };

            return View(lstEmpSalaryData);
        }
        [HttpGet]
        public ActionResult create (int id)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            return View();
        }
        [HttpPost]
        public ActionResult create(EmployeeSalary employee)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            if (ModelState.IsValid)
            {
                human.EmployeeSalary.Add(employee);
                return View();
            }
            
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit( int id)
        {
            HumanResourceEntities human = new HumanResourceEntities();
           var query = human.EmployeeSalary.FirstOrDefault(a => a.Id == id);
            if (query != null)
            {
                return View();
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Edit(EmployeeSalary emps)
        {
            HumanResourceEntities human = new HumanResourceEntities();
            var query1 = human.EmployeeSalary.FirstOrDefault(a => a.Id == emps.Id);
            if (query1 != null)
            {
                human.EmployeeSalary.Remove(query1);
                human.EmployeeSalary.Add(emps);
                human.SaveChanges();
                return View();
            }
            return RedirectToAction("index");
        }
    }
}