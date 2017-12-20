using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.pakad
{
    public class AdvertisementHandler
    {public enum AdvertisementStatus
        {
            Pending, Approved, Disabled
    }
    public List<Advertisement> GetAdvertisement()
        {
            using (DemoContext con = new DemoContext())
            {
                return (from c in con.Advertisements
                        .Include("SubCategroy.Category")
                        .Include("City.Province.Country")
                        .Include("User")
                        .Include("Images")
                        .Include("Type")
                        .Include("Status")
                        select c

                       ).ToList();

            }
        }



        public List<Advertisement> GetFeaturedAd()
        {
           DemoContext context = new DemoContext();
            using (context)
            {
                return (from c in context.Advertisements
                         .Include(a => a.SubCategory.Category)
                        .Include(a => a.City.Province.Country)
                        .Include(a => a.User)
                        .Include(a => a.Images)
                        .Include(a => a.Status)
                        .Include(a => a.Type)
                        where c.isFeatured == true
                        select c).ToList();
            }
        }


        public  Advertisement Getadvertisemnt(int id)
        {
            using (DemoContext con = new DemoContext())
            {
                return (from c in con.Advertisements where c.Id == id select c).FirstOrDefault();
            }
        }


        public List<Advertisement> GetLatestAdvertisement(int count)
        {
            using (DemoContext con = new DemoContext())
            {
                return (from c in con.Advertisements
                        .Include(a => a.SubCategory.Category)
                        .Include(a => a.City.Province.Country)
                        .Include(a => a.User)
                        .Include(a => a.Images)
                        .Include(a => a.Status)
                        .Include(a => a.Type)
                        orderby c.PostedOn
                        select c

                       ).Take(count).ToList();

            }
        }



        public List<Advertisement> GetAdvertisementsByCategory(Category category)
        {
            using (DemoContext context = new DemoContext())
            {
                return (from adv in context.Advertisements
                        .Include(a => a.SubCategory.Category)
                        .Include(a => a.City.Province.Country)
                        .Include(a => a.User)
                        .Include(a => a.Images)
                        .Include(a => a.Status)
                        .Include(a => a.Type)
                        where adv.SubCategory.Category.Id == category.Id
                        select adv).ToList();
            }
        }


        public void AddStatus(Advertisement add)
        {
            using (DemoContext con=new DemoContext())
            {
                
                con.Entry(add.Status).State = EntityState.Modified;
                
                con.Advertisements.Add(add);
                con.SaveChanges();
            }
        }
        public void Add(Advertisement add)
        {
            using (DemoContext con = new DemoContext())
            {
                con.Entry(add.City).State = EntityState.Unchanged;
                con.Entry(add.Type).State = EntityState.Unchanged;
                con.Entry(add.Status).State = EntityState.Unchanged;
                con.Entry(add.SubCategory).State = EntityState.Unchanged;
                con.Entry(add.User).State = EntityState.Unchanged;
                con.Advertisements.Add(add);
                con.SaveChanges();

            }
        }

        public void Update(int id, Advertisement adv)
        {
            DemoContext context = new DemoContext();
            using (context)
            {

                
                
                    Advertisement toUpdate = (from m in context.Advertisements
                                        .Include(a =>a.Status)
                                       where m.Id == id
                                       select m).FirstOrDefault();

                    //toUpdate.Name = mobile.Name;
                    //toUpdate.Price = mobile.Price;
                    //...

                    context.SaveChanges();
                
            }
        }

        public void Delete( Advertisement adv)
        {
            using (DemoContext con = new DemoContext())
            {
                Advertisement delete = (from c in con.Advertisements
                                        .Include(a => a.Images)
                                        where c.Id == adv.Id
                                        select c).FirstOrDefault();

                con.Advertisements.Remove(delete);
                
                con.SaveChanges();
            }
        }

    }
}