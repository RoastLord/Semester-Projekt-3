using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace HypersWebApp.Controllers
{
    public class ProductController : Controller
    {
        ServiceReference1.IProductInterface productInterface = new ServiceReference1.ProductInterfaceClient();
        public ActionResult Harddisk()
        {
            //Under udvikling stadig da database / kodeopbugningen i den anden solution er under opbygning
            ViewBag.Message = productInterface.FindProduct(1).Name;
            return View();
        }
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