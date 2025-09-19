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
    public partial class frmAddSchema : Form
    {
        public frmAddSchema()
        {
            InitializeComponent();
            frmAddSchema_Load(this, EventArgs.Empty);
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

            // Example columns
            dgv.Columns.Add("EnquiryId", "Enquiry ID");
            dgv.Columns.Add("CustomerName", "Customer Name");
            dgv.Columns.Add("Status", "Status");
            dgv.Columns.Add("Date", "Date");


            // Example rows
            dgv.Rows.Add("E001", "John Doe", "Success", DateTime.Now.ToShortDateString());
            dgv.Rows.Add("E002", "Mary Smith", "Pending", DateTime.Now.ToShortDateString());
            dgv.Rows.Add("E003", "Sam Kumar", "Error", DateTime.Now.ToShortDateString());

            dgv.CellClick += Dgv_CellClick;

            this.Controls.Add(dgv);
        }

        // Make dgv accessible
        private DataGridView dgv;

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string enquiryId = dgv.Rows[e.RowIndex].Cells["EnquiryId"].Value.ToString();
                    MessageBox.Show($"Edit clicked for {enquiryId}");
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Delete")
                {
                    string enquiryId = dgv.Rows[e.RowIndex].Cells["EnquiryId"].Value.ToString();
                    var confirm = MessageBox.Show($"Are you sure you want to delete {enquiryId}?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        dgv.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

    }
}
