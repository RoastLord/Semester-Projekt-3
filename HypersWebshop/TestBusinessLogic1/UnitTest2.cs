using System;
using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBusinessLogic1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product product = new Product(1, "RAM", 3, 300, 200, Product_Description.RAM, Product_Status.Tested);
            ProductController productController = new ProductController();

        }

    }
}
