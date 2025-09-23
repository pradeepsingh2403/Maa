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
                    string sql = @"SELECT id,receipt_number, donor_name,in_favour, donation_amount,DATE_FORMAT(donation_date,'%d-%m-%Y') as donation_date, payment_mode, mobile_number, gotra, created_at FROM donations WHERE created_at >= DATE_SUB(NOW(), INTERVAL 10 DAY)";

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
                        dt.Columns["receipt_number"].ColumnName = "Recipt No";
                        dt.Columns["in_favour"].ColumnName = "In Favour Of";







                        dt.Columns["donor_name"].ColumnName = "Donor Name";
                        dt.Columns["donation_amount"].ColumnName = "Donation Amount";
                        dt.Columns["payment_mode"].ColumnName = "Mode Of Payment";
                        dt.Columns["mobile_number"].ColumnName = "Mobile";
                        dt.Columns["gotra"].ColumnName = "Gotra";
                        dt.Columns["donation_date"].ColumnName = "Donation Date";
                     

                        // Reorder columns so S.No comes first
                        dt.Columns["S.No"].SetOrdinal(0);

                        // Bind to DataGridView
                        donationTableList.DataSource = dt;
                        donationTableList.Font = new Font("Segoe UI", 12);

                        if (!donationTableList.Columns.Contains("Action"))
                        {
                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            btn.Name = "Edit";
                            btn.HeaderText = "Action";
                            btn.Text = "Edit";
                            btn.UseColumnTextForButtonValue = true;
                            donationTableList.Columns.Add(btn);
                            donationTableList.CellClick += donationTableList_CellEdit;
                        }

                        if (!donationTableList.Columns.Contains("Delete"))
                        {
                            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                            btnDelete.Name = "Delete";
                            btnDelete.HeaderText = "Delete";
                            btnDelete.Text = "Delete";
                            btnDelete.UseColumnTextForButtonValue = true;

                            // Set the button color to red
                            btnDelete.DefaultCellStyle.BackColor = Color.Red;       // Background color
                            btnDelete.DefaultCellStyle.ForeColor = Color.White;     // Text color for better visibility

                            donationTableList.Columns.Add(btnDelete);
                            donationTableList.CellClick += donationTableList_CellDelete;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 


        private void donationTableList_CellEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header row clicks
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if clicked column is "Edit"
                if (donationTableList.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string donorName = donationTableList.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    modalEditDonationOpen(donorName);
                }
            }
        }



        private void modalEditDonationOpen(string donationId)
        {
            FrmEditDonation popup = new FrmEditDonation(donationId);
            popup.ShowDialog();
        }




        private void donationTableList_CellDelete(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (donationTableList.Columns[e.ColumnIndex].Name == "Delete")
                {
                    string donorId = donationTableList.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    string donorName = donationTableList.Rows[e.RowIndex].Cells["Donor Name"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete donor '{donorName}' (ID: {donorId})?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            using (var con = new MySqlConnection(GlobalFunctions.ConnString))
                            {
                                con.Open();
                                string deleteSql = "DELETE FROM donations WHERE id = @id";

                                using (var cmd = new MySqlCommand(deleteSql, con))
                                {
                                    cmd.Parameters.AddWithValue("@id", donorId);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Donor deleted successfully.", "Deleted");
                                        donationTableList.Rows.RemoveAt(e.RowIndex); // UI से row हटाएँ
                                    }
                                    else
                                    {
                                        MessageBox.Show("Delete failed! Record not found.", "Error");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting donor: " + ex.Message, "Error");
                        }
                    }
                }
            }
        }





        // Filter Section 

        private void modalOpen(object sender, MouseEventArgs e)
        {
          
            using (FrmDonationFillter popup = new FrmDonationFillter())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    LoadDonations(
                        popup.receipt_number,
                        popup.filter_Payment_Mode,
                        popup.mobile_number,
                        popup.id_Number_Filter,
                        popup.tithi_filter,
                        popup.min_Amount_Input,
                        popup.max_Amount_Input,
                        popup.start_date,
                        popup.end_date

                        );
                }
            }
         
        }

        private void LoadDonations(
      string receipt_number = null,
      string filter_Payment_Mode = null,
      string mobile_number = null,
      string id_Number_Filter = null,
      string tithi_filter = null,
      string min_Amount_Input = null,
      string max_Amount_Input = null,
      string start_date = null,
      string end_date = null
  )
        {
            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();

                    string sql = @"SELECT id, receipt_number, donor_name, in_favour, donation_amount,
                                  DATE_FORMAT(donation_date,'%d-%m-%Y') as donation_date,
                                  payment_mode, mobile_number, gotra, created_at 
                           FROM donations 
                           WHERE 1=1";

                    if (!string.IsNullOrEmpty(receipt_number))
                        sql += " AND receipt_number LIKE @receipt_number";

                    if (!string.IsNullOrEmpty(filter_Payment_Mode))
                        sql += " AND payment_mode = @filter_Payment_Mode";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        if (!string.IsNullOrEmpty(receipt_number))
                            cmd.Parameters.AddWithValue("@receipt_number", "%" + receipt_number + "%");

                        if (!string.IsNullOrEmpty(filter_Payment_Mode))
                            cmd.Parameters.AddWithValue("@filter_Payment_Mode", filter_Payment_Mode);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Add serial no column
                        if (!dt.Columns.Contains("S.No"))
                            dt.Columns.Add("S.No", typeof(int));

                        int counter = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                            row["S.No"] = counter++;
                        }

                        // Rename columns
                        dt.Columns["receipt_number"].ColumnName = "Receipt No";
                        dt.Columns["in_favour"].ColumnName = "In Favour Of";
                        dt.Columns["donor_name"].ColumnName = "Donor Name";
                        dt.Columns["donation_amount"].ColumnName = "Donation Amount";
                        dt.Columns["payment_mode"].ColumnName = "Mode Of Payment";
                        dt.Columns["mobile_number"].ColumnName = "Mobile";
                        dt.Columns["gotra"].ColumnName = "Gotra";
                        dt.Columns["donation_date"].ColumnName = "Donation Date";

                        dt.Columns["S.No"].SetOrdinal(0);

                        donationTableList.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donations: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
