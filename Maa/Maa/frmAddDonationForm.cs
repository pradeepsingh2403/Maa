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
    public partial class frmAddDonationForm : Form
    {
        public frmAddDonationForm()
        {
            InitializeComponent();
            LoadPaymentMode();
            LoadIDType();
            LoadSchemes();
        }
        private void LoadPaymentMode()
        {
            cmbPaymentMode.Items.Clear();
            cmbPaymentMode.Items.Add("Cash");
            cmbPaymentMode.Items.Add("Check");
            cmbPaymentMode.Items.Add("Credit Card");
            cmbPaymentMode.Items.Add("Debit Card");
            cmbPaymentMode.Items.Add("Online Transfer");
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
        private void LoadSchemes()
        {
            string connStr = GlobalFunctions.ConnString;
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT id, name FROM schemes WHERE status = 1"; // load only active schemes
                using (var cmd = new MySqlCommand(sql, con))
                using (var da = new MySqlDataAdapter(cmd))
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
            // Donor Details
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

            // Donation Details
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

            // Optional checks (if mandatory in your system)
            if (string.IsNullOrWhiteSpace(txtFullAddress.Text))
            {
                MessageBox.Show("Please enter Full Address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullAddress.Focus();
                return false;
            }

            return true; // ✅ All validations passed
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = ValidateInputs();
                if (!isValid)
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
                   dtpDonationDate.Value
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
                DateTime donationDate
            )
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(GlobalFunctions.ConnString))
                {
                    string query = @"
                    INSERT INTO donations
                    (payment_mode, in_favour, donor_name, mobile_number, whatsapp_number, alternate_number, 
                     area, city, gotra, id_type, id_number, scheme_name, donation_amount, full_address, donation_date, created_at, updated_at)
                    VALUES
                    (@payment_mode, @in_favour, @donor_name, @mobile_number, @whatsapp_number, @alternate_number, 
                     @area, @city, @gotra, @id_type, @id_number, @scheme_name, @donation_amount, @full_address, @donation_date, NOW(), NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
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

                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rows > 0)
                            MessageBox.Show("Donation record inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Failed to insert donation record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting donation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txWhatsAppNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAlternateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtReceiptNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonationAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmAddDonationForm_Load(object sender, EventArgs e)
        {
            dtpDonationDate.Value = DateTime.Now;
        }
    }
}
