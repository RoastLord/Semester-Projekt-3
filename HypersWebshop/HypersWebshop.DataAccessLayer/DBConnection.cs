using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HypersWebshop.DataAccessLayer
{
    public class DBConnection
    {
        private string _connectionString = "Data Source=.\\SQLExpress;Initial Catalog = CoolShop; Integrated Security = True";
        SqlConnection connection;

        public void OpenConnection()
        {
            connection = new SqlConnection(_connectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void ExecuteQueries(string query)
        {
            OpenConnection();
            //string ps = "insert into Product values ('7gag', 2600);";
            SqlCommand cmd = new SqlCommand(query, connection);
            // cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


    }
}
