using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Interface;
using WebApplication2.DAl.Database;
using WebApplication2.Models;

namespace WebApplication2.BL.Reposatory
{
    public class DistrictRep :IDistrictRep
    {
        private readonly DbContainer db;
        public DistrictRep(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<DistrictVM> Get()
        {
            var data = db.District.Select(a => new DistrictVM { Id = a.Id,DistrictName  = a.DistrictName, CityName = a.CityId });
            return data;
        }

        public DistrictVM GetByID(int id)
        {
            var data = db.District.Where(a => a.Id == id)
                    .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityName = a.CityId })
                    .FirstOrDefault();
            return data;
        }
    }
}
