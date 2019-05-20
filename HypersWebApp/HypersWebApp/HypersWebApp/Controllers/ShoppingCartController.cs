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
        ProductServiceClient client = new ProductServiceClient();

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
            CustumerCreation(name, lAdress, phone, email, intZip, city);
            return RedirectToAction("Payment");
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

        public ActionResult Payment(List<CompositeProduct>compositeProducts, CompositeCustomer compositeCustomer)
        {
            client.ProcessSale(compositeProducts, compositeCustomer);
            return View();
        }
    }


}