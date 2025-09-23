using MySql.Data.MySqlClient;
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
    public partial class frmRolePermission : Form
    {
        public frmRolePermission()
        {
            InitializeComponent();
            frmAddRole_Load(this, EventArgs.Empty);
            LoadRolesCombo(cmbRole);
            ApplyPermissions();
        }
        private void ApplyPermissions()
        {
            int roleId = GlobalFunctions.roleId; // Store the logged-in user's role id
            string formName = this.Name; // Form name matches the module form_name
            RolePermission permission = GlobalFunctions.GetRolePermission(roleId, formName);
            btnSubmit.Enabled = permission.CanSave;
            dgv.Enabled = permission.CanView; // Or you can just hide rows if no view permission
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

            // === Add columns ===
            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("module_name", "Module Name");
            dgv.Columns.Add("form_name", "Form Name");

            // Permission checkboxes
            DataGridViewCheckBoxColumn chkSave = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Save",
                Name = "Save",
                Width = 60
            };
            dgv.Columns.Add(chkSave);

            DataGridViewCheckBoxColumn chkUpdate = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Update",
                Name = "Update",
                Width = 70
            };
            dgv.Columns.Add(chkUpdate);

            DataGridViewCheckBoxColumn chkDelete = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Delete",
                Name = "Delete",
                Width = 70
            };
            dgv.Columns.Add(chkDelete);

            // ✅ New "View" column
            DataGridViewCheckBoxColumn chkView = new DataGridViewCheckBoxColumn
            {
                HeaderText = "View",
                Name = "View",
                Width = 70
            };
            dgv.Columns.Add(chkView);

            // ✅ New "Export" column
            DataGridViewCheckBoxColumn chkExport = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Export",
                Name = "Export",
                Width = 70
            };
            dgv.Columns.Add(chkExport);

            this.Controls.Add(dgv);

            // === Load module list ===
            LoadModules();
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
                string connStr = GlobalFunctions.ConnString;

                using (var con = new MySqlConnection(connStr))
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

                        // Delete existing permission for this role-module first (to prevent duplicates)
                        using (var cmdDel = new MySqlCommand("DELETE FROM role_permissions WHERE role_id=@roleId AND module_id=@moduleId", con))
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
                    (@roleId, @moduleId, @canSave, @canUpdate, @canDelete, @canView, @canExport, NOW(), NOW())";

                        using (var cmd = new MySqlCommand(sqlInsert, con))
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


        private void LoadModules()
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;

                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"SELECT id, module_name, form_name FROM modules WHERE status = 1";
                    using (var cmd = new MySqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgv.Rows.Add(
                                reader["id"].ToString(),
                                reader["module_name"].ToString(),
                                reader["form_name"].ToString(),
                                false, // Save
                                false, // Update
                                false  // Delete
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading modules: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridView dgv;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int roleId = Convert.ToInt32(cmbRole.SelectedValue); // assuming cmbRoles is your role dropdown
                SaveRolePermissions(roleId);
                LoadRolePermissions(roleId); // Refresh to show saved permissions
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error save role permission: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRolePermissions(int roleId)
        {
            if (roleId <= 0) return;

            try
            {
                string connStr = GlobalFunctions.ConnString;

                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();

                    // Get permissions for the selected role
                    string sql = @"SELECT module_id, can_save, can_update, can_delete, can_view, can_export
                           FROM role_permissions
                           WHERE role_id = @roleId";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@roleId", roleId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Clear previous selections first
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.IsNewRow) continue;

                                row.Cells["Save"].Value = false;
                                row.Cells["Update"].Value = false;
                                row.Cells["Delete"].Value = false;
                                row.Cells["View"].Value = false;
                                row.Cells["Export"].Value = false;
                            }

                            // Apply permissions from DB
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
    }


}
