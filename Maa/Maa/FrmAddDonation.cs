using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Maa
{
    public partial class FrmAddDonation : Form
    {
        public FrmAddDonation()
        {
            InitializeComponent();
            //textBox11.Visible = false;
            //textBox10.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void show_Other_Inputbox(object sender, EventArgs e)
        {
            MessageBox.Show(donationAmount.Text);
        }

        private void FrmAddDonation_Load(object sender, EventArgs e)
        {
            paymentIdInputBox.Visible = false;
            label17.Visible = false;
            paymentIdInputBox.Text = "";




            //tithiInput Hide
            tithiLabel.Visible = false;
            tithiInput.Visible = false;
            tithiInput.Text = "";
            //splDate Hide
            splDateIabel.Visible = false;
            splDateInput.Visible = false;
            splDateInput.Text = "";
            //alternateNumberInput Hide
            alternateNumberLabel.Visible = false;
            alternateNumberInput.Visible = false;
            alternateNumberInput.Text = "";
            //ritualPerformingDateInput Hide
            ritualPerformingDateLabel.Visible = false;
            ritualPerformingDateInput.Visible = false;
            ritualPerformingDateInput.Text = "";
            //ritualPerformingDateInput2 Hide
            ritualPerformingDateIable2.Visible = false;
            ritualPerformingDateInput2.Visible = false;
            ritualPerformingDateInput.Text = "";
            appendValuesOfSchemes();
        }

        private void selectScheme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void appendValuesOfSchemes()
        {
            string connStr = GlobalFunctions.ConnString;
            string sql = @"SELECT name FROM schemes WHERE status = 1";

            using (var con = new MySqlConnection(connStr))
            {
                try
                {
                    con.Open();

                    using (var cmd = new MySqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {

                        // Check if we have data
                        bool hasData = false;
                        while (reader.Read())
                        {
                            // Add the name to the ComboBox (assuming the column name is 'name')
                            selectScheme.Items.Add(reader["name"].ToString());
                            hasData = true;
                        }

                        // If no data found, disable ComboBox or keep it in a non-editable state
                        if (!hasData)
                        {
                            selectScheme.Enabled = false;  // Disable ComboBox if no data found
                        }

                        selectScheme.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void IdType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (paymentModeDropdown.SelectedItem.ToString() == "Cash")
            {
                paymentIdInputBox.Visible = false;
                label17.Visible = false;
                paymentIdInputBox.Text = "";

            }
            else
            {
                label17.Visible = true;
                paymentIdInputBox.Visible = true;
                paymentIdInputBox.Text = "";
                paymentIdInputBox.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void donationTotalAmount_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(donationTotalAmount.Text, out decimal amount))
            {
                if (amount > 2000)
                {
                    tithiLabel.Visible = true;
                    tithiInput.Visible = true;
                    splDateIabel.Visible = true;
                    splDateInput.Visible = true;
                    alternateNumberLabel.Visible = true;
                    alternateNumberInput.Visible = true;
                    ritualPerformingDateLabel.Visible = true;
                    ritualPerformingDateInput.Visible = true;
                    ritualPerformingDateIable2.Visible = true;
                    ritualPerformingDateInput2.Visible = true;
                }
                else
                {
                    //tithiInput Hide
                    tithiLabel.Visible = false;
                    tithiInput.Visible = false;
                    tithiInput.Text = "";
                    //splDate Hide
                    splDateIabel.Visible = false;
                    splDateInput.Visible = false;
                    splDateInput.Text = "";
                    //alternateNumberInput Hide
                    alternateNumberLabel.Visible = false;
                    alternateNumberInput.Visible = false;
                    alternateNumberInput.Text = "";
                    //ritualPerformingDateInput Hide
                    ritualPerformingDateLabel.Visible = false;
                    ritualPerformingDateInput.Visible = false;
                    ritualPerformingDateInput.Text = "";
                    //ritualPerformingDateInput2 Hide
                    ritualPerformingDateIable2.Visible = false;
                    ritualPerformingDateInput2.Visible = false;
                    ritualPerformingDateInput.Text = "";

                }
            }
            else
            {
                donationTotalAmount.Text = "";
                // ❌ Not a valid number
                MessageBox.Show("Please enter a valid numeric amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tithiInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void donationSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = GlobalFunctions.ConnString; // अपना connection string
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();

                    string sql = @"INSERT INTO donations 
        (donor_name, donation_date, in_favour, donation_amount, payment_mode,payment_mode_details, receipt_number, 
         full_address, gotra, id_type, id_number, scheme_name, mobile_number, spl_date, tithi, 
         ritual_performing_date2, ritual_performing_date,alternate_number, created_at, updated_at) 
        VALUES 
        (@donor_name, @donation_date, @in_favour, @donation_amount, @payment_mode, @receipt_number, 
         @full_address, @gotra, @id_type, @id_number, @scheme_name, @mobile_number, @spl_date, @tithi, 
         @ritual_performing_date2, @ritual_performing_date,@alternate_number, NOW(), NOW())";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@donor_name", donarNameInput.Text);
                        cmd.Parameters.AddWithValue("@donation_date", donationDateInput.Text);
                        cmd.Parameters.AddWithValue("@in_favour", inFavourOfInput.Text);
                        cmd.Parameters.AddWithValue("@donation_amount", donationTotalAmount.Text);
                        cmd.Parameters.AddWithValue("@payment_mode", paymentModeDropdown.Text);
                        cmd.Parameters.AddWithValue("@payment_mode_details", paymentIdInputBox.Text);
                        cmd.Parameters.AddWithValue("@full_address", addressInputBox.Text);
                        cmd.Parameters.AddWithValue("@gotra", gortramInputBox.Text);
                        cmd.Parameters.AddWithValue("@id_type", IdTypeDropdown.Text);
                        cmd.Parameters.AddWithValue("@id_number", idNumberInputBox.Text);
                        cmd.Parameters.AddWithValue("@scheme_name", selectScheme.Text);
                        cmd.Parameters.AddWithValue("@mobile_number", mobileInputBox.Text);
                        cmd.Parameters.AddWithValue("@spl_date", splDateInput.Text);
                        cmd.Parameters.AddWithValue("@tithi", tithiInput.Text);
                        cmd.Parameters.AddWithValue("@ritual_performing_date2", ritualPerformingDateInput2.Text);
                        cmd.Parameters.AddWithValue("@ritual_performing_date", ritualPerformingDateInput.Text);
                        cmd.Parameters.AddWithValue("@alternate_number", alternateNumberInput.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Donation saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }

      
    }
}
