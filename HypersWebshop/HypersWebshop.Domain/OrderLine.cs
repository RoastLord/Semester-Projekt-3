using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public class OrderLine
    {
        public int Amount { get; set; }
        public long Price { get; set; }
        public long TotalPrice { get; set; }
        public Product Product { get; set; }

        public OrderLine(int amount, long price, long totalPrice, Product product)
        {
            Amount = amount;
            Price = price;
            TotalPrice = totalPrice;
            Product = product;
            
        }
    }
}
