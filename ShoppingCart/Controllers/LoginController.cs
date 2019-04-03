using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }

       public ActionResult Authenticate(string Username, string Password)
        {
            return View();
        }

        public ActionResult Logout(string sessionId)
        {
            Session["sessionId"] = null;
            //clear sessionId
            //clear cart selection

            return View("Main");
        }

        public ActionResult InvalidUser()
        {
            return View();
        }


    }
}