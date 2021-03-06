﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HypersWebshop.Domain;
using HypersWebshop.BusinessLogic;
using HypersWebshop.DataAccessLayer;
using System.Collections.Generic;

namespace TestBusinessLogic
{
    [TestClass]
    public class OrderControllerTest
    {
        OrderController orderController = new OrderController();
        ProductController productController = new ProductController();
        PersonController personController = new PersonController();
        [TestMethod]
        public void TestProcessSale()
        {
            // Arrange
            Customer customer = new Customer()
            {
                Name = "test",
                Address = "Hadsundvej 30",
                PhoneNo = "14212",
                Email = "per@mail.dk",
                Zipcode = 9000,
            };
            Product product = new Product()
            {
                Name = "TestProductyeet",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.Battery,
                ProductStatus = Product_Status.Published
            };
            Product product2 = new Product()
            {
                Name = "TestProduct2yeet",
                Price = 100,
                PurchasePrice = 50,
                ProductDescription = Product_Description.RAM,
                ProductStatus = Product_Status.Published
            };
            List<Product> products = new List<Product>();
            products.Add(product);
            products.Add(product2);
            product.ProductId = productController.Create(product);
            product2.ProductId = productController.Create(product2);
            Order order = new Order (DateTime.Today, DateTime.Today, customer);
            foreach(Product p in products)
            {
                OrderLine orderLine = new OrderLine();
                orderLine.Product = p;
                order.OrderLines.Add(orderLine);
            }
            // Act
            orderController.ProcessSale(order);

            // Assert
            foreach(OrderLine ol in order.OrderLines)
            {
                Assert.AreEqual(Product_Status.Sold, productController.FindProduct(ol.Product.ProductId).ProductStatus);
            }
        }


        //[TestMethod]
        //public void TestRemoveProductFromOrderline()
        //{
        //    //Arrange
        //    ProductController productController = new ProductController();
        //    OrderController orderController = new OrderController();
        //    PersonController personController = new PersonController();

        //    Customer customer = new Customer()
        //    {
        //        Name = "JensPer",
        //        Address = "Hadsundvej 30",
        //        PhoneNo = "123412345234",
        //        Email = "per@mail.dk",
        //        Zipcode = 9000,
        //        City = "Aalborg"
        //    };

            
        //    personController.CreateCustomer(customer);
        //    Order order = new Order(0, 100, DateTime.Today, DateTime.Today, customer);
            
        //    Product product = new Product()
        //    {
        //        Name = "testRemoveProductproduct",
        //        Price = 100,
        //        PurchasePrice = 50,
        //        ProductDescription = Product_Description.Battery,
        //        ProductStatus = Product_Status.Published
        //    };
        //    OrderLine orderLine = new OrderLine();
        //    orderLine.Product = product;
            
        //    product.ProductId = productController.Create(product);
        //    order.OrderNo = orderController.CreateOrder(order);
        //    orderController.AddOrderlineToOrder(order.OrderNo, orderLine);

        //    //Act
        //    orderController.RemoveProductFromShoppingcart(order.OrderNo, product.ProductId);

        //    //Assert

        //    List<OrderLine> list = orderController.FindOrderLines(order.OrderNo);
        //    bool check = false;
        //    foreach (OrderLine o in list)
        //    {
                
        //        if(o.Product.Name == product.Name)
        //        {

        //            check = true;
        //        }
        //    }


        //    Assert.AreEqual(false, check);
        //}
    }
}

