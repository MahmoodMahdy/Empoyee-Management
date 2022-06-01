using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL.Interface
{
   public interface IEmployeeRep 
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetByID(int id);
        void Add(EmployeeVM emp);
        void Edit(EmployeeVM emp);
        void Delete(int id);
    }
}
