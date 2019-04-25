using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public abstract class Person
    {
        //Ændre zipcode til string
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Password { get; set; }

    }
}
