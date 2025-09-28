using CrystalDecisions.CrystalReports.Engine;
using Maa_v2;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Maa
{
    public partial class frmAddDonationForm : Form
    {
        public frmAddDonationForm()
        {
            InitializeComponent();
            LoadPaymentMode();
            LoadIDType();
            LoadSchemes();
            this.Load += frmAddDonationForm_Load;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            RolePermission permission = GlobalFunctions.GetRolePermission(GlobalFunctions.role, this.Name);
            if (permission != null)
            {
                btnSave.Enabled = permission.CanSave;
                btnUpdate.Enabled = permission.CanUpdate;
                btnDelete.Enabled = permission.CanDelete;
            }

        }

        private void LoadPaymentMode()
        {
            cmbPaymentMode.Items.Clear();
            cmbPaymentMode.Items.Add("Cash");
            cmbPaymentMode.Items.Add("Check");
            cmbPaymentMode.Items.Add("Credit Card");
            cmbPaymentMode.Items.Add("Debit Card");
            cmbPaymentMode.Items.Add("Online");
            cmbPaymentMode.SelectedIndex = 0; // Set default selection
        }

        private void LoadIDType()
        {
            cmbIDType.Items.Clear();
            cmbIDType.Items.Add("Aadhar Card");
            cmbIDType.Items.Add("Pan Card");
            cmbIDType.Items.Add("VoterID");
            cmbIDType.Items.Add("Driver's License");
            cmbIDType.Items.Add("Passport");
            cmbIDType.SelectedIndex = 0; // Set default selection
        }


        // Add this in your form class
        private DataGridView dgvDonations;

        // Keep a class-level variable to store selected donation ID
        private int selectedDonationId = 0;

        // Attach this event to your DataGridView



        private void frmAddDonationForm_Load(object sender, EventArgs e)
        {
            dtpDonationDate.Value = DateTime.Now;

            // === GroupBox setup ===
            groupBox1.Top = 20;
            groupBox1.Left = 10;
            groupBox1.Width = this.ClientSize.Width - 20;
            groupBox1.Height = 387;

            // === DataGridView setup ===
            dgvDonations = new DataGridView
            {
                Top = groupBox1.Bottom + 10,
                Left = 10,
                Width = this.ClientSize.Width - 20,
                Height = this.ClientSize.Height - (groupBox1.Bottom + 30),
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

            dgvDonations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 155);
            dgvDonations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDonations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvDonations.ColumnHeadersHeight = 40;

            dgvDonations.DefaultCellStyle.BackColor = Color.White;
            dgvDonations.DefaultCellStyle.ForeColor = Color.Black;
            dgvDonations.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvDonations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 255);
            dgvDonations.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDonations.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            this.Controls.Add(dgvDonations);

            // === Attach double click event AFTER DataGridView is created ===
            dgvDonations.CellDoubleClick += DgvDonations_CellDoubleClick;

            // === Handle form resize dynamically ===
            this.Resize += (s, ev) =>
            {
                groupBox1.Width = this.ClientSize.Width - 20;
                dgvDonations.Top = groupBox1.Bottom + 10;
                dgvDonations.Width = this.ClientSize.Width - 20;
                dgvDonations.Height = this.ClientSize.Height - dgvDonations.Top - 20;
            };

            // === Load today's donations ===
            LoadTodaysDonations();
        }

        private void DgvDonations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            DataGridViewRow row = dgvDonations.Rows[e.RowIndex];

            // Make sure row has data
            if (row.DataBoundItem == null) return;

            cmbPaymentMode.Text = row.Cells["payment_mode"].Value.ToString();
            txtInFaverOff.Text = row.Cells["in_favour"].Value.ToString();
            txtDonarName.Text = row.Cells["donor_name"].Value.ToString();
            txtMobileNumber.Text = row.Cells["mobile_number"].Value.ToString();
            txWhatsAppNumber.Text = row.Cells["whatsapp_number"].Value.ToString();
            txtAlternateNumber.Text = row.Cells["alternate_number"].Value.ToString();
            txtArea.Text = row.Cells["area"].Value.ToString();
            txtCity.Text = row.Cells["city"].Value.ToString();
            txtGotram.Text = row.Cells["gotra"].Value.ToString();
            cmbIDType.Text = row.Cells["id_type"].Value.ToString();
            txtIDNumber.Text = row.Cells["id_number"].Value.ToString();
            cmbSchemeName.Text = row.Cells["scheme_name"].Value.ToString();
            txtDonationAmount.Text = row.Cells["donation_amount"].Value.ToString();
            txtFullAddress.Text = row.Cells["full_address"].Value.ToString();
            dtpDonationDate.Value = Convert.ToDateTime(row.Cells["donation_date"].Value);
            txtReceiptNumber.Text = row.Cells["receipt_number"].Value.ToString();

            // Set the selectedDonationId for updates
            selectedDonationId = Convert.ToInt32(row.Cells["id"].Value);
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            RolePermission permission = GlobalFunctions.GetRolePermission(GlobalFunctions.role, this.Name);
            if (permission != null)
            {
                btnSave.Enabled = permission.CanSave;
                btnUpdate.Enabled = permission.CanUpdate;
                btnDelete.Enabled = permission.CanDelete;
            }
        }

        private void LoadTodaysDonations()
        {
            DataTable dt = new DataTable();
            string connStr = GlobalFunctions.ConnString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = @"
                        SELECT 
                            receipt_number AS [Receipt Number],
                            donor_name AS [Donor Name],
                            donation_amount AS [Donor Amount],
                            payment_mode AS [Payment Mode],
                            mobile_number AS [Mobile],
                            gotra AS [Gotra],
                            created_at AS [Created At]
                        FROM donations
                        WHERE CAST(created_at AS DATE) = CAST(GETDATE() AS DATE)
                        ORDER BY created_at DESC";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            dgvDonations.DataSource = dt;
        }

        private void LoadSchemes()
        {
            string connStr = GlobalFunctions.ConnString;
            using (var con = new SqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT id, name FROM schemes WHERE status = 1"; // load only active schemes
                using (var cmd = new SqlCommand(sql, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbSchemeName.DataSource = dt;
                    cmbSchemeName.DisplayMember = "name";   // what user sees
                    cmbSchemeName.ValueMember = "id";       // what you save to DB
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDonarName.Text))
            {
                MessageBox.Show("Please enter Donor Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonarName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMobileNumber.Text))
            {
                MessageBox.Show("Please enter Mobile Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNumber.Focus();
                return false;
            }

            if (cmbIDType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select ID Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbIDType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIDNumber.Text))
            {
                MessageBox.Show("Please enter ID Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDonationAmount.Text))
            {
                MessageBox.Show("Please enter Donation Amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonationAmount.Focus();
                return false;
            }

            if (cmbPaymentMode.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Payment Mode.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMode.Focus();
                return false;
            }

            if (cmbSchemeName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Scheme Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSchemeName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullAddress.Text))
            {
                MessageBox.Show("Please enter Full Address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReceiptNumber.Text))
            {
                MessageBox.Show("Please enter Receipt Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceiptNumber.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtInFaverOff.Text))
            {
                MessageBox.Show("Please enter In Favour Of.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInFaverOff.Focus();
                return false;
            }

            return true; // ✅ All validations passed
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                InsertDonation(
                    cmbPaymentMode.Text,
                    txtInFaverOff.Text,
                    txtDonarName.Text,
                    txtMobileNumber.Text,
                    txWhatsAppNumber.Text,
                    txtAlternateNumber.Text,
                    txtArea.Text,
                    txtCity.Text,
                    txtGotram.Text,
                    cmbIDType.Text,
                    txtIDNumber.Text,
                    cmbSchemeName.Text,
                    string.IsNullOrWhiteSpace(txtDonationAmount.Text) ? 0 : Convert.ToDecimal(txtDonationAmount.Text),
                    txtFullAddress.Text,
                    dtpDonationDate.Value,
                    txtReceiptNumber.Text
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertDonation(
    string paymentMode,
    string inFavour,
    string donorName,
    string mobileNumber,
    string whatsappNumber,
    string alternateNumber,
    string area,
    string city,
    string gotra,
    string idType,
    string idNumber,
    string schemeName,
    decimal donationAmount,
    string fullAddress,
    DateTime donationDate,
    string receiptNumber
)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    string query = @"
            INSERT INTO donations
            (payment_mode, in_favour, donor_name, mobile_number, whatsapp_number, alternate_number, 
             area, city, gotra, id_type, id_number, scheme_name, donation_amount, full_address, donation_date, receipt_number, created_at, updated_at)
            VALUES
            (@payment_mode, @in_favour, @donor_name, @mobile_number, @whatsapp_number, @alternate_number, 
             @area, @city, @gotra, @id_type, @id_number, @scheme_name, @donation_amount, @full_address, @donation_date, @receiptNumber, GETDATE(), GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@payment_mode", paymentMode);
                        cmd.Parameters.AddWithValue("@in_favour", inFavour);
                        cmd.Parameters.AddWithValue("@donor_name", donorName);
                        cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);
                        cmd.Parameters.AddWithValue("@whatsapp_number", whatsappNumber);
                        cmd.Parameters.AddWithValue("@alternate_number", alternateNumber);
                        cmd.Parameters.AddWithValue("@area", area);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@gotra", gotra);
                        cmd.Parameters.AddWithValue("@id_type", idType);
                        cmd.Parameters.AddWithValue("@id_number", idNumber);
                        cmd.Parameters.AddWithValue("@scheme_name", schemeName);
                        cmd.Parameters.AddWithValue("@donation_amount", donationAmount);
                        cmd.Parameters.AddWithValue("@full_address", fullAddress);
                        cmd.Parameters.AddWithValue("@donation_date", donationDate);
                        cmd.Parameters.AddWithValue("@receiptNumber", receiptNumber);

                        con.Open();
                        cmd.ExecuteNonQuery(); // ✅ use this instead of ExecuteScalar()

                        MessageBox.Show("Donation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Use the same receiptNumber you passed in
                        frmPreview preview = new frmPreview(receiptNumber);
                        preview.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting donation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDonation(int donationId)
        {
            if (donationId <= 0)
            {
                MessageBox.Show("Please select a donation to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this donation?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    string query = "Update donations set deleted_at=GETDATE() WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", donationId);
                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("Donation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTodaysDonations(); // Refresh grid
                            ClearControls(); // Clear form inputs
                            selectedDonationId = 0;
                            btnSave.Enabled = true;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete donation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting donation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txWhatsAppNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtAlternateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtReceiptNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtDonationAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedDonationId <= 0)
            {
                MessageBox.Show("Please select a donation record from the list to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs())
                return;

            UpdateDonation(
                selectedDonationId,
                cmbPaymentMode.Text,
                txtInFaverOff.Text,
                txtDonarName.Text,
                txtMobileNumber.Text,
                txWhatsAppNumber.Text,
                txtAlternateNumber.Text,
                txtArea.Text,
                txtCity.Text,
                txtGotram.Text,
                cmbIDType.Text,
                txtIDNumber.Text,
                cmbSchemeName.Text,
                string.IsNullOrWhiteSpace(txtDonationAmount.Text) ? 0 : Convert.ToDecimal(txtDonationAmount.Text),
                txtFullAddress.Text,
                dtpDonationDate.Value,
                txtReceiptNumber.Text
            );

            // Reset after update
            selectedDonationId = 0;
            ClearControls();
        }

        private void ClearControls()
        {
            cmbPaymentMode.SelectedIndex = 0;
            txtInFaverOff.Clear();
            txtDonarName.Clear();
            txtMobileNumber.Clear();
            txWhatsAppNumber.Clear();
            txtAlternateNumber.Clear();
            txtArea.Clear();
            txtCity.Clear();
            txtGotram.Clear();
            cmbIDType.SelectedIndex = 0;
            txtIDNumber.Clear();
            cmbSchemeName.SelectedIndex = 0;
            txtDonationAmount.Clear();
            txtFullAddress.Clear();
            dtpDonationDate.Value = DateTime.Now;
            txtReceiptNumber.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDonation(selectedDonationId);
        }

        public void UpdateDonation(
    int donationId,
    string paymentMode,
    string inFavour,
    string donorName,
    string mobileNumber,
    string whatsappNumber,
    string alternateNumber,
    string area,
    string city,
    string gotra,
    string idType,
    string idNumber,
    string schemeName,
    decimal donationAmount,
    string fullAddress,
    DateTime donationDate,
    string receiptNumber
)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    string query = @"
                UPDATE donations
                SET
                    payment_mode = @payment_mode,
                    in_favour = @in_favour,
                    donor_name = @donor_name,
                    mobile_number = @mobile_number,
                    whatsapp_number = @whatsapp_number,
                    alternate_number = @alternate_number,
                    area = @area,
                    city = @city,
                    gotra = @gotra,
                    id_type = @id_type,
                    id_number = @id_number,
                    scheme_name = @scheme_name,
                    donation_amount = @donation_amount,
                    full_address = @full_address,
                    donation_date = @donation_date,
                    receipt_number = @receiptNumber,
                    updated_at = GETDATE()
                WHERE id = @donationId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@payment_mode", paymentMode);
                        cmd.Parameters.AddWithValue("@in_favour", inFavour);
                        cmd.Parameters.AddWithValue("@donor_name", donorName);
                        cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);
                        cmd.Parameters.AddWithValue("@whatsapp_number", whatsappNumber);
                        cmd.Parameters.AddWithValue("@alternate_number", alternateNumber);
                        cmd.Parameters.AddWithValue("@area", area);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@gotra", gotra);
                        cmd.Parameters.AddWithValue("@id_type", idType);
                        cmd.Parameters.AddWithValue("@id_number", idNumber);
                        cmd.Parameters.AddWithValue("@scheme_name", schemeName);
                        cmd.Parameters.AddWithValue("@donation_amount", donationAmount);
                        cmd.Parameters.AddWithValue("@full_address", fullAddress);
                        cmd.Parameters.AddWithValue("@donation_date", donationDate);
                        cmd.Parameters.AddWithValue("@receiptNumber", receiptNumber);
                        cmd.Parameters.AddWithValue("@donationId", donationId);

                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("Donation record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTodaysDonations(); // Refresh DataGridView
                            btnSave.Enabled = true;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No record was updated. Please check the ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating donation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
