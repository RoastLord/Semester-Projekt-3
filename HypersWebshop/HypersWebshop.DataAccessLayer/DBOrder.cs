using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HypersWebshop.DataAccessLayer
{
    class DBOrder
    {
        static public int CreateTransactionScope(string connectionString1, string commandText)
        {
            int returnValue = 0;
            //Skal måske ændres!
            System.IO.StringWriter writer = new System.IO.StringWriter();

            try
            {
                using(TransactionScope scope = new TransactionScope())
                {

                    using(SqlConnection connection1 = new SqlConnection(connectionString1))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(commandText, connection1);
                        returnValue = command1.ExecuteNonQuery();
                        writer.WriteLine("Rows to be affected by command1: { 0}", returnValue);

                    }

                    scope.Complete();
                }

            }

            catch (TransactionAbortedException)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}");
            }
            Console.WriteLine(writer.ToString());

            return returnValue;
        }

    }

}
