using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public class Customer : Person
    {

        public Customer(string name, string address, string phoneNo, string email, int zipcode, string city) : base(name, address, phoneNo, email, zipcode, city)
        {
            Name = name;
            Address = address;
            PhoneNo = phoneNo;
            Email = email;
            Zipcode = zipcode;
            City = city;
        }
    }
}
