using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HypersWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly Product _context;

        public HomeController(Product context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Index(string sortOrder)
        //{
        //    ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
        //    var products = from p in _context
        //                   select p;
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            products = products.OrderByDescending(s => s.LastName);
        //            break;
        //        case "Date":
        //            products = products.OrderBy(s => s.EnrollmentDate);
        //            break;
        //        case "date_desc":
        //            products = products.OrderByDescending(s => s.EnrollmentDate);
        //            break;
        //        default:
        //            products = products.OrderBy(s => s.LastName);
        //            break;
        //    }
        //    return View(await products.AsNoTracking().ToListAsync());
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Hypers is a danish corporation working for a better future";
            ViewBag.Location = "Aalborg, Denmark";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}