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
    public class WebService : IWebService
    {
        ProductController productController = new ProductController();
        PersonController personController = new PersonController();
        OrderController orderController = new OrderController();

        public CompositeProduct FindProduct(int id)
        {
            Product product = productController.FindProduct(id);
            CompositeProduct composite = ProductToComposite(product);
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
                OrderLine orderLine = new OrderLine();
                orderLine.Product = p;
                order.AddToOrderLine(orderLine);
                orderController.AddOrderlineToOrder(order.OrderNo, orderLine);
            }
            // Færdiggør salget, dvs ændre alle produkt statusser til "Solgt" + returner en string (kvitteringen)
            return orderController.ProcessSale(order);
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


        public List<CompositeProduct> FindProductsByDescription(Product_Description description)
        {
            List<Product> products = productController.FindProductsByDescription(description);
            List<CompositeProduct> compositeProducts = new List<CompositeProduct>();

            foreach(Product product in products)
            {
                CompositeProduct composite = ProductToComposite(product);
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
                CompositeProduct composite = ProductToComposite(product);
                compositeProducts.Add(composite);
            }
            return compositeProducts;
        }

        public void CreateCustomer(CompositeCustomer composite)
        {
            Customer customer = CompositeToCustomer(composite);
            personController.CreateCustomer(customer);
        }
    }
}
