using HypersWebApp.Models;
using HypersWebApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HypersWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        WebServiceClient client = new WebServiceClient();
        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<ProductViewModel> cart = (List<ProductViewModel>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("cart");
        }
        private int isExisting(int id)
        {
            List<ProductViewModel> cart = (List<ProductViewModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].compositeProduct.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<ProductViewModel> cart = new List<ProductViewModel>();
                cart.Add(new ProductViewModel(client.FindProduct(id)));
                Session["cart"] = cart;
            }
            else
            {
                List<ProductViewModel> cart = (List<ProductViewModel>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                {
                    cart.Add(new ProductViewModel(client.FindProduct(id)));
                }
                Session["cart"] = cart;
            }
            return View("Cart");
        }

        public ActionResult BuyView()
        {

            return View();
        }

        [HttpPost]
        public ActionResult BuyView(FormCollection collection)
        {
            string name = collection["Name"];
            string lAdress = collection["LAdress"];
            string phone = collection["Phone"];
            string email = collection["Email"];
            string zip = collection["Zip"];
            string city = collection["City"];
            int intZip = int.Parse(zip);
            List<ProductViewModel> cart = (List<ProductViewModel>)Session["cart"];
            List<CompositeProduct> compProductList = new List<CompositeProduct>();
            foreach (ProductViewModel p in cart)
            {
                CompositeProduct compProduct = p.compositeProduct;
                compProductList.Add(compProduct);
            }
            CompositeCustomer compCustomer = CustumerCreation(name, lAdress, phone, email, intZip, city);
            string saleString = client.ProcessSale(compProductList, compCustomer);
            return RedirectToAction("Payment", new { saleString });
        }

        public CompositeCustomer CustumerCreation(string name, string address, string phoneNo, string email, int zip, string city)
        {
            CompositeCustomer compositeCustomer = new CompositeCustomer();
            compositeCustomer.CustomerName = name;
            compositeCustomer.CustomerAddress = address;
            compositeCustomer.CustomerPhoneNo = phoneNo;
            compositeCustomer.CustomerEmail = email;
            compositeCustomer.CustomerZipcode = zip;
            compositeCustomer.CustomerCity = city;
            return compositeCustomer;
        }

        public ActionResult Payment(string saleString)
        {
            saleString = saleString + " could not be purchased at the time. Please try again";
            ViewBag.saleString = saleString;
            Session["cart"] = null;
            return View();
        }
    }
}