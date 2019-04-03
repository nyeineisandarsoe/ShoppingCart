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

        public bool validateUserbyUsername(string Username, string Password)
        {
            SqlConnection conn = GetConnection();
            using(conn)
            {
                conn.Open();
                string sqlStatement = @"Select Password
                                            From [User]
                                                where UserName =  '" + Username + "'";
                SqlCommand Cmd = new SqlCommand(sqlStatement, conn);
                SqlDataReader Reader = Cmd.ExecuteReader();

                if (Reader.Read())
                {
                    String realPassword = (string)Reader["Password"];
                    if(realPassword == Password)
                    {
                        return true;
                    }
                }

                return false;
            }
            
        }
       
    }
}