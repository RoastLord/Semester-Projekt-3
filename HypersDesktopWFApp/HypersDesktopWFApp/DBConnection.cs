using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersDesktopWFApp
{
    public class DBConnection
    {
        private string _connectionString = "Data Source=.\\SQLExpress;Initial Catalog = Hypers; Integrated Security = True";
        public SqlConnection connection;

        public SqlConnection OpenConnection()
        {
            connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
