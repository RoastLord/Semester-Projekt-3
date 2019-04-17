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
            Product theShit = productController.Get(1);

            Console.WriteLine("Produkt ID: " + theShit.ProductId);
            Console.WriteLine("Produkt Navn: " + theShit.Name);
            Console.WriteLine("Produkt Stock: " + theShit.AmountInStock);
            Console.WriteLine("Produkt Pris : " + theShit.Price);
            Console.WriteLine("Produkt Beskrivelse: " + theShit.ProductDescription);
            Console.WriteLine("Produkt Status: " + theShit.ProductStatus);
            Console.ReadKey();
        }
    }
}
