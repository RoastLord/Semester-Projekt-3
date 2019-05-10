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
            comboBoxProductStatus.SelectedIndex = 1;


        }

        private void btnRefresh(object sender, EventArgs e)
        {
            comboBoxProductStatus_SelectedIndexChanged(sender, e);


        }

        private void comboBoxProductStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CompositeProduct> products = service.FindProductsByStatus((Product_Status)comboBoxProductStatus.SelectedIndex);
            dataGridView1.DataSource = products;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateProductView form = new CreateProductView();
            form.Show();


        }

        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    MessageBox.Show("Er du sikker på du vil ændre værdien i: " + sender.ToString());
        //}
    }
}
