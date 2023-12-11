using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication77.Models
{
    public class AttendanceAndDeparture
    {

        public int Id { get; set; }
        public Nullable<int> Attendance { get; set; }
        public Nullable<int> departure { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Section { get; set; }
        public Nullable<int> EmpId { get; set; }


    }
}