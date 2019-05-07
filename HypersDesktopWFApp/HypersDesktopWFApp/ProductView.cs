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
            dataGridView1.Rows.Clear();
            ServiceReference1.Product_Status status = (Product_Status) comboBoxProductStatus.SelectedIndex;
            // Brug status når metoden er lavet
            List<CompositeType> products = service.FindProductsByStatus(status);

            int i = 0;
            foreach (CompositeType product in products)
            {
                dataGridView1.Rows.Insert(i, 1, product.Name, product.Price, product.PurchasePrice, product.ProductDescription, product.Product_Status);
                i++;
            }
        }
    }
}
