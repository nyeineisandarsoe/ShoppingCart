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
        public string[] ActivationCode { get; set; }
        public string PurchaseDate { get; set; }

        public List<PurchaseProduct> ListAll(int UserId)
        {
            List<PurchaseProduct> products = new List<PurchaseProduct>();
            string sql = @"Select pa.ProductId, p.PurchaseId, p.PurchaseDate, Count(pa.ProductId) as Quantity 
                        from PurchaseProductActivation pa, Purchase p
                        Where pa.PurchaseId = p.PurchaseId
                        and p.UserId = " + UserId +
                        @"Group By p.PurchaseId, p.PurchaseDate, pa.ProductId
                        Order By p.PurchaseId DESC;";
            SqlConnection con = GetConnection();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime purchasedate = Convert.ToDateTime(reader["PurchaseDate"]);
                    int productid = Convert.ToInt32(reader["ProductId"]);
                    int purchaseid = Convert.ToInt32(reader["PurchaseId"]);

                    Product product = new Product();
                    product = product.GetbyId(productid);

                    PurchaseProductActivation purchaseProductActivation = new PurchaseProductActivation();
                    string activationlist = purchaseProductActivation.GetActivationCode(productid, purchaseid);
                    string[] activations = activationlist.Split(',');
                    Array.Resize(ref activations, activations.Length - 1);
                    products.Add(new PurchaseProduct
                    {
                        PurchaseId = purchaseid,
                        ProductId = productid,
                        ProductName = product.ProductName,
                        Description = product.Description,
                        Image = product.Image,
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        PurchaseDate = purchasedate.ToString("MMMM dd, yyyy"),
                        ActivationCode = activations
                    });
                }
            }
            return products;
        }
    }
}