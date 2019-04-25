using System;
using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBusinessLogic1
{
    [TestClass]
    public class DBCustomerTest
    {
        CustomerController customerController = new CustomerController();

        [TestMethod]
        public void RegisterAsCustomerTest()
        {
            //Arrange
            Customer customer = new Customer()
            {
                Name = "Per",
                Address = "Vej",
                PhoneNo = "Nummer",
                Email = "email",
                Zipcode = 9000,
                Password = "hunter"
            };

            //Act
            customerController.Create(customer);

            //Assert
            Assert.AreEqual(customer.PhoneNo, customerController.Get(customer.PhoneNo).PhoneNo);
        }
    }
}
