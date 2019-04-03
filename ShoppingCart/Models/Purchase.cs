using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ShoppingCart.Models
{
    public class Purchase : DatabaseConnection
    {
        public int PurchaseId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public int CreatePurchase(int UserId)
        {

            string sql = "Insert Into Purchase (UserId, PurchaseDate) Values ( "+ UserId +", GETDATE());";
            SqlConnection con = GetConnection();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery();
            }
        }

        public int GetMaxId()
        {
            string sql = "Select Max(PurchaseId) as MaxId FROM Purchase;";
            SqlConnection con = GetConnection();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader data = cmd.ExecuteReader();
                data.Read();
                int MaxId = Convert.ToInt32(data["MaxId"]);
                return MaxId;
            }
        }
    }
}