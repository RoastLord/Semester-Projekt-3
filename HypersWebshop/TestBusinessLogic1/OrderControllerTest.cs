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
            Product product = productController.FindProduct(1);
            Customer customer = personController.GetCustomer("12341234");
            OrderLine orderLine = new OrderLine(product);
            Order order = new Order (DateTime.Today, DateTime.Today, customer);
            order.OrderNo = orderController.CreateOrder(order);
            personController.AddOrderToCustomer(order.OrderNo, customer);
            orderController.AddOrderlineToOrder(order.OrderNo, orderLine);

            // Act
            orderController.ProcessSale(order);

            // Assert
            Assert.AreEqual(Product_Status.Sold, productController.FindProduct(1).ProductStatus);
        }


        [TestMethod]
        public void TestRemoveProductFromOrderline()
        {
            //Arrange
            ProductController productController = new ProductController();
            OrderController orderController = new OrderController();
            PersonController personController = new PersonController();



            Customer customer = personController.GetCustomer("12341234");
            Order order = new Order(100, DateTime.Today, DateTime.Today, customer);

            Product product = productController.FindProduct(1);
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

