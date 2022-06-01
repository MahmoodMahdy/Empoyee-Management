using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL.Interface
{
    public interface IDistrictRep
    {
        IQueryable<DistrictVM> Get();
        DistrictVM GetByID(int id);
    }
}
