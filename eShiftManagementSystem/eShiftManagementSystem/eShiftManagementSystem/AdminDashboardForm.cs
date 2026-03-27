using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShiftManagementSystem
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "📋 Admin Dashboard";
        }

        private void btnViewAllJobs_Click(object sender, EventArgs e)
        {
            // Open form to view and manage all jobs
            AdminViewJobsForm jobsForm = new AdminViewJobsForm();
            jobsForm.ShowDialog();
        }

        private void btnManageTransportUnits_Click_1(object sender, EventArgs e)
        {
            // Open form to manage lorries, drivers, assistants
            ManageTransportUnitsForm unitsForm = new ManageTransportUnitsForm();
            unitsForm.ShowDialog();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            // Logout and return to login screen
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void btnViewAllJobs_Click_1(object sender, EventArgs e)
        {
            AdminViewJobsForm jobsForm = new AdminViewJobsForm();
            jobsForm.ShowDialog();
        }

        private void btnManageLoads_Click(object sender, EventArgs e)
        {
            AdminManageLoadsForm loadsForm = new AdminManageLoadsForm();
            loadsForm.ShowDialog();
        }
    }
}