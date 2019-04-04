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
            user = user.validateUser(Username, Password);

            if (user.UserId != 0)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.FirstName;
                Session["Sessionid"] = Guid.NewGuid().ToString();

                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData["ErrorMessage"] = "true";
                return RedirectToAction("Index", "Login");
            }           
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            Session["UserName"] = null;

            return RedirectToAction("Index", "Product");
        }
    }
}