using HypersDesktopWFApp.ServiceReference1;
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
    public partial class ProductView : Form
    {
        ServiceReference1.IProductService service = new ServiceReference1.ProductServiceClient();
        public ProductView()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxProductStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CompositeType> products = service.FindProductsByStatus((Product_Status)comboBoxProductStatus.SelectedIndex);
            dataGridView1.DataSource = products;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var CreateProductFrom = new Form();
            CreateProductFrom.Show();

        }
    }
}
