using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc1.Models
{
    public class LoginModel
    { 
    
        [Required]
        public string LoginId { get; set; }
        [Required]
        public string Password { get; set; }

        public string ContactNumber { get; set; }
        public bool RememberMe { get; set; }

        public bool isFeature { get; set; }
    }
}