using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Filters;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.Auth = "true";
                ViewBag.UserName = Session["UserName"];
            }

            Product product = new Product();

            ArrayList productIds = (ArrayList)Session["ProductIds"];


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
                        productList += productIds[i - 1] + ",";
                    }
                }
            }


            if (productList != "")
            {
                string[] productIdList = productList.Split(',');

                var dict = new Dictionary<string, int>();

                foreach (var value in productIdList)
                {
                    if (dict.ContainsKey(value))
                        dict[value]++;
                    else
                        dict[value] = 1;
                }

                ViewData["Quantity"] = dict;
                ViewData["ProductCart"] = product.ProductCart(productList);

            }
            return View();
        }

        public ActionResult removeItem(string productid)
        {
            ArrayList productIds = (ArrayList)Session["ProductIds"];

            for (int i = 0; i < productIds.Count; i++)
            {
                productIds.Remove(productid);
            }

            Session["ProductIds"] = productIds;

            return RedirectToAction("Index");
        }

        public ActionResult addQuantity(string productid, int quantity)
        {
            ArrayList productIds = (ArrayList)Session["ProductIds"];

            productIds.Add(productid);

            Session["ProductIds"] = productIds;

            return RedirectToAction("Index");
        }

        public ActionResult reduceQuantity(string productid, int quantity)
        {
            ArrayList productIds = (ArrayList)Session["ProductIds"];

            productIds.Remove(productid);

            Session["ProductIds"] = productIds;

            return RedirectToAction("Index");
        }

        [AuthenticationFilter]
        public ActionResult Checkout(string CartSession)
        {
            ArrayList productIds = (ArrayList)Session["ProductIds"];
            string[] array = productIds.ToArray(typeof(string)) as string[];
            int[] productids = Array.ConvertAll(array, s => int.Parse(s));

            int userid = Convert.ToInt32(Session["UserId"]);
            Purchase purchase = new Purchase();
            int rowsAffected = purchase.CreatePurchase(userid);
            if (rowsAffected >= 1)
            {
                PurchaseProductActivation purchaseproductati = new PurchaseProductActivation();
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