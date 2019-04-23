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

    public class DBProduct : ICRUD<Product>
    {
        DBConnection dBConnection;
        
        // I querien "CREATE_PRODUCT" bliver der kaldt en "OUTPUT IDENT_CURRENT" query, som returnerer ID'et på produktet.
        private string CREATE_PRODUCT = "INSERT INTO Product OUTPUT IDENT_CURRENT('Product') VALUES (@Name, @AmountInStock, @Price, @PurchasePrice, @Description, @Status)";
        private string FIND_PRODUCT_BY_ID = "SELECT * FROM Product WHERE id = (@id)";
        private string DELETE_PRODUCT = "DELETE FROM Product WHERE ID = (@id)";
        private string FIND_PRODUCTS_BY_DESCRIPTION = "SELECT * from Product WHERE description = @description";
        private string UPDATE_PRODUCT = "UPDATE Product SET name = @name, amountInStock = @amountInStock," +
                                        " price = @price, purchasePrice = @PurchasePrice, " +
                                        "description = @description, status = @status WHERE id = @id;";
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

                        entity.ProductId = command.ExecuteWithIdentity();
                    }
                    scope.Complete();
                }
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
            }
            catch (TransactionAbortedException)
            {
            }
        }

        //public Product Get(int id)
        //{
        //    Product product;
        //    using (SqlConnection con = dBConnection.OpenConnection())
        //    {

        //        SqlCommand command = new SqlCommand(FIND_PRODUCT_BY_ID, con);
        //        command.Parameters.AddWithValue("id", id);
        //        SqlDataReader dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            product = new Product()
        //            {
        //                ProductId = dr.GetInt32(0),
        //                Name = dr.GetString(1),
        //                AmountInStock = dr.GetInt32(2),
        //                Price = dr.GetInt64(3),
        //                PurchasePrice = dr.GetInt64(4),
        //                ProductDescription = (Product_Description)dr.GetInt32(5),
        //                ProductStatus = (Product_Status) dr.GetInt32(6)
        //            };
        //            return product;
        //        }
        //    }
        //    Product dummy = new Product();
        //    return dummy;
        //}

        public Product Get(int id)
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
                        AmountInStock = dr.GetInt("amountInStock"),
                        Price = dr.GetLong("price"),
                        PurchasePrice = dr.GetLong("purchasePrice"),
                        ProductDescription = (Product_Description)dr.GetInt("description"),
                        ProductStatus = (Product_Status)dr.GetInt("status")
                    };
                    return product;
                }
            }
            Product dummy = new Product();
            return dummy;
        }

            public IEnumerable<Product> GetAll(Enum productDescription)
        {
            List<Product> products = new List<Product>();
            // Den rigtige transaktion?
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
                                AmountInStock = dr.GetInt("amountInStock"),
                                Price = dr.GetLong("price"),
                                PurchasePrice = dr.GetLong("purchasePrice"),
                                ProductDescription = (Product_Description)dr.GetInt("description"),
                                ProductStatus = (Product_Status)dr.GetInt("status")

                            };
                            products.Add(product);
                        }
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
            }
            return products;

        }

        public void Update(Product product)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection con = dBConnection.OpenConnection())
                    {
                            SqlCommand command = new SqlCommand(UPDATE_PRODUCT, con);
                        //    command.AddMultipleWithValue(new Dictionary <string, object>() {
                        //        { "name",           product.Name },
                        //        { "amountInStock",  product.AmountInStock },
                        //        { "price",          product.Price },
                        //        { "purchasePrice",  product.PurchasePrice },
                        //        { "description",    product.ProductDescription },
                        //        { "status",         product.ProductStatus },
                        //        { "id",             product.ProductId },
                        //});



                        command.Parameters.AddWithValue("name", product.Name);
                        command.Parameters.AddWithValue("amountInStock", product.AmountInStock);
                        command.Parameters.AddWithValue("price", product.Price);
                        command.Parameters.AddWithValue("purchasePrice", product.PurchasePrice);
                        command.Parameters.AddWithValue("description", product.ProductDescription);
                        command.Parameters.AddWithValue("status", product.ProductStatus);
                        command.Parameters.AddWithValue("id", product.ProductId);

                        //Kan evt returneres så man kan se hvor mange elementer der er blevet opdateret.
                        int noOfRowsAffected = command.ExecuteNonQuery();
                    }
                    
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
            }
        }

    }
}
