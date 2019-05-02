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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            DBConnection dBConnection = new DBConnection();
            dBConnection.OpenConnection();

            if (dBConnection.connection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Du er ikke oppressed");
            }
            else
            {
                MessageBox.Show("Du er rimlig oppressed lige nu");
            }
        }
    }
}
