using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;

namespace HypersWebshop.ServiceLib
{
    public class ProductProxy : IProductService
    {
        ProductController productController = new ProductController();


        public string GetData(int value)
        {
            return "";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            //if (composite.BoolValue)
            //{
            //    composite.StringValue += "Suffix";
            //}
            return composite;
        }


        public void CreateProduct(Product product)
        {
            //productController.Create(product);
        }

        public CompositeType FindProduct(int id)
        {
            Product product = productController.FindProduct(id);
            CompositeType composite = new CompositeType();
            composite.Name = product.Name;
            composite.Price = product.Price;
            composite.PurchasePrice = product.PurchasePrice;
            composite.ProductDescription = product.ProductDescription;
            composite.Product_Status = product.ProductStatus;
            return composite;
        }

        public void ggwp()
        {
            throw new NotImplementedException();
        }

        public List<CompositeType> FindProductsByDescription(Product_Description description)
        {
            List<Product> oldProducts = productController.FindProductsByDescription(description);
            List<CompositeType> products = new List<CompositeType>();
            foreach(Product product in oldProducts)
            {
                CompositeType composite = new CompositeType();
                composite.Name = product.Name;
                composite.Price = product.Price;
                composite.PurchasePrice = product.PurchasePrice;
                composite.ProductDescription = product.ProductDescription;
                composite.Product_Status = product.ProductStatus;
                products.Add(composite);
            }
            return products;
        }
    }
}
