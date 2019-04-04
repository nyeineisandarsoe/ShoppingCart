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
            int user_id = 0;
            string username = "";

            List<User> user_info = new List<User>();

            User user = new User();

            user_info = user.validateUser(Username, Password);

            foreach (var info in user_info)
            {
                user_id = info.UserId;
                username = info.UserName;
            }

            if (user_id != 0)
            {
                Session["UserId"] = user_id;
                Session["UserName"] = username;

                return RedirectToAction("Index", "Product");
            }

            return RedirectToAction("Index", "Login");           
        }

        public ActionResult Logout(string sessionId)
        {
            Session["sessionId"] = null;

            return RedirectToAction("Index", "Login");
        }

        public ActionResult InvalidUser()
        {
            return View();
        }
    }
}