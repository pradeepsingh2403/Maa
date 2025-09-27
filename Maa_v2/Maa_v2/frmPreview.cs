using CrystalDecisions.CrystalReports.Engine;
using Maa;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Maa_v2
{
    public partial class frmPreview : Form
    {
        private string _receiptNo;  // store receipt no

        // Constructor receives ReceiptNo from caller
        public frmPreview(string receiptNo)
        {
            InitializeComponent();
            _receiptNo = receiptNo;
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            ShowInvoiceReport();
        }

        private void ShowInvoiceReport()
        {
            try
            {
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "InvoiceAbove2000.rpt");
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);

                string connStr = GlobalFunctions.ConnString;
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"SELECT *
                             FROM donations
                             WHERE receipt_number = @receiptNo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@receiptNo", _receiptNo);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Donations");   // Table name must match what .rpt was designed with

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show($"No data found for Receipt No: {_receiptNo}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        rptDoc.SetDataSource(ds.Tables["Donations"]);
                        crystalReportViewer1.ReportSource = rptDoc;
                        crystalReportViewer1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing report: " + ex.Message);
            }
        }
    }
}
