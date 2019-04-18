using HypersWebshop.DataAccessLayer;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    public class ProductController : ICRUD<Product>
    {
        DBProduct dbProduct = new DBProduct();

        public void Create(Product entity)
        {
            dbProduct.Create(entity);
        }

        public void Delete(Product entity)
        {
            dbProduct.Delete(entity);
        }

        public Product Get(int id)
        {
            return dbProduct.Get(id);
        }

        // Skal fixes, evt have en ny paramter der indikerer hvad der skal ændres
        public void Update(Product entity)
        {
            dbProduct.Update(entity, entity);
        }

        public void ChangeProductStatus(Product product, Product_Status newStatus)
        {
            Product newProduct = product;
            newProduct.ProductStatus = newStatus;

            dbProduct.Update(product, newProduct);
        }

        public IEnumerable<Product> GetAll(Enum productDescription)
        {
            return dbProduct.GetAll(productDescription);
        }
    }
}
