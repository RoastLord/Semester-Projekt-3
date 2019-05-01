using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            OrderController orderController = new OrderController();
            ProductController productController = new ProductController();
            PersonController personController = new PersonController();
            Customer customer = new Customer()
            {
                Name = "Per",
                Address = "Hadsundvej 30",
                PhoneNo = "12341234",
                Email = "per@mail.dk",
                Zipcode = 9000,
            };
            int customerId = personController.CreateCustomer(customer);

            Product product = new Product()
            {
                Name = "TestProcessSaleProduct",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            product.ProductId = productController.Create(product);
            OrderLine orderLine = new OrderLine(product);
            Order order = new Order(DateTime.Today, DateTime.Today, customer);
            order.OrderNo = orderController.CreateOrder(order);
            Console.WriteLine("Skal være 1: " + order.OrderNo);
            Console.ReadKey();
            personController.AddOrderToCustomer(order.OrderNo, customer);
            orderController.AddOrderlineToOrder(order.OrderNo, orderLine);

            // Act
            orderController.ProcessSale(order);

            // Assert
            Console.WriteLine("Skal være solgt: " + productController.FindProduct(product.ProductId).ProductStatus);
            Console.ReadKey();












            //Product product = new Product()
            //{
            //    Name = "Skovl",
            //    AmountInStock = 5,
            //    Price = 120,
            //    PurchasePrice = 100,
            //    ProductDescription = Product_Description.CPU,
            //    ProductStatus = Product_Status.Published
            //};

            //Product testProdukt = new Product()
            //{
            //    Name = "Skovl2",
            //    AmountInStock = 5,
            //    Price = 120,
            //    PurchasePrice = 100,
            //    ProductDescription = Product_Description.CPU,
            //    ProductStatus = Product_Status.Published
            //};

            //ProductController productController = new ProductController();

            ////Act
            //productController.Create(product);
            //productController.Create(testProdukt);

            //Console.WriteLine("TESTEN HER: Skovl, 5, 120, 100, cpu, publish");
            //Console.WriteLine("Produkt ID: " + testProdukt.ProductId);
            //Console.WriteLine("Produkt Navn: " + testProdukt.Name);
            //Console.WriteLine("Produkt Stock: " + testProdukt.AmountInStock);
            //Console.WriteLine("Produkt Pris : " + testProdukt.Price);
            //Console.WriteLine("Produkt indkøbspris" + testProdukt.PurchasePrice);
            //Console.WriteLine("Produkt Beskrivelse: " + testProdukt.ProductDescription);
            //Console.WriteLine("Produkt Status: " + testProdukt.ProductStatus);

            //productController.ChangeProductStatus(testProdukt, Product_Status.Tested);
            //product.Name = "Per";
            //productController.Update(product);

            //Console.WriteLine("testProdukt efter update (skal være tested): " + productController.Get(testProdukt.ProductId).ProductStatus);
            //Console.WriteLine("Skal være Per: " + productController.Get(product.ProductId).Name);


            ////productController.Delete(productController.Get(1));
            //Console.WriteLine("ID 1 er slettet");
            //Console.WriteLine("Liste over produkter");
            //foreach (Product p in productController.GetAll(Product_Description.CPU))
            //{
            //    Console.WriteLine(p.Name + " " + p.ProductDescription);
            //}

            //    Customer customer = new Customer()
            //    {
            //        Name = "Per",
            //        Address = "Vej",
            //        PhoneNo = "123",
            //        Email = "email",
            //        Zipcode = 9000,


            //    };
            //    CustomerController customerController = new CustomerController();
            //    customerController.Create(customer);
            //    Console.WriteLine("gg");
            //    Customer newCust = customerController.Get(customer.PhoneNo);
            //    string test = customerController.GetCityByZipCode(newCust.Zipcode);
            //    Console.WriteLine(test);

            //OrderController orderController = new OrderController();
            //orderController.RemoveProductFromShoppingcart(1, 2);


            //OrderController orderController = new OrderController();
            //ProductController productController = new ProductController();
            //PersonController personController = new PersonController();
            //Customer customer = new Customer()
            //{
            //    Name = "Per",
            //    Address = "Hadsundvej 30",
            //    PhoneNo = "123412364",
            //    Email = "per@mail.dk",
            //    Zipcode = 9000,
            //};
            //personController.CreateCustomer(customer);
            //Order order = new Order(1, 100, DateTime.Today, DateTime.Today, customer);
            //Product product = new Product()
            //{
            //    Name = "TestProcessSaleProduct",
            //    Price = 100,
            //    PurchasePrice = 50,
            //    ProductDescription = Product_Description.Batteri,
            //    ProductStatus = Product_Status.Published
            //};
            //OrderLine orderLine = new OrderLine(product);
            //product.ProductId = productController.Create(product);
            //order.AddToOrderLine(orderLine);

            //orderController.ProcessSale(order);

            //Console.WriteLine(productController.FindProduct(product.ProductId).ProductStatus);
            //Console.ReadKey();
        }
    }
}
