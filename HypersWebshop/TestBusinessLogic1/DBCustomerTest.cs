using System;
using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBusinessLogic1
{
    [TestClass]
    public class DBCustomerTest
    {
        PersonController personController = new PersonController();

        // Probably Querien i dBCustomer er broken
        //[TestMethod]
        //public void RegisterAsCustomerTest()
        //{
        //    //Arrange
        //    Customer customer = new Customer()
        //    {
        //        Name = "Per",
        //        Address = "Vej",
        //        PhoneNo = "Nummer",
        //        Email = "email",
        //        Zipcode = 9000
        //    };

        //    //Act
        //    customerController.Create(customer);

        //    //Assert
        //    Assert.AreEqual(customer.PhoneNo, customerController.Get(customer.PhoneNo).PhoneNo);
        //}
    }
}
