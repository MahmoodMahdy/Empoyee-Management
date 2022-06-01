using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Interface;
using WebApplication2.DAl.Database;
using WebApplication2.Models;

namespace WebApplication2.BL.Reposatory
{
    public class CountryRep : ICountryRepo
    {
        private readonly DbContainer db;


        public CountryRep(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<CountryVM> Get()
        {
            var data = db.Country.Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
            return data;
        }

        public CountryVM GetByID(int id)
        {
            var data = db.Country.Where(a => a.Id == id)
                    .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName })
                    .FirstOrDefault();
            return data;
        }
    }
}
