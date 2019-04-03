using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ShoppingCart.Models
{
    public class PurchaseProductActivation : DatabaseConnection
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public string ActivitionCode { get; set; }

        public int CreatePurchaseProductActivation(int MaxId, int ProductId)
        {
            string ActivitionCode = System.Guid.NewGuid().ToString();
            List<Purchase> purchases = new List<Purchase>();
            string sql = "Insert Into PurchaseProductActivation (PurchaseId, ProductId, ActivationCode) Values ("+ MaxId + ", "+ ProductId +", '"+ ActivitionCode +"' );";
            SqlConnection con = GetConnection();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}