    using HypersWebshop.DataAccessLayer;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    public class PersonController
    {
        DBPerson dBPerson = new DBPerson();

        public void CreateCustomer(Customer customer)
        {
            dBPerson.CreateCustomer(customer);
        }

        public void AddOrderToCustomer(int orderNo, Customer customer)
        {
            dBPerson.AddOrderToCustomer(orderNo, customer);
        }

        public Customer GetCustomer(string phoneNo)
        {
            return dBPerson.FindCustomer(phoneNo);
        }

        public string GetCityByZipCode(int zipcode)
        {
            return dBPerson.GetCityByZipCode(zipcode);
        }
    }
}
