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
    public class ProductProxy : IProductInterface
    {
        ProductController productController = new ProductController();


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public void CreateProduct(Product product)
        {
            productController.Create(product);
        }

        public Product FindProduct(int id)
        {
            return productController.Get(id);
        }

        public void ggwp()
        {
            throw new NotImplementedException();
        }
    }
}
