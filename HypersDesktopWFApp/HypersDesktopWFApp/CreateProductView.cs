using HypersDesktopWFApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HypersDesktopWFApp
{
    public partial class CreateProductView : Form
    {
        ServiceReference1.IDesktopService service = new DesktopServiceClient();
        public CreateProductView()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CompositeProduct product = new CompositeProduct();
                product.Name = txtName.Text;
                product.Price = (long)numCreateprice.Value;
                product.PurchasePrice = (long)numCreatePurchasePrice.Value;
                product.ProductDescription = (Product_Description)cmbDescription.SelectedIndex;
                product.Product_Status = (Product_Status)cmbStatus.SelectedIndex;

                service.CreateProduct(product);
                this.Close();
            }
            catch(CommunicationException)
            {
                MessageBox.Show("Alle felter skal udfyldes før man kan oprette et produkt");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
