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
    public partial class SubmitJobForm : Form
    {
        private string customerEmail;

        public SubmitJobForm(string email)
        {
            InitializeComponent();
            customerEmail = email;
        }

        private void SubmitJobForm_Load(object sender, EventArgs e)
        {
            // Default date
            dtpJobDate.Value = DateTime.Today;

            // Attach live price calculation
            numDistance.ValueChanged += (s, ev) => CalculateTotalPrice();
            numWeight.ValueChanged += (s, ev) => CalculateTotalPrice();

            // Initial calculation
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            decimal distance = numDistance.Value;
            decimal weight = numWeight.Value;
            decimal rate = 0.10m; // Rate per KM per KG

            decimal price = distance * weight * rate;
            txtPrice.Text = price.ToString("0.00");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string fromLocation = txtFromLocation.Text.Trim();
            string toLocation = txtToLocation.Text.Trim();
            DateTime jobDate = dtpJobDate.Value;
            decimal distance = numDistance.Value;
            decimal weight = numWeight.Value;
            decimal price;

            if (fromLocation == "" || toLocation == "")
            {
                MessageBox.Show("Please fill in both From and To locations.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Invalid calculated price.");
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Get CustomerID
                    SqlCommand getIdCmd = new SqlCommand("SELECT CustomerID FROM Customers WHERE Email = @Email", conn);
                    getIdCmd.Parameters.AddWithValue("@Email", customerEmail);

                    object result = getIdCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Could not find customer.");
                        return;
                    }

                    int customerId = (int)result;

                    // Insert Job
                    SqlCommand insertCmd = new SqlCommand(@"
                        INSERT INTO Jobs 
                        (CustomerID, FromLocation, ToLocation, JobDate, DistanceKM, TotalWeightKG, Price)
                        VALUES 
                        (@CustomerID, @From, @To, @JobDate, @Distance, @Weight, @Price)", conn);

                    insertCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    insertCmd.Parameters.AddWithValue("@From", fromLocation);
                    insertCmd.Parameters.AddWithValue("@To", toLocation);
                    insertCmd.Parameters.AddWithValue("@JobDate", jobDate);
                    insertCmd.Parameters.AddWithValue("@Distance", distance);
                    insertCmd.Parameters.AddWithValue("@Weight", weight);
                    insertCmd.Parameters.AddWithValue("@Price", price);

                    int rows = insertCmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Job submitted successfully!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to submit job.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            string fromLocation = txtFromLocation.Text.Trim();
            string toLocation = txtToLocation.Text.Trim();
            DateTime jobDate = dtpJobDate.Value;
            decimal distance = numDistance.Value;
            decimal weight = numWeight.Value;
            decimal price;

            // Validate user input
            if (fromLocation == "" || toLocation == "")
            {
                MessageBox.Show("Please fill in both 'From Location' and 'To Location'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Invalid calculated price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Get CustomerID using email
                    SqlCommand getIdCmd = new SqlCommand("SELECT CustomerID FROM Customers WHERE Email = @Email", conn);
                    getIdCmd.Parameters.AddWithValue("@Email", customerEmail);

                    object result = getIdCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Customer not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int customerId = (int)result;

                    // Insert new Job record and return JobID
                    SqlCommand insertCmd = new SqlCommand(@"
                INSERT INTO Jobs 
                (CustomerID, FromLocation, ToLocation, JobDate, DistanceKM, TotalWeightKG, Price)
                VALUES 
                (@CustomerID, @From, @To, @JobDate, @Distance, @Weight, @Price);
                SELECT SCOPE_IDENTITY();", conn);  // <--- Added SELECT here

                    insertCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    insertCmd.Parameters.AddWithValue("@From", fromLocation);
                    insertCmd.Parameters.AddWithValue("@To", toLocation);
                    insertCmd.Parameters.AddWithValue("@JobDate", jobDate);
                    insertCmd.Parameters.AddWithValue("@Distance", distance);
                    insertCmd.Parameters.AddWithValue("@Weight", weight);
                    insertCmd.Parameters.AddWithValue("@Price", price);

                    // Get the newly inserted JobID
                    int newJobId = Convert.ToInt32(insertCmd.ExecuteScalar());

                    if (newJobId > 0)
                    {
                        MessageBox.Show("✅ Job submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Open AddLoadsForm to add loads for this job
                        AddLoadsForm loadForm = new AddLoadsForm(newJobId);
                        loadForm.ShowDialog();

                        this.Close(); // Close the submit job form
                    }
                    else
                    {
                        MessageBox.Show("❌ Job submission failed. Please try again.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("🚨 Error while submitting job:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}