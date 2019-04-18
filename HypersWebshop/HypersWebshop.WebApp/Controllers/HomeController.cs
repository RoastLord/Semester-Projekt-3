using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HypersWebshop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.ProductInterfaceClient myProxy = new ServiceReference1.ProductInterfaceClient();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = myProxy.FindProduct(1).Name;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}