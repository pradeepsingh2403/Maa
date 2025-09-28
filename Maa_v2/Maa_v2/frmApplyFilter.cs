using System;
using System.Windows.Forms;

namespace Maa
{
    public partial class frmApplyFilter : Form
    {
        // Properties to pass filter values back
        public string ReceiptNo { get; private set; }
        public string MobileNumber { get; private set; }
        public decimal? MinAmount { get; private set; }
        public decimal? MaxAmount { get; private set; }
        public string PaymentMode { get; private set; }
        public string IdNumber { get; private set; }
        public string StartDate { get; private set; }
        public string EndDate { get; private set; }
        public string Tithi { get; private set; }

        public frmApplyFilter()
        {
            InitializeComponent();

            // Populate payment mode dropdown
            cmbPaymentMode.Items.Clear();
            cmbPaymentMode.Items.Add("All");
            cmbPaymentMode.Items.Add("Cash");
            cmbPaymentMode.Items.Add("Cheque");
            cmbPaymentMode.Items.Add("Credit Card");
            cmbPaymentMode.Items.Add("Debit Card");
            cmbPaymentMode.Items.Add("Online");
            cmbPaymentMode.SelectedIndex = 0; // Default selection

            // Default date values
            mcStartDate.SetDate(DateTime.Today);
            mcEndDate.SetDate(DateTime.Today);
            mcTithi.SetDate(DateTime.Today);

            mcStartDate.Visible = false;
            mcEndDate.Visible = false;
            mcTithi.Visible = false;
        }

        private void frmApplyFilter_Load(object sender, EventArgs e)
        {
            // Safe defaults on load

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            // Capture values from controls → store in properties
            ReceiptNo = txtReceiptNo.Text.Trim();
            MobileNumber = txtMobileNo.Text.Trim();
            IdNumber = txtIDNumber.Text.Trim();

            MinAmount = string.IsNullOrWhiteSpace(txtMinAmount.Text) ? (decimal?)null : Convert.ToDecimal(txtMinAmount.Text);
            MaxAmount = string.IsNullOrWhiteSpace(txtMaxAmount.Text) ? (decimal?)null : Convert.ToDecimal(txtMaxAmount.Text);

            PaymentMode = cmbPaymentMode.SelectedItem != null ? cmbPaymentMode.SelectedItem.ToString() : "All";

            StartDate = txtStartDate.Text.Trim();
            EndDate = txtEndDate.Text.Trim();
            Tithi = txtTithi.Text.Trim();

            // ---------- VALIDATION ----------

            // Amount validation
            if ((MinAmount.HasValue && !MaxAmount.HasValue) || (!MinAmount.HasValue && MaxAmount.HasValue))
            {
                MessageBox.Show("Please enter both Min Amount and Max Amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Date validation
            if ((!string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate)) ||
                (string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate)))
            {
                MessageBox.Show("Please enter both Start Date and End Date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ---------- SUCCESS ----------
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // MonthCalendar toggle buttons
        private void btnMonthViewStartDate_Click(object sender, EventArgs e)
        {
            mcStartDate.Visible = !mcStartDate.Visible;
        }

        private void btnMonthViewEndDate_Click(object sender, EventArgs e)
        {
            mcEndDate.Visible = !mcEndDate.Visible;
        }

        private void btnMonthViewTithi_Click(object sender, EventArgs e)
        {
            mcTithi.Visible = !mcTithi.Visible;
        }

        // MonthCalendar selection events
        private void mcStartDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtStartDate.Text = mcStartDate.SelectionStart.ToString("dd-MM-yyyy");
            mcStartDate.Visible = false;
        }

        private void mcEndDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtEndDate.Text = mcEndDate.SelectionStart.ToString("dd-MM-yyyy");
            mcEndDate.Visible = false;
        }

        private void mcTithi_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtTithi.Text = mcTithi.SelectionStart.ToString("dd-MM-yyyy");
            mcTithi.Visible = false;
        }
    }
}
