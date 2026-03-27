namespace eShiftManagementSystem
{
    partial class AddLoadsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLoadsForm));
            this.lblFromLocation = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lstLoads = new System.Windows.Forms.ListBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnAddLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.AutoSize = true;
            this.lblFromLocation.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromLocation.Location = new System.Drawing.Point(249, 9);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(0, 25);
            this.lblFromLocation.TabIndex = 3;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(12, 82);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(167, 25);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Product Name:";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(31, 122);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(148, 25);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "Weight (KG):";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(71, 162);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(108, 25);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(209, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 32);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Add Load for Job";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(210, 85);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(190, 22);
            this.txtProductName.TabIndex = 8;
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(210, 125);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(120, 22);
            this.numWeight.TabIndex = 9;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(210, 167);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 22);
            this.numQuantity.TabIndex = 10;
            // 
            // lstLoads
            // 
            this.lstLoads.FormattingEnabled = true;
            this.lstLoads.ItemHeight = 16;
            this.lstLoads.Location = new System.Drawing.Point(76, 215);
            this.lstLoads.Name = "lstLoads";
            this.lstLoads.Size = new System.Drawing.Size(229, 84);
            this.lstLoads.TabIndex = 11;
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(36, 365);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(138, 37);
            this.btnFinish.TabIndex = 14;
            this.btnFinish.Text = "Done";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click_1);
            // 
            // btnAddLoad
            // 
            this.btnAddLoad.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLoad.Location = new System.Drawing.Point(331, 365);
            this.btnAddLoad.Name = "btnAddLoad";
            this.btnAddLoad.Size = new System.Drawing.Size(138, 37);
            this.btnAddLoad.TabIndex = 15;
            this.btnAddLoad.Text = "Add Load";
            this.btnAddLoad.UseVisualStyleBackColor = true;
            this.btnAddLoad.Click += new System.EventHandler(this.btnAddLoad_Click_1);
            // 
            // AddLoadsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddLoad);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lstLoads);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblFromLocation);
            this.Name = "AddLoadsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddLoadsForm";
            this.Load += new System.EventHandler(this.AddLoadsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFromLocation;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ListBox lstLoads;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnAddLoad;
    }
}