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
    public partial class frmRole : Form
    {
        public frmRole()
        {
            InitializeComponent();
            CreateDataGridView();
            LoadRoles();
            btnDelete.Enabled = false;
            RolePermission permission = GlobalFunctions.GetRolePermission(GlobalFunctions.role, this.Name);
            if (permission != null)
            {
                btnAdd.Enabled = permission.CanSave;
                btnDelete.Enabled = permission.CanDelete;
            }

        }

        private DataGridView dgv;
        private int selectedRoleId = -1;

        private void CreateDataGridView()
        {
            dgv = new DataGridView
            {
                Top = groupBox1.Bottom + 10,
                Left = 10,
                Width = this.ClientSize.Width - 20,
                Height = this.ClientSize.Height - (groupBox1.Bottom + 20),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 10),
                MultiSelect = false,
                EnableHeadersVisualStyles = false
            };

            // Header styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 155);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            // Row styling
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
            dgv.GridColor = Color.LightGray;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.Controls.Add(dgv);
            dgv.CellDoubleClick += Dgv_CellDoubleClick;
            // Resize handler
            this.Resize += (s, e) =>
            {
                dgv.Width = this.ClientSize.Width - 20;
                dgv.Height = this.ClientSize.Height - (groupBox1.Bottom + 20);
            };
        }

        // --- Load roles from SQL Server ---
        private void LoadRoles()
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT id, name, created_at, updated_at FROM roles";
                    using (var adapter = new SqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv.DataSource = dt;

                        // Hide ID column
                        if (dgv.Columns.Contains("id")) dgv.Columns["id"].Visible = false;

                        // Rename headers
                        if (dgv.Columns.Contains("name")) dgv.Columns["name"].HeaderText = "Role Name";
                        if (dgv.Columns.Contains("created_at")) dgv.Columns["created_at"].HeaderText = "Created At";
                        if (dgv.Columns.Contains("updated_at")) dgv.Columns["updated_at"].HeaderText = "Updated At";

                        // Center all headers and left-align cell text
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
                MessageBox.Show("Error loading roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                selectedRoleId = Convert.ToInt32(row.Cells["id"].Value); // store the ID
                txtRoleName.Text = row.Cells["name"].Value.ToString();   // show name in textbox
                btnAdd.Enabled = false; // disable Add button when editing
                btnDelete.Enabled = true;
                RolePermission permission = GlobalFunctions.GetRolePermission(GlobalFunctions.role, this.Name);
                if (permission != null)
                {
                    btnAdd.Enabled = permission.CanSave;
                    btnDelete.Enabled = permission.CanDelete;
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertRole (txtRoleName.Text.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRole();
        }

        private void InsertRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Please enter a role name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "INSERT INTO roles (name, created_at, updated_at) VALUES (@name, GETDATE(), GETDATE())";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", roleName);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Role added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtRoleName.Clear();
                            LoadRoles(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to add role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRole()
        {
            if (selectedRoleId <= 0)
            {
                MessageBox.Show("Please select a role from the grid to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this role?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string connStr = GlobalFunctions.ConnString;
                    using (var con = new SqlConnection(connStr))
                    {
                        con.Open();
                        string sql = "DELETE FROM roles WHERE id=@id";

                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedRoleId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Role deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtRoleName.Clear();
                                selectedRoleId = -1;
                                LoadRoles(); // refresh DataGridView
                                btnDelete.Enabled = false;
                                btnAdd.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
