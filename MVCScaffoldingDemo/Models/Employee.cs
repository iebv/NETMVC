using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCScaffoldingDemo.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
    }

   
}