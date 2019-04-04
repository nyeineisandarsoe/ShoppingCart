using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ShoppingCart.Models
{
    public class PurchaseProduct : DatabaseConnection
    {
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Total { get; set; }
        public string ActivationCode { get; set; }
        public string PurchaseDate { get; set; }

        public List<PurchaseProduct> ListAll(int UserId)
        {
            List<PurchaseProduct> product = new List<PurchaseProduct>();

            string SqlProduct = @"SELECT Product.*, Purchase.*, PurchaseProductActivation.*
                                    FROM Product, Purchase, PurchaseProductActivation
                                    WHERE Product.ProductId = PurchaseProductActivation.ProductId" +
                                    @" AND PurchaseProductActivation.PurchaseId=Purchase.PurchaseId" +
                                    @" AND Purchase.UserId =" + UserId;
            SqlConnection con = GetConnection();
            using (con)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(SqlProduct, con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product.Add(new PurchaseProduct
                    {
                        ProductName = (reader["ProductName"]).ToString(),
                        Description = (reader["Description"]).ToString(),
                        Image = (reader["Image"]).ToString(),
                        //Quantity = 1,
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        PurchaseDate = reader["PurchaseDate"].ToString(),
                        ActivationCode = reader["ActivationCode"].ToString()

                    });
                }

            }
            return product;
        } 
    }  
    
}