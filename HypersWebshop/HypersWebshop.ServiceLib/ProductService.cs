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
    public class ProductService : IProductService
    {
        ProductController productController = new ProductController();

        public int CreateProduct(CompositeProduct composite)
        {
            Product product = new Product();
            product.Name = composite.Name;
            product.Price = composite.Price;
            product.PurchasePrice = composite.PurchasePrice;
            product.ProductDescription = composite.ProductDescription;
            product.ProductStatus = composite.Product_Status;
            return productController.Create(product);
        }

        public CompositeProduct FindProduct(int id)
        {
            Product product = productController.FindProduct(id);
            CompositeProduct composite = new CompositeProduct();
            composite.Name = product.Name;
            composite.Price = product.Price;
            composite.PurchasePrice = product.PurchasePrice;
            composite.ProductDescription = product.ProductDescription;
            composite.Product_Status = product.ProductStatus;
            return composite;
        }

        public List<CompositeProduct> FindProductsByDescription(Product_Description description)
        {
            List<Product> products = productController.FindProductsByDescription(description);
            List<CompositeProduct> compositeProducts = new List<CompositeProduct>();

            foreach(Product product in products)
            {
                CompositeProduct composite = new CompositeProduct();
                composite.ProductId = product.ProductId;
                composite.Name = product.Name;
                composite.Price = product.Price;
                composite.PurchasePrice = product.PurchasePrice;
                composite.ProductDescription = product.ProductDescription;
                composite.Product_Status = product.ProductStatus;
                compositeProducts.Add(composite);
            }
            return compositeProducts;
        }

        public List<CompositeProduct> FindProductsByStatus(Product_Status status)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = productController.FindProductsByStatus(status);
            }
            catch (FaultException)
            {
                throw;
            }
            
            List<CompositeProduct> compositeProducts = new List<CompositeProduct>();

            foreach(Product product in products)
            {
                CompositeProduct composite = new CompositeProduct();
                composite.ProductId = product.ProductId;
                composite.Name = product.Name;
                composite.Price = product.Price;
                composite.PurchasePrice = product.PurchasePrice;
                composite.ProductDescription = product.ProductDescription;
                composite.Product_Status = product.ProductStatus;
                compositeProducts.Add(composite);
            }

            return compositeProducts;
        }

        public void UpdateProduct(CompositeProduct composite)
        {
            Product product = new Product();

            product.Name = composite.Name;
            product.Price = composite.Price;
            product.PurchasePrice = composite.PurchasePrice;
            product.ProductDescription = composite.ProductDescription;
            product.ProductStatus = composite.Product_Status;
            product.ProductId = composite.ProductId;

            productController.UpdateProduct(product);

        }
    }
}
