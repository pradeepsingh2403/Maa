using MySql.Data.MySqlClient;

namespace Maa
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async Task<bool> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                using (var con = new MySqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();

                    string query = @"SELECT COUNT(*) 
                                 FROM admins 
                                 WHERE Email = @Email AND Password = @Password";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var result = Convert.ToInt32(cmd.ExecuteScalar());
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmailID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both email and password.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValidLogin = Login(txtEmailID.Text, txtPassword.Text);

            if (isValidLogin)
            {
                MessageBox.Show("Login successful!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new MDIParent().Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                using (var con = new MySqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();  // synchronous open

                    string query = @"SELECT COUNT(*) 
                             FROM admins 
                             WHERE Email = @Email AND Password = @Password";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var result = Convert.ToInt32(cmd.ExecuteScalar());
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login failed: {ex.Message}");
                return false;
            }
        }
    }
}
