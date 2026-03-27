using System;//basic .NET functionality.
using System.Data.SqlClient;//used for SQL Server database connectivity.
using System.Windows.Forms;//provides GUI controls like buttons, textboxes, forms.

namespace eShiftManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Customer");
            cmbRole.SelectedIndex = 0;
        }
        //inherits from Form, making it a Windows Form.
        //InitializeComponent() sets up the UI elements (buttons, textboxes, combobox, etc.).

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role = cmbRole.SelectedItem.ToString();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())//Opens SQL connection (via your custom DatabaseHelper.GetConnection()).
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (role == "Admin") //If role is Admin, check Admins table.
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Admins WHERE Username = @user AND Password = @pass", conn);
                    }
                    else // Customer
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE Email = @user AND Password = @pass", conn);
                    }

                    cmd.Parameters.AddWithValue("@user", username);//Passes user input safely to query.
                    cmd.Parameters.AddWithValue("@pass", password);

                    int result = (int)cmd.ExecuteScalar();

                    if (result == 1)
                    {
                        MessageBox.Show("Login successful!", "Success");

                        if (role == "Admin")
                        {
                            AdminDashboardForm adminDashboard = new AdminDashboardForm();
                            adminDashboard.Show();
                            this.Hide(); ;
                        }
                        else
                        {
                            CustomerDashboardForm dashboard = new CustomerDashboardForm(username);
                            dashboard.Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Check your credentials.", "Error");//If connection or query fails, shows error message.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);// Hides login form and opens RegisterForm for new user registration.
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm register = new RegisterForm();
            register.Show();
        }
    }
}
