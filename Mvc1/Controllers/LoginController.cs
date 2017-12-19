using ClassLibrary1;
using ClassLibrary1.user;
using Mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult UserLogin() {

            ViewBag.Query = Request.QueryString["returnurl"];
            HttpCookie myCookie = Request.Cookies[Webutil.USerCookie];
            if (myCookie!=null)
            {
                myCookie.Expires = DateTime.Today.AddDays(7);
                HttpContext.Response.Cookies.Add(myCookie);
                string[] data = myCookie.Value.Split(',');
                User user = new Userhandler().Getuser(data[0], data[1]);
                if (user!=null)
                {
                    Session.Add(Webutil.CurrentUser, user);
                    if (user.IsInRole(Webutil.AdminRole))
                    {
                        return RedirectToAction("Admin", "Home");
                    }
                    return RedirectToAction("Home", "Index");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(LoginModel model)
        {
            User user = new Userhandler().Getuser(model.LoginId, model.Password);
            if (user != null)
            {
                Session.Add(Webutil.CurrentUser, user);

                if (model.RememberMe)
                {
                    if (Request.Browser.Cookies)
                    {
                        HttpCookie c = new HttpCookie(Webutil.USerCookie);
                        c.Expires = DateTime.Today.AddDays(7);
                        c.Value = $"{user.LoginId},{user.Password}";
                        
                        HttpContext.Response.Cookies.Add(c);
                    }
                }

                string temp = Request.QueryString["returnurl"];
                if (user.IsInRole(Webutil.AdminRole))
                {
                    if (!string.IsNullOrWhiteSpace(temp))
                    {
                        string[] parts = temp.Split('/');
                        RedirectToAction(parts[1], parts[0]);
                    }

                    return RedirectToAction("Admin", "Home");
                }


                if (!string.IsNullOrWhiteSpace(temp))
                {
                    string[] parts = temp.Split('/');
                    RedirectToAction(parts[1], parts[0]);
                }

                return RedirectToAction("Index", "Home");







            }

           
            return View();
        }

        [HttpGet]
        public new ActionResult Profile()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpCookie myCookie = Request.Cookies[Webutil.USerCookie];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now;
                Response.SetCookie(myCookie);
            }


            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }


        public ActionResult Signup(FormCollection data)
        {

            User usr = new User();

            usr.LoginId = data["LoginId"];
            usr.Password = data["Password"];
            usr.FullName = data["FullName"];
            usr.BirthDate =Convert.ToDateTime( data["DoB"]);
            usr.Email = data["Mail"];
            usr.Role = new Role { Id = Webutil.AdminRole };
            usr.Address = new Address { Id = 1 };
            


            new Userhandler().Add(usr);



            return RedirectToAction("UserLogin");
        }






    }
}