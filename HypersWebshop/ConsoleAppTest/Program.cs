using HypersWebshop.BusinessLogic;
using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Product product = new Product()
            //{
            //    Name = "Skovl",
            //    AmountInStock = 5,
            //    Price = 120,
            //    PurchasePrice = 100,
            //    ProductDescription = Product_Description.CPU,
            //    ProductStatus = Product_Status.Published
            //};

            //Product testProdukt = new Product()
            //{
            //    Name = "Skovl2",
            //    AmountInStock = 5,
            //    Price = 120,
            //    PurchasePrice = 100,
            //    ProductDescription = Product_Description.CPU,
            //    ProductStatus = Product_Status.Published
            //};

            //ProductController productController = new ProductController();

            ////Act
            //productController.Create(product);
            //productController.Create(testProdukt);

            //Console.WriteLine("TESTEN HER: Skovl, 5, 120, 100, cpu, publish");
            //Console.WriteLine("Produkt ID: " + testProdukt.ProductId);
            //Console.WriteLine("Produkt Navn: " + testProdukt.Name);
            //Console.WriteLine("Produkt Stock: " + testProdukt.AmountInStock);
            //Console.WriteLine("Produkt Pris : " + testProdukt.Price);
            //Console.WriteLine("Produkt indkøbspris" + testProdukt.PurchasePrice);
            //Console.WriteLine("Produkt Beskrivelse: " + testProdukt.ProductDescription);
            //Console.WriteLine("Produkt Status: " + testProdukt.ProductStatus);

            //productController.ChangeProductStatus(testProdukt, Product_Status.Tested);
            //product.Name = "Per";
            //productController.Update(product);

            //Console.WriteLine("testProdukt efter update (skal være tested): " + productController.Get(testProdukt.ProductId).ProductStatus);
            //Console.WriteLine("Skal være Per: " + productController.Get(product.ProductId).Name);


            ////productController.Delete(productController.Get(1));
            //Console.WriteLine("ID 1 er slettet");
            //Console.WriteLine("Liste over produkter");
            //foreach (Product p in productController.GetAll(Product_Description.CPU))
            //{
            //    Console.WriteLine(p.Name + " " + p.ProductDescription);
            //}

            //Customer customer = new Customer()
            //{
            //    Name = "Per",
            //    Address = "Vej",
            //    PhoneNo = "123",
            //    Email = "email",
            //    Zipcode = 9000,
            //    Password = "hunter2"
            //};
            //CustomerController customerController = new CustomerController();
            //customerController.Create(customer);

            string txtUsername = "123";
            string txtPassword = "hunter2";

            LoginController loginController = new LoginController();

            if (loginController.CheckLogin(txtUsername, txtPassword))
            {
                // accessGranted();
                Console.WriteLine("Velkommen mydude");
            }

            else
            {
                Console.WriteLine("Nixen bixen");
            }

            Console.ReadKey();
        }
    }
}
