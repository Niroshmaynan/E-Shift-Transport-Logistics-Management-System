using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eShiftManagementSystem
{
    public partial class CustomerDashboardForm : Form
    {
        private string customerEmail;

        // Modified constructor to accept email
        public CustomerDashboardForm(string email)
        {
            InitializeComponent();
            customerEmail = email;
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT FullName FROM Customers WHERE Email = @Email", conn);
                    cmd.Parameters.AddWithValue("@Email", customerEmail);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string fullName = result.ToString();
                        lblWelcome.Text = $"Welcome, {fullName}!";
                    }
                    else
                    {
                        lblWelcome.Text = "Welcome!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading customer info: " + ex.Message);
                }
            }
        }

        private void btnSubmitJob_Click(object sender, EventArgs e)
        {
            SubmitJobForm jobForm = new SubmitJobForm(customerEmail);
            jobForm.ShowDialog(); // Use ShowDialog to block until closed
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close the current form and return to the login form
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnMyJobs_Click(object sender, EventArgs e)
        {
            ViewJobsForm viewForm = new ViewJobsForm(customerEmail);
            viewForm.ShowDialog();
        }
    }
}