using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HypersWebshop.DataAccessLayer
{

    public class DBProduct
    {
        DBConnection dBConnection;

        // I querien "CREATE_PRODUCT" bliver der kaldt en "OUTPUT IDENT_CURRENT" query, som returnerer ID'et på produktet.
        private string CREATE_PRODUCT = "INSERT INTO Product (name, price, purchaseprice, description, status) OUTPUT IDENT_CURRENT('Product') VALUES (@Name, @Price, @PurchasePrice, @Description, @Status)";
        private string FIND_PRODUCT_BY_ID = "SELECT * FROM Product WHERE id = (@id)";
        private string FIND_PRODUCTS_BY_DESCRIPTION = "SELECT * from Product WHERE description = @description";
        private string FIND_PRODUCTS_BY_STATUS = "SELECT * from Product WHERE status = @status";
        private string GET_ROWID = "Select rowId FROM Product WHERE id = @id";
        private string UPDATE_PRODUCT = "UPDATE Product SET name = @name, " +
                                        " price = @price, purchasePrice = @PurchasePrice, " +
                                        "description = @description, status = @status WHERE rowId = @rowId AND id = @id";
        public DBProduct()
        {
            dBConnection = new DBConnection();
        }


        public int Create(Product entity)
        {
            int productId = -1;
            try
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
            }
            catch (TransactionAbortedException)
            {
            }
            return productId;
        }



        public List<Product> FindByDescription(Enum productDescription)
        {
            List<Product> products = new List<Product>();
            try
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
            }
            catch (TransactionAbortedException)
            {
            }
            return null;
        }

        public List<Product> FindByStatus(Enum productStatus)
        {
            List<Product> productList = new List<Product>();

            try
            {
                using (SqlConnection con = dBConnection.OpenConnection())
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
                            ProductDescription = (Product_Description)dr.GetInt("description"),
                            ProductStatus = (Product_Status)dr.GetInt("status")
                        };
                        productList.Add(product);
                    }
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
                using (TransactionScope scope = DALExtensions.CreateReadComittedTransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                        byte[] rowId = null;
                        using (SqlCommand command = con.CreateCommand())
                        {
                            command.CommandText = GET_ROWID;
                            command.Parameters.AddWithValue("id", product.ProductId);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                rowId = (byte[])reader["rowId"];
                            }
                            reader.Close();
                            command.CommandText = UPDATE_PRODUCT;
                            command.AddMultipleWithValue(new Dictionary<string, object>() {
                                { "name",           product.Name },
                                { "price",          product.Price },
                                { "PurchasePrice",  product.PurchasePrice },
                                { "description",    product.ProductDescription },
                                { "status",         product.ProductStatus },
                                { "rowId",          rowId}
                        });
                            NoOfRowsAffected = command.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
            }
            if(NoOfRowsAffected == 0)
            {
                throw new ProductAlreadySoldException(product.Name + " has already been purchased by another user");
            }

            return NoOfRowsAffected;
        }

        public Product FindProduct(int id)
        {
            Product product;
            try
            {
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
            }
            catch (TransactionAbortedException)
            {

            }
            return null;
        }
    }
}