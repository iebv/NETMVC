using AutoMapper;
using MVCScaffoldingDemo.Dtos;
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
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return _context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDto>);
        }

        //GET /api/employees/1
        public EmployeeDto GetEmployee(int id)
        {
            Employee employee = _context.Employees.SingleOrDefault(x => x.ID == id);

            if (employee == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            return Mapper.Map<Employee, EmployeeDto>(employee);
        }

        //POST /api/employees/
        [HttpPost]
        public EmployeeDto CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            Employee employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);
            _context.Employees.Add(employee);
            _context.SaveChanges();

            employeeDto.ID = employee.ID;

            return employeeDto;
        }

        //PUT /api/employees/1
        [HttpPut]
        public void UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            Employee employeeInDb = _context.Employees.SingleOrDefault(c => c.ID == id);

            if (employeeInDb == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            Mapper.Map(employeeDto, employeeInDb);
   
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
