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
            ViewBag.UserName = Session["UserName"];
            int userId = Convert.ToInt32(Session["UserId"]);
            ViewData["PurchasedProduct"] = purchaseProduct.ListAll(userId); 
            return View();
        }
    }
}