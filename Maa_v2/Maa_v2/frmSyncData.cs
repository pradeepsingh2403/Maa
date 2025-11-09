using Maa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Linq;
using Mysqlx.Prepare;
using System.Linq;

namespace Maa_v2
{
    public partial class frmSyncData : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        int currentPage = 1;
        int perPage = 50;
        public frmSyncData()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDonationList_Load);
            this.picLoader.Visible = false;
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

        private async Task LoadDonationData(int page = 1, int perPage = 50)
        {
            try
            {
                // ✅ Show loader
                picLoader.Visible = true;
                donationTableList.Enabled = false;

                // 1️⃣ Base URL for your API
                string baseUrl = GlobalFunctions.LiveAPIURL + "donations";

                // 2️⃣ Build query string (pagination + filters)
                var query = new StringBuilder($"?paginate={page}&per_page={perPage}");
                string apiUrl = baseUrl + query.ToString();

                // 3️⃣ Make GET request
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                // 4️⃣ Parse JSON
                var jsonResponse = JObject.Parse(json);

                if (jsonResponse["status"]?.ToString() != "success")
                {
                    MessageBox.Show("API returned an error or invalid response.");
                    return;
                }

                var dataArray = jsonResponse["data"] as JArray;
                if (dataArray == null || dataArray.Count == 0)
                {
                    MessageBox.Show("No donation records found.");
                    return;
                }

                // 5️⃣ Convert JSON → DataTable
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(dataArray.ToString());

                // ✅ Keep only specific columns
                string[] columnsToKeep = {
            "receipt_number",
            "donor_name",
            "donation_amount",
            "payment_mode",
            "mobile_number",
            "gotra",
            "created_at",
            "tithi",
            "id_number"
        };

                foreach (DataColumn col in dt.Columns.Cast<DataColumn>().ToList())
                {
                    if (!columnsToKeep.Contains(col.ColumnName))
                        dt.Columns.Remove(col);
                }

                // Bind to DataGridView
                donationTableList.DataSource = dt;

                // Rename columns for display
                donationTableList.Columns["receipt_number"].HeaderText = "Receipt Number";
                donationTableList.Columns["donor_name"].HeaderText = "Donor Name";
                donationTableList.Columns["donation_amount"].HeaderText = "Donor Amount";
                donationTableList.Columns["payment_mode"].HeaderText = "Payment Mode";
                donationTableList.Columns["mobile_number"].HeaderText = "Mobile";
                donationTableList.Columns["gotra"].HeaderText = "Gotra";
                donationTableList.Columns["created_at"].HeaderText = "Created At";
                donationTableList.Columns["tithi"].HeaderText = "Tithi";
                donationTableList.Columns["id_number"].HeaderText = "ID Number";

                // Format date column
                if (donationTableList.Columns["created_at"] != null)
                    donationTableList.Columns["created_at"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // 7️⃣ Pagination info
                var pagination = jsonResponse["pagination"];
                if (pagination != null)
                {
                    int currentPage = pagination.Value<int>("current_page");
                    int lastPage = pagination.Value<int>("last_page");
                    bool hasNext = pagination.Value<bool>("has_next");

                    lblPageInfo.Text = $"Page {currentPage} of {lastPage}";
                    btnNext.Enabled = hasNext;
                    btnPrev.Enabled = currentPage > 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                // ✅ Hide loader
                picLoader.Visible = false;
                donationTableList.Enabled = true;
            }
        }


        #endregion

        #region Buttons

        private async void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            await LoadDonationData(page: currentPage, perPage: perPage);
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

        private async void btnSyncData_Click(object sender, EventArgs e)
        {
            await SyncDonationsAsync();
        }

        private async Task SyncDonationsAsync()
        {
            string connectionString = GlobalFunctions.ConnString;
            string apiUrl = GlobalFunctions.LiveAPIURL + "donations/store"; // 🔗 your API endpoint

            try
            {
                DataTable unsyncedData = new DataTable();

                // 1️⃣ Step 1: Fetch unsynced donations (IsDataSync = 0)
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM donations with(nolock) WHERE IsDataSync = 0";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        con.Open();
                        adapter.Fill(unsyncedData);
                    }
                }

                if (unsyncedData.Rows.Count == 0)
                {
                    MessageBox.Show("No unsynced donations found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2️⃣ Step 2: Convert DataTable rows to JSON payload
                var donationList = new List<object>();

                foreach (DataRow row in unsyncedData.Rows)
                {
                    donationList.Add(new
                    {
                        admin_id = row["admin_id"],
                        donor_name = row["donor_name"],
                        mobile_number = row["mobile_number"],
                        donation_amount = row["donation_amount"],
                        whatsapp_number = row["whatsapp_number"],
                        alternate_number = row["alternate_number"],
                        area = row["area"],
                        city = row["city"],
                        gotra = row["gotra"],
                        id_type = row["id_type"],
                        id_number = row["id_number"],
                        scheme_name = row["scheme_name"],
                        full_address = row["full_address"],
                        payment_mode = row["payment_mode"],
                        in_favour = row["in_favour"],
                        donation_date = row["donation_date"],
                        ritual_performing_date = row["ritual_performing_date"],
                        ritual_performing_date2 = row["ritual_performing_date2"],
                        tithi = row["tithi"],
                        spl_date = row["spl_date"]
                    });
                }
                string jsonPayload = JsonConvert.SerializeObject(donationList, Newtonsoft.Json.Formatting.Indented);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // 3️⃣ Step 3: POST to API
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // 4️⃣ Step 4: Update synced records
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE donations SET IsDataSync = 1 WHERE IsDataSync = 0";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        con.Open();
                        int updated = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{updated} donations synced successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while syncing donations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            await LoadDonationData(page: currentPage, perPage: perPage);
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await LoadDonationData(page: currentPage, perPage: perPage);
            }
        }
    }
}
