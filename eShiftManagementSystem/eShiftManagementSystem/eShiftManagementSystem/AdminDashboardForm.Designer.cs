namespace eShiftManagementSystem
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnViewAllJobs = new System.Windows.Forms.Button();
            this.btnManageTransportUnits = new System.Windows.Forms.Button();
            this.btnManageLoads = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(265, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(276, 32);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "📋 Admin Dashboard";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(541, 200);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(173, 37);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // btnViewAllJobs
            // 
            this.btnViewAllJobs.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAllJobs.Location = new System.Drawing.Point(84, 111);
            this.btnViewAllJobs.Name = "btnViewAllJobs";
            this.btnViewAllJobs.Size = new System.Drawing.Size(173, 37);
            this.btnViewAllJobs.TabIndex = 17;
            this.btnViewAllJobs.Text = "View all jobs";
            this.btnViewAllJobs.UseVisualStyleBackColor = true;
            this.btnViewAllJobs.Click += new System.EventHandler(this.btnViewAllJobs_Click_1);
            // 
            // btnManageTransportUnits
            // 
            this.btnManageTransportUnits.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageTransportUnits.Location = new System.Drawing.Point(468, 111);
            this.btnManageTransportUnits.Name = "btnManageTransportUnits";
            this.btnManageTransportUnits.Size = new System.Drawing.Size(246, 37);
            this.btnManageTransportUnits.TabIndex = 16;
            this.btnManageTransportUnits.Text = "Manage Transport Units";
            this.btnManageTransportUnits.UseVisualStyleBackColor = true;
            this.btnManageTransportUnits.Click += new System.EventHandler(this.btnManageTransportUnits_Click_1);
            // 
            // btnManageLoads
            // 
            this.btnManageLoads.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageLoads.Location = new System.Drawing.Point(84, 200);
            this.btnManageLoads.Name = "btnManageLoads";
            this.btnManageLoads.Size = new System.Drawing.Size(246, 37);
            this.btnManageLoads.TabIndex = 19;
            this.btnManageLoads.Text = "Manage Loads";
            this.btnManageLoads.UseVisualStyleBackColor = true;
            this.btnManageLoads.Click += new System.EventHandler(this.btnManageLoads_Click);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageLoads);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewAllJobs);
            this.Controls.Add(this.btnManageTransportUnits);
            this.Controls.Add(this.lblTitle);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboardForm";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnViewAllJobs;
        private System.Windows.Forms.Button btnManageTransportUnits;
        private System.Windows.Forms.Button btnManageLoads;
    }
}