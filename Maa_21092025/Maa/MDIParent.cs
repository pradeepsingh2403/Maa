using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Maa
{
    public partial class frmRole : Form
    {
        private DataGridView dgv;
        private GroupBox groupBox1;
        private TextBox txtRoleName;
        private Button btnAdd, btnDelete;

        public frmRole()
        {
            InitializeComponent();
            InitializeLayout();
            LoadRoles();
        }

        private void InitializeLayout()
        {
            // --- GroupBox ---
            groupBox1 = new GroupBox
            {
                Text = "Role Management",
                Top = 20,
                Left = 10,
                Width = this.ClientSize.Width - 20,
                Height = 120,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            this.Controls.Add(groupBox1);

            // --- TextBox ---
            txtRoleName = new TextBox
            {
                Top = 30,
                Left = 20,
                Width = 250,
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Enter role name"
            };
            groupBox1.Controls.Add(txtRoleName);

            // --- Add Button ---
            btnAdd = new Button
            {
                Text = "Add Role",
                Top = txtRoleName.Top,
                Left = txtRoleName.Right + 10,
                Width = 100,
                Height = txtRoleName.Height
            };
            btnAdd.Click += BtnAdd_Click;
            groupBox1.Controls.Add(btnAdd);

            // --- Delete Button ---
            btnDelete = new Button
            {
                Text = "Delete Selected",
                Top = txtRoleName.Top,
                Left = btnAdd.Right + 10,
                Width = 120,
                Height = txtRoleName.Height
            };
            btnDelete.Click += BtnDelete_Click;
            groupBox1.Controls.Add(btnDelete);

            // --- DataGridView ---
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
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 10)
            };

            // Professional styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 155);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
            dgv.GridColor = Color.LightGray;

            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(dgv);

            // Resize handler
            this.Resize += (s, e) =>
            {
                groupBox1.Width = this.ClientSize.Width - 20;
                dgv.Width = this.ClientSize.Width - 20;
                dgv.Height = this.ClientSize.Height - (groupBox1.Bottom + 20);
            };
        }

        // --- Load roles ---
        private void LoadRoles()
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT id, name, created_at, updated_at FROM roles";
                    using (var adapter = new MySqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv.DataSource = dt;

                        // Adjust column headers
                        if (dgv.Columns.Contains("id")) dgv.Columns["id"].Visible = false;
                        if (dgv.Columns.Contains("name")) dgv.Columns["name"].HeaderText = "Role Name";
                        if (dgv.Columns.Contains("created_at")) dgv.Columns["created_at"].HeaderText = "Created At";
                        if (dgv.Columns.Contains("updated_at")) dgv.Columns["updated_at"].HeaderText = "Updated At";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Insert role ---
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text.Trim();
            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Please enter role name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "INSERT INTO roles (name, created_at, updated_at) VALUES (@name, NOW(), NOW())";
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", roleName);
                        cmd.ExecuteNonQuery();
                    }
                }
                txtRoleName.Clear();
                LoadRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Delete selected role ---
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int roleId = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);

            if (MessageBox.Show("Are you sure you want to delete this role?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string connStr = GlobalFunctions.ConnString;
                    using (var con = new MySqlConnection(connStr))
                    {
                        con.Open();
                        string sql = "DELETE FROM roles WHERE id=@id";
                        using (var cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@id", roleId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
