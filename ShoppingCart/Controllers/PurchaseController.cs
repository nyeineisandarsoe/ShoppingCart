using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Filters;


namespace ShoppingCart.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult ViewItem()
        {
            return View();
        }

        [ViewPurchaseIdFilter]
        public ActionResult ListPurchaseIds(string Username)
        {
            Purchase purchase = new Purchase();
            List<Int32> purchaseList = purchase.GetPurchaseIdsbyUsername(Username);
            ViewData["purchaseList"] = purchaseList;
            return View();
        }


        public ActionResult BackToGall()
        {
            return View();
        }
    }
}