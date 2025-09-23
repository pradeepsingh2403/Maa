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
    public partial class FrmDonationFillter : Form
    {
        public string receipt_number { get; private set; } 
        public string mobile_number { get; private set; }
        public string max_Amount_Input { get; private set; }
        public string min_Amount_Input { get; private set; }
        public string filter_Payment_Mode { get; private set; }
        public string id_Number_Filter { get; private set; }
        public string start_date { get; private set; }
        public string end_date { get; private set; }
        public string tithi_filter { get; private set; }
        //public string filter_Payment_Mode { get; private set; }
        public FrmDonationFillter()
        {
            InitializeComponent();

            // Remove Minimize button
            this.MinimizeBox = false;

            // Keep/Remove Maximize as you want
            this.MaximizeBox = false;

            // Keep control box (title bar) but disable Close
            this.ControlBox = true;

            // Open in the center of screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmPopup_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            receipt_number = reciptInput.Text.Trim();
            mobile_number = mobileInput.Text.Trim();
            min_Amount_Input = minAmountInput.Text.Trim();
            max_Amount_Input = maxAmountInput.Text.Trim();
            filter_Payment_Mode = filterPaymentMode.Text.Trim();
            id_Number_Filter = idNumberFilter.Text.Trim();
            start_date = startDateFilter.Text.Trim();
            end_date = endDateFilter.Text.Trim();
            tithi_filter = tithiFilter.Text.Trim();

            this.DialogResult = DialogResult.OK;  
            this.Close();
        }
    }
}
