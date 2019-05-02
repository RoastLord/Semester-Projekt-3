using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public class OrderLine
    {     
        public Product Product { get; set; }

        public OrderLine(Product product)
        {
            Product = product;
        }
    }
}
