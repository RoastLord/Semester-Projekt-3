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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateProductView form = new UpdateProductView();
            form.txtUpdateProductID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            form.txtUpdateName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            form.numPrice.Value = Decimal.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            form.numPurchasePrice.Value = Decimal.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            form.cmbUpdateDescription.SelectedIndex = (int)dataGridView1.CurrentRow.Cells[4].Value;
            form.cmbUpdateStatus.SelectedIndex = (int)dataGridView1.CurrentRow.Cells[5].Value;
            form.Show();
        }
    }
}
