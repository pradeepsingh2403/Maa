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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Maa
{
    public partial class FrmListDonations : Form
    {
        public FrmListDonations()
        {
            InitializeComponent();
            donationTableList.ReadOnly = true;
            donationTableList.AllowUserToAddRows = false;
            donationTableList.AllowUserToDeleteRows = false;
            donationTableList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            donationTableList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.AutoSize;
            donationTableList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);

        }

        private void FrmListDonations_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"SELECT id,donor_name,donation_amount,payment_mode,mobile_number,gotra FROM donations";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        // Add Serial Number column
                        dt.Columns.Add("S.No", typeof(int));

                        int counter = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                            row["S.No"] = counter++;
                        }
                      
                        //donationTableList.DataSource = dt;
                        dt.Columns["donor_name"].ColumnName = "Donor Name";
                        dt.Columns["donation_amount"].ColumnName = "Donation Amount";
                        dt.Columns["payment_mode"].ColumnName = "Mode Of Payment";
                        dt.Columns["mobile_number"].ColumnName = "Mobile";
                        dt.Columns["gotra"].ColumnName = "Gotra";

                        // Reorder columns so S.No comes first
                        dt.Columns["S.No"].SetOrdinal(0);

                        // Bind to DataGridView
                        donationTableList.DataSource = dt;
                        donationTableList.Font = new Font("Segoe UI", 12);

                        if (!donationTableList.Columns.Contains("Action"))
                        {
                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                            btn.Name = "Edit";
                            btn.HeaderText = "Action";
                            btn.Text = "Edit";
                            btn2.Text = "Edit";
                            btn.UseColumnTextForButtonValue = true;
                            btn2.UseColumnTextForButtonValue = true;
                            donationTableList.Columns.Add(btn2);
                            donationTableList.Columns.Add(btn);
                            donationTableList.CellClick += donationTableList_CellClick;


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void donationTableList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header row clicks
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if clicked column is "Edit"
                if (donationTableList.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string donorName = donationTableList.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    MessageBox.Show("You clicked Edit for donor: " + donorName, "Edit Action");
                }
            }
        }

        private void modalOpen(object sender, MouseEventArgs e)
        {
            FrmPopup popup = new FrmPopup();
            popup.ShowDialog(); 
        }
    }
}
