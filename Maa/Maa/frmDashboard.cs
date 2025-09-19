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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            CreateDashboard();
        }

        private void CreateDashboard()
        {
            // Form properties
            this.Text = "Dashboard";
            this.WindowState = FormWindowState.Maximized; // Full screen
            this.BackColor = Color.White;

            // Dashboard box details
            string[] titles = { "Total Enquiries", "Success Rate", "Pending Requests", "Errors" };
            Color[] colors = { Color.LightBlue, Color.LightGreen, Color.Khaki, Color.LightCoral };

            int screenWidth = this.ClientSize.Width;
            int startY = 40;             // Top margin for boxes
            int height = 150;            // Box height
            int gap = 20;                // Gap between boxes
            int boxWidth = (screenWidth - (gap * (titles.Length + 1))) / titles.Length;
            // Formula: (TotalWidth - total gaps) / number of boxes

            for (int i = 0; i < titles.Length; i++)
            {
                Panel box = new Panel
                {
                    Size = new Size(boxWidth, height),
                    BackColor = colors[i],
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(gap + i * (boxWidth + gap), startY) // auto spacing
                };

                // Title label
                Label lbl = new Label
                {
                    Text = titles[i],
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, 20)
                };

                // Value label
                Label valueLbl = new Label
                {
                    Text = "0", // Replace with dynamic values
                    Font = new Font("Segoe UI", 22, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, 70),
                    ForeColor = Color.Black
                };

                box.Controls.Add(lbl);
                box.Controls.Add(valueLbl);
                this.Controls.Add(box);
            }

            // === Add DataGridView below boxes ===
            DataGridView dgv = new DataGridView
            {
                Left = 20,
                Width = this.ClientSize.Width - 40,
                Top = startY + height + 50,
                Height = this.ClientSize.Height - (startY + height + 80),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
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

            this.Controls.Add(dgv);
        }


    }
}
    