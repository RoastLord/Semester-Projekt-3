using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HypersWebshop.Domain;
using HypersWebshop.BusinessLogic;

namespace TestBusinessLogic
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSale()
        {
            // Arrange
            Customer customer1 = new Customer("testn", "testad", "testpn", "testemail", 9000, "testcity");
            Product product1 = new Product(1, "testproduct", 1, 100, 50, Product_Description.Harddisk, Product_Status.Published);
            OrderLine orderLine = new OrderLine(1, 100, 100, product1);
            Order order = new Order(1, 100, DateTime.Today, DateTime.Today, customer1);
            order.AddToOrderLine(orderLine);
            OrderController orderController = new OrderController();

            // Act
            orderController.ProcessSale(order);

            // Assert
            Assert.AreEqual(Product_Status.Sold, product1.ProductStatus);
        }
    }
}
