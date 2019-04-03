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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<User> validateUser(string Username, string Password)
        {
            List<User> user_info = new List<User>();

            string sql = "SELECT * FROM [User] WHERE UserName = '" + Username + "' AND Password = '" + Password + "'";

            SqlConnection con = GetConnection();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    user_info.Add(new User
                    {
                        UserId = Convert.ToInt32(data["UserId"]),
                        UserName = data["UserName"].ToString()
                    });
                }
            }

            return user_info;
        }
    }
}