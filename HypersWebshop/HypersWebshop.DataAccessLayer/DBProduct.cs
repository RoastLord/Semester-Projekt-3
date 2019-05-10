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

        // I querien "CREATE_PRODUCT" bliver der kaldt en "OUTPUT IDENT_CURRENT" query, som returnerer ID'et på produktet.
        private string CREATE_PRODUCT = "INSERT INTO Product OUTPUT IDENT_CURRENT('Product') VALUES (@Name, @Price, @PurchasePrice, @Description, @Status)";
        private string FIND_PRODUCT_BY_ID = "SELECT * FROM Product WHERE id = (@id)";
        private string DELETE_PRODUCT = "DELETE FROM Product WHERE ID = (@id)";
        private string FIND_PRODUCTS_BY_DESCRIPTION = "SELECT * from Product WHERE description = @description";
        private string FIND_PRODUCTS_BY_STATUS = "SELECT * from Product WHERE status = @status";
        private string UPDATE_PRODUCT = "UPDATE Product SET name = @name, " +
                                        " price = @price, purchasePrice = @PurchasePrice, " +
                                        "description = @description, status = @status WHERE id = @id;";
        public DBProduct()
        {
            dBConnection = new DBConnection();
        }


        public int Create(Product entity)
        {
            int productId = -1;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(CREATE_PRODUCT, con);
                        command.AddMultipleWithValue(new Dictionary<string, object>() {
                                { "name",           entity.Name },
                                { "price",          entity.Price },
                                { "purchasePrice",  entity.PurchasePrice },
                                { "description",    entity.ProductDescription },
                                { "status",         entity.ProductStatus },
                        });
                        productId = command.ExecuteWithIdentity();
                    }
                    scope.Complete();

                }
            }
            catch (TransactionAbortedException)
            {
            }
            return productId;
        }

        // Skal evt ikke bruges
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
            }
            catch (TransactionAbortedException)
            {
            }
        }

        public Product FindProduct(int id)
        {
            Product product;
            using (SqlConnection con = dBConnection.OpenConnection())
            {

                SqlCommand command = new SqlCommand(FIND_PRODUCT_BY_ID, con);
                command.Parameters.AddWithValue("id", id);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    product = new Product()
                    {
                        ProductId = dr.GetInt("id"),
                        Name = dr.GetString("name"),
                        Price = dr.GetLong("price"),
                        PurchasePrice = dr.GetLong("purchasePrice"),
                        ProductDescription = (Product_Description)dr.GetInt("description"),
                        ProductStatus = (Product_Status)dr.GetInt("status")
                    };
                    return product;
                }
            }
            return null;
        }

            public IEnumerable<Product> FindByDescription(Enum productDescription)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(FIND_PRODUCTS_BY_DESCRIPTION, con);
                        command.Parameters.AddWithValue("description", productDescription);
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            Product product = new Product()
                            {
                                ProductId = dr.GetInt("id"),
                                Name = dr.GetString("name"),
                                Price = dr.GetLong("price"),
                                PurchasePrice = dr.GetLong("purchasePrice"),
                                ProductDescription = (Product_Description)dr.GetInt("description"),
                                ProductStatus = (Product_Status)dr.GetInt("status")

                            };
                            products.Add(product);
                            return products;
                        }
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
            }
            return null;

        public List<Product> FindByStatus(Enum productStatus)
        {
            List<Product> productList = new List<Product>();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.connection)
                    {
                        SqlCommand sqlCommand = new SqlCommand(FIND_PRODUCTS_BY_STATUS, con);
                        sqlCommand.Parameters.AddWithValue("status", productStatus);
                        SqlDataReader dr = sqlCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            Product product = new Product()
                            {
                                ProductId = dr.GetInt("id"),
                                Name = dr.GetString("name"),
                                Price = dr.GetLong("price"),
                                PurchasePrice = dr.GetLong("purchasePrice"),
                                ProductDescription = (Product_Description)dr.GetInt("productDescription"),
                                ProductStatus = (Product_Status)dr.GetInt("productStatus")
                            };
                            productList.Add(product);
                        }
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
            }
            return productList;
        }

        public int Update(Product product)
        {
            int NoOfRowsAffected = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        SqlCommand command = new SqlCommand(UPDATE_PRODUCT, con);
                        Console.WriteLine("Pris Fra dBProduct: " + product.Price);
                        Console.WriteLine(product.ProductId);
                        command.AddMultipleWithValue(new Dictionary<string, object>() {
                                { "name",           product.Name },
                                { "price",          product.Price },
                                { "PurchasePrice",  product.PurchasePrice },
                                { "description",    product.ProductDescription },
                                { "status",         product.ProductStatus },
                                { "id",             product.ProductId },
                        });
                        //Kan evt returneres så man kan se hvor mange elementer der er blevet opdateret.
                        NoOfRowsAffected = command.ExecuteNonQuery();
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException tae)
            {
                Console.WriteLine(tae.Message);
            }
            return NoOfRowsAffected;
        }

    }
}
