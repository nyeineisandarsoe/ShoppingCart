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
    /*
    public class ProductDatabase:DatabaseConnection
    {
        public static Product ProductDetailByProductID(int ProductId)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                connection.Open();
                
                string SqlProduct = @"select p.*, pp.*, p.Price * pp.Quantity as Total
                                    from Product p, PurchaseProduct pp, purchase pu
                                    where p.ProductId = pp.ProductId" + pu
            }
        }
    }*/
}