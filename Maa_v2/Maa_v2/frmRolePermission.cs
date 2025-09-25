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

            // === Checkbox column ===
            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Name = "Select",
                Width = 50,
                ReadOnly = false // Allow editing only in this column
            };
            dgv.Columns.Add(chkCol);

            // Example columns
            dgv.Columns.Add("EnquiryId", "Enquiry ID");
            dgv.Columns.Add("CustomerName", "Customer Name");
            dgv.Columns.Add("Status", "Status");
            dgv.Columns.Add("Date", "Date");

            // Example rows
            dgv.Rows.Add(false, "E001", "John Doe", "Success", DateTime.Now.ToShortDateString());
            dgv.Rows.Add(false, "E002", "Mary Smith", "Pending", DateTime.Now.ToShortDateString());
            dgv.Rows.Add(false, "E003", "Sam Kumar", "Error", DateTime.Now.ToShortDateString());

            // Make all columns except checkbox readonly
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name != "Select")
                    col.ReadOnly = true;
            }

            this.Controls.Add(dgv);
        }

        private DataGridView dgv;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<string> selectedIds = new List<string>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isChecked)
                {
                    string enquiryId = row.Cells["EnquiryId"].Value.ToString();
                    selectedIds.Add(enquiryId);
                }
            }

            if (selectedIds.Count > 0)
            {
                // Example: show in MessageBox (replace this with your processing code)
                MessageBox.Show("Selected Enquiry IDs: " + string.Join(", ", selectedIds));
            }
            else
            {
                MessageBox.Show("No rows selected!");
            }
        }

    }


}
