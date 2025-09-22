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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            try
            {
                CreateDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    private void CreateDashboard()
    {
        // --- Form properties ---
        this.Text = "Dashboard";
        this.WindowState = FormWindowState.Maximized;
        this.BackColor = Color.White;

        // --- Box titles and colors ---
        string[] titles = { "Total Donation", "Total Cash", "Today Cheque", "Total Online" };
        Color[] colors = { Color.LightBlue, Color.LightGreen, Color.Khaki, Color.LightCoral };
        int screenWidth = this.ClientSize.Width;
        int startY = 40;
        int height = 150;
        int gap = 20;
        int boxWidth = (screenWidth - (gap * (titles.Length + 1))) / titles.Length;

        // --- Fetch data from MySQL ---
        string connStr = GlobalFunctions.ConnString;
        int totalDonation = 0;
        int totalCash = 0;
        int todayCheque = 0;
        int totalOnline = 0;

        DataTable donationData = new DataTable();

        using (var con = new MySqlConnection(connStr))
        {
            con.Open();

            // Get dashboard numbers
            string sqlBoxes = @"
            SELECT 
                COUNT(*) AS TotalDonation,
                SUM(CASE WHEN payment_mode='Cash' THEN donation_amount ELSE 0 END) AS TotalCash,
                SUM(CASE WHEN payment_mode='Cheque' AND DATE(ritual_performing_date)=CURDATE() THEN donation_amount ELSE 0 END) AS TodayCheque,
                SUM(CASE WHEN payment_mode='Online' THEN donation_amount ELSE 0 END) AS TotalOnline
            FROM donations";

            using (var cmd = new MySqlCommand(sqlBoxes, con))
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

            // Get all donation data for DataGridView
            string sqlGrid = "SELECT id, payment_mode, payment_mode_details, receipt_number, donor_name, donation_amount, donation_date FROM donations";
            using (var adapter = new MySqlDataAdapter(sqlGrid, con))
            {
                adapter.Fill(donationData);
            }
        }

        // --- Create boxes ---
        int[] values = { totalDonation, totalCash, todayCheque, totalOnline };

        for (int i = 0; i < titles.Length; i++)
        {
            Panel box = new Panel
            {
                Size = new Size(boxWidth, height),
                BackColor = colors[i],
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(gap + i * (boxWidth + gap), startY)
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
        }

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

        // Bind donation data
        dgv.DataSource = donationData;

        this.Controls.Add(dgv);
    }


}
}
    