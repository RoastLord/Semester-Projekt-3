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
        ServiceReference1.IDesktopService service = new DesktopServiceClient();
        public UpdateProductView()
        {
            InitializeComponent();
        }


        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                CompositeProduct compositeProduct = new CompositeProduct();
                compositeProduct.ProductId = Int32.Parse(txtUpdateProductID.Text);
                compositeProduct.Name = txtUpdateName.Text;
                compositeProduct.Price = (long)numPrice.Value;
                compositeProduct.PurchasePrice = (long)numPurchasePrice.Value;
                compositeProduct.ProductDescription = (Product_Description)cmbUpdateDescription.SelectedIndex;
                compositeProduct.Product_Status = (Product_Status)cmbUpdateStatus.SelectedIndex;
                service.UpdateProduct(compositeProduct);
                this.Hide();
            }
            catch(Exception)
            {
                MessageBox.Show("Something went wrong. Please try again");
            }
         
        }

        private void btnUpdateCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
