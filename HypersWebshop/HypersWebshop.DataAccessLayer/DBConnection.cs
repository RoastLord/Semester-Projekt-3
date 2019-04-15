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

        public void OpenConnection(String dinEgenConnectionStreng)
        {
            // Her er en kopi af min connection-string. Ændre "CoolShop" til hvad-end jeres egen database hedder, som i tester på
            // "Data Source=.\\SQLExpress;Initial Catalog = CoolShop; Integrated Security = True"
            connection = new SqlConnection(dinEgenConnectionStreng);
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

        public SqlDataReader DataReader(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }


    }
}
