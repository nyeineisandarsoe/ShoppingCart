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

        public List<PurchaseProduct> ProductDetailByPurchaseID(int PurchaseId)
        {
            List<PurchaseProduct> product = new List<PurchaseProduct>();

            string SqlProduct = @"SELECT Product.ProductName, Product.Description, Product.Image, PurchaseProduct.Quantity, 
                                    PurchaseProduct.Quantity*Product.Price as Total, Purchase.PurchaseDate, PurchaseProductActivation.ActivationCode
                                    FROM Product, PurchaseProduct, Purchase, PurchaseProductActivation
                                    WHERE pp.PurchaseId = " + PurchaseId +
                                    @" AND Product.ProductId = PurchaseProduct.ProductId" +
                                    @" AND PurchaseProduct.PurchaseId=Purchase.PurchaseId" +
                                    @" AND PurchaseProduct.PurchaseId = PurchaseProductActivation.PurchaseId" +
                                    @" AND Product.ProductId=PurchaseProductActivation.ProductId";
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
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Total = Convert.ToDouble(reader["Total"])
                   
                        
                    });
                }

            }

            return product;
        }

    }
    
    
}