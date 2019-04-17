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
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return dbProduct.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void ChangeProductStatus(Product product, Product_Status newStatus)
        {
            Product newProduct = product;
            newProduct.ProductStatus = newStatus;

            dbProduct.Update(product, newProduct);
        }
    }
}
