using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HealthSpot.Models
{
    public class LoginModel
    {
        [DisplayName(displayName: "Employee ID")]
        public int Id { get; set; }
        [DisplayName(displayName: "Password")]
        public string Password { get; set; }
    }
}