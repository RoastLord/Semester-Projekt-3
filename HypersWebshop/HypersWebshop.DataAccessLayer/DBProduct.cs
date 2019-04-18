using HypersWebshop.DataAccessLayer.Interfaces;
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
    public static class Util
    {
        // Extension method for SqlCommand, made to prettify ident return
        public static int ExecuteWithIdentity(this SqlCommand cmd)
        {
            int tempID = -1;
            int.TryParse(cmd.ExecuteScalar()?.ToString(), out tempID);
            return tempID;
        }
    }

    public class DBProduct : ICRUD<Product>
    {
        DBConnection dBConnection;
        /* Spacemagic to product key output:
         * 'OUTPUT IDENT_CURRENT('Product')'
         */
        private string CREATE_PRODUCT = "INSERT INTO Product OUTPUT IDENT_CURRENT('Product') VALUES (@Name, @AmountInStock, @Price, @PurchasePrice, @Description, @Status)";
        private string FIND_PRODUCT_BY_ID = "SELECT * FROM Product WHERE id = (@id)";
        private string DELETE_PRODUCT = "DELETE FROM Product WHERE ID = (@id)";
        private string FIND_PRODUCTS_BY_DESCRIPTION = "SELECT * from Product WHERE description = @description";
        private string UPDATE_PRODUCT = "UPDATE Product SET name = @name, amountInStock = @amountInStock," +
                                     " price = @price, purchasePrice = @PurchasePrice, description = @description, status = @status WHERE id = @id;";
        public DBProduct()
        {
            dBConnection = new DBConnection();
        }



        public void Create(Product entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(CREATE_PRODUCT, con);
                        command.Parameters.AddWithValue("Name", entity.Name);
                        command.Parameters.AddWithValue("AmountInStock", entity.AmountInStock);
                        command.Parameters.AddWithValue("Price", entity.Price);
                        command.Parameters.AddWithValue("PurchasePrice", entity.PurchasePrice);
                        command.Parameters.AddWithValue("Description", entity.ProductDescription);
                        command.Parameters.AddWithValue("Status", entity.ProductStatus);

                        // ExecuteScalar sætter alt til 0.. Hvorfor??
                        entity.ProductId = command.ExecuteWithIdentity();
                    }
                    scope.Complete();
                }
                Console.WriteLine("Connection fra Create() er: " + dBConnection.connection.State);
            }
            catch (TransactionAbortedException)
            {
            }
        }

        public void Delete(Product entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(DELETE_PRODUCT, con);
                        command.Parameters.AddWithValue("id", entity.ProductId);
                        command.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
                Console.WriteLine("Connection fra Delete() er: " + dBConnection.connection.State);
            }
            catch (TransactionAbortedException)
            {
            }
        }

        public Product Get(int id)
        {
            using (SqlConnection con = dBConnection.OpenConnection())
            {
                Product product;
                SqlCommand command = new SqlCommand(FIND_PRODUCT_BY_ID, con);
                command.Parameters.AddWithValue("id", id);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    product = new Product()
                    {
                        ProductId = dr.GetInt32(0),
                        Name = dr.GetString(1),
                        AmountInStock = dr.GetInt32(2),
                        Price = dr.GetInt64(3),
                        PurchasePrice = dr.GetInt64(4),
                        ProductDescription = (Product_Description)dr.GetInt32(5),
                        ProductStatus = (Product_Status)dr.GetInt32(6)
                    };
                    return product;
                }
                // Måske yikes kode
                //dBConnection.CloseConnection();
                //Console.WriteLine("Connection fra Get() er:  " + dBConnection.connection.State);
            }
            // Hvordan kan jeg return produktet jeg instanstiere i while loop.
            Product dummy = new Product();
            return dummy;



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
        

        public IEnumerable<Product> GetAll(Enum productDescription)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = dBConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand(FIND_PRODUCTS_BY_DESCRIPTION, con);
                command.Parameters.AddWithValue("description", productDescription);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = dr.GetInt32(0),
                        Name = dr.GetString(1),
                        AmountInStock = dr.GetInt32(2),
                        Price = dr.GetInt64(3),
                        PurchasePrice = dr.GetInt64(4),
                        ProductDescription = (Product_Description)dr.GetInt32(5),
                        ProductStatus = (Product_Status)dr.GetInt32(6)
                        
                    };
                    products.Add(product);
                }
            }
            return products;
        }

        public void Update(Product oldProduct, Product newProduct)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(UPDATE_PRODUCT, con);
                        
                        command.Parameters.AddWithValue("Name", newProduct.Name);
                        command.Parameters.AddWithValue("AmountInStock", newProduct.AmountInStock);
                        command.Parameters.AddWithValue("Price", newProduct.Price);
                        command.Parameters.AddWithValue("PurchasePrice", newProduct.PurchasePrice);
                        command.Parameters.AddWithValue("Description", newProduct.ProductDescription);
                        command.Parameters.AddWithValue("Status", newProduct.ProductStatus);
                        command.Parameters.AddWithValue("id", oldProduct.ProductId);

                        command.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
                Console.WriteLine("Connection fra Update() er: " + dBConnection.connection.State);
            }
            catch (TransactionAbortedException)
            {
            }
        }
    }
}
