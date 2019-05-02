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
                Price = 20000,
                PurchasePrice = 7500,
                ProductDescription = Product_Description.Harddisk,
                ProductStatus = Product_Status.Published
            };

            //Act
            int productId = productController.Create(product);

            //Assert
            Assert.AreEqual(product.Name, productController.FindProduct(productId).Name);
        }

        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            ProductController productController = new ProductController();
            Product product = new Product()
            {
                Name = "Toshiba Harddisk",
                Price = 19900,
                PurchasePrice = 7500,
                ProductDescription = Product_Description.Harddisk,
                ProductStatus = Product_Status.Published
            };
            product.ProductId = productController.Create(product);

            //Act
            product.Price = 18999;
            productController.UpdateProduct(product);

            //Assert
            Assert.AreEqual(18999, productController.FindProduct(product.ProductId).Price);

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
