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
        public float Price { get; set; }
        public float PurchasePrice { get; set; }
        public Product_Description ProductDescription { get; set; }
        public Product_Status ProductStatus { get; set; } 

        public Product(int productId, string name, int amountInStock, float price, float purchasePrice, Product_Description productDescription, Product_Status productStatus)
        {
            ProductId = productId;
            Name = name;
            AmountInStock = amountInStock;
            Price = price;
            PurchasePrice = purchasePrice;
            ProductDescription = productDescription;
            ProductStatus = productStatus;
        }
        public Product(string name, int amountInStock, float price, float purchasePrice, Product_Description productDescription, Product_Status productStatus)
        {
            Name = name;
            AmountInStock = amountInStock;
            Price = price;
            PurchasePrice = purchasePrice;
            ProductDescription = productDescription;
            ProductStatus = productStatus;
        }

    }
}
