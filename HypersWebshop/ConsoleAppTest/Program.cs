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
            ProductController productController = new ProductController();
            OrderController orderController = new OrderController();
            PersonController personController = new PersonController();

            List<Product> products = new List<Product>();
            Product product1 = productController.FindProduct(1);
            products.Add(product1);
            Product product2 = productController.FindProduct(2);
            products.Add(product2);
            Product product3 = productController.FindProduct(3);
            products.Add(product3);
            Product product4 = productController.FindProduct(9);
            products.Add(product4);

            


            Customer customer = new Customer();
            customer.Name = "navn";
            customer.Address = "adrs";
            customer.PhoneNo = "12333asdfdsfa55";
            customer.Zipcode = 9000;
            customer.Email = "email";
            
            

            // Lokalvariabel til at holde styr på totalprisen for ordren
            long totalPrice = 0;

            // Lav listen af Composite Objekter om til en liste af normale Produkter TEST
            foreach (Product p in products)
            {
                totalPrice += p.Price;
            }

            // Lav en Order lokalvariabel, med 7 dages levering
            Order order = new Order(totalPrice, DateTime.Now, DateTime.Now.AddDays(7), customer);

            // Gem ordren i databasen, og hent ID'et ud som databasen generer for os
            order.OrderNo = orderController.CreateOrder(order);

            // Gem Customer i databasen
            personController.CreateCustomer(customer);

            // Tilknyt ordren til Customer i databasen
            personController.AddOrderToCustomer(order.OrderNo, customer);

            // Lav OrderLine objekter for hvert produkt, og tilføj dem til lokalvariablen "order" + gem de invidiuelle orderLines i databasen
            foreach (Product p in products)
            {
                OrderLine orderLine = new OrderLine();
                orderLine.Product = p;
                order.AddToOrderLine(orderLine);
                orderController.AddOrderlineToOrder(order.OrderNo, orderLine);
            }
            // Færdiggør salget, dvs ændre alle produkt statusser til "Solgt" + returner en string (kvitteringen)
            Console.WriteLine(orderController.ProcessSale(order));
            Console.ReadKey();
        }


    }
    
}
