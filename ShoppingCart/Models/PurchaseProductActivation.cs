using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class PurchaseProductActivation
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public string ActivitionCode { get; set; }
    }
}