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
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestSale()
        {
            //arrange
            Customer customer1 = new Customer("testn", "testad", "testpn", "testemail", 9000, "testcity");
            Product product1 = new Product(1, "testproduct", 1, 100, 50, Product_Description.Harddisk, Product_Status.Published);

            //act
            //ProductController.changeProductStatusSold(product1);

            //assert
            Assert.AreEqual ( Product_Status.Sold, product1.ProductStatus);
        }
    }
}
