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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eShiftManagementSystem
{
    public partial class ViewLoadsForm : Form
    {
        private int jobId;

        public ViewLoadsForm(int jobId)
        {
            InitializeComponent();
            this.jobId = jobId;
        }

        private void ViewLoadsForm_Load(object sender, EventArgs e)
        {
            // Set dynamic title
            lblTitle.Text = $"📦 Loads for Job #{jobId}";

            // Load loads from DB
            LoadLoads();
        }

        private void LoadLoads()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(@"
                SELECT 
                    LoadID, 
                    ProductName, 
                    Weight, 
                    Quantity
                FROM Loads
                WHERE JobID = @JobID", conn);

                    adapter.SelectCommand.Parameters.AddWithValue("@JobID", jobId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("⚠ No loads found for this job.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvLoads.DataSource = null; // clear table
                        return;
                    }

                    dgvLoads.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading loads: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
