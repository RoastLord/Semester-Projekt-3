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
        public void create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(string phoneNo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        //public Product changeProductStatus(Product product, Product_Status newStatus)
        //{
        //    Product p = product;

        //    p.ProductStatus = newStatus;
        //    DBProduct dBProduct = new DBProduct():
        //    dbProduct.Update(product, p);
        //}

        public Product changeProductStatusSold(Product product)
        {
            Product p = product;
            Boolean paid = true;


            if (paid)
            {

                if (p.ProductStatus != Product_Status.Published)
                {
                    //Skal eftertjekkes
                    Console.WriteLine("Error, produktet er ikke tilgængeligt");
                }
                else
                {
                    //Sætter produktets status til solgt
                    p.ProductStatus = Product_Status.Sold;
                }
            }
            else
            {
                Console.WriteLine("Betalingen gik ikke gennem");
            }

            return p;
        }
    }
}
