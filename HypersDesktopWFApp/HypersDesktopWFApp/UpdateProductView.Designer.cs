namespace HypersDesktopWFApp
{
    partial class UpdateProductView
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
            this.txtUpdateName = new System.Windows.Forms.TextBox();
            this.lblUpdateName = new System.Windows.Forms.Label();
            this.lblUpdatePrice = new System.Windows.Forms.Label();
            this.lblUpdatePurchasePrice = new System.Windows.Forms.Label();
            this.cmbUpdateDescription = new System.Windows.Forms.ComboBox();
            this.cmbUpdateStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateCancel = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.lblUpdateDescription = new System.Windows.Forms.Label();
            this.lblUpdateProductStatus = new System.Windows.Forms.Label();
            this.txtUpdateProductID = new System.Windows.Forms.TextBox();
            this.lblUpdateId = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numPurchasePrice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUpdateName
            // 
            this.txtUpdateName.Location = new System.Drawing.Point(59, 165);
            this.txtUpdateName.Name = "txtUpdateName";
            this.txtUpdateName.Size = new System.Drawing.Size(100, 20);
            this.txtUpdateName.TabIndex = 0;
            // 
            // lblUpdateName
            // 
            this.lblUpdateName.AutoSize = true;
            this.lblUpdateName.Location = new System.Drawing.Point(56, 149);
            this.lblUpdateName.Name = "lblUpdateName";
            this.lblUpdateName.Size = new System.Drawing.Size(35, 13);
            this.lblUpdateName.TabIndex = 3;
            this.lblUpdateName.Text = "Name";
            // 
            // lblUpdatePrice
            // 
            this.lblUpdatePrice.AutoSize = true;
            this.lblUpdatePrice.Location = new System.Drawing.Point(56, 205);
            this.lblUpdatePrice.Name = "lblUpdatePrice";
            this.lblUpdatePrice.Size = new System.Drawing.Size(31, 13);
            this.lblUpdatePrice.TabIndex = 4;
            this.lblUpdatePrice.Text = "Price";
            // 
            // lblUpdatePurchasePrice
            // 
            this.lblUpdatePurchasePrice.AutoSize = true;
            this.lblUpdatePurchasePrice.Location = new System.Drawing.Point(263, 95);
            this.lblUpdatePurchasePrice.Name = "lblUpdatePurchasePrice";
            this.lblUpdatePurchasePrice.Size = new System.Drawing.Size(76, 13);
            this.lblUpdatePurchasePrice.TabIndex = 5;
            this.lblUpdatePurchasePrice.Text = "PurchasePrice";
            // 
            // cmbUpdateDescription
            // 
            this.cmbUpdateDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateDescription.FormattingEnabled = true;
            this.cmbUpdateDescription.Items.AddRange(new object[] {
            "Harddisk",
            "RAM",
            "Batteri",
            "Strømforsyning",
            "GPU",
            "CPU Køling",
            "Motherboard",
            "CPU",
            "Optisk Drev"});
            this.cmbUpdateDescription.Location = new System.Drawing.Point(264, 165);
            this.cmbUpdateDescription.Name = "cmbUpdateDescription";
            this.cmbUpdateDescription.Size = new System.Drawing.Size(121, 21);
            this.cmbUpdateDescription.TabIndex = 12;
            // 
            // cmbUpdateStatus
            // 
            this.cmbUpdateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateStatus.FormattingEnabled = true;
            this.cmbUpdateStatus.Items.AddRange(new object[] {
            "Sold",
            "Published",
            "Unpublished",
            "Tested",
            "Untested",
            "Rejected"});
            this.cmbUpdateStatus.Location = new System.Drawing.Point(264, 220);
            this.cmbUpdateStatus.Name = "cmbUpdateStatus";
            this.cmbUpdateStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbUpdateStatus.TabIndex = 7;
            // 
            // btnUpdateCancel
            // 
            this.btnUpdateCancel.Location = new System.Drawing.Point(59, 256);
            this.btnUpdateCancel.Name = "btnUpdateCancel";
            this.btnUpdateCancel.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCancel.TabIndex = 8;
            this.btnUpdateCancel.Text = "Cancel";
            this.btnUpdateCancel.UseVisualStyleBackColor = true;
            this.btnUpdateCancel.Click += new System.EventHandler(this.btnUpdateCancel_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(264, 256);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateProduct.TabIndex = 9;
            this.btnUpdateProduct.Text = "Update";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // lblUpdateDescription
            // 
            this.lblUpdateDescription.AutoSize = true;
            this.lblUpdateDescription.Location = new System.Drawing.Point(261, 143);
            this.lblUpdateDescription.Name = "lblUpdateDescription";
            this.lblUpdateDescription.Size = new System.Drawing.Size(60, 13);
            this.lblUpdateDescription.TabIndex = 10;
            this.lblUpdateDescription.Text = "Description";
            // 
            // lblUpdateProductStatus
            // 
            this.lblUpdateProductStatus.AutoSize = true;
            this.lblUpdateProductStatus.Location = new System.Drawing.Point(261, 204);
            this.lblUpdateProductStatus.Name = "lblUpdateProductStatus";
            this.lblUpdateProductStatus.Size = new System.Drawing.Size(74, 13);
            this.lblUpdateProductStatus.TabIndex = 11;
            this.lblUpdateProductStatus.Text = "ProductStatus";
            // 
            // txtUpdateProductID
            // 
            this.txtUpdateProductID.Location = new System.Drawing.Point(59, 111);
            this.txtUpdateProductID.Name = "txtUpdateProductID";
            this.txtUpdateProductID.ReadOnly = true;
            this.txtUpdateProductID.Size = new System.Drawing.Size(100, 20);
            this.txtUpdateProductID.TabIndex = 13;
            // 
            // lblUpdateId
            // 
            this.lblUpdateId.AutoSize = true;
            this.lblUpdateId.Location = new System.Drawing.Point(59, 95);
            this.lblUpdateId.Name = "lblUpdateId";
            this.lblUpdateId.Size = new System.Drawing.Size(58, 13);
            this.lblUpdateId.TabIndex = 14;
            this.lblUpdateId.Text = "Product ID";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(59, 221);
            this.numPrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 20);
            this.numPrice.TabIndex = 15;
            // 
            // numPurchasePrice
            // 
            this.numPurchasePrice.Location = new System.Drawing.Point(266, 110);
            this.numPurchasePrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPurchasePrice.Name = "numPurchasePrice";
            this.numPurchasePrice.Size = new System.Drawing.Size(120, 20);
            this.numPurchasePrice.TabIndex = 16;
            // 
            // UpdateProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numPurchasePrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblUpdateId);
            this.Controls.Add(this.txtUpdateProductID);
            this.Controls.Add(this.lblUpdateProductStatus);
            this.Controls.Add(this.lblUpdateDescription);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnUpdateCancel);
            this.Controls.Add(this.cmbUpdateStatus);
            this.Controls.Add(this.cmbUpdateDescription);
            this.Controls.Add(this.lblUpdatePurchasePrice);
            this.Controls.Add(this.lblUpdatePrice);
            this.Controls.Add(this.lblUpdateName);
            this.Controls.Add(this.txtUpdateName);
            this.Name = "UpdateProductView";
            this.Text = "UpdateProduct";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtUpdateName;
        public System.Windows.Forms.Label lblUpdateName;
        public System.Windows.Forms.Label lblUpdatePrice;
        public System.Windows.Forms.Label lblUpdatePurchasePrice;
        public System.Windows.Forms.ComboBox cmbUpdateDescription;
        public System.Windows.Forms.ComboBox cmbUpdateStatus;
        public System.Windows.Forms.Button btnUpdateCancel;
        public System.Windows.Forms.Button btnUpdateProduct;
        public System.Windows.Forms.Label lblUpdateDescription;
        public System.Windows.Forms.Label lblUpdateProductStatus;
        public System.Windows.Forms.TextBox txtUpdateProductID;
        public System.Windows.Forms.Label lblUpdateId;
        public System.Windows.Forms.NumericUpDown numPrice;
        public System.Windows.Forms.NumericUpDown numPurchasePrice;
    }
}