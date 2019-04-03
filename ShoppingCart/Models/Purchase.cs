using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Purchase: DatabaseConnection
    {
        public int PurchaseId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public List<int> GetPurchaseIdsbyUsername(string Username)
        {
            List<Int32> purchaseIdList = new List<Int32>();

            SqlConnection conn = GetConnection();
            using (conn)
            {
                conn.Open();
                string sqlStatement = @"Select PurchaseId
                                            From Purchase
                                                where UserName =  " + Username;
                SqlCommand Cmd = new SqlCommand(sqlStatement, conn);
                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    int purchaseId = (int)Reader["PurchaseId"];
                    purchaseIdList.Add(purchaseId);
                }

                return purchaseIdList;
            }

        }
    }
}