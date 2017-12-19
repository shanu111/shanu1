using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc1.Models
{
    public class AlertModel
    {
        public AlertModel() { }


        public AlertModel(string message,AlertType type)
        {
            switch (type)
            {
                case AlertType.Success:
                    Heading = "Succes";
                    CssClass = "alert-success";
                    break;
                case AlertType.Information:
                    Heading = "Info";
                    CssClass = "alert-info";
                    break;
                case AlertType.error:
                    Heading = "Error";
                    CssClass = "alert-danger";
                    break;
                case AlertType.Warningn:
                    Heading = "Warning";
                    CssClass = "alert-warning";
                    break;
                    
                   
            }

            this.Message = message;
        }

        public string CssClass { get; set; }
        public string Message { get; set; }

        public string Heading { get; set; }
    }





    public enum AlertType
    {
        Success,
        Information,
        error,
        Warningn
    }
}