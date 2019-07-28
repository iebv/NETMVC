﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCScaffoldingDemo.Dtos
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
    }
}