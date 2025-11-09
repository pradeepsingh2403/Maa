using Maa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maa_v2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = LoginUser(email, password);
            if (success)
            {
               // MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open main form or dashboard
                this.Hide();
                new MDIParent().Show();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool LoginUser(string email, string password)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    string query = @"
                SELECT id, name, role_id, password, status
                FROM dbo.admins
                WHERE email = @Email AND password=@Password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isActive = Convert.ToBoolean(reader["status"]);
                                string storedPassword = reader["password"].ToString();

                                if (!isActive)
                                {
                                    MessageBox.Show("Your account is inactive. Contact admin.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                                if (storedPassword == password) // If passwords are plain text
                                {
                                    GlobalFunctions.userId = Convert.ToInt32(reader["id"]);
                                    GlobalFunctions.userName = reader["name"].ToString();
                                    GlobalFunctions.role = Convert.ToInt32(reader["role_id"].ToString());
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email not found.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
