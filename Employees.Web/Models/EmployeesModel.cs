using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Web.Models
{
    public class EmployeesModel
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
        public int Employee_anual_salary { get; set; }
    }
}