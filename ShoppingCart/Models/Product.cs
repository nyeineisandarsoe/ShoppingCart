using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ShoppingCart.Models
{
    public class Product : DatabaseConnection
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public List<Product> ListAll()
        {
            List<Product> products = new List<Product>();

            string sql = "SELECT * FROM Product";

            SqlConnection con = GetConnection();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    products.Add(new Product {

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