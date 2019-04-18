using System;
using System.Data;
using System.Data.SqlClient;
using HypersWebshop.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBusinessLogic1
{
    [TestClass]
    public class DBConnecetionTest
    {
        [TestMethod]
        public void TestConnection()
        {
            //Arrange
            DBConnection dBConnecetion = new DBConnection();

            //Act
            SqlConnection con = dBConnecetion.OpenConnection();

            //Assert
            Assert.AreEqual(ConnectionState.Open, con.State);


        }
    }
}
