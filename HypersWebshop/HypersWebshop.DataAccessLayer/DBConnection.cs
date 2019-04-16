using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HypersWebshop.DataAccessLayer
{
    public class DBConnection
    {
        private string _connectionString = "Data Source=.\\SQLExpress;Initial Catalog = Hypers; Integrated Security = True";
        public SqlConnection connection;

        public DBConnection()
        {

        }

        public SqlConnection OpenConnection()
        {
            connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                Console.WriteLine("Connection er nu " + connection.State);
            }
            return connection;
        }


        public void CloseConnection()
        {
            connection.Close();
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

    }
}
