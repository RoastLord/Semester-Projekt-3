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
                Name = "Skovl",
                AmountInStock = 5,
                Price = 120,
                PurchasePrice = 100,
                ProductDescription = Product_Description.CPU,
                ProductStatus = Product_Status.Published
            };

            ProductController productController = new ProductController();

            //Act
            productController.Create(product);
            Product theShit = productController.Get(3);

            Console.WriteLine("Produkt med id 3: " + theShit.ProductId);
            Console.WriteLine("Produkt med id 3: " + theShit.Name);
            Console.WriteLine("Produkt med id 3: " + theShit.AmountInStock);
            Console.WriteLine("Produkt med id 3: " + theShit.Price);
            
            Console.WriteLine("Produkt med id 3: " + theShit.ProductDescription);
            Console.WriteLine("Produkt med id 3: " + theShit.ProductStatus);
            Console.ReadKey();
        }
    }
}
