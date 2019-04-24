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
            Customer customer = new Customer()
            {
                Name = "Per",
                Address = "Vej",
                PhoneNo = "Nummer",
                Email = "email",
                Zipcode = 9000,


            };
            customerController.Create(customer);

            Assert.AreEqual(customer, customerController.Get(customer.PhoneNo));
        }
}
}
