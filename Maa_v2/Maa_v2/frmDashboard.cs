using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            this.Resize += FrmDashboard_Resize; // make boxes responsive
        }

        private DataTable donationData = new DataTable();
        private Panel[] boxes;

        private void FrmDashboard_Resize(object sender, EventArgs e)
        {
            ResizeBoxes();
        }

        private void CreateDashboard()
        {
            // --- Form properties ---
            this.Text = "Dashboard";
            this.BackColor = Color.White;

            // --- Box titles and colors ---
            string[] titles = { "Total Donation", "Total Cash", "Today Cheque", "Total Online" };
            Color[] colors = { Color.LightBlue, Color.LightGreen, Color.Khaki, Color.LightCoral };
            int startY = 40;
            int height = 150;
            int gap = 10;

            boxes = new Panel[titles.Length];

            // --- Fetch data from SQL Server ---
            string connStr = GlobalFunctions.ConnString;
            int totalDonation = 0;
            int totalCash = 0;
            int todayCheque = 0;
            int totalOnline = 0;

            using (var con = new SqlConnection(connStr))
            {
                con.Open();

                // Dashboard summary numbers for current date only
                string sqlBoxes = @"
                SELECT 
                    COUNT(*) AS TotalDonation,
                    SUM(CASE WHEN payment_mode='Cash' THEN donation_amount ELSE 0 END) AS TotalCash,
                    SUM(CASE WHEN payment_mode='Cheque' THEN donation_amount ELSE 0 END) AS TodayCheque,
                    SUM(CASE WHEN payment_mode='Online' THEN donation_amount ELSE 0 END) AS TotalOnline
                FROM donations
                WHERE CAST(donation_date AS DATE) >= CAST(GETDATE()-120 AS DATE)";

                using (var cmd = new SqlCommand(sqlBoxes, con))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        totalDonation = reader["TotalDonation"] != DBNull.Value ? Convert.ToInt32(reader["TotalDonation"]) : 0;
                        totalCash = reader["TotalCash"] != DBNull.Value ? Convert.ToInt32(reader["TotalCash"]) : 0;
                        todayCheque = reader["TodayCheque"] != DBNull.Value ? Convert.ToInt32(reader["TodayCheque"]) : 0;
                        totalOnline = reader["TotalOnline"] != DBNull.Value ? Convert.ToInt32(reader["TotalOnline"]) : 0;
                    }
                }

                // Fetch donations for DataGridView (current date only)
                string sqlGrid = @"
                    SELECT id, payment_mode, payment_mode_details, receipt_number, donor_name, donation_amount, donation_date
                    FROM donations
                    WHERE CAST(donation_date AS DATE) >= CAST(GETDATE()-120 AS DATE)
                    ORDER BY donation_date DESC";

                using (var adapter = new SqlDataAdapter(sqlGrid, con))
                {
                    donationData.Clear();
                    adapter.Fill(donationData);
                }
            }

            int[] values = { totalDonation, totalCash, todayCheque, totalOnline };

            // --- Create boxes ---
            for (int i = 0; i < titles.Length; i++)
            {
                Panel box = new Panel
                {
                    Height = height,
                    BackColor = colors[i],
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lbl = new Label
                {
                    Text = titles[i],
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, 20)
                };

                Label valueLbl = new Label
                {
                    Text = values[i].ToString(),
                    Font = new Font("Segoe UI", 22, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, 70),
                    ForeColor = Color.Black
                };

                box.Controls.Add(lbl);
                box.Controls.Add(valueLbl);

                this.Controls.Add(box);
                boxes[i] = box;
            }

            // Initial positioning
            ResizeBoxes();

            // --- Create DataGridView ---
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

            dgv.DataSource = donationData;
            this.Controls.Add(dgv);
        }

        private void ResizeBoxes()
        {
            if (boxes == null || boxes.Length == 0) return;

            int gap = 10;
            int startY = 40;
            int screenWidth = this.ClientSize.Width;
            int boxWidth = (screenWidth - (gap * (boxes.Length + 1))) / boxes.Length;

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Width = boxWidth;
                boxes[i].Left = gap + i * (boxWidth + gap);
                boxes[i].Top = startY;
            }
        }
    }
}
