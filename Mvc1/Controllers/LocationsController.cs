using ClassLibrary1;
using Mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc1.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Provinces(int id)
        {

            DDLModel model = new DDLModel();
            model.Caption = "-select province-";
            model.Name = "Province";
            model.Values = new LocationHandler().GetProvince(new Country { Id = id }).ToselectList();
            return PartialView("~/Views/Shared/DDLlayout.cshtml",model);

        }


        public ActionResult Cities(int id)
        {

            DDLModel model =new DDLModel();
            model.Name = "City";
            model.Caption = "-Select Cities-";
            model.Values = new LocationHandler().GetCities(new province { Id = id }).ToselectList();
            return PartialView("~/Views/Shared/DDLlayout.cshtml",model);
            
        }
    }
}