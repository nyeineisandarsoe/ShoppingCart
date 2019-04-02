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

        public List<Product> ProductCart(string CartSession)
        {
            List<Product> products = new List<Product>();
            
            string sql = "SELECT * FROM Product WHERE ProductId In ("+CartSession+")";
            SqlConnection con = GetConnection();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    products.Add(new Product
                    {

                        ProductId = Convert.ToInt32(data["ProductId"]),
                        ProductName = data["ProductName"].ToString(),
                        Price = Convert.ToDouble(data["Price"]),
                        Description = data["Description"].ToString(),
                        Image = data["Image"].ToString()
                    });
                }
            }

            return products;
        }
    }
}