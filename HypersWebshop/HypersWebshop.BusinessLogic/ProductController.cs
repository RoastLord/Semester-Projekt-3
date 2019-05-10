using HypersWebshop.DataAccessLayer;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    public class ProductController
    {
        DBProduct dbProduct = new DBProduct();

        public int Create(Product entity)
        {
            return dbProduct.Create(entity);
        }

        public void DeleteProduct(Product entity)
        {
            dbProduct.Delete(entity);
        }

        public Product FindProduct(int id)
        {
            return dbProduct.FindProduct(id);
        }

        // Skal kaldes med en opdateret lokalvariabel
        public int UpdateProduct(Product product)
        {
            Console.WriteLine("Pris Fra Controller: " + product.Price);
            return dbProduct.Update(product);
        }

        public List<Product> FindProductsByDescription(Product_Description description)
        {
            return dbProduct.FindByDescription(description);
        }

        public List<Product> FindProductsByStatus(Product_Status status)
        {
            return dbProduct.FindByStatus(status);
        }

        public void ChangeProductStatus(Product product, Product_Status newStatus)
        {
            product.ProductStatus = newStatus;
            dbProduct.Update(product);
        }
    }
}
