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
            Product product = new Product("navn", 5, 100, 50, Product_Description.Batteri, Product_Status.Published);
            ProductController productController = new ProductController();
            productController.create(product);

            Assert.AreEqual(product, product);
        }
    }
}
