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
    public partial class AdminManageLoadsForm : Form
    {
        private DataTable loadsTable;

        public AdminManageLoadsForm()
        {
            InitializeComponent();
        }

        private void AdminManageLoadsForm_Load(object sender, EventArgs e)
        {
            LoadAllLoads();
        }

        private void LoadAllLoads(string jobIdFilter = "")
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT LoadID, JobID, ProductName, Weight, Quantity
                        FROM Loads";

                    if (!string.IsNullOrWhiteSpace(jobIdFilter))
                        query += " WHERE JobID = @jobId";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    if (!string.IsNullOrWhiteSpace(jobIdFilter))
                        adapter.SelectCommand.Parameters.AddWithValue("@jobId", jobIdFilter);

                    loadsTable = new DataTable();
                    adapter.Fill(loadsTable);
                    dgvLoads.DataSource = loadsTable;

                    dgvLoads.ReadOnly = true;
                    dgvLoads.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvLoads.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading loads: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllLoads(txtJobIDFilter.Text.Trim());
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtJobIDFilter.Clear();
            LoadAllLoads();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminLoadForm loadForm = new AdminLoadForm();
            if (loadForm.ShowDialog() == DialogResult.OK)
                LoadAllLoads(txtJobIDFilter.Text.Trim());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLoads.SelectedRows.Count > 0)
            {
                int loadId = Convert.ToInt32(dgvLoads.SelectedRows[0].Cells["LoadID"].Value);
                AdminLoadForm loadForm = new AdminLoadForm(loadId);
                if (loadForm.ShowDialog() == DialogResult.OK)
                    LoadAllLoads(txtJobIDFilter.Text.Trim());
            }
            else
            {
                MessageBox.Show("Please select a load to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLoads.SelectedRows.Count > 0)
            {
                int loadId = Convert.ToInt32(dgvLoads.SelectedRows[0].Cells["LoadID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this load?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("DELETE FROM Loads WHERE LoadID = @id", conn);
                            cmd.Parameters.AddWithValue("@id", loadId);
                            cmd.ExecuteNonQuery();
                            LoadAllLoads(txtJobIDFilter.Text.Trim());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting load: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a load to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
