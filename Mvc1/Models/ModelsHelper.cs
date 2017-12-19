using ClassLibrary1;
using ClassLibrary1.pakad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ClassLibrary1.pakad.Advertisement;

namespace Mvc1.Models
{
    public static class ModelsHelper
    {

        public static List<SelectListItem> ToselectList(this IEnumerable<Ilistable> values)
        {
            List<SelectListItem> temp = new List<SelectListItem>();
            foreach (var c in values)
            {
                temp.Add(new SelectListItem { Text = c.Name, Value = Convert.ToString(c.Id) });

            }
            temp.TrimExcess();
            return temp;

        }



        public static List<AdsumModel> ToselectModelList(this List<Advertisement> values)
        {
            List<AdsumModel> temp = new List<AdsumModel>();
            foreach (var c in values)
            {
                AdsumModel m = new AdsumModel();
                m.Id = c.Id;
                m.Title = c.Title;
                m.Price = c.Price;


                m.ImageUrl = (c.Images.Count > 0) ? c.Images.First().Url : "/images/images.png";
                temp.Add(m);

            }
            temp.TrimExcess();
            return temp;

        }



        public static List<CategoryModel> ToselectCatModelList(this List<Category> values)
        {
            List<CategoryModel> temp = new List<CategoryModel>();
            foreach (var c in values)
            {
                CategoryModel m = new CategoryModel();
                m.Id = c.Id;
                m.Name = c.Name;

                temp.Add(m);

            }
            temp.TrimExcess();
            return temp;

        }


        public static List<StatusModel> ToselectStatusList(this List<AdStatus> values)
        {
            List<StatusModel> temp = new List<StatusModel>();
            foreach (var c in values)
            {
                StatusModel m = new StatusModel();
                m.Id = c.Id;
                m.Name = c.Name;

                temp.Add(m);

            }
            temp.TrimExcess();
            return temp;

        }




        //public static AdsumModel GetAdSumDetail(int id)
        //{
        //    Advertisement m = new AdvertisementHandler().Getadvertisemnt(id);
        //    AdsumModel pdm = new AdsumModel
        //    {
        //        Id = m.Id,
        //        Price = m.Price,
        //        Title = m.Title

        //    };

        //    if (m.Images!=null&&m.Images.Count>0)
        //    {
        //        foreach (var img in m.Images)
        //        {
        //            pdm.ImageUrl.Add(img.Url);
        //        }
        //    }
        //    return pdm;
        //}



    }
}