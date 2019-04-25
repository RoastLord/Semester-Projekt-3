using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.DataAccessLayer
{
    public class DBLogin
    {
        private string GET_PASSWORD_BY_USERNAME = "SELECT phoneNo, password FROM Person WHERE phoneNo = @phoneNo";
        public DBConnection dBConnection;
        public DBLogin()
        {
            dBConnection = new DBConnection();
            
        }

        // VIRKER KUN VED STRING PASSSWORDS. Skal laves om til hashing
        public string GetPassword(string userName)
        {
            using(SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(GET_PASSWORD_BY_USERNAME, con);
                cmd.Parameters.AddWithValue("phoneNo", userName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return dr.GetString("password");
                }
                
        
            }
            return null;
        }
    }
}
