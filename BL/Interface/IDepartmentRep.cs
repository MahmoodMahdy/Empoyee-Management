using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL.Interface
{
   public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetByID(int id); 
        void Add(DepartmentVM dpt);
        void Edit(DepartmentVM dpt);
        void Delete(int id);
    }
}
