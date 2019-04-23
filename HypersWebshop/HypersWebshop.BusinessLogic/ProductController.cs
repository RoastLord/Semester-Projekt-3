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

        // Skal kaldes med en opdateret lokalvariabel
        public void Update(Product entity)
        {
            dbProduct.Update(entity);
        }

        public void ChangeProductStatus(Product product, Product_Status newStatus)
        {
            product.ProductStatus = newStatus;
            dbProduct.Update(product);
        }

        public IEnumerable<Product> GetAll(Enum productDescription)
        {
            return dbProduct.GetAll(productDescription);
        }
    }
}
