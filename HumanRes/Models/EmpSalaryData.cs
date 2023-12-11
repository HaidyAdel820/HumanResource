using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication77.Models
{
    public class EmpSalaryData
    {
        public int EmpId { get; set; }
        public int EmpSalaryId { get; set; }
        public string Section { set; get; }
        public string Salary { set; get; }
        public string absence { set; get; }
        public string Presence { set; get; }
        public string ExtraHours { set; get; }
        public string ExtraDiscount { set; get; }
        public string Discount { set; get; }
        public string ExtraTotal { set; get; }
        public string Name { set; get; }
        public int Net { get; set; }
    }
}