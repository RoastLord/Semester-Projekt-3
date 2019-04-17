using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            Product product = new Product()
            {
                Name = "Navn",
                AmountInStock = 5,
                Price = 120,
                PurchasePrice = 100,
                ProductDescription = Product_Description.CPU,
                ProductStatus = Product_Status.Published
            };

            ProductController productController = new ProductController();

            //Act
            productController.Create(product);

            Console.WriteLine("Produkt med id 1: " + productController.Get(1).ProductId);
            Console.ReadKey();
        }
    }
}
