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
        [AuthenticationFilter]
        public ActionResult Index()
        {
            PurchaseProduct purchaseProduct = new PurchaseProduct();
            ViewBag.Auth = "true";
            ViewData["PurchasedProduct"] = purchaseProduct.ListAll(1); 
            return View();
        }
    }
}