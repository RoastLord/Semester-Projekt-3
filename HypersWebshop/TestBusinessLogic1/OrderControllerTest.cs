using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HypersWebshop.Domain;
using HypersWebshop.BusinessLogic;

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
            Customer customer = new Customer()
            {
                Name = "Per",
                Address = "Hadsundvej 30",
                PhoneNo = "12341234",
                Email = "per@mail.dk",
                Zipcode = 9000,
            };
            Order order = new Order(1, 100, DateTime.Today, DateTime.Today, customer);
            Product product = new Product()
            {
                Name = "Lenovo Batteri",
                AmountInStock = 10,
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            OrderLine orderLine = new OrderLine(1, 100, 100, product);
            productController.Create(product);
            order.AddToOrderLine(orderLine);
            int expectedAmount = product.AmountInStock - orderLine.Amount;

            // Act
            orderController.ProcessSale(order);

            // Assert
            Assert.AreEqual(Product_Status.Sold, productController.Get(product.ProductId).ProductStatus);
            Assert.AreEqual(expectedAmount, productController.Get(product.ProductId).AmountInStock);
        }
    }
}
