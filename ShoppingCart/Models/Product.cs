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

        public List<Product> ProductCart(string CartSession)
        {
            List<Product> products = new List<Product>();

            string sql = "SELECT * FROM Product WHERE ProductId In (" + CartSession + ")";
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

        public List<Product> SearchProductByKeyword(string keyword)
        {
            List<Product> products = new List<Product>();

            string sql1 = "SELECT * FROM Product WHERE ProductName LIKE '%" + keyword + "%';";
            string sql2 = "SELECT * FROM Product WHERE Description LIKE '%" + keyword + "%';";


            SqlConnection con = GetConnection();

            using (con)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataReader data1 = cmd1.ExecuteReader();
                if (data1.HasRows)
                {
                    while (data1.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(data1["ProductId"]),
                            ProductName = data1["ProductName"].ToString(),
                            Price = Convert.ToDouble(data1["Price"]),
                            Description = data1["Description"].ToString(),
                            Image = data1["Image"].ToString()
                        });
                    }
                }
                data1.Close();

                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataReader data2 = cmd2.ExecuteReader();
                if (data2.HasRows)
                {
                    while (data2.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(data2["ProductId"]),
                            ProductName = data2["ProductName"].ToString(),
                            Price = Convert.ToDouble(data2["Price"]),
                            Description = data2["Description"].ToString(),
                            Image = data2["Image"].ToString()
                        });
                    }
                }
                data2.Close();
            }
            return products;
        }

        public Product GetbyId(int ProductId)
        {
            Product product = new Product();
            string sql = @"Select ProductName, Description, Price, Image 
                        from Product
                        Where ProductID =" + ProductId;
            SqlConnection con = GetConnection();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    data.Read();
                    product.ProductName = data["ProductName"].ToString();
                    product.Price = Convert.ToInt32(data["Price"]);
                    product.Image = data["Image"].ToString();
                    product.Description = data["Description"].ToString();
                }
            }
            return product;
        }
    }
}