using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HypersWebshop.DataAccessLayer
{
    public class DBOrder
    {

        DBConnection dBConnection;

        private string CREATE_ORDER = "INSERT INTO SalesOrder OUTPUT IDENT_CURRENT('SalesOrder') VALUES (@totalPrice, @date, @deliveryDate)";
        private string CREATE_ORDERLINE = "INSERT INTO orderLine VALUES(@o_id, @pr_id)";
        private string FIND_ORDER = "SELECT * FROM SalesOrder INNER JOIN Customer ON SalesOrder.id = Customer.o_id" +
                                    " INNER JOIN Person ON Customer.pe_id = Person.id" +
                                    " WHERE SalesOrder.id = @orderNo";
        private string REMOVE_ALL_PRODUCTS_FROM_ORDER = "DELETE FROM OrderLine WHERE o_id = @o_id";
        private string REMOVE_PRODUCT = "DELETE FROM OrderLine WHERE o_id = (@o_id) AND pr_id = (@pr_id)";
        private string FIND_ORDERLINES = "SELECT * FROM OrderLine WHERE o_id = (@o_id)";
        public DBOrder()
        {
            dBConnection = new DBConnection();
        }

        public int CreateOrder(Order order)
        {
            int orderNo = -1;

            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand(CREATE_ORDER, con);
                command.Parameters.AddWithValue("totalPrice", order.TotalPrice);
                command.Parameters.AddWithValue("@date", order.Date);
                command.Parameters.AddWithValue("@deliveryDate", order.DeliveryDate);
                orderNo = command.ExecuteWithIdentity();
            }

            return orderNo;
        }

        public void CreateOrderline(int orderNo, OrderLine orderLine)
        {
            try
            {
                using (SqlConnection con = dBConnection.OpenConnection())
                {
                    SqlCommand command = new SqlCommand(CREATE_ORDERLINE, con);
                    command.AddMultipleWithValue(new Dictionary<string, object>()
                    {
                        { "o_id", orderNo },
                        {"pr_id", orderLine.Product.ProductId },
                    });
                    command.ExecuteNonQuery();

                }
            }
            catch(SqlException e)
            {
                throw e;
            }
        }
        public List<OrderLine> FindOrderLines(int orderNo)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand(FIND_ORDERLINES, con);
                command.Parameters.AddWithValue("o_id", orderNo);
                SqlDataReader dr = command.ExecuteReader();
                DBProduct dBProduct = new DBProduct();
                while (dr.Read())
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.Product = dBProduct.FindProduct(dr.GetInt("pr_id"));
                    orderLines.Add(orderLine);
                }

            }
            return orderLines;
        }
        public int RemoveAllProductsFromOrder(int orderNo)
            {
                int NumberOfRowsAffected = 0;
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        using (SqlConnection con = dBConnection.OpenConnection())
                        {
                            SqlCommand command = new SqlCommand(REMOVE_ALL_PRODUCTS_FROM_ORDER, con);
                            command.Parameters.AddWithValue("o_id", orderNo);
                            //Evt returner for at vise den er slettet
                            NumberOfRowsAffected = command.ExecuteNonQuery();
                        }
                        scope.Complete();
                    }
                }
                catch (TransactionAbortedException)
                {

                }
                return NumberOfRowsAffected;
            }
        
        public Order FindOrder(int orderNo)
        {
            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand(FIND_ORDER, con);
                command.Parameters.AddWithValue("orderNo", orderNo);
                SqlDataReader dr = command.ExecuteReader();
                DBPerson dBCustomer = new DBPerson();
                while (dr.Read())
                {
                    Order order = new Order(
                        dr.GetInt("id"),
                        dr.GetLong("totalPrice"),
                        dr.GetDateTime("date"),
                        dr.GetDateTime("deliveryDate"),
                        dBCustomer.FindCustomer(dr.GetString("phoneNo"))
                        );
                    return order;
                    // dr.GetDateTime("date"),
                    //dr.GetDateTime("deliveryDate"),
                }

            }
            return null;
        }
        public int RemoveProductFromOrder(int orderNo, int productID)
        {
            int NumberOfRowsAffected = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(REMOVE_PRODUCT, con);
                        command.AddMultipleWithValue(new Dictionary<string, object>(){
                            {"o_id", orderNo},
                            {"pr_id", productID}
                        });
                        //Evt returner for at vise den er slettet
                        NumberOfRowsAffected = command.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {

            }
            return NumberOfRowsAffected;
        }
    }

}
