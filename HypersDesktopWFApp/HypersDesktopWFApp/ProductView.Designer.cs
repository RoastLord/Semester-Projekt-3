using System.Windows.Forms;

namespace HypersDesktopWFApp
{
    partial class ProductView
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
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compositeTypeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxProductStatus = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositeTypeBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Location = new System.Drawing.Point(12, 114);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(81, 34);
            this.btnUpdateTable.TabIndex = 2;
            this.btnUpdateTable.Text = "Opdater Tabel";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            this.btnUpdateTable.Click += new System.EventHandler(this.btnRefresh);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Name,
            this.Price,
            this.PurchasePrice,
            this.ProductDescription,
            this.Product_Status});
            this.dataGridView1.DataSource = this.compositeTypeBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(110, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(615, 294);
            this.dataGridView1.TabIndex = 4;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.DataPropertyName = "PurchasePrice";
            this.PurchasePrice.HeaderText = "PurchasePrice";
            this.PurchasePrice.Name = "PurchasePrice";
            // 
            // ProductDescription
            // 
            this.ProductDescription.DataPropertyName = "ProductDescription";
            this.ProductDescription.HeaderText = "ProductDescription";
            this.ProductDescription.Name = "ProductDescription";
            // 
            // Product_Status
            // 
            this.Product_Status.DataPropertyName = "Product_Status";
            this.Product_Status.HeaderText = "Product_Status";
            this.Product_Status.Name = "Product_Status";
            // 
            // compositeTypeBindingSource2
            // 
            this.compositeTypeBindingSource2.DataSource = typeof(HypersDesktopWFApp.ServiceReference1.CompositeProduct);
            // 
            // comboBoxProductStatus
            // 
            this.comboBoxProductStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductStatus.FormattingEnabled = true;
            this.comboBoxProductStatus.Items.AddRange(new object[] {
            "Sold",
            "Published",
            "Unpublished",
            "Tested",
            "Untested",
            "Rejected"});
            this.comboBoxProductStatus.Location = new System.Drawing.Point(12, 74);
            this.comboBoxProductStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxProductStatus.Name = "comboBoxProductStatus";
            this.comboBoxProductStatus.Size = new System.Drawing.Size(82, 21);
            this.comboBoxProductStatus.TabIndex = 5;
            this.comboBoxProductStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxProductStatus_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Opret Produkt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(12, 183);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(81, 47);
            this.btnUpdateProduct.TabIndex = 7;
            this.btnUpdateProduct.Text = "Opdater Produkt";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // ProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxProductStatus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpdateTable);
            this.Text = "Hypers Webshop";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositeTypeBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxProductStatus;
        private BindingSource compositeTypeBindingSource2;
        private Button button2;
        private DataGridViewTextBoxColumn ProductId;
        private new DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn PurchasePrice;
        private DataGridViewTextBoxColumn ProductDescription;
        private DataGridViewTextBoxColumn Product_Status;
        private Button btnUpdateProduct;
    }
}