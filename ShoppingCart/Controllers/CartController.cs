using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Filters;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index(string CartSession)
        {
            if (Session["UserId"] != null)
            {
                ViewBag.Auth = "true";
            }
            Product product = new Product();

            ArrayList productIds = (ArrayList)Session["productIds"];

            string productList = "";

            if (productIds == null)
            {
                productList = "0";
            }
            else
            {
                int totalCount = productIds.Count;
                for (int i = 1; i <= totalCount; i++)
                {
                    if (i == totalCount)
                    {
                        productList += productIds[i - 1];
                    }
                    else
                    {
                        productList += productIds[i - 1] + ", ";
                    }
                }
            }

            ViewData["ProductCart"] = product.ProductCart(productList);
            
            return View();
        }

        [AuthenticationFilter]
        public ActionResult Checkout(string CartSession)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            Purchase purchase = new Purchase();
            int rowsAffected = purchase.CreatePurchase(userid);
            if(rowsAffected >= 1)
            {
                PurchaseProductActivation purchaseproductati = new PurchaseProductActivation();
                CartSession = "2,3";
                string[] pids = CartSession.Split(',');
                int[] productids = pids.Select(int.Parse).ToArray();
                int maxid = purchase.GetMaxId();
                foreach (var productid in productids)
                {
                    rowsAffected += purchaseproductati.CreatePurchaseProductActivation(maxid, productid);
                }
            }
            if (rowsAffected >= 2)
            {
                return RedirectToAction("Index", "Purchase");
            }
            return Content("Something Wrong.");
        }
    }
}