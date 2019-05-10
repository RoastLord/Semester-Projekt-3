namespace HypersDesktopWFApp
{
    partial class CreateProductView
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(113, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(113, 123);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 1;
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(113, 162);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(100, 20);
            this.txtPurchasePrice.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(113, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(272, 240);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(110, 66);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(110, 107);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(110, 146);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(79, 13);
            this.lblPurchasePrice.TabIndex = 9;
            this.lblPurchasePrice.Text = "Purchase Price";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(272, 66);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(272, 109);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status";
            // 
            // cmbDescription
            // 
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Items.AddRange(new object[] {
            "Harddisk",
            "RAM",
            "Batteri",
            "Strømforsyning",
            "GPU",
            "CPU Køling",
            "Motherboard",
            "CPU",
            "Optisk Drev"});
            this.cmbDescription.Location = new System.Drawing.Point(275, 82);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(121, 21);
            this.cmbDescription.TabIndex = 12;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Sold",
            "Published",
            "Unpublished",
            "Tested",
            "Untested",
            "Rejected"});
            this.cmbStatus.Location = new System.Drawing.Point(275, 123);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 13;
            // 
            // CreateProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Name = "CreateProductView";
            this.Text = "CreateProductView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbDescription;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}