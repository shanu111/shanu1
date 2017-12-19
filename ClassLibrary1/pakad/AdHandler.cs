using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.pakad
{
 public   class AdHandler
    {
        public List<AdType> Gettypes()
        {
            using (DemoContext con = new DemoContext())
            {
                return (from c in con.Types select c).ToList();
            }
        }


        
    }
}
