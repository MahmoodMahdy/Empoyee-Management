using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DAl.Entities;
using WebApplication2.DAL.Entities;

namespace WebApplication2.DAl.Database
{

    public class DbContainer : IdentityDbContext
    {

        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts) { }
        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server= .; database = sharpDb1; integrated security=true;");
        //}
    }


}
