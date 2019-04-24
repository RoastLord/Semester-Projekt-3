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
        private string CREATE_CUSTOMER = "INSERT INTO Customer (pe_id) VALUES (@pe_id)";
        private string GET_CUSTOMER = "SELECT * FROM Person JOIN Customer ON Person.id = Customer.pe_id WHERE Person.PhoneNo = @PhoneNo";
        private string GET_CITY_BY_ZIPCODE = "SELECT * From ZipCity WHERE zipcode = @zipcode";

        public DBCustomer()
        {
            dBConnection = new DBConnection();
        }

        public Customer Get(string phoneNo)
        {
            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(GET_CUSTOMER, con);
                cmd.Parameters.AddWithValue("PhoneNo", phoneNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customer customer = new Customer()
                    {
                        Name = dr.GetString("name"),
                        Address = dr.GetString("address"),
                        PhoneNo = dr.GetString("phoneNo"),
                        Email = dr.GetString("email"),
                        Zipcode = dr.GetInt("zipcode"),

                    };
                    customer.City = GetCityByZipCode(customer.Zipcode);
                    return customer;
                }
            }
            return null;
        }

        public string GetCityByZipCode(int zipcode)
        {
            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(GET_CITY_BY_ZIPCODE, con);
                cmd.Parameters.AddWithValue("zipcode", zipcode);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string city = dr.GetString("city");
                    return city;
                }

            }
            return null;

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

                SqlCommand cmd2 = new SqlCommand(CREATE_CUSTOMER, con);
                cmd2.AddMultipleWithValue(new Dictionary<string, object>()
                        {
                            {"pe_id",          tempId },
                        });
                cmd2.ExecuteWithIdentity();
            }
        }
    }
}
