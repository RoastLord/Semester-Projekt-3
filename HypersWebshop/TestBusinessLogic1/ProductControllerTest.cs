using System;
using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBusinessLogic1
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void TestCreate()
        {
            //Arrange
            ProductController productController = new ProductController();
            Product product = new Product()
            {
                Name = "Seagate Harddisk",
                AmountInStock = 20,
                Price = 20000,
                PurchasePrice = 7500,
                ProductDescription = Product_Description.Harddisk,
                ProductStatus = Product_Status.Published
            };

            //Act
            productController.Create(product);

            //Assert
            Assert.AreEqual(product.ProductId, productController.Get(product.ProductId).ProductId);
        }

        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            ProductController productController = new ProductController();
            Product product = new Product()
            {
                Name = "Toshiba Harddisk",
                AmountInStock = 15,
                Price = 19900,
                PurchasePrice = 7500,
                ProductDescription = Product_Description.Harddisk,
                ProductStatus = Product_Status.Published
            };
            productController.Create(product);

            //Act
            product.Price = 18999;
            productController.Update(product);

            //Assert
            Assert.AreEqual(product.Price, productController.Get(product.ProductId).Price);

        }

        //[TestMethod]
        //public void TestDelete()
        //{
        //    //Arrange
        //    ProductController productController = new ProductController();
        //    Product product = new Product()
        //    {
        //        Name = "Intel Core CPU",
        //        AmountInStock = 15,
        //        Price = 50000,
        //        PurchasePrice = 35000,
        //        ProductDescription = Product_Description.CPU,
        //        ProductStatus = Product_Status.Published
        //    };
        //    productController.Create(product);


        //    //Act
        //    productController.Delete(product);


        //    //Assert
        //    Assert.AreNotEqual(product, productController.Get(product.ProductId));

        //}
    }
}
