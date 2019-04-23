using System.Collections.Generic;
using System.Data.SqlClient;

namespace HypersWebshop.DataAccessLayer
{
    public static class SqlExtensions
    {
        //Extension metode til at tilføje flere parametre ad gangen.
        public static void AddMultipleWithValue(this SqlCommand command, IDictionary<string, object> values)
        {
            foreach (var val in values)
            {
                command.Parameters.AddWithValue(val.Key, val.Value);
            }
        }

        //Extension metode til at returnere ID'et på objektet man kalder med SqlCommand.    
        public static int ExecuteWithIdentity(this SqlCommand cmd)
        {
            int tempID = -1;
            // ?-tegnet stoppet programmet fra at crashe, hvis ExecuteScalar returnerer null.
            int.TryParse(cmd.ExecuteScalar()?.ToString(), out tempID);
            return tempID;
        }

        /* Extension methods for getting data by column name.
         * These extensions wrap the NpgsqlDataReader (aka. ResultSet)
         * in order to allow us to get data by column name, instead of
         * column index.
         * Selecting by column name requires an extra method call, somehow.
         * I dont know why this isn't native. I really should be.
         */
        public static bool GetBoolean(this SqlDataReader dr, string columnName)
        {
            return dr.GetBoolean(dr.GetOrdinal(columnName));
        }

        public static int GetInt(this SqlDataReader dr, string columnName)
        {
            return dr.GetInt32(dr.GetOrdinal(columnName));
        }

        public static long GetLong(this SqlDataReader dr, string columnName)
        {
            return dr.GetInt64(dr.GetOrdinal(columnName));
        }

        public static string GetString(this SqlDataReader dr, string columnName)
        {
            return dr.GetString(dr.GetOrdinal(columnName));
        }
    }
}
