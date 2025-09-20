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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
            frmUsers_Load(this,EventArgs.Empty);
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            // Keep your existing formatting code as-is...
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

            // === Define columns ===
            dgv.Columns.Clear();
            dgv.Columns.Add("UserId", "User ID");
            dgv.Columns.Add("UserName", "User Name");
            dgv.Columns.Add("Email", "Email");

            // === Add sample rows ===
            dgv.Rows.Add("U001", "John Doe", "john@example.com");
            dgv.Rows.Add("U002", "Mary Smith", "mary@example.com");
            dgv.Rows.Add("U003", "Sam Kumar", "sam@example.com");

            // === Handle row click ===
            dgv.CellClick += dgv_CellClick;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // avoid header row
            {
                string userId = dgv.Rows[e.RowIndex].Cells["UserId"].Value.ToString();
                string userName = dgv.Rows[e.RowIndex].Cells["UserName"].Value.ToString();

                // Example process: show info
                MessageBox.Show($"Processing User ID: {userId}, Name: {userName}");

                // TODO: put your own logic here
            }
        }


    }
}
