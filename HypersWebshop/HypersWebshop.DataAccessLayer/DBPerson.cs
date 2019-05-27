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
    public class DBPerson
    {
        DBConnection dBConnection = new DBConnection();
        private string CREATE_PERSON = "INSERT INTO Person  OUTPUT IDENT_CURRENT('Person') VALUES(@name, @address, @phoneNo, @email, @zipcode)";
        private string CREATE_CUSTOMER = "INSERT INTO Customer (pe_id) VALUES (@pe_id)";
        // private string GET_CUSTOMER = "SELECT * FROM Person JOIN Customer ON Person.id = Customer.pe_id WHERE Person.PhoneNo = @PhoneNo";
        // private string GET_CITY_BY_ZIPCODE = "SELECT * From ZipCity WHERE zipcode = @zipcode";
        private string ADD_ORDER_TO_CUSTOMER = "UPDATE Customer SET o_id = @o_id FROM Person WHERE Customer.pe_id = Person.id AND Person.phoneNo = @PhoneNo";



        public void CreateCustomer(Customer customer)
        {
            int tempId = -1;
            try
            {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand cmd = new SqlCommand(CREATE_PERSON, con);
                        cmd.AddMultipleWithValue(new Dictionary<string, object>()
                        {
                            {"@name",           customer.Name },
                            {"@address",        customer.Address },
                            {"@phoneNo",        customer.PhoneNo },
                            {"@email",          customer.Email },
                            {"@zipcode",        customer.Zipcode }
                        });
                        tempId = cmd.ExecuteWithIdentity();

                        SqlCommand cmd2 = new SqlCommand(CREATE_CUSTOMER, con);
                        cmd2.Parameters.AddWithValue("pe_id", tempId);
                        cmd2.ExecuteNonQuery();
                    }
            }
            catch(TransactionAbortedException)
            {
            }
        }

        public void AddOrderToCustomer(int orderId, Customer customer)
        {
            try
            {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand cmd = new SqlCommand(ADD_ORDER_TO_CUSTOMER, con);
                        cmd.AddMultipleWithValue(new Dictionary<string, object>()
                        {
                            {"o_id",            orderId },
                            {"@phoneNo",        customer.PhoneNo },
                        });
                        cmd.ExecuteNonQuery();
                    }
            }
            catch(TransactionAbortedException)
            {
            }
        }

        //public Customer FindCustomer(string phoneNo)
        //{
        //    try
        //    {
        //        using (SqlConnection con = dBConnection.OpenConnection())
        //        {
        //            SqlCommand cmd = new SqlCommand(GET_CUSTOMER, con);
        //            cmd.Parameters.AddWithValue("PhoneNo", phoneNo);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                Customer customer = new Customer()
        //                {
        //                    Name = dr.GetString("name"),
        //                    Address = dr.GetString("address"),
        //                    PhoneNo = dr.GetString("phoneNo"),
        //                    Email = dr.GetString("email"),
        //                    Zipcode = dr.GetInt("zipcode"),

        //                };
        //                customer.City = GetCityByZipCode(customer.Zipcode);
        //                return customer;
        //            }
        //        }
        //    }
        //    catch(TransactionAbortedException)
        //    {
        //    }
        //    return null;
        //}

        //public string GetCityByZipCode(int zipcode)
        //{
        //    string city = "";
        //    try
        //    {
        //        using (SqlConnection con = dBConnection.OpenConnection())
        //        {
        //            SqlCommand cmd = new SqlCommand(GET_CITY_BY_ZIPCODE, con);
        //            cmd.Parameters.AddWithValue("zipcode", zipcode);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                city = dr.GetString("city");

        //            }
        //        }
        //        return city;
        //    }
        //    catch(TransactionAbortedException)
        //    {
        //    }
        //    return null;
        //}
    }
}