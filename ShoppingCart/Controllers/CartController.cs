using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Product product = new Product();
            string CartSession = "2,3";
            ViewData["ProductCart"] = product.ProductCart(CartSession);
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}