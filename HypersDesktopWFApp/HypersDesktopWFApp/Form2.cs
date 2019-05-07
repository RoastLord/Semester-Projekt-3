﻿using HypersDesktopWFApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HypersDesktopWFApp
{
    public partial class Form2 : Form
    {
        ServiceReference1.IProductService service = new ServiceReference1.ProductServiceClient();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CompositeType> products = service.FindProductsByDescription(ServiceReference1.Product_Description.Batteri);

            int i = 0;
            foreach (CompositeType product in products)
            {
                dataGridView1.Rows.Insert(i, product.Name, product.Price, product.PurchasePrice, product.ProductDescription.ToString(), product.Product_Status.ToString());
                i++;
            }
            
        }
    }
}
