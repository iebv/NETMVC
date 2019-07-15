using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCScaffoldingDemo.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name = myConnectionString") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}