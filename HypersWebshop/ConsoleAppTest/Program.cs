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
            ProductController productController = new ProductController();
            OrderController orderController = new OrderController();
            PersonController personController = new PersonController();

            Customer customer = new Customer()
            {
                Name = "JensPer",
                Address = "Hadsundvej 30",
                PhoneNo = "123412345",
                Email = "per@mail.dk",
                Zipcode = 9000,
            };


            personController.CreateCustomer(customer);
            Order order = new Order(0, 100, DateTime.Today, DateTime.Today, customer);
            order.OrderNo = orderController.CreateOrder(order);

            Product product1 = new Product()
            {
                Name = "testRemoveProductproduct",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            Product product2 = new Product()
            {
                Name = "testRemoveProductproduct",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            Product product3 = new Product()
            {
                Name = "testRemoveProductproduct",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            OrderLine orderLine1 = new OrderLine(product1);
            OrderLine orderLine2 = new OrderLine(product2);
            OrderLine orderLine3 = new OrderLine(product3);

            product1.ProductId = productController.Create(product1);
            product2.ProductId = productController.Create(product2);
            product3.ProductId = productController.Create(product3);

            orderController.AddOrderlineToOrder(order.OrderNo, orderLine1);
            orderController.AddOrderlineToOrder(order.OrderNo, orderLine2);
            orderController.AddOrderlineToOrder(order.OrderNo, orderLine3);

            Console.ReadKey();
            //Act
            orderController.RemoveAllProducts(order.OrderNo);


        }
    }
}
