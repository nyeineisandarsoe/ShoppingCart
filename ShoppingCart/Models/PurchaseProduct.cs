using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class PurchaseProduct
    {
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public int Quantity { get; set; }

    }
}