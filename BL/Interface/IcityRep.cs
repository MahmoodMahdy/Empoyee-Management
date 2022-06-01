using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL.Interface
{
      public interface IcityRep
    {
        IQueryable<CityVM> Get();
        CityVM GetByID(int id);
    }
}
