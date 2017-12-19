using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc1.Models
{
    public class USerModel
    {
        public string LoginId { get; set; }
        public int Password { get; set; }
        public string FullName { get; set; }

        public Nullable< DateTime> DateofBirth { get; set; }

        public string Mail { get; set; }


    }
}