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
    public partial class UpdateProductView : Form
    {
        ServiceReference1.IProductService service = new ServiceReference1.ProductServiceClient();
        public UpdateProductView()
        {
            InitializeComponent();
        }


        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            CompositeProduct compositeProduct = new CompositeProduct();
            compositeProduct.ProductId = Int32.Parse(txtUpdateProductID.Text);
            compositeProduct.Name = txtUpdateName.Text;
            compositeProduct.Price = (int) numPrice.Value;
            compositeProduct.PurchasePrice = 5;
            compositeProduct.ProductDescription = (Product_Description) cmbUpdateDescription.SelectedIndex;
            compositeProduct.Product_Status = (Product_Status)cmbUpdateStatus.SelectedIndex;
            service.UpdateProduct(compositeProduct);
            this.Hide();
        }

        private void btnUpdateCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
