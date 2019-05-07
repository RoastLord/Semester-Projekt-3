namespace HypersDesktopWFApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compositeTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compositeTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxProductStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositeTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositeTypeBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 356);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Søg";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Price,
            this.PurchasePrice,
            this.Product_Description,
            this.Product_Status});
            this.dataGridView1.Location = new System.Drawing.Point(177, 160);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "Produkter";
            this.dataGridView1.Size = new System.Drawing.Size(800, 500);
            this.dataGridView1.TabIndex = 4;
            // 
            // Name
            // 
            this.Name.HeaderText = "Navn";
            this.Name.Name = "Name";
            // 
            // Price
            // 
            this.Price.HeaderText = "Pris";
            this.Price.Name = "Price";
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.HeaderText = "Indkøbspris";
            this.PurchasePrice.Name = "PurchasePrice";
            // 
            // Product_Description
            // 
            this.Product_Description.HeaderText = "Produktbeskrivelse";
            this.Product_Description.Name = "Product_Description";
            // 
            // Product_Status
            // 
            this.Product_Status.HeaderText = "Produktstatus";
            this.Product_Status.Name = "Product_Status";
            // 
            // compositeTypeBindingSource
            // 
            this.compositeTypeBindingSource.DataSource = typeof(HypersDesktopWFApp.ServiceReference1.CompositeType);
            // 
            // compositeTypeBindingSource1
            // 
            this.compositeTypeBindingSource1.DataSource = typeof(HypersDesktopWFApp.ServiceReference1.CompositeType);
            // 
            // comboBox1
            // 
            this.comboBoxProductStatus.FormattingEnabled = true;
            this.comboBoxProductStatus.Location = new System.Drawing.Point(18, 160);
            this.comboBoxProductStatus.Name = "comboBoxProductStatus";
            this.comboBoxProductStatus.Items.Add("Sold");
            this.comboBoxProductStatus.Items.Add("Published");
            this.comboBoxProductStatus.Items.Add("Unpublished");
            this.comboBoxProductStatus.Items.Add("Tested");
            this.comboBoxProductStatus.Items.Add("Untested");
            this.comboBoxProductStatus.Items.Add("Rejected");
            this.comboBoxProductStatus.Size = new System.Drawing.Size(121, 28);
            this.comboBoxProductStatus.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.comboBoxProductStatus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Text = "Hypers Webshop";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositeTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositeTypeBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource compositeTypeBindingSource;
        private System.Windows.Forms.BindingSource compositeTypeBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Status;
        private System.Windows.Forms.ComboBox comboBoxProductStatus;
    }
}