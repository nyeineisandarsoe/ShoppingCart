using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

    }

    public class ProductDatabase:DatabaseConnection
    {
        public static Product ProductDetailByProductID(int ProductId)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                connection.Open();
                
                string SqlProduct = @"SELECT "
            }
        }
    }
}