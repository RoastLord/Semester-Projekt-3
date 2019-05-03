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
        ServiceReference1.IProductInterface productInterface = new ServiceReference1.ProductInterfaceClient();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtinput = textBox1.Text;
            var product = productInterface.FindProduct(int.Parse(txtinput));
            textBox1.Text = product.Product_Status.ToString();
            dataGridView1.Rows.Insert(0, product.Name, product.Price, product.PurchasePrice, product.ProductDescription.ToString(), product.Product_Status.ToString());

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
