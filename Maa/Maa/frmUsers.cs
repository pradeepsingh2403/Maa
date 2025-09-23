using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Maa
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();

            // Load event and grid setup
            frmUsers_Load(this, EventArgs.Empty);
            dgv.CellDoubleClick += Dgv_CellDoubleClick;

            // Load users from database
            LoadUsers();
            LoadRolesCombo(cmbRole);
            LoadStatusComboFromDb(cmbStatus);
            GenerateZigZagPassword();
        }
        private void GenerateZigZagPassword()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            Random rnd = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                if (i % 2 == 0) // Even index → letter
                    password.Append(letters[rnd.Next(letters.Length)]);
                else            // Odd index → number
                    password.Append(numbers[rnd.Next(numbers.Length)]);
            }

            txtPassword.Text = password.ToString();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            // DataGridView styling
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;

            // Header styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 155);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            // Row styling
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
        }

        private void LoadUsers()
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;

                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"SELECT id, name, image, email, phone,password, status, role_id, created_at, updated_at 
                           FROM admins";

                    using (var adapter = new MySqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgv.DataSource = dt;

                        // Optional: hide ID and role_id columns
                        if (dgv.Columns.Contains("id")) dgv.Columns["id"].Visible = false;
                        if (dgv.Columns.Contains("role_id")) dgv.Columns["role_id"].Visible = false;

                        // Rename headers
                        if (dgv.Columns.Contains("name")) dgv.Columns["name"].HeaderText = "Name";
                        if (dgv.Columns.Contains("image")) dgv.Columns["image"].HeaderText = "Image";
                        if (dgv.Columns.Contains("email")) dgv.Columns["email"].HeaderText = "Email";
                        if (dgv.Columns.Contains("phone")) dgv.Columns["phone"].HeaderText = "Phone";
                        if (dgv.Columns.Contains("password")) dgv.Columns["password"].HeaderText = "Password";
                        if (dgv.Columns.Contains("status")) dgv.Columns["status"].HeaderText = "Status";
                        if (dgv.Columns.Contains("created_at")) dgv.Columns["created_at"].HeaderText = "Created At";
                        if (dgv.Columns.Contains("updated_at")) dgv.Columns["updated_at"].HeaderText = "Updated At";

                        // Align headers and cells
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        }

                        // Optional: show image in a PictureBox or use a DataGridViewImageColumn if required
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admins: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Store selected user/admin ID for update/delete
        private int selectedUserId = 0;

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                // Transfer values to textboxes
                txtUserName.Text = row.Cells["name"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phone"].Value?.ToString() ?? "";
                txtPassword.Text = row.Cells["password"].Value?.ToString() ?? "";

                // Set Role ComboBox
                if (cmbRole.Items.Count > 0 && row.Cells["role_id"].Value != null)
                    cmbRole.SelectedValue = Convert.ToInt32(row.Cells["role_id"].Value);

                // Set Status ComboBox
                if (cmbStatus.Items.Count > 0 && row.Cells["status"].Value != null)
                    cmbStatus.SelectedValue = Convert.ToInt32(row.Cells["status"].Value);

                // Store selected ID
                selectedUserId = Convert.ToInt32(row.Cells["id"].Value);
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get selected role and status IDs from ComboBoxes
            int roleId = cmbRole.SelectedValue != null ? Convert.ToInt32(cmbRole.SelectedValue) : 0;
            int statusId = cmbStatus.SelectedValue != null ? Convert.ToInt32(cmbStatus.SelectedValue) : 0;

            // Use the txtPassword text for password
            string password = txtPassword.Text.Trim();

            // Call insert method
            InsertUsers(txtUserName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), password, roleId, statusId);
        }

        private void InsertUsers(string name, string email, string phone, string password, int roleId, int statusId)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all required fields (Name, Email, Password).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"INSERT INTO admins 
                           (name, image, email, phone, password, status, role_id, created_at, updated_at) 
                           VALUES (@name, @image, @email, @phone, @password, @status, @role_id, NOW(), NOW())";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone ?? "");
                        cmd.Parameters.AddWithValue("@password", password); // ⚠️ Hash in production!
                        cmd.Parameters.AddWithValue("@role_id", roleId);
                        cmd.Parameters.AddWithValue("@status", statusId);
                        cmd.Parameters.AddWithValue("@image", DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Admin added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers(); // Refresh DataGridView
                            ClearData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void UpdateUser()
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Please select a record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtUserName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            int roleId = cmbRole.SelectedValue != null ? Convert.ToInt32(cmbRole.SelectedValue) : 0;
            int statusId = cmbStatus.SelectedValue != null ? Convert.ToInt32(cmbStatus.SelectedValue) : 0;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all required fields (Name, Email, Password).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"UPDATE admins
                           SET name = @name,
                               email = @email,
                               phone = @phone,
                               password = @password,
                               role_id = @role_id,
                               status = @status,
                               updated_at = NOW()
                           WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone ?? "");
                        cmd.Parameters.AddWithValue("@password", password); // ⚠️ Hash in production
                        cmd.Parameters.AddWithValue("@role_id", roleId);
                        cmd.Parameters.AddWithValue("@status", statusId);
                        cmd.Parameters.AddWithValue("@id", selectedUserId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Admin updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to update admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRolesCombo(ComboBox cmbRole)
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT id, name FROM roles ORDER BY name";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            cmbRole.DisplayMember = "name"; // what user sees
                            cmbRole.ValueMember = "id";     // actual value
                            cmbRole.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatusComboFromDb(ComboBox cmbStatus)
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT id, status FROM status ORDER BY status";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            cmbStatus.DisplayMember = "status";  // What user sees
                            cmbStatus.ValueMember = "id";        // Actual value used internally
                            cmbStatus.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ClearData()
        {
            txtUserName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            GenerateZigZagPassword();
            txtUserName.Focus();
        }

        private void frmUsers_Load_1(object sender, EventArgs e)
        {

        }
    }
}
