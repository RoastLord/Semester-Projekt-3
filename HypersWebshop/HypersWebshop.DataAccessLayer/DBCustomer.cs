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
    public class DBCustomer
    {
        DBConnection dBConnection;
        private string CREATE_PERSON = "INSERT INTO Person OUTPUT IDENT_CURRENT('Person') VALUES(@name, @address, @phoneNo, @email, @zipcode)";
        private string CREATE_CUSTOMER = "INSERT INTO Customer VALUES (@pe_id, @o_id)";
        //Evt. ON DELETE SET NULL på Order Id???

        public DBCustomer()
        {
            dBConnection = new DBConnection();
        }

        public void Create(Customer customer)
        {

            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(CREATE_PERSON, con);
                cmd.AddMultipleWithValue(new Dictionary<string, object>()
                        {
                            {"name",           customer.Name },
                            {"address",        customer.Address },
                            {"phoneNo",        customer.PhoneNo },
                            {"email",          customer.Email },
                            {"zipcode",        customer.Zipcode },
                        });

                int tempId = cmd.ExecuteWithIdentity();
                Console.WriteLine("ID på Person: " + tempId);
                SqlCommand cmd2 = new SqlCommand(CREATE_CUSTOMER, con);
                cmd2.AddMultipleWithValue(new Dictionary<string, object>()
                        {
                            {"pe_id",          tempId },
                            {"o_id",           null },

                        });
                cmd2.ExecuteWithIdentity();
                


            }
        }


        public void CreateCustomer()
        {
            using (SqlConnection con = dBConnection.OpenConnection())
            {



            }
        }
    }
}
