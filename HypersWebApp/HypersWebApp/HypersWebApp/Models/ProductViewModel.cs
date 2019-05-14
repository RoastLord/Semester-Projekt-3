using HypersWebApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HypersWebApp.Models
{
    public class ProductViewModel
    {
        public CompositeProduct compositeProduct = new CompositeProduct();
        public ProductViewModel(CompositeProduct compositeProduct)
        {
            this.compositeProduct = compositeProduct;
        }
    }



    //public class ProductViewModel
    //{

    //    public int ProductID { get; set; }
    //    public string Name { get; set; }
    //    public long Price { get; set; }
    //    public long PurchasePrice { get; set; }
    //}


    //public class ProductsPageViewModel
    //{

    //    public ProductsPageViewModel
    //        {
    //            List<ProductViewModel> ProductsList = new List<ProductViewModel>();
    //        }

    //    public ICollection<ProductViewModel> ProductsList { get; set; }
    //}
}