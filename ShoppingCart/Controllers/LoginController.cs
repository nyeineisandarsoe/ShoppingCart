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
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Authenticate(string Username, string Password)
        {
            User user = new User();
            bool isValidUser = user.validateUserbyUsername(Username, Password);
            if (isValidUser)
            {
                string sessionId = Guid.NewGuid().ToString();
                Session["sessionId"] = sessionId;
                return RedirectToAction("","", new{Username = @Username});
            }
            else
            {
                return RedirectToAction("InvalidUser");
            }
            
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