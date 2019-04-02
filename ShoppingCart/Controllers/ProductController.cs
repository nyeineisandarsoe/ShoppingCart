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
        // GET: Gallery
        public ActionResult Index()
        {
            Product product = new Product();
            ViewBag["ProductData"] = product.ListAll();
            return View();
        }
    }
}