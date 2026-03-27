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
    public partial class TransportUnitForm : Form
    {
        private int? unitId; // null = Add mode, not null = Edit mode

        public TransportUnitForm(int? id = null)
        {
            InitializeComponent();
            unitId = id;
        }

        private void TransportUnitForm_Load(object sender, EventArgs e)
        {
            if (unitId.HasValue)
            {
                LoadUnitData();
                this.Text = "Edit Transport Unit";
            }
            else
            {
                this.Text = "Add Transport Unit";
            }
        }

        private void LoadUnitData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM TransportUnits WHERE UnitID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", unitId.Value);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtLorryNumber.Text = reader["LorryNumber"].ToString();
                        txtDriverName.Text = reader["DriverName"].ToString();
                        txtAssistantName.Text = reader["AssistantName"].ToString();
                        txtContainerType.Text = reader["ContainerType"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transport unit: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLorryNumber.Text))
            {
                MessageBox.Show("Lorry number is required.");
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 🔹 Check for duplicate Lorry Number
                    SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM TransportUnits WHERE LorryNumber = @lorry" +
                        (unitId.HasValue ? " AND UnitID <> @id" : ""), conn);

                    checkCmd.Parameters.AddWithValue("@lorry", txtLorryNumber.Text.Trim());
                    if (unitId.HasValue)
                        checkCmd.Parameters.AddWithValue("@id", unitId.Value);

                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("❌ A transport unit with this Lorry Number already exists.");
                        return;
                    }

                    // 🔹 Prepare Insert or Update command
                    SqlCommand cmd;
                    if (unitId.HasValue) // Edit
                    {
                        cmd = new SqlCommand(@"
                    UPDATE TransportUnits
                    SET LorryNumber = @lorry, DriverName = @driver, AssistantName = @assistant, ContainerType = @container
                    WHERE UnitID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", unitId.Value);
                    }
                    else // Add
                    {
                        cmd = new SqlCommand(@"
                    INSERT INTO TransportUnits (LorryNumber, DriverName, AssistantName, ContainerType)
                    VALUES (@lorry, @driver, @assistant, @container)", conn);
                    }

                    cmd.Parameters.AddWithValue("@lorry", txtLorryNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@driver", txtDriverName.Text.Trim());
                    cmd.Parameters.AddWithValue("@assistant", txtAssistantName.Text.Trim());
                    cmd.Parameters.AddWithValue("@container", txtContainerType.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Transport Unit saved successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("🚨 Error saving transport unit: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
