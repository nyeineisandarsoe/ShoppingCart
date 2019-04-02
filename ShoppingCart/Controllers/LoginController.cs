using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if ()
            {
                string sessionId = Guid.NewGuid().ToString();
            }
            else
            {
                return RedirectToAction("InvalidUser");
            }
            //verify username and password
            //create session id
            //update session id to database
            //valid redirect to Gallery 

            //invalid redirect to View("Main") with JS error message
        }

        public ActionResult Logout(string sessionId)
        {
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