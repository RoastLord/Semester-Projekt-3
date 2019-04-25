using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HypersWebshop.Domain;
using HypersWebshop.BusinessLogic;
using HypersWebshop.DataAccessLayer;

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

        [TestMethod]
        public void TestShoppingCart()
        {
            //Arrange
            DBConnection dBConnection;
            OrderController orderController = new OrderController();
            ProductController productController = new ProductController();
            Customer customer = new Customer()
            {
                Name ="Per",
                Address = "Hadsundvej 30",
                PhoneNo = "12341234",
                Email = "per@mail.dk",
                Zipcode = 9000,
                City = "Aalborg"
            };
            Order order = new Order(1, 100, DateTime.Today, DateTime.Today, customer);
            dBConnection =  new DBConnection();
            Product product = new Product()
            {
                Name = "Lenovo Batteri",
                AmountInStock = 10,
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            Product product2 = new Product()
            {
                Name = "Lenovo",
                AmountInStock = 10,
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Batteri,
                ProductStatus = Product_Status.Published
            };
            OrderLine orderLine = new OrderLine(1, 100, 100, product);
            productController.Create(product);
            productController.Create(product2);
            order.AddToOrderLine(orderLine);
            int expectedAmount = product.AmountInStock - orderLine.Amount;
            //Act
            DBOrder dBOrder = new DBOrder();
            dBOrder.Create(order);
            dBOrder.CreateOrderline(product, order, 1);
            dBOrder.CreateOrderline(product2, order, 1);
            //Assert
            Assert.AreEqual(order.OrderNo, 1);
            Assert.AreEqual(orderLine.Product.Name, product.Name);
        }
    }
}
