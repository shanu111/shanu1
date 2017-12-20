using ClassLibrary1.pakad;
using ClassLibrary1.user;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.pakad.Advertisement;

namespace ClassLibrary1
{
   public class DemoContext :DbContext
    {
        public DemoContext():base("Tempdb")
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<AdType> Types { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdStatus> Status { get; set; }
        public DbSet<Signup> Signups { get; set; }

    }
}
