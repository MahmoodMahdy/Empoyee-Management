using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Interface;
using WebApplication2.DAl.Database;
using WebApplication2.Models;

namespace WebApplication2.BL.Reposatory
{
    public class CityRep : IcityRep
    {
        private readonly DbContainer db;


        public CityRep(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<CityVM> Get()
        {
            var data = db.City.Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryName = a.CountryId });
            return data;
        }

       public CityVM GetByID(int id)
            {
              var data = db.City.Where(a => a.Id == id)
                      .Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryName = a.CountryId })
                      .FirstOrDefault();
              return data;
            }
        }
    } 
