using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class LocationHandler
    {

        public List<Country> GetCountries()
        {
            using (DemoContext con = new DemoContext()) { 

                return (from c in con.Countries select c).ToList();
            }
        }


       public Country GetCountries(int id)
        {
            using (DemoContext con=new DemoContext())
            {
                return (from c in con.Countries where c.Id == id select c).FirstOrDefault();
            }
        }


        public List<province> GetProvince(Country country)
        {
            using (DemoContext con=new DemoContext())
            {
                return (from c in con.Provinces.Include("Country") where c.Country.Id == country.Id select c).ToList();
            }
        }

        public List<City>GetCities(province province)
        {
            using (DemoContext con=new DemoContext())
            {
                return (from c in con.Cities.Include("province.Country") where c.Province.Id == province.Id select c).ToList();
            }
        }

    }
}
