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
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime? Tithi { get; private set; }

        public frmApplyFilter()
        {
            InitializeComponent();
            cmbPaymentMode.Items.Clear();
            cmbPaymentMode.Items.Add("Cash");
            cmbPaymentMode.Items.Add("Check");
            cmbPaymentMode.Items.Add("Credit Card");
            cmbPaymentMode.Items.Add("Debit Card");
            cmbPaymentMode.Items.Add("Online");
            cmbPaymentMode.SelectedIndex = 0; // Set default selection

            // Optional: Set default dates
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }
        private void frmApplyFilter_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddMonths(-1); // safe default
            dtpEndDate.Value = DateTime.Today;
            dtTithi.Value = DateTime.Today;
        }



    
    private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            // Capture values from controls
            string receiptNo = txtReceiptNo.Text.Trim();
            string mobileNumber = txtMobileNo.Text.Trim();
            string idNumber = txtIDNumber.Text.Trim();

            decimal? minAmount = string.IsNullOrEmpty(txtMinAmount.Text) ? (decimal?)null : Convert.ToDecimal(txtMinAmount.Text);
            decimal? maxAmount = string.IsNullOrEmpty(txtMaxAmount.Text) ? (decimal?)null : Convert.ToDecimal(txtMaxAmount.Text);

            string paymentMode = cmbPaymentMode.SelectedItem?.ToString() ?? "All";

            DateTime? startDate = dtpStartDate.Value.Date;
            DateTime? endDate = dtpEndDate.Value.Date;
            DateTime? tithi = dtTithi.Checked ? dtTithi.Value.Date : (DateTime?)null;

            // Pass these values back using properties or directly
            this.Tag = new
            {
                ReceiptNo = receiptNo,
                MobileNumber = mobileNumber,
                IdNumber = idNumber,
                MinAmount = minAmount,
                MaxAmount = maxAmount,
                PaymentMode = paymentMode,
                StartDate = startDate,
                EndDate = endDate,
                Tithi = tithi
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
