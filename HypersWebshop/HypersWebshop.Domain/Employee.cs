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

    }
}
