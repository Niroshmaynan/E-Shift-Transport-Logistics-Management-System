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
    public partial class ManageTransportUnitsForm : Form
    {
        private DataTable unitsTable;

        public ManageTransportUnitsForm()
        {
            InitializeComponent();
        }

        private void ManageTransportUnitsForm_Load(object sender, EventArgs e)
        {
            LoadUnits();
        }

        private void LoadUnits()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TransportUnits", conn);
                    unitsTable = new DataTable();
                    adapter.Fill(unitsTable);
                    dgvUnits.DataSource = unitsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading units: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TransportUnitForm unitForm = new TransportUnitForm();
            if (unitForm.ShowDialog() == DialogResult.OK)
            {
                LoadUnits();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUnits.SelectedRows.Count > 0)
            {
                int unitId = Convert.ToInt32(dgvUnits.SelectedRows[0].Cells["UnitID"].Value);
                TransportUnitForm unitForm = new TransportUnitForm(unitId);
                if (unitForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUnits();
                }
            }
            else
            {
                MessageBox.Show("Please select a unit to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUnits.SelectedRows.Count > 0)
            {
                int unitId = Convert.ToInt32(dgvUnits.SelectedRows[0].Cells["UnitID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this unit?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("DELETE FROM TransportUnits WHERE UnitID = @id", conn);
                            cmd.Parameters.AddWithValue("@id", unitId);
                            cmd.ExecuteNonQuery();
                            LoadUnits();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting unit: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a unit to delete.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
