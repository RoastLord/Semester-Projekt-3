using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HypersWebshop.Domain;
using HypersWebshop.BusinessLogic;
using HypersWebshop.DataAccessLayer;
using System.Collections.Generic;

namespace TestBusinessLogic
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void TestProcessSale()
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
            personController.CreateCustomer(customer);

            Product product = new Product()
            {
                Name = "TestProduct",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            product.ProductId = productController.Create(product);
            OrderLine orderLine = new OrderLine(product);
            Order order = new Order (DateTime.Today, DateTime.Today, customer);
            order.OrderNo = orderController.CreateOrder(order);
            personController.AddOrderToCustomer(order.OrderNo, customer);
            orderController.AddOrderlineToOrder(order.OrderNo, orderLine);

            // Act
            orderController.ProcessSale(order);

            // Assert
            Assert.AreEqual(Product_Status.Sold, productController.FindProduct(product.ProductId).ProductStatus);
        }


        [TestMethod]
        public void TestRemoveProductFromOrderline()
        {
            //Arrange
            ProductController productController = new ProductController();
            OrderController orderController = new OrderController();
            PersonController personController = new PersonController();

            Customer customer = new Customer()
            {
                Name = "JensPer",
                Address = "Hadsundvej 30",
                PhoneNo = "12341234",
                Email = "per@mail.dk",
                Zipcode = 9000,
                City = "Aalborg"
            };

            
            personController.CreateCustomer(customer);
            Order order = new Order(0, 100, DateTime.Today, DateTime.Today, customer);
            
            Product product = new Product()
            {
                Name = "testRemoveProductproduct",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            OrderLine orderLine = new OrderLine(product);
            
            product.ProductId = productController.Create(product);
            order.OrderNo = orderController.CreateOrder(order);
            orderController.AddOrderlineToOrder(order.OrderNo, orderLine);

            //Act
            orderController.RemoveProductFromShoppingcart(order.OrderNo, product.ProductId);

            //Assert

            List<OrderLine> list = orderController.GetOrderLines(order.OrderNo);
            bool check = false;
            foreach (OrderLine o in list)
            {
                
                if(o.Product.Name == product.Name)
                {

                    check = true;
                }
            }


            Assert.AreEqual(false, check);
        }
    }
}

