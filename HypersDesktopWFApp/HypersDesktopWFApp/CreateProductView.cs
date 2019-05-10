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
    public partial class CreateProductView : Form
    {
        ServiceReference1.IProductService service = new ServiceReference1.ProductServiceClient();
        public CreateProductView()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            long tempPrice = 0;
            Int64.TryParse(txtPrice.Text, out tempPrice);
            long tempPurchasePrice = 0;
            Int64.TryParse(txtPurchasePrice.Text, out tempPurchasePrice);

            CompositeProduct product = new CompositeProduct();
            product.Name = txtName.Text;
            product.Price = tempPrice;
            product.PurchasePrice = tempPurchasePrice;
            product.ProductDescription = (Product_Description) cmbDescription.SelectedIndex;
            product.Product_Status = (Product_Status)cmbStatus.SelectedIndex;

            service.CreateProduct(product);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
