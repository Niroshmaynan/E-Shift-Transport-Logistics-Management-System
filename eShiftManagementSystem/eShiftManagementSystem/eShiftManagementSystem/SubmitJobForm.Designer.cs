namespace eShiftManagementSystem
{
    partial class SubmitJobForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmitJobForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFromLocation = new System.Windows.Forms.Label();
            this.txtFromLocation = new System.Windows.Forms.TextBox();
            this.lblToLocation = new System.Windows.Forms.Label();
            this.txtToLocation = new System.Windows.Forms.TextBox();
            this.lblJobDate = new System.Windows.Forms.Label();
            this.dtpJobDate = new System.Windows.Forms.DateTimePicker();
            this.lblDistance = new System.Windows.Forms.Label();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(259, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Submit New Job";
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.AutoSize = true;
            this.lblFromLocation.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromLocation.Location = new System.Drawing.Point(24, 73);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(170, 25);
            this.lblFromLocation.TabIndex = 2;
            this.lblFromLocation.Text = "From Location:";
            // 
            // txtFromLocation
            // 
            this.txtFromLocation.Location = new System.Drawing.Point(225, 76);
            this.txtFromLocation.Name = "txtFromLocation";
            this.txtFromLocation.Size = new System.Drawing.Size(187, 22);
            this.txtFromLocation.TabIndex = 3;
            // 
            // lblToLocation
            // 
            this.lblToLocation.AutoSize = true;
            this.lblToLocation.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToLocation.Location = new System.Drawing.Point(55, 116);
            this.lblToLocation.Name = "lblToLocation";
            this.lblToLocation.Size = new System.Drawing.Size(139, 25);
            this.lblToLocation.TabIndex = 4;
            this.lblToLocation.Text = "To Location:";
            // 
            // txtToLocation
            // 
            this.txtToLocation.Location = new System.Drawing.Point(225, 121);
            this.txtToLocation.Name = "txtToLocation";
            this.txtToLocation.Size = new System.Drawing.Size(187, 22);
            this.txtToLocation.TabIndex = 5;
            // 
            // lblJobDate
            // 
            this.lblJobDate.AutoSize = true;
            this.lblJobDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobDate.Location = new System.Drawing.Point(83, 159);
            this.lblJobDate.Name = "lblJobDate";
            this.lblJobDate.Size = new System.Drawing.Size(111, 25);
            this.lblJobDate.TabIndex = 6;
            this.lblJobDate.Text = "Job Date:";
            // 
            // dtpJobDate
            // 
            this.dtpJobDate.Location = new System.Drawing.Point(225, 166);
            this.dtpJobDate.Name = "dtpJobDate";
            this.dtpJobDate.Size = new System.Drawing.Size(200, 22);
            this.dtpJobDate.TabIndex = 7;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(25, 202);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(169, 25);
            this.lblDistance.TabIndex = 8;
            this.lblDistance.Text = "Distance (KM):";
            // 
            // numDistance
            // 
            this.numDistance.Location = new System.Drawing.Point(225, 211);
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(120, 22);
            this.numDistance.TabIndex = 9;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(287, 362);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(138, 37);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit Job";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(17, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 37);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Weight (KG):";
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(225, 250);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(120, 22);
            this.numWeight.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.LightGray;
            this.txtPrice.Location = new System.Drawing.Point(225, 292);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(187, 22);
            this.txtPrice.TabIndex = 17;
            // 
            // SubmitJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.numDistance);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.dtpJobDate);
            this.Controls.Add(this.lblJobDate);
            this.Controls.Add(this.txtToLocation);
            this.Controls.Add(this.lblToLocation);
            this.Controls.Add(this.txtFromLocation);
            this.Controls.Add(this.lblFromLocation);
            this.Controls.Add(this.lblTitle);
            this.Name = "SubmitJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubmitJobForm";
            this.Load += new System.EventHandler(this.SubmitJobForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFromLocation;
        private System.Windows.Forms.TextBox txtFromLocation;
        private System.Windows.Forms.Label lblToLocation;
        private System.Windows.Forms.TextBox txtToLocation;
        private System.Windows.Forms.Label lblJobDate;
        private System.Windows.Forms.DateTimePicker dtpJobDate;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.NumericUpDown numDistance;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
    }
}