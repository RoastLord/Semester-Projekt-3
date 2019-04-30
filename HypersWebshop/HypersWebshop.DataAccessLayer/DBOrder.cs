using HypersWebshop.DataAccessLayer.Interfaces;
using HypersWebshop.Domain;
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
    public class DBOrder : ICRUD<Order>
    {

        DBConnection dBConnection;

        private string CREATE_ORDER = "INSERT INTO salesOrder OUTPUT IDENT_CURRENT('salesOrder') VALUES (@totalPrice, @date, @deliveryDate)";
        private string CREATE_ORDERLINE = "INSERT INTO orderLine OUTPUT IDENT_CURRENT('orderLine') VALUES(@price, @amount, @o_id, @pr_id)";
        private string GET_ORDER = "SELECT * FROM SalesOrder INNER JOIN Customer ON SalesOrder.id = Customer.o_id" +
            " INNER JOIN Person ON Customer.pe_id = Person.id" +
            " WHERE SalesOrder.OrderNo = @OrderNo";
        private string REMOVE_PRODUCT = "DELETE FROM OrderLine WHERE o_id = (@o_id) AND pr_id = (@pr_id)";
        private string GET_ORDERLINES = "SELECT * FROM OrderLine WHERE o_id = (@o_id)";
        public DBOrder()
        {
            dBConnection = new DBConnection();
        }

        public void Create(Order entity)
        {

            try
            {
                using (SqlConnection con = dBConnection.OpenConnection())
                {
                    SqlCommand command = new SqlCommand(CREATE_ORDER, con);
                    command.Parameters.AddWithValue("totalPrice", entity.TotalPrice);
                    command.Parameters.AddWithValue("date", entity.Date);
                    command.Parameters.AddWithValue("deliveryDate", entity.DeliveryDate);

                    entity.OrderNo = command.ExecuteWithIdentity();
                }
            }
            catch
            {
                throw OrderCreationException();
            }
        }

        private Exception OrderCreationException()
        {
            //TODO
            throw new NotImplementedException();
        }
        public void CreateOrderline(Product product, Order order, int amount)
        {
            try
            {
                using (SqlConnection con = dBConnection.OpenConnection())
                {
                    SqlCommand command = new SqlCommand(CREATE_ORDERLINE, con);
                    command.AddMultipleWithValue(new Dictionary<string, object>()
                    {
                        { "o_id", order.OrderNo },
                        {"pr_id", product.ProductId },
                        {"price", product.Price },
                        {"amount", amount }
                    });
                    command.ExecuteNonQuery();

                }
            }
            catch
            {
                throw OrderLineCreationException();
            }
        }
        //skal flydtes over i exception class
        private Exception OrderLineCreationException()
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }
        public OrderLine GetOrderLine(int o_id)
        {
            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand(GET_ORDERLINES, con);
                command.Parameters.AddWithValue("o_id", o_id);
                SqlDataReader dr = command.ExecuteReader();
                DBProduct dBProduct = new DBProduct();
                while (dr.Read())
                {
                    OrderLine orderLine = new OrderLine(
                        dr.GetInt("amount"),
                        dr.GetLong("price"),
                        dr.GetInt("amount") * dr.GetLong("price"),
                        dBProduct.Get(dr.GetInt("pr_id"))
                        );
                    return orderLine;
                }
                    
            }
            return null;
        }
        public Order Get(int orderNo)
        {
            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand(GET_ORDER, con);
                command.Parameters.AddWithValue("OrderNo", orderNo);
                SqlDataReader dr = command.ExecuteReader();
                DBCustomer dBCustomer = new DBCustomer();
                while (dr.Read())
                {
                    Order order = new Order(
                        dr.GetInt("id"),
                        dr.GetLong("totalPrice"),
                        dr.GetDateTime("date"),
                        dr.GetDateTime("deliveryDate"),
                        dBCustomer.Get(dr.GetString("phoneNo"))
                        );
                    return order;
                }

            }
            return null;
        }
        public void RemoveProduct(int orderNo, int productID)
        {
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
                        int numberOfRows = command.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
            }
            catch(TransactionAbortedException)
            {

            }
        }

        public IEnumerable<Order> GetAll(Enum productDescription)
            {
                throw new NotImplementedException();
            }

            public void Update(Order entity)
            {
                throw new NotImplementedException();
            }
        }

    }
