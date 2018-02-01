using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HealthSpot.Models
{
    public class EmployeeModel
    {
        [DisplayName("Employee ID")]
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
        public bool IsAuthorized { get; set; }
    }
}