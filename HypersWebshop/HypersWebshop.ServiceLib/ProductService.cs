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
        PersonController personController = new PersonController();
        OrderController orderController = new OrderController();

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

        public string ProcessSale(List<CompositeProduct> compProducts, CompositeCustomer compCustomer)
        {
            // Lav Composite objekt om til et "normalt" objekt
            Customer customer = CompositeToCustomer(compCustomer);
            List<Product> products = new List<Product>();

            // Lokalvariabel til at holde styr på totalprisen for ordren
            long totalPrice = 0;

            // Lav listen af Composite Objekter om til en liste af normale Produkter TEST
            foreach(CompositeProduct compP in compProducts)
            {
                products.Add(CompositeToProduct(compP));
                // For hvert produkt, + prisen til totalprisen
                totalPrice += compP.Price;
            }
            
            // Lav en Order lokalvariabel, med 7 dages levering
            Order order = new Order(totalPrice, DateTime.Now, DateTime.Now.AddDays(7), customer);

            // Gem ordren i databasen, og hent ID'et ud som databasen generer for os
            order.OrderNo = orderController.CreateOrder(order);

            // Gem Customer i databasen
            personController.CreateCustomer(customer);

            // Tilknyt ordren til Customer i databasen
            personController.AddOrderToCustomer(order.OrderNo, customer);

            // Lav OrderLine objekter for hvert produkt, og tilføj dem til lokalvariablen "order" + gem de invidiuelle orderLines i databasen
            foreach (Product p in products)
            {
                OrderLine orderLine = new OrderLine(p);
                order.AddToOrderLine(orderLine);
                orderController.AddOrderlineToOrder(order.OrderNo, orderLine);
            }
            // Færdiggør salget, dvs ændre alle produkt statusser til "Solgt" + returner en string (kvitteringen)
            return orderController.ProcessSale(order);

        }

        private Product CompositeToProduct(CompositeProduct comp)
        {
            Product product = new Product();
            product.Name = comp.Name;
            product.Price = comp.Price;
            product.PurchasePrice = comp.PurchasePrice;
            product.ProductDescription = comp.ProductDescription;
            product.ProductStatus = comp.Product_Status;
            return product;
        }

        private Customer CompositeToCustomer(CompositeCustomer comp)
        {
            Customer customer = new Customer();
            customer.Name = comp.Name;
            customer.Address = comp.Address;
            customer.PhoneNo = comp.PhoneNo;
            customer.Email = comp.Email;
            customer.City = comp.City;
            return customer;
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
            List<Product> products = productController.FindProductsByStatus(status);
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

        public void CreateCustomer(CompositeCustomer composite)
        {
            Customer customer = new Customer();

            customer.Name = composite.CustomerName;
            customer.Address = composite.CustomerAddress;
            customer.PhoneNo = composite.CustomerPhoneNo;
            customer.Email = composite.CustomerEmail;
            customer.Zipcode = composite.CustomerZipcode;
            customer.City = composite.CustomerCity;

            personController.CreateCustomer(customer);
        }
    }
}
