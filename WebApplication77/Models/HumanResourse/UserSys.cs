using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication77.Models.HumanResourse
{
    public partial class UserSys
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "you must error FullName")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "you error UserName ")]
        public string UserName { get; set; }
        [Remote("checkEmail", "UserSystem", ErrorMessage = "you must error Email", AdditionalFields = "initialValue")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Powers { get; set; }

    }
}