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

        public int UpdateProduct(Product product)
        {
            return dbProduct.Update(product);
        }

        public List<Product> FindProductsByDescription(Enum productDescription)
        {
            return dbProduct.FindByDescription(productDescription);
        }

        public List<Product> FindProductsByStatus(Product_Status status)
        {
            return dbProduct.FindByStatus(status);
        }

        //public void ChangeProductStatus(Product product, Product_Status newStatus)
        //{
        //    product.ProductStatus = newStatus;
        //    dbProduct.Update(product);
        //}
    }
}
