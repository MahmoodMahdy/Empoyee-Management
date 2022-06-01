using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Healper;
using WebApplication2.BL.Interface;
using WebApplication2.DAl.Database;
using WebApplication2.DAL.Entities;
using WebApplication2.Models;

namespace WebApplication2.BL.Reposatory
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer db;
        private readonly IMapper mspper;

        public EmployeeRep(DbContainer db, IMapper _Mspper)
        {
            this.db = db;
            mspper = _Mspper;
        }
        public IQueryable<EmployeeVM> Get()
        {
            var data = db.employee.Select(a => new EmployeeVM
            {
                Id = a.Id,
                Name = a.Name,Salary =a.Salary ,Address =a.Address ,Email=a.Email ,HireDate= a.HireDate 
                ,IsActive=a.IsActive , Notes = a.Notes   ,  DepartmentId = a.Department.DepartmentName,
                DistrictId = a.District.DistrictName , CvName = a.CvName , PhotoName = a.PhotoName 
            });
            return data;
        }
        public void Add(EmployeeVM emp)
        {
            //Mapping
            //Employee d = new Employee();
            //d.EmployeeName = dpt.EmployeeName;
            //d.EmployeeCode = dpt.EmployeeCode;

            var data = mspper.Map<Employee>(emp);

            data.PhotoName = UploadHealper.SaveFile(emp.PhotoUrl, "Photos");
            data.CvName = UploadHealper.SaveFile(emp.CvUrl, "Docs"); 

            db.employee.Add(data);
            db.SaveChanges();

        }

        public EmployeeVM GetByID(int id)
        {
            var data = db.employee.Where(a => a.Id == id)
                 .Select(a => new EmployeeVM
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Salary = a.Salary,
                     Address = a.Address,
                     Email = a.Email,
                     HireDate = a.HireDate
                ,
                     IsActive = a.IsActive,
                     Notes = a.Notes,
                     DepartmentId = a.Department.DepartmentName , 
                     DistrictId = a.District.DistrictName ,
                     CvName = a.CvName,
                     PhotoName = a.PhotoName
                 }).FirstOrDefault();
            return data;
        }

        public void Edit(EmployeeVM emp)
        {
            var oldData = db.employee.Find(emp.Id);

            oldData.Name = emp.Name;
            oldData.Salary = emp.Salary;
            oldData.Address = emp.Address;
            oldData.Email = emp.Email;
            oldData.HireDate = emp.HireDate;
            oldData.IsActive = emp.IsActive;
            oldData.Notes = emp.Notes;
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var deletedObject = db.employee.Find(id);


            db.employee.Remove(deletedObject);

            UploadHealper.RemoveFile("Photos/", deletedObject.PhotoName);
            UploadHealper.RemoveFile("Docs/", deletedObject.CvName);

            db.SaveChanges();

        }
    }
}
