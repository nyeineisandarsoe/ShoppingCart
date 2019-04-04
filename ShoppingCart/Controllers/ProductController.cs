using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        ArrayList productIds = new ArrayList();

        public ActionResult Index()
        {
            if(Session["UserId"] != null)
            {
                ViewBag.Auth = "true";
                ViewBag.UserName = Session["UserName"];
            }
            Product product = new Product();
            ViewData["ProductData"] = product.ListAll();
            return View();
        }

        public ActionResult AddtoCart(string productId)
        {
            if (Session["ProductIds"] != null)
            {
                productIds = (ArrayList)Session["ProductIds"];
            }

            productIds.Add(productId);

            Session["ProductIds"] = productIds;

            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            Product product = new Product();
            ViewData["Products"] = product.SearchProductByKeyword(Request["search"]);
            return View();
        }
    }
}