using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.pakad
{
  public  class CategoryHandler
    {
        public List<Category> Getcategory()
        {
            using (DemoContext con=new DemoContext())
            {
                return (from c in con.Categories select c).ToList();
            }
            
        }


        public List<AdStatus> GetStatus()
        {
            using (DemoContext con = new DemoContext())
            {
                return (from c in con.Status select c).ToList();
            }

        }


        public List<SubCategory>GetSubcategory(int id)
        {
            using (DemoContext con=new DemoContext())
            {
                return (from c in con.SubCategories.Include("Category") where c.Category.Id == id select c).ToList();
            }
            {

            }
        }

    }
}
