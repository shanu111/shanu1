using ClassLibrary1.pakad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ClassLibrary1.pakad.Advertisement;

namespace Mvc1.Models
{
    public class AdsumModel
    {
        public enum AdvertisementStatus
        {
            Pending=1, Approved=2, Disabled=3
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public string ImageUrl { get; set; }
        public AdStatus status { get; set; }


    }
}