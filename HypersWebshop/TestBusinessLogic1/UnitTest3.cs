using System;
using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBusinessLogic1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Product product = new Product()
            {
                Name = "TestProdukt9000",
                AmountInStock = 1,
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Harddisk,
                ProductStatus = Product_Status.Published
            };
            ProductController productController = new ProductController();

            //Act
            productController.Create(product);

            //Assert
            Assert.AreEqual(productController.Get(1), product);
        }
    }
}
