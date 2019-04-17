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
            Product product2 = new Product()
            {
                Name = "Skovl2",
                AmountInStock = 5,
                Price = 120,
                PurchasePrice = 100,
                ProductDescription = Product_Description.CPU,
                ProductStatus = Product_Status.Published
            };

            ProductController productController = new ProductController();

            //Act
            productController.Create(product);
            Product testProdukt = productController.Get(1);

            Console.WriteLine("Produkt ID: " + testProdukt.ProductId);
            Console.WriteLine("Produkt Navn: " + testProdukt.Name);
            Console.WriteLine("Produkt Stock: " + testProdukt.AmountInStock);
            Console.WriteLine("Produkt Pris : " + testProdukt.Price);
            Console.WriteLine("Produkt Beskrivelse: " + testProdukt.ProductDescription);
            Console.WriteLine("Produkt Status: " + testProdukt.ProductStatus);
            productController.ChangeProductStatus(testProdukt, Product_Status.Tested);
            Console.WriteLine("testProdukt efter update: " + testProdukt.ProductStatus);
            

            productController.Delete(productController.Get(2));
            Console.WriteLine("ID 2 er slettet");

            foreach (Product p in productController.GetAll(Product_Description.CPU))
            {
                Console.WriteLine(p.Name + "" + p.ProductDescription);
            }
            Console.ReadKey();
        }
    }
}
