using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult ViewItem()
        {


            ViewData[""] = ;
            ViewData[""] = ;
            ViewData[""] = ;


            return View();
        }

        public ActionResult BackToGall()
        {
            return RedirectResult("","Gallery");//Not sure the actionName
        }
    }
}