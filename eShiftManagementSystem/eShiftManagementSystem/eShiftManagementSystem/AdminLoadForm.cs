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
    public partial class AdminLoadForm : Form
    {
        private int? loadId; // null = Add mode, value = Edit mode

        public AdminLoadForm(int? loadId = null)
        {
            InitializeComponent();
            this.loadId = loadId;
        }

        private void AdminLoadForm_Load(object sender, EventArgs e)
        {
            if (loadId.HasValue)
            {
                this.Text = "Edit Load";
                LoadLoadDetails();
            }
            else
            {
                this.Text = "Add New Load";
            }
        }

        private void LoadLoadDetails()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT JobID, ProductName, Weight, Quantity FROM Loads WHERE LoadID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", loadId.Value);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtJobID.Text = reader["JobID"].ToString();
                        txtProductName.Text = reader["ProductName"].ToString();
                        numWeight.Value = Convert.ToDecimal(reader["Weight"]);
                        numQuantity.Value = Convert.ToInt32(reader["Quantity"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading load details: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobID.Text) || string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please fill in Job ID and Product Name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (loadId.HasValue) // Update
                    {
                        cmd = new SqlCommand(@"
                            UPDATE Loads
                            SET JobID = @job, ProductName = @product, Weight = @weight, Quantity = @qty
                            WHERE LoadID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", loadId.Value);
                    }
                    else // Insert
                    {
                        cmd = new SqlCommand(@"
                            INSERT INTO Loads (JobID, ProductName, Weight, Quantity)
                            VALUES (@job, @product, @weight, @qty)", conn);
                    }

                    cmd.Parameters.AddWithValue("@job", Convert.ToInt32(txtJobID.Text.Trim()));
                    cmd.Parameters.AddWithValue("@product", txtProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@weight", numWeight.Value);
                    cmd.Parameters.AddWithValue("@qty", numQuantity.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Load saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving load: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}