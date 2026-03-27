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
    public partial class AdminViewJobsForm : Form
    {
        private DataTable transportUnitsTable;
        private DataTable jobsTable;

        public AdminViewJobsForm()
        {
            InitializeComponent();
        }

        private void AdminViewJobsForm_Load(object sender, EventArgs e)
        {
            LoadTransportUnits();
            LoadJobs();
        }

        private void LoadTransportUnits()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT UnitID, LorryNumber FROM TransportUnits", conn);
                    transportUnitsTable = new DataTable();
                    adapter.Fill(transportUnitsTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transport units: " + ex.Message);
            }
        }

        private void LoadJobs(string searchTerm = "")
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    J.JobID,
                    C.FullName AS Customer,
                    J.FromLocation,
                    J.ToLocation,
                    J.JobDate,
                    J.DistanceKM,
                    J.TotalWeightKG,
                    J.Price,
                    J.Status,
                    J.TransportUnitID
                FROM Jobs J
                INNER JOIN Customers C ON J.CustomerID = C.CustomerID
                WHERE (@search = '' OR 
                       C.FullName LIKE '%' + @search + '%' OR 
                       CAST(J.JobID AS NVARCHAR) LIKE '%' + @search + '%')
                ORDER BY J.JobID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@search", searchTerm);

                    jobsTable = new DataTable();
                    adapter.Fill(jobsTable);

                    dgvAllJobs.DataSource = jobsTable;

                    // Ensure AutoGenerateColumns is ON so columns appear
                    dgvAllJobs.AutoGenerateColumns = true;

                    // Rebuild Status column safely
                    DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
                    {
                        DataPropertyName = "Status",
                        HeaderText = "Status"
                    };
                    statusColumn.Items.AddRange("Pending", "Assigned", "Completed");

                    if (dgvAllJobs.Columns.Contains("Status"))
                    {
                        int statusIndex = dgvAllJobs.Columns["Status"].Index;
                        dgvAllJobs.Columns.RemoveAt(statusIndex);
                        dgvAllJobs.Columns.Insert(statusIndex, statusColumn);
                    }
                    else
                    {
                        dgvAllJobs.Columns.Add(statusColumn);
                    }

                    // Rebuild Transport Unit column safely
                    DataGridViewComboBoxColumn unitColumn = new DataGridViewComboBoxColumn
                    {
                        DataPropertyName = "TransportUnitID",
                        HeaderText = "Transport Unit",
                        DataSource = transportUnitsTable,
                        DisplayMember = "LorryNumber",
                        ValueMember = "UnitID"
                    };

                    if (dgvAllJobs.Columns.Contains("TransportUnitID"))
                    {
                        int unitIndex = dgvAllJobs.Columns["TransportUnitID"].Index;
                        dgvAllJobs.Columns.RemoveAt(unitIndex);
                        dgvAllJobs.Columns.Insert(unitIndex, unitColumn);
                    }
                    else
                    {
                        dgvAllJobs.Columns.Add(unitColumn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading jobs: " + ex.Message);
            }
        }

        private void btnSaveChanges_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    foreach (DataRow row in jobsTable.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            SqlCommand cmd = new SqlCommand(@"
                                UPDATE Jobs 
                                SET Status = @Status, TransportUnitID = @UnitID
                                WHERE JobID = @JobID", conn);

                            cmd.Parameters.AddWithValue("@Status", row["Status"]);
                            cmd.Parameters.AddWithValue("@UnitID", row["TransportUnitID"] == DBNull.Value ? (object)DBNull.Value : row["TransportUnitID"]);
                            cmd.Parameters.AddWithValue("@JobID", row["JobID"]);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("✅ Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadJobs(); // Refresh
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTransportUnits();
            LoadJobs();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (jobsTable == null || jobsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No jobs available to generate a report.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.FileName = "Jobs_Report.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder csvData = new StringBuilder();

                        // Add headers
                        string[] columnNames = jobsTable.Columns.Cast<DataColumn>()
                            .Select(col => col.ColumnName).ToArray();
                        csvData.AppendLine(string.Join(",", columnNames));

                        // Add rows
                        foreach (DataRow row in jobsTable.Rows)
                        {
                            string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                            csvData.AppendLine(string.Join(",", fields));
                        }

                        // Summary
                        int totalJobs = jobsTable.Rows.Count;
                        int completedJobs = jobsTable.AsEnumerable().Count(r => r["Status"].ToString() == "Completed");
                        int pendingJobs = jobsTable.AsEnumerable().Count(r => r["Status"].ToString() == "Pending");
                        decimal totalRevenue = jobsTable.AsEnumerable()
                            .Where(r => decimal.TryParse(r["Price"].ToString(), out _))
                            .Sum(r => Convert.ToDecimal(r["Price"]));

                        csvData.AppendLine();
                        csvData.AppendLine($"Total Jobs:,{totalJobs}");
                        csvData.AppendLine($"Completed Jobs:,{completedJobs}");
                        csvData.AppendLine($"Pending Jobs:,{pendingJobs}");
                        csvData.AppendLine($"Total Revenue:,{totalRevenue}");

                        System.IO.File.WriteAllText(sfd.FileName, csvData.ToString());
                        MessageBox.Show("✅ Report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadJobs(txtSearch.Text.Trim());
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadJobs();
        }
    }
}
