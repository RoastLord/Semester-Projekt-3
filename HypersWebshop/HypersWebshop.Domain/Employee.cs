using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public class Employee : Person
    { 
        public Boolean IsAdmin { get; set; }
        public DateTime Birthday { get; set; }

        public Employee(bool isAdmin, DateTime birthday, string name, string address, string phoneNo, string email, int zipcode, string city) : base(name, address, phoneNo, email, zipcode, city)
        { 
            IsAdmin = isAdmin;
            Birthday = birthday;
            Name = name;
            Address = address;
            PhoneNo = phoneNo;
            Email = email;
            Zipcode = zipcode;
            City = city;
        }
    }
}
