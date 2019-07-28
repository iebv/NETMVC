using MVCScaffoldingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCScaffoldingDemo.Controllers.api
{
    public class EmployeesController : ApiController
    {
        private MyDbContext _context;

        public EmployeesController() {
            _context = new MyDbContext();
        }

        //GET /api/employees
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        //GET /api/employees/1
        public Employee GetEmployee(int id)
        {
            Employee employee = _context.Employees.SingleOrDefault(x => x.ID == id);

            if (employee == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            return employee;
        }

        //POST /api/employees/
        [HttpPost]
        public Employee CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        //PUT /api/employees/1
        [HttpPut]
        public void UpdateEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            Employee employeeInDb = _context.Employees.SingleOrDefault(c => c.ID == id);

            if (employeeInDb == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            employeeInDb.Name = employee.Name;
            employeeInDb.Age = employee.Age;
            employeeInDb.JoiningDate = employee.JoiningDate;

            _context.SaveChanges();
        }

        //DELETE /api/employees/1
        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            Employee employeeInDb = _context.Employees.SingleOrDefault(x => x.ID == id);

            if (employeeInDb == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
        }
    }
}
