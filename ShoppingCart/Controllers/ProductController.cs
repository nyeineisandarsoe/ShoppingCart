using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            Product product = new Product();
            ViewData["ProductData"] = product.ListAll();
            return View();
        }

        public ActionResult Search()
        {
            Product product = new Product();
            ViewData["ProductsByName"] = product.ListProductByName(Request["search"]);
            return View();
        }
    }
}