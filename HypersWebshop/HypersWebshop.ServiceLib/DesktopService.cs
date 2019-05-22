using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.ServiceLib
{
    public class DesktopService : IDesktopService
    {
        ProductController productController = new ProductController();
        PersonController personController = new PersonController();
        OrderController orderController = new OrderController();

        public int CreateProduct(CompositeProduct composite)
        {
            return productController.Create(CompositeToProduct(composite));
        }

        public CompositeProduct FindProduct(int id)
        {
            return ProductToComposite(productController.FindProduct(id));
        }

        public List<CompositeProduct> FindProductsByDescription(Product_Description description)
        {
            List<Product> products = productController.FindProductsByDescription(description);
            List<CompositeProduct> compositeProducts = new List<CompositeProduct>();

            foreach (Product product in products)
            {
                compositeProducts.Add(ProductToComposite(product));
            }
            return compositeProducts;
        }

        public List<CompositeProduct> FindProductsByStatus(Product_Status status)
        {
            List<Product> products = productController.FindProductsByStatus(status);
            List<CompositeProduct> compositeProducts = new List<CompositeProduct>();

            foreach (Product product in products)
            {
                compositeProducts.Add(ProductToComposite(product));
            }
            return compositeProducts;
        }

        public void UpdateProduct(CompositeProduct composite)
        {
            productController.UpdateProduct(CompositeToProduct(composite));
        }

        private Product CompositeToProduct(CompositeProduct comp)
        {
            Product product = new Product();
            product.ProductId = comp.ProductId;
            product.Name = comp.Name;
            product.Price = comp.Price;
            product.PurchasePrice = comp.PurchasePrice;
            product.ProductDescription = comp.ProductDescription;
            product.ProductStatus = comp.Product_Status;
            return product;
        }

        private CompositeProduct ProductToComposite(Product product)
        {
            CompositeProduct compositeProduct = new CompositeProduct();
            compositeProduct.ProductId = product.ProductId;
            compositeProduct.Name = product.Name;
            compositeProduct.Price = product.Price;
            compositeProduct.PurchasePrice = product.PurchasePrice;
            compositeProduct.ProductDescription = product.ProductDescription;
            compositeProduct.Product_Status = product.ProductStatus;

            return compositeProduct;
        }

        private CompositeCustomer CustomerToComposite(Customer customer)
        {
            CompositeCustomer compositeCustomer = new CompositeCustomer();
            compositeCustomer.CustomerAddress = customer.Address;
            compositeCustomer.CustomerEmail = customer.Email;
            compositeCustomer.CustomerZipcode = customer.Zipcode;
            compositeCustomer.CustomerPhoneNo = customer.PhoneNo;

            return compositeCustomer;
        }

        private Customer CompositeToCustomer(CompositeCustomer comp)
        {
            return new Customer()
            {
                Name = comp.CustomerName,
                Address = comp.CustomerAddress,
                PhoneNo = comp.CustomerPhoneNo,
                Email = comp.CustomerEmail,
                Zipcode = comp.CustomerZipcode
            };
        }

    }
}
