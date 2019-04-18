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
            Product product1 = new Product()
            {
                Name = "testproduct",
                AmountInStock = 1,
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Harddisk,
                ProductStatus = Product_Status.Published
            };
            OrderLine orderLine = new OrderLine(1, 100, 100, product1);
            Order order = new Order(1, 100, DateTime.Today, DateTime.Today, customer1);
            order.AddToOrderLine(orderLine);
            OrderController orderController = new OrderController();
            ProductController productController = new ProductController();
            // Act
            orderController.ProcessSale(order);

            // Assert
            Assert.AreEqual(Product_Status.Sold, productController.Get(product1.ProductId).ProductStatus);
        }
    }
}
