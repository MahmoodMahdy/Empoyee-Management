using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication2.DAl.Entities;
using WebApplication2.DAL.Entities;
using WebApplication2.Models;

namespace WebApplication2.BL.Mapper
{
    public class DomainProfile : Profile 
    {
        public DomainProfile()
        {
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();

            CreateMap<EmployeeVM, Employee>();
            CreateMap<Employee, EmployeeVM>();
        }
    }
}
