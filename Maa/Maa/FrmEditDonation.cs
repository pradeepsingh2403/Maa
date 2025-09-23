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
    public partial class FrmEditDonation : Form
    {
        private string _donationId;
        public FrmEditDonation(string donationId)
        {
            InitializeComponent();
            _donationId = donationId;
            // Remove Minimize button
            this.MinimizeBox = false;

            // Keep/Remove Maximize as you want
            this.MaximizeBox = false;

            // Keep control box (title bar) but disable Close
            this.ControlBox = true;

            // Open in the center of screen
            this.StartPosition = FormStartPosition.CenterScreen;
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


            string connStr = GlobalFunctions.ConnString; // अपना connection string
            string sql = @"SELECT * FROM donations WHERE id = @id";

            using (var con = new MySqlConnection(connStr))
            {
                try
                {
                    con.Open();

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        // सही parameter नाम
                        cmd.Parameters.AddWithValue("@id", _donationId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // सिर्फ पहला row read करो
                            {

                             



                                string donor_name = reader["donor_name"].ToString();
                                string in_favour = reader["in_favour"].ToString();
                                string mobile_number = reader["mobile_number"].ToString();
                                string payment_mode = reader["payment_mode"].ToString();
                                string gotra = reader["gotra"].ToString();
                                string id_type = reader["id_type"].ToString();
                                string id_number = reader["id_number"].ToString();
                                string scheme_name = reader["scheme_name"].ToString();
                                string donation_amount = reader["donation_amount"].ToString();
                                string donation_date = reader["donation_date"].ToString() ?? null;
                                string payment_mode_details = reader["payment_mode_details"].ToString();
                                string full_address = reader["full_address"].ToString();
                                string tithi = reader["tithi"].ToString();
                                string spl_date = reader["spl_date"].ToString();
                                string alternate_number = reader["alternate_number"].ToString();
                                string ritual_performing_date = reader["ritual_performing_date"].ToString();
                                string ritual_performing_date2 = reader["ritual_performing_date2"].ToString();


                                if (decimal.TryParse(donation_amount, out decimal amount))
                                {
                                    if (amount < 2000)
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

                                        MessageBox.Show("small");
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







                                //Adding Value For Update
                                donarNameInput.Text = donor_name;

                                donationDateInput.Text = donation_date ?? null;
                                inFavourOfInput.Text = in_favour;
                                donationTotalAmount.Text = donation_amount;
                                paymentModeDropdown.Text = payment_mode;
                                paymentIdInputBox.Text = payment_mode_details;
                                addressInputBox.Text = full_address;
                                gortramInputBox.Text = gotra;
                                IdTypeDropdown.Text = id_type;
                                idNumberInputBox.Text = id_number;
                                selectScheme.Text = scheme_name;
                                mobileInputBox.Text = mobile_number;
                                splDateInput.Text=spl_date;
                                tithiInput.Text=tithi;
                                ritualPerformingDateInput2.Text= ritual_performing_date2;
                                ritualPerformingDateInput.Text= ritual_performing_date;
                                alternateNumberInput.Text=alternate_number;



                            }
                            else
                            {
                                MessageBox.Show("No Data Found");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }








            //paymentIdInputBox.Visible = false;
            //label17.Visible = false;
            //paymentIdInputBox.Text = ""; 
            ////tithiInput Hide
            //tithiLabel.Visible = false;
            //tithiInput.Visible = false;
            //tithiInput.Text = "";
            ////splDate Hide
            //splDateIabel.Visible = false;
            //splDateInput.Visible = false;
            //splDateInput.Text = "";
            ////alternateNumberInput Hide
            //alternateNumberLabel.Visible = false;
            //alternateNumberInput.Visible = false;
            //alternateNumberInput.Text = "";
            ////ritualPerformingDateInput Hide
            //ritualPerformingDateLabel.Visible = false;
            //ritualPerformingDateInput.Visible = false;
            //ritualPerformingDateInput.Text = "";
            ////ritualPerformingDateInput2 Hide
            //ritualPerformingDateIable2.Visible = false;
            //ritualPerformingDateInput2.Visible = false;
            //ritualPerformingDateInput.Text = "";
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
        //    string connStr = GlobalFunctions.ConnString; // अपना connection string
        //    using (var con = new MySqlConnection(connStr))
        //    {
        //        con.Open();

        //        string sql = @"INSERT INTO donations 
        //(donor_name, donation_date, in_favour, donation_amount, payment_mode,payment_mode_details, receipt_number, 
        // full_address, gotra, id_type, id_number, scheme_name, mobile_number, spl_date, tithi, 
        // ritual_performing_date2, ritual_performing_date,alternate_number, created_at, updated_at) 
        //VALUES 
        //(@donor_name, @donation_date, @in_favour, @donation_amount, @payment_mode, @receipt_number, 
        // @full_address, @gotra, @id_type, @id_number, @scheme_name, @mobile_number, @spl_date, @tithi, 
        // @ritual_performing_date2, @ritual_performing_date,@alternate_number, NOW(), NOW())";

        //        using (var cmd = new MySqlCommand(sql, con))
        //        {
        //            cmd.Parameters.AddWithValue("@donor_name", donarNameInput.Text);
        //            cmd.Parameters.AddWithValue("@donation_date", donationDateInput.Text);
        //            cmd.Parameters.AddWithValue("@in_favour", inFavourOfInput.Text);
        //            cmd.Parameters.AddWithValue("@donation_amount", donationTotalAmount.Text);
        //            cmd.Parameters.AddWithValue("@payment_mode", paymentModeDropdown.Text);
        //            cmd.Parameters.AddWithValue("@payment_mode_details", paymentIdInputBox.Text);
        //            cmd.Parameters.AddWithValue("@full_address", addressInputBox.Text);
        //            cmd.Parameters.AddWithValue("@gotra", gortramInputBox.Text);
        //            cmd.Parameters.AddWithValue("@id_type", IdTypeDropdown.Text);
        //            cmd.Parameters.AddWithValue("@id_number", idNumberInputBox.Text);
        //            cmd.Parameters.AddWithValue("@scheme_name", selectScheme.Text);
        //            cmd.Parameters.AddWithValue("@mobile_number", mobileInputBox.Text);
        //            cmd.Parameters.AddWithValue("@spl_date", splDateInput.Text);
        //            cmd.Parameters.AddWithValue("@tithi", tithiInput.Text);
        //            cmd.Parameters.AddWithValue("@ritual_performing_date2", ritualPerformingDateInput2.Text);
        //            cmd.Parameters.AddWithValue("@ritual_performing_date", ritualPerformingDateInput.Text);
        //            cmd.Parameters.AddWithValue("@alternate_number", alternateNumberInput.Text);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }

            MessageBox.Show("Donation saved successfully!");
        }

    }
}
