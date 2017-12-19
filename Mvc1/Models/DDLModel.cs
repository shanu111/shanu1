using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc1.Models
{
    public class DDLModel
    {
        public string Name { get; set; }
        public string Caption { get; set; }

        public string Glypicon { get; set; }

        public List<SelectListItem> Values { get; set; }
    }
}