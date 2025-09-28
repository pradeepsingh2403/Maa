using Maa;
using System;
using System.Data;
using System.Data.SqlClient;
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

            // Handle button clicks in grid
            donationTableList.CellContentClick += donationTableList_CellContentClick;
        }

        private void frmDonationList_Load(object sender, EventArgs e)
        {
            LoadDonationData();
        }

        #region Load Donation Data

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

                    if (!string.IsNullOrEmpty(receiptNo))
                        query += " AND receipt_number LIKE @ReceiptNo";

                    if (!string.IsNullOrEmpty(mobileNumber))
                        query += " AND mobile_number = @MobileNumber";

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
                            cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);

                        if (minAmount.HasValue)
                            cmd.Parameters.AddWithValue("@MinAmount", minAmount.Value);

                        if (maxAmount.HasValue)
                            cmd.Parameters.AddWithValue("@MaxAmount", maxAmount.Value);

                        if (!string.IsNullOrEmpty(paymentMode) && paymentMode != "All")
                            cmd.Parameters.AddWithValue("@PaymentMode", paymentMode);

                        if (!string.IsNullOrEmpty(idNumber))
                            cmd.Parameters.AddWithValue("@IdNumber", "%" + idNumber + "%");

                        if (startDate.HasValue)
                            cmd.Parameters.AddWithValue("@StartDate", startDate.Value);

                        if (endDate.HasValue)
                            cmd.Parameters.AddWithValue("@EndDate", endDate.Value);

                        if (!string.IsNullOrEmpty(tithi))
                            cmd.Parameters.AddWithValue("@Tithi", "%" + tithi + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        donationTableList.DataSource = dt;

                        // Format Created At column
                        if (donationTableList.Columns["Created At"] != null)
                            donationTableList.Columns["Created At"].DefaultCellStyle.Format = "dd/MM/yyyy";

                        // ✅ Add Print Invoice button column if not already added
                        if (!donationTableList.Columns.Contains("PrintInvoice"))
                        {
                            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                            btnCol.Name = "PrintInvoice";
                            btnCol.HeaderText = "Action";
                            btnCol.Text = "Print Invoice";
                            btnCol.UseColumnTextForButtonValue = true;
                            donationTableList.Columns.Add(btnCol);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        #endregion

        #region Buttons

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            using (frmApplyFilter filterForm = new frmApplyFilter())
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime? startDate = null, endDate = null, tithiDate = null;
                    DateTime tempDate;

                    if (DateTime.TryParse(filterForm.StartDate, out tempDate))
                        startDate = tempDate;

                    if (DateTime.TryParse(filterForm.EndDate, out tempDate))
                        endDate = tempDate;

                    if (DateTime.TryParse(filterForm.Tithi, out tempDate))
                        tithiDate = tempDate;

                    LoadDonationData(
                        receiptNo: filterForm.ReceiptNo,
                        mobileNumber: filterForm.MobileNumber,
                        minAmount: filterForm.MinAmount,
                        maxAmount: filterForm.MaxAmount,
                        paymentMode: filterForm.PaymentMode,
                        idNumber: filterForm.IdNumber,
                        startDate: startDate,
                        endDate: endDate,
                        tithi: tithiDate.HasValue ? tithiDate.Value.ToString("yyyy-MM-dd") : ""
                    );
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            LoadDonationData();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        #endregion

        #region DataGridView Button Click

        private void donationTableList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && donationTableList.Columns[e.ColumnIndex].Name == "PrintInvoice")
            {
                string receiptNo = donationTableList.Rows[e.RowIndex].Cells["Receipt Number"].Value.ToString();

                frmPreview preview = new frmPreview(receiptNo);

                // Set as MDI child
                preview.MdiParent = this.MdiParent;  // assumes current form is inside an MDI parent
                preview.WindowState = FormWindowState.Maximized;

                preview.Show(); // use Show() instead of ShowDialog()
            }
        }

        #endregion

        #region Export Excel

        private void ExportToExcel()
        {
            try
            {
                if (donationTableList.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;

                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Donation List";

                for (int i = 0; i < donationTableList.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = donationTableList.Columns[i].HeaderText;
                    worksheet.Cells[1, i + 1].Font.Bold = true;
                }

                for (int i = 0; i < donationTableList.Rows.Count; i++)
                {
                    for (int j = 0; j < donationTableList.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = donationTableList.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                worksheet.Columns.AutoFit();

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    Title = "Save as Excel File",
                    FileName = "DonationList.xlsx"
                };

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

        #endregion
    }
}
