using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Maa
{
    public partial class frmRolePermission : Form
    {
        private DataGridView dgv;

        public frmRolePermission()
        {
            InitializeComponent();
            frmAddRole_Load(this, EventArgs.Empty);
            LoadRolesCombo(cmbRole);
            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            int roleId = GlobalFunctions.role; // Logged-in user's role id
            string formName = this.Name; // Form name matches module form_name
            RolePermission permission = GlobalFunctions.GetRolePermission(roleId, formName);
            if (permission != null)
            {
                btnSubmit.Enabled = permission.CanSave;
                dgv.Enabled = permission.CanView;
            }
        }

        private void LoadRolesCombo(ComboBox cmbRole)
        {
            try
            {
                using (var con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();
                    string sql = "SELECT id, name FROM roles ORDER BY name";

                    using (var cmd = new SqlCommand(sql, con))
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbRole.DisplayMember = "name";
                        cmbRole.ValueMember = "id";
                        cmbRole.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddRole_Load(object sender, EventArgs e)
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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                EditMode = DataGridViewEditMode.EditOnEnter, // ✅ allow checkbox click
                ReadOnly = false
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

            // === Add columns ===
            dgv.Columns.Add("id", "ID");
            dgv.Columns["id"].ReadOnly = true;

            dgv.Columns.Add("module_name", "Module Name");
            dgv.Columns["module_name"].ReadOnly = true;

            dgv.Columns.Add("form_name", "Form Name");
            dgv.Columns["form_name"].ReadOnly = true;

            dgv.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Save", Name = "Save", Width = 60 });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Update", Name = "Update", Width = 70 });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Delete", Name = "Delete", Width = 70 });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "View", Name = "View", Width = 70 });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Export", Name = "Export", Width = 70 });

            this.Controls.Add(dgv);

            // === Load modules ===
            LoadModules();
        }

        private void LoadModules()
        {
            try
            {
                using (var con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();
                    string sql = "SELECT id, module_name, form_name FROM modules WHERE status = 1";

                    using (var cmd = new SqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgv.Rows.Add(
                                reader["id"].ToString(),
                                reader["module_name"].ToString(),
                                reader["form_name"].ToString(),
                                false, false, false, false, false
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading modules: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveRolePermissions(int roleId)
        {
            if (roleId <= 0)
            {
                MessageBox.Show("Please select a valid role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int moduleId = Convert.ToInt32(row.Cells["id"].Value);
                        bool canSave = Convert.ToBoolean(row.Cells["Save"].Value ?? false);
                        bool canUpdate = Convert.ToBoolean(row.Cells["Update"].Value ?? false);
                        bool canDelete = Convert.ToBoolean(row.Cells["Delete"].Value ?? false);
                        bool canView = Convert.ToBoolean(row.Cells["View"].Value ?? false);
                        bool canExport = Convert.ToBoolean(row.Cells["Export"].Value ?? false);

                        // Delete existing permission
                        using (var cmdDel = new SqlCommand("DELETE FROM role_permissions WHERE role_id=@roleId AND module_id=@moduleId", con))
                        {
                            cmdDel.Parameters.AddWithValue("@roleId", roleId);
                            cmdDel.Parameters.AddWithValue("@moduleId", moduleId);
                            cmdDel.ExecuteNonQuery();
                        }

                        // Insert new permission
                        string sqlInsert = @"
INSERT INTO role_permissions
(role_id, module_id, can_save, can_update, can_delete, can_view, can_export, created_at, updated_at)
VALUES
(@roleId, @moduleId, @canSave, @canUpdate, @canDelete, @canView, @canExport, GETDATE(), GETDATE())";

                        using (var cmd = new SqlCommand(sqlInsert, con))
                        {
                            cmd.Parameters.AddWithValue("@roleId", roleId);
                            cmd.Parameters.AddWithValue("@moduleId", moduleId);
                            cmd.Parameters.AddWithValue("@canSave", canSave ? 1 : 0);
                            cmd.Parameters.AddWithValue("@canUpdate", canUpdate ? 1 : 0);
                            cmd.Parameters.AddWithValue("@canDelete", canDelete ? 1 : 0);
                            cmd.Parameters.AddWithValue("@canView", canView ? 1 : 0);
                            cmd.Parameters.AddWithValue("@canExport", canExport ? 1 : 0);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Role permissions saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving permissions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRolePermissions(int roleId)
        {
            if (roleId <= 0) return;

            try
            {
                using (var con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();
                    string sql = @"SELECT module_id, can_save, can_update, can_delete, can_view, can_export
                                   FROM role_permissions
                                   WHERE role_id = @roleId";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@roleId", roleId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.IsNewRow) continue;
                                row.Cells["Save"].Value = false;
                                row.Cells["Update"].Value = false;
                                row.Cells["Delete"].Value = false;
                                row.Cells["View"].Value = false;
                                row.Cells["Export"].Value = false;
                            }

                            while (reader.Read())
                            {
                                int moduleId = Convert.ToInt32(reader["module_id"]);
                                foreach (DataGridViewRow row in dgv.Rows)
                                {
                                    if (row.IsNewRow) continue;
                                    if (Convert.ToInt32(row.Cells["id"].Value) == moduleId)
                                    {
                                        row.Cells["Save"].Value = Convert.ToBoolean(reader["can_save"]);
                                        row.Cells["Update"].Value = Convert.ToBoolean(reader["can_update"]);
                                        row.Cells["Delete"].Value = Convert.ToBoolean(reader["can_delete"]);
                                        row.Cells["View"].Value = Convert.ToBoolean(reader["can_view"]);
                                        row.Cells["Export"].Value = Convert.ToBoolean(reader["can_export"]);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading role permissions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRolePermissions(Convert.ToInt32(cmbRole.SelectedValue));
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int roleId = Convert.ToInt32(cmbRole.SelectedValue);
                SaveRolePermissions(roleId);
                LoadRolePermissions(roleId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving role permission: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
