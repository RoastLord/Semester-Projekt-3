using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HypersWebshop.DTTestTab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            ServiceReference1.ProductInterfaceClient myProxy = new ServiceReference1.ProductInterfaceClient();
        //Skal vi bruge using af domænelag eller hvordan gør vi??
        private void Button1_Click(object sender, EventArgs e)
        {
            
            
            Product product = new Product()
            {
                Name = "Lasse",
                Price = 100,
                PurchasePrice = 50,
                ProductStatus = Product_Status.Published,
                ProductDescription = Product_Description.Batteri
            };
            myProxy.CreateProduct(product);

            this.label1.Text = myProxy.FindProduct(1).Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
