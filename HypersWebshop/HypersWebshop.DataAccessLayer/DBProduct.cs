using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HypersWebshop.DataAccessLayer
{
    public class DBProduct
    {
        DBConnection dBConnection;
        private string CREATE_PRODUCT = "INSERT INTO Product VALUES (@Description, @Status, @Price, @PurchasePrice, @AmountInStock";

        public DBProduct()
        {
            dBConnection = new DBConnection();
        }

        public void CreateProduct(Product product)
        {
            int returnValue = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(CREATE_PRODUCT, con);
                        command.Parameters.AddWithValue("Description", product.ProductDescription);
                        command.Parameters.AddWithValue("Status", product.ProductStatus);
                        command.Parameters.AddWithValue("Price", product.Price);
                        command.Parameters.AddWithValue("PurchasePrice", product.PurchasePrice);
                        command.Parameters.AddWithValue("AmountInStock", product.AmountInStock);

                        //Hvis returnValue > 0 er der sket en ændring
                        returnValue = command.ExecuteNonQuery();
                        Console.WriteLine(returnValue);
                    }
                    scope.Complete();
                }
                Console.WriteLine("Connection is now " + dBConnection.connection.State);
            }
            catch (TransactionAbortedException)
            {
            }
        }


        //public void DbAction(Action<SqlCommand> action)
        //{
        //    using (SqlConnection con = dBConnection.OpenConnection())
        //    using (var comm = con.CreateCommand())
        //    {
        //        action(comm);
        //        con.Close();
        //    }
        //}
    }
}
