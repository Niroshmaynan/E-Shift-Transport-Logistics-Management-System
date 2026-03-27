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
    public partial class AddLoadsForm : Form
    {
        private int jobId;

        public AddLoadsForm(int jobId)
        {
            InitializeComponent();
            this.jobId = jobId;
        }

        private void AddLoadsForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Add Loads for Job #" + jobId;
            numWeight.DecimalPlaces = 2;
            numQuantity.Minimum = 1;
        }

        private void btnAddLoad_Click_1(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            decimal weight = numWeight.Value;
            int quantity = (int)numQuantity.Value;

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please enter the product name.");
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Loads (JobID, ProductName, Weight, Quantity)
                VALUES (@JobID, @Name, @Weight, @Qty)", conn);

                    cmd.Parameters.AddWithValue("@JobID", jobId);
                    cmd.Parameters.AddWithValue("@Name", productName);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@Qty", quantity);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("✅ Load added successfully.");

                        // Show in the ListBox
                        lstLoads.Items.Add($"{productName} | {weight} KG | x{quantity}");

                        // Reset input fields
                        txtProductName.Clear();
                        numWeight.Value = 0;
                        numQuantity.Value = 1;
                    }
                    else
                    {
                        MessageBox.Show("❌ Failed to add load.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("🚨 Error: " + ex.Message);
            }
        }

        private void btnFinish_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}