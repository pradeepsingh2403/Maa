using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maa
{
    public partial class frmAddScheme : Form
    {
        public frmAddScheme()
        {
            InitializeComponent();
            frmAddSchema_Load(this, EventArgs.Empty);
            LoadSchemes();
            LoadStatusComboFromDb(cmbStatus);
            dgv.CellDoubleClick += dgv_CellDoubleClick; // attach event
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            RolePermission permission = GlobalFunctions.GetRolePermission(GlobalFunctions.role, this.Name);
            if (permission != null)
            {
                btnAdd.Enabled = permission.CanSave;
                btnUpdate.Enabled = permission.CanUpdate;
                btnDelete.Enabled = permission.CanDelete;
            }
        }

        private void frmAddSchema_Load(object sender, EventArgs e)
        {
            // === GroupBox setup ===
            groupBox1.Top = 20;
            groupBox1.Left = 10;
            groupBox1.Width = this.ClientSize.Width - 20;
            groupBox1.Height = 140;

            this.Resize += (s, ev) =>
            {
                groupBox1.Width = this.ClientSize.Width - 20;
                dgv.Top = groupBox1.Bottom + 10;
                dgv.Width = this.ClientSize.Width - 20;
                dgv.Height = this.ClientSize.Height - dgv.Top - 20;
            };

            // === DataGridView setup ===
            dgv = new DataGridView
            {
                Top = groupBox1.Bottom + 10,
                Left = 10,
                Width = this.ClientSize.Width - 20,
                Height = this.ClientSize.Height - (groupBox1.Bottom + 20),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 155);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
            this.Controls.Add(dgv);
        }

        // Make dgv accessible
        private DataGridView dgv;

        private void LoadSchemes()
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;

                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"SELECT id, name, status, created_at, updated_at 
                           FROM schemes";

                    using (var adapter = new SqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgv.DataSource = dt;

                        // Hide ID column if not needed
                        if (dgv.Columns.Contains("id")) dgv.Columns["id"].Visible = false;

                        // Rename headers for readability
                        if (dgv.Columns.Contains("name")) dgv.Columns["name"].HeaderText = "Scheme Name";
                        if (dgv.Columns.Contains("status")) dgv.Columns["status"].HeaderText = "Status";
                        if (dgv.Columns.Contains("created_at")) dgv.Columns["created_at"].HeaderText = "Created At";
                        if (dgv.Columns.Contains("updated_at")) dgv.Columns["updated_at"].HeaderText = "Updated At";

                        // Align headers and cells
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schemes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadStatusComboFromDb(ComboBox cmbStatus)
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT id, status FROM status ORDER BY status";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertScheme(txtSchemeName.Text.Trim(),Convert.ToInt32( cmbStatus.SelectedValue));  
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateScheme(selectedSchemeId, txtSchemeName.Text.Trim(), Convert.ToInt32(cmbStatus.SelectedValue));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteScheme(selectedSchemeId);
        }

        int selectedSchemeId = 0; // declare at class level


        private void DeleteScheme(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("Please select a scheme to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this scheme?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"DELETE FROM schemes WHERE id = @id";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Scheme deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSchemes(); // refresh grid after delete
                            txtSchemeName.Text = "";
                            cmbStatus.SelectedIndex = 0;
                            txtSchemeName.Focus();
                            btnAdd.Enabled = true;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Scheme not found or already deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting scheme: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                // transfer values to controls
                txtSchemeName.Text = row.Cells["name"].Value?.ToString();

                // Handle status (make sure cmbStatus is bound with id/value properly)
                if (row.Cells["status"].Value != null)
                {
                    cmbStatus.SelectedValue = Convert.ToInt32(row.Cells["status"].Value);
                }

                // Store selected ID for update/delete later
                selectedSchemeId = Convert.ToInt32(row.Cells["id"].Value);
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                RolePermission permission = GlobalFunctions.GetRolePermission(GlobalFunctions.role, this.Name);
                if (permission != null)
                {
                    btnAdd.Enabled = permission.CanSave;
                    btnUpdate.Enabled = permission.CanUpdate;
                    btnDelete.Enabled = permission.CanDelete;
                }

            }
        }

        private void InsertScheme(string name, int status)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a scheme name.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = GlobalFunctions.ConnString;

                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"INSERT INTO schemes 
                           (name, status, created_at, updated_at) 
                           VALUES (@name, @status, GETDATE(), GETDATE())";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@status", status);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Scheme added successfully!",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSchemes(); // refresh grid
                            txtSchemeName.Text = "";
                            cmbStatus.SelectedIndex = 0;
                            txtSchemeName.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add scheme.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting scheme: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateScheme(int id, string name, int status)
        {
            if (id <= 0)
            {
                MessageBox.Show("Please select a scheme to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Scheme name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"UPDATE schemes 
                           SET name = @name, 
                               status = @status, 
                               updated_at = GETDATE() 
                           WHERE id = @id";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@status", status);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Scheme updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSchemes(); // refresh grid
                            txtSchemeName.Text = "";
                            cmbStatus.SelectedIndex = 0;
                            txtSchemeName.Focus();
                            btnAdd.Enabled = true;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No changes made to the scheme.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating scheme: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
