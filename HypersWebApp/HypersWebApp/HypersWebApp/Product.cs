using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HypersWebApp
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long PurchasePrice { get; set; }

        public Product(int ProductId, string Name, long Price, long PurchasePrice)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.Price = Price;
            this.PurchasePrice = PurchasePrice;
        }

        public override string ToString()
        {
            return "Product: " + Name + " " + Price + " " + PurchasePrice;
        }
    }
}