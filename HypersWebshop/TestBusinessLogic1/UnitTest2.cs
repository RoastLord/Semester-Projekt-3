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
            //arrange
            Product product = new Product()
            {
                Name = "RAM",
                AmountInStock = 3,
                Price = 300,
                PurchasePrice = 20,
                ProductDescription = Product_Description.RAM,
                ProductStatus = Product_Status.Tested
            };
            ProductController productController = new ProductController();

            //act
            productController.ChangeProductStatus(product, Product_Status.Published);

            //assert
            Assert.AreEqual(product.ProductStatus, Product_Status.Published);

        }

    }
}
