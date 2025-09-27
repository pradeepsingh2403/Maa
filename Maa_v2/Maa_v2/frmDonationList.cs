using Maa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Maa_v2
{
    public partial class frmDonationList : Form
    {

        public frmDonationList()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDonationList_Load);

            // Setup DataGridView defaults
            donationTableList.ReadOnly = true;
            donationTableList.AllowUserToAddRows = false;
            donationTableList.AllowUserToDeleteRows = false;
            donationTableList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmDonationList_Load(object sender, EventArgs e)
        {
            LoadDonationData();
        }

        private void LoadDonationList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    string query = @"
                        SELECT 
                            receipt_number AS [Receipt Number],
                            donor_name AS [Donor Name],
                            donation_amount AS [Donor Amount],
                            payment_mode AS [Payment Mode],
                            mobile_number AS [Mobile],
                            gotra AS [Gotra],
                            created_at AS [Created At]
                        FROM donations
                        WHERE CAST(created_at AS DATE) <= CAST(GETDATE() - 10 AS DATE)";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    donationTableList.DataSource = dt;

                    // Optional: Format Created At column
                    if (donationTableList.Columns["Created At"] != null)
                    {
                        donationTableList.Columns["Created At"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donation list: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            // Filter logic here
            using (frmApplyFilter filterForm = new frmApplyFilter())
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    // Apply filters using the parameters from filter form
                    LoadDonationData(
                        receiptNo: filterForm.ReceiptNo,
                        mobileNumber: filterForm.MobileNumber,
                        minAmount: filterForm.MinAmount,
                        maxAmount: filterForm.MaxAmount,
                        paymentMode: filterForm.PaymentMode,
                        idNumber: filterForm.IdNumber,
                        startDate: filterForm.StartDate,
                        endDate: filterForm.EndDate,
                        tithi: "" + filterForm.Tithi
                    );
                }
            }
        }


        private void LoadDonationData(
            string receiptNo = "",
            string mobileNumber = "",
            decimal? minAmount = null,
            decimal? maxAmount = null,
            string paymentMode = "All",
            string idNumber = "",
            DateTime? startDate = null,
            DateTime? endDate = null,
            string tithi = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();

                    string query = @"SELECT 
                                receipt_number AS [Receipt Number],
                                donor_name AS [Donor Name],
                                donation_amount AS [Donor Amount],
                                payment_mode AS [Payment Mode],
                                mobile_number AS [Mobile],
                                gotra AS [Gotra],
                                created_at AS [Created At],
                                tithi AS [Tithi],
                                id_number AS [ID Number]
                             FROM donations
                             WHERE 1=1";

                    // Dynamic filters
                    if (!string.IsNullOrEmpty(receiptNo))
                        query += " AND receipt_number LIKE @ReceiptNo";

                    if (!string.IsNullOrEmpty(mobileNumber))
                        query += " AND mobile_number LIKE @MobileNumber";

                    if (minAmount.HasValue)
                        query += " AND donation_amount >= @MinAmount";

                    if (maxAmount.HasValue)
                        query += " AND donation_amount <= @MaxAmount";

                    if (!string.IsNullOrEmpty(paymentMode) && paymentMode != "All")
                        query += " AND payment_mode = @PaymentMode";

                    if (!string.IsNullOrEmpty(idNumber))
                        query += " AND id_number LIKE @IdNumber";

                    if (startDate.HasValue)
                        query += " AND created_at >= @StartDate";

                    if (endDate.HasValue)
                        query += " AND created_at <= @EndDate";

                    if (!string.IsNullOrEmpty(tithi))
                        query += " AND tithi LIKE @Tithi";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrEmpty(receiptNo))
                            cmd.Parameters.AddWithValue("@ReceiptNo", "%" + receiptNo + "%");

                        if (!string.IsNullOrEmpty(mobileNumber))
                            cmd.Parameters.AddWithValue("@MobileNumber", "%" + mobileNumber + "%");

                        if (minAmount.HasValue)
                            cmd.Parameters.AddWithValue("@MinAmount", minAmount.Value);

                        if (maxAmount.HasValue)
                            cmd.Parameters.AddWithValue("@MaxAmount", maxAmount.Value);

                        if (!string.IsNullOrEmpty(paymentMode) && paymentMode != "All")
                            cmd.Parameters.AddWithValue("@PaymentMode", paymentMode);

                        if (!string.IsNullOrEmpty(idNumber))
                            cmd.Parameters.AddWithValue("@IdNumber", "%" + idNumber + "%");

                        if (startDate.HasValue && startDate.Value > (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                            cmd.Parameters.AddWithValue("@StartDate", startDate.Value);

                        if (endDate.HasValue && endDate.Value > (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                            cmd.Parameters.AddWithValue("@EndDate", endDate.Value);

                        if (!string.IsNullOrEmpty(tithi))
                            cmd.Parameters.AddWithValue("@Tithi", "%" + tithi + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        donationTableList.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            LoadDonationData(); // Reload all data
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            // Export DataGridView to Excel
            ExportToExcel();
        }



        private void ExportToExcel()
        {
            try
            {
                if (donationTableList.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create Excel application
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false; // Make Excel visible if you want

                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Donation List";

                // Export column headers
                for (int i = 0; i < donationTableList.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = donationTableList.Columns[i].HeaderText;
                    worksheet.Cells[1, i + 1].Font.Bold = true;
                }

                // Export rows
                for (int i = 0; i < donationTableList.Rows.Count; i++)
                {
                    for (int j = 0; j < donationTableList.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = donationTableList.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                // Autofit columns
                worksheet.Columns.AutoFit();

                // Save dialog
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Save as Excel File";
                sfd.FileName = "DonationList.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    workbook.Close(false);
                    excelApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
