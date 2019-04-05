using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ShoppingCart.Models
{
    public class DatabaseConnection
    {
        private string connection_string = "SERVER=LAPTOP-AFJE04OK; DATABASE=ShoppingCart; Integrated Security=true";

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connection_string);

            return connection; 
        }
    }
}