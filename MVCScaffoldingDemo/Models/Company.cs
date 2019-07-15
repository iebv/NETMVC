using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCScaffoldingDemo.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalEmployees { get; set; }
        public ICollection<Employee> EmployeeList { get; set; } 
    }
}