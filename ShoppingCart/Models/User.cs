using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class User : DatabaseConnection
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Username is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        public User validateUser(string Username, string Password)
        {
            User user = new User();

            string sql = "SELECT * FROM [User] WHERE UserName = '" + Username + "' AND Password = '" + Password + "'";

            SqlConnection con = GetConnection();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    data.Read();
                    user.UserId = Convert.ToInt32(data["UserId"]);
                    user.UserName = data["UserName"].ToString();
                }
            }

            return user;
        }
    }
}