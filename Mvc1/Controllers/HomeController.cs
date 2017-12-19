using ClassLibrary1.pakad;
using ClassLibrary1.user;
using Mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            //User currentUser = (User)Session[Webutil.CurrentUser];

            //if (currentUser == null) return RedirectToAction("UserLogin", "Login", new { returnUrl = "Advertisement/postAd" });
            ViewBag.Newad = new AdvertisementHandler().GetLatestAdvertisement(12).ToselectModelList();
            return View();

        }
        [HttpGet]
        public ActionResult Featured()
        {
            User currentUser = (User)Session[Webutil.CurrentUser];

            if (currentUser == null) return RedirectToAction("UserLogin", "Login", new { returnUrl = "Home/Featured" });
            ViewBag.Newad = new AdvertisementHandler().GetFeaturedAd().ToselectModelList();
          

            return View();

        }



        [HttpGet]
        public ActionResult Admin()
        {
            User currentUser = (User)Session[Webutil.CurrentUser];

            if (currentUser == null) return RedirectToAction("UserLogin", "Login", new { returnUrl = "Home/Admin" });

            ViewBag.Newad = new AdvertisementHandler().GetLatestAdvertisement(12).ToselectModelList();
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Advertisement a = new AdvertisementHandler().Getadvertisemnt(id);

            new AdvertisementHandler().Delete(a);

            return RedirectToAction("Admin", "Home");
            
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            // changed here too
            Advertisement a = new AdvertisementHandler().Getadvertisemnt(id);
            ViewBag.Ad = a;
            return View();

        }

        [HttpPost]
        public ActionResult Edit(FormCollection data)
        {
            // my changes
            var ad = new AdvertisementHandler().Getadvertisemnt(Convert.ToInt32(data["Ad"]));
            ad.Status = new AdStatus { Id = Convert.ToInt32(data["Status"]) };
            new AdvertisementHandler().Update(ad.Id, ad);
            return RedirectToAction("Admin");
        }

        

        [HttpGet]

        public ActionResult ByCategory(int id)
        {
            Advertisement c = new Advertisement();

            if (Convert.ToBoolean( c.Status.Id=2))
            {
                User currentUser = (User)Session[Webutil.CurrentUser];

                if (currentUser == null) return RedirectToAction("UserLogin", "Login", new { returnUrl = "Home/ByCategory" });


                ViewBag.Cid = new AdvertisementHandler().GetAdvertisementsByCategory(new Category { Id = id }).ToselectModelList();
                
            }
            return View();
        }

        [HttpGet]

        public ActionResult ByCategoryGrid(int id)
        {
            ViewBag.Cid = new AdvertisementHandler().GetAdvertisementsByCategory(new Category { Id = id }).ToselectModelList();
            return View();
        }

        










        /////////////////////////////////////////
        //public ActionResult Property()
        //{

        //    ViewBag.Cid = new AdvertisementHandler().GetAdvertisementsByCategory(new Category { Id = 1 }).ToselectModelList();
        //    return View();
        //}


        //[HttpGet]
        //public ActionResult Mobiles()
        //{

        //    ViewBag.Cid = new AdvertisementHandler().GetAdvertisementsByCategory(new Category { Id = 3 }).ToselectModelList();
        //    return View();
        //}



        //[HttpGet]
        //public ActionResult Books()
        //{

        //    ViewBag.Cid = new AdvertisementHandler().GetAdvertisementsByCategory(new Category { Id = 2 }).ToselectModelList();
        //    return View();
        //}
    }
}