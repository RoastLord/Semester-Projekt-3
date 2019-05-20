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
            List<Product> list = productController.FindProductsByStatus((Product_Status)2);
            

            
            foreach(Product p in list)
            {
                Console.WriteLine(p.Name);
            }
            Console.ReadKey();
            


        }
    }
}
