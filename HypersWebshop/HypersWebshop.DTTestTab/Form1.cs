using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HypersWebshop.DTTestTab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.TestInterfaceClient myProxy = new ServiceReference2.TestInterfaceClient();
            DateTime dt = myProxy.TestMethod();

            this.label1.Text = dt.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
