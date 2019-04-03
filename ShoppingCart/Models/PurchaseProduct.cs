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
        public DateTime PurchaseDate { get; private set; }

        #region Select by ProductId
        /// <summary>
        /// Select by ProductId
        /// </summary>
        /// <param name="PurchaseId"></param>
        /// <returns></returns>
        public List<PurchaseProduct> ProductDetailsPurchaseId(int PurchaseId)
        {
            List<PurchaseProduct> product = new List<PurchaseProduct>();

            string SqlProduct = @"SELECT Product.*, PurchaseProduct.*, 
                                    PurchaseProduct.Quantity*Product.Price as Total, Purchase.*, PurchaseProductActivation.*
                                    FROM Product, PurchaseProduct, Purchase, PurchaseProductActivation
                                    WHERE Purchase.PurchaseId = " + PurchaseId +
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
                        Total = Convert.ToDouble(reader["Total"]),
                        PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]),
                        ActivationCode = reader["ActivationCode"].ToString()

                    });
                }

            }

            return product;
        }
        #endregion

        #region Select All items
        /// <summary>
        /// Select All items
        /// </summary>
        /// <returns></returns>
        public List<PurchaseProduct> ListAll(int UserId)
        {
            List<PurchaseProduct> product = new List<PurchaseProduct>();

            string SqlProduct = @"SELECT Product.*, PurchaseProduct.*, 
                                    PurchaseProduct.Quantity*Product.Price as Total, Purchase.*, PurchaseProductActivation.*
                                    FROM Product, PurchaseProduct, Purchase, PurchaseProductActivation
                                    WHERE Product.ProductId = PurchaseProductActivation.ProductId" +
                                    @" AND PurchaseProductActivation.PurchaseId=Purchase.PurchaseId" +                          
                                    @" AND Product.ProductId=PurchaseProductActivation.ProductId"+
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
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Total = Convert.ToDouble(reader["Total"]),
                        PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]),
                        ActivationCode = reader["ActivationCode"].ToString()

                    });
                }

            }
            return product;
        } 
        #endregion

    }  
    
}