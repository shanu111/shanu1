using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.user
{
    public class Userhandler
    {
        public List<User> Getuser()
        {
            using (DemoContext con= new DemoContext())
            {
                return (from c in con.Users .Include("Role").Include("Address.City.Province.Country") select c).ToList();
            }
        }


        public User Getuser(string loginid,string password)
        {
            using (DemoContext con = new DemoContext())
            {
                return (from c in con.Users.Include("Role").Include("Address.City.Province.Country")
                        where c.LoginId.Equals(loginid) && c.Password.Equals(password)
                        select c).FirstOrDefault();
            }
        }




        public void Add(User add)
        {
            using (DemoContext con = new DemoContext())
            {


                con.Entry(add.Role).State = EntityState.Unchanged;
                con.Entry(add.Address).State = EntityState.Unchanged;


                con.Users.Add(add);
                con.SaveChanges();

            }
        }










        public List<Role> GetRoles()
        {
            DemoContext context = new DemoContext();
            using (context)
            {
                return (from u in context.Roles
                        select u).ToList();
            }
        }





    }
}

