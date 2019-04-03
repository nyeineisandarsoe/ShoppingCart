using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class PurchaseController : Controller
    {
        
        public ActionResult ViewItem()
        {
            PurchaseProduct purchaseProduct = new PurchaseProduct();

            
            ViewData["PurchasedProduct"] = purchaseProduct.ListAll(1); 
            return View();
        }
    }
}