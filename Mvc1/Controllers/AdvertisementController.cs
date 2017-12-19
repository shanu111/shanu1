using ClassLibrary1;
using ClassLibrary1.pakad;
using ClassLibrary1.user;
using Mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ClassLibrary1.pakad.Advertisement;

namespace Mvc1.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        public ActionResult Search()
        {
            ViewBag.Categories = new CategoryHandler().Getcategory().ToselectList();
            return View();
        }



        public ActionResult Subcategories(int id)
        {
            DDLModel model = new DDLModel();
            model.Name = "Subcategory";
            model.Caption = "-Select SubCategory-";
            model.Glypicon = "glyphicon-tags";

            model.Values = new CategoryHandler().GetSubcategory(id).ToselectList();
            return PartialView("~/Views/Shared/DDLlayout.cshtml", model);



        }


        [HttpGet]

        public ActionResult postAd()
        {
            User currentUser = (User)Session[Webutil.CurrentUser];

            if (currentUser == null) return RedirectToAction("UserLogin", "Login", new { returnUrl = "Advertisement/postAd" });



            ViewBag.CountryList = new LocationHandler().GetCountries().ToselectList();
            ViewBag.Categories = new CategoryHandler().Getcategory().ToselectList();
            var temp = new AdHandler().Gettypes().ToselectList();
            temp.First().Selected = true;
            ViewBag.Adtypes = temp;
            return View();
        }

        [HttpPost]

        public ActionResult postAd(FormCollection data)
        {
            User currentUser = (User)Session[Webutil.CurrentUser];

            if (currentUser == null) return RedirectToAction("UserLogin", "Login", new { returnUrl = "Advertisement/postAd" });

            // try
            // {
            Advertisement adv = new Advertisement();

            adv.City = new City { Id = Convert.ToInt32(data["City"]) };
            adv.Title = data["AdvTitle"];
            adv.Price = Convert.ToSingle(data["Price"]);
            adv.ValidUpto = Convert.ToDateTime(data["Validity"]);
            adv.SubCategory = new SubCategory { Id = Convert.ToInt32(data["SubCategory"]) };
            adv.Type = new AdType { Id = Convert.ToInt32(data["Adtype"]) };
            adv.Description = data["Description"];
            adv.Status = new AdStatus { Id = 1 };

            adv.isFeatured = Convert.ToBoolean(data["Featured"].Split(',')[0]);
            adv.User = currentUser;
            adv.PostedOn = DateTime.Now;
            long uno = DateTime.Now.Ticks;
            int counter = 0;

            foreach (string fcName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fcName];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    string url = "/img/adv/" + $"{ uno}_{ ++counter}" + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    string path = Request.MapPath(url);

                    adv.Images.Add(new AdImage { Url = url, Priority = counter });
                    file.SaveAs(path);
                }

            }

            new AdvertisementHandler().Add(adv);
            return RedirectToAction("postAd");
            //TempData.Add("AlertMessage", new AlertModel("Congratulations", AlertType.Success));
        }


        // catch(Exception ex)
        //{
        //  TempData.Add("AlertMessage", new AlertModel("Failed To add", AlertType.error));
        //}
         
    

    }
}