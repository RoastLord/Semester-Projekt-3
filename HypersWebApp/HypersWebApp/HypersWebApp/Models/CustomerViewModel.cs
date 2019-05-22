using HypersWebApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HypersWebApp.Models
{
    public class CustomerViewModel
    {
        public CompositeCustomer compositeCustomer = new CompositeCustomer();
        public CustomerViewModel(CompositeCustomer compositeCustomer)
        {
            this.compositeCustomer = compositeCustomer;
        }
    }
}