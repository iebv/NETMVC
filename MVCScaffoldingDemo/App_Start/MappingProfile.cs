using AutoMapper;
using MVCScaffoldingDemo.Dtos;
using MVCScaffoldingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCScaffoldingDemo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>();
        }
    }
}