using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int AmountInStock { get; set; }
        public long Price { get; set; }
        public long PurchasePrice { get; set; }
        public Product_Description ProductDescription { get; set; }
        public Product_Status ProductStatus { get; set; } 

        

    }
}
