﻿using HypersWebApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace HypersWebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductInterfaceClient client = new ProductInterfaceClient();

        public ActionResult Harddisk()
        {
            List<Product> products = new List<Product>();
            Product product1 = new Product(1, "testnavn1", 100, 50);
            Product product2 = new Product(2, "testnavn2", 50, 100);
            Product product3 = new Product(3, "testnavn3", 150, 50);
            Product product4 = new Product(4, "testnavn4", 200, 100);
            Product product5 = new Product(5, "testnavn5", 10, 50);

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);


            StringBuilder stringBuilder = new StringBuilder();

            foreach (Product product in products)
            {
                

                stringBuilder.AppendLine(product.ToString());
                stringBuilder.AppendLine("-----------------------------------");
                

            }

            ViewBag.List = stringBuilder.ToString();

            return View();
        }

        //StringBuilder stringBuilder = new StringBuilder();


        //stringBuilder.AppendLine(order.OrderNo.ToString());
        //    stringBuilder.AppendLine(order.Customer.Name);
        //    stringBuilder.AppendLine(order.Customer.Address);
        //    stringBuilder.AppendLine(order.Customer.City);
        //    stringBuilder.AppendLine(order.Customer.Email);
        //    stringBuilder.AppendLine(order.Customer.PhoneNo);
        //    stringBuilder.AppendLine(order.TotalPrice.ToString());

        //    foreach (OrderLine orderLine in order.OrderLines)
        //    {

        //        stringBuilder.AppendLine(orderLine.Product.Name);
        //        stringBuilder.AppendLine(orderLine.Product.Price.ToString());

        //    }

        //    return stringBuilder.ToString();


        //public ActionResult Harddisk()
        //{
        //    //Under udvikling stadig da database / kodeopbugningen i den anden solution er under opbygning
        //    ViewBag.Message = "Harddisk(også disk, fastpladelager, baggrundslager) er et digitalt lagringsmedie -og en almindelig brugt betegnelse " +
        //        "for disk.Da den diskenhed en pc er udstyret med, er anbragt i et kabinet(sammen med andre enheder)," +
        //        "benyttes betegnelsen også fejlagtigt for kabinettet med indhold.";
        //    return View();
        //}
        public ActionResult Ram()
    {
        return View();
    }
    public ActionResult Batteri()
    {
        return View();
    }
    public ActionResult CPU()
    {
        return View();
    }
    public ActionResult CPU_Køling()
    {
        return View();
    }
    public ActionResult GPU()
    {
        return View();
    }
    public ActionResult Motherboard()
    {
        return View();
    }
    public ActionResult Optisk_Drev()
    {
        return View();
    }
    public ActionResult Strømforsyning()
    {
        return View();
    }
}
}