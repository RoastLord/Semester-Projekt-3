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

        private void button3_Click_1(object sender, EventArgs e)
        {
            CompositeProduct composite = new CompositeProduct();

            composite.ProductId = (int) dataGridView1.CurrentRow.Cells[0].Value;
            composite.Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            composite.Price = (long)dataGridView1.CurrentRow.Cells[2].Value;
            composite.PurchasePrice = (long) dataGridView1.CurrentRow.Cells[3].Value;
            composite.ProductDescription = (Product_Description) (int) dataGridView1.CurrentRow.Cells[4].Value;
            composite.Product_Status = (Product_Status) (int) dataGridView1.CurrentRow.Cells[5].Value;

            service.UpdateProduct(composite);
            btnRefresh(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProductView form = new UpdateProductView();
            
            form.Show();
            
        }
    }
}
