using HypersWebApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace HypersWebApp.Controllers
{
    public class ProductController : Controller
    {

        ProductServiceClient client = new ProductServiceClient();

        public ActionResult Harddisk()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList(); 
            return View();
        }

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
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
        public ActionResult Batteri()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
        public ActionResult CPU()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
        public ActionResult CPU_Køling()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
        public ActionResult GPU()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
        public ActionResult Motherboard()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
        public ActionResult Optisk_Drev()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
        public ActionResult Strømforsyning()
        {
            ViewBag.ListProduct = client.FindProductsByStatus(Product_Status.Published).ToList();
            return View();
        }
    }
}