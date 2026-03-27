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
    public partial class ViewJobsForm : Form
    {
        private string customerEmail;

        public ViewJobsForm(string email)
        {
            InitializeComponent();
            customerEmail = email;
        }

        private void ViewJobsForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "📋 Your Submitted Jobs";
            LoadJobs();
        }

        private void LoadJobs()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Get the customer's ID using their email
                    SqlCommand getIdCmd = new SqlCommand("SELECT CustomerID FROM Customers WHERE Email = @Email", conn);
                    getIdCmd.Parameters.AddWithValue("@Email", customerEmail);
                    object result = getIdCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("❌ Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int customerId = (int)result;

                    // Load all jobs for that customer
                    SqlDataAdapter adapter = new SqlDataAdapter(@"
                        SELECT 
                            JobID, 
                            FromLocation AS [From], 
                            ToLocation AS [To], 
                            JobDate AS [Date], 
                            DistanceKM AS [KM], 
                            TotalWeightKG AS [Weight (KG)], 
                            Price, 
                            Status
                        FROM Jobs 
                        WHERE CustomerID = @CustomerID
                        ORDER BY JobDate ASC", conn);

                    adapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvJobs.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("🚨 Error loading jobs:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewLoads_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get JobID from selected row
            int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);

            // Open ViewLoadsForm with JobID
            ViewLoadsForm loadsForm = new ViewLoadsForm(jobId);
            loadsForm.ShowDialog();
        }
    }
}