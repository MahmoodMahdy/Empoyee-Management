using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Interface;
using WebApplication2.DAl.Database;
using WebApplication2.DAl.Entities;
using WebApplication2.Models;

namespace WebApplication2.BL.Reposatory
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mspper;

        public DepartmentRep(DbContainer db ,IMapper _Mspper)
        {
            this.db = db;
            mspper = _Mspper;
        }
        public IQueryable<DepartmentVM> Get()
        {
            var data = db.department.Select(a =>new DepartmentVM {
                Id = a.Id ,DepartmentName=a.DepartmentName 
                ,
                DepartmentCode = a.DepartmentCode
            });
            return data;
        }
        public void Add(DepartmentVM dpt)
        {
            //Mapping
            //Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;

            var data = mspper.Map<Department>(dpt); 
            db.department.Add(data);
            db.SaveChanges();

        }

        public DepartmentVM GetByID(int id)
        {
            var data = db.department.Where(a => a.Id == id)
                 .Select(a => new DepartmentVM
                 {
                     Id = a.Id,
                     DepartmentName = a.DepartmentName,
                     DepartmentCode = a.DepartmentCode
                 }).FirstOrDefault(); 
                return data;
        }

        public void Edit(DepartmentVM dpt)
        {
            var oldData = db.department.Find(dpt.Id); 
         
            oldData.DepartmentName = dpt.DepartmentName;
            oldData.DepartmentCode = dpt.DepartmentCode;
            db.SaveChanges(); 

        }

        public void Delete(int id)
        {
            var deletedObject = db.department.Find(id);
            db.department.Remove(deletedObject);
            db.SaveChanges(); 

        }
    }
}
