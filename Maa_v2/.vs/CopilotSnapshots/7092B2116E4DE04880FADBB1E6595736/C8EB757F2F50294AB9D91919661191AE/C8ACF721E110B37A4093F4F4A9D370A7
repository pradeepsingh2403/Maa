using CrystalDecisions.CrystalReports.Engine;
using Maa;
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

namespace Maa_v2
{
    public partial class frmPreview : Form
    {
        public frmPreview()
        {
            InitializeComponent();
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            ShowInvoiceReport();
        }
        private void ShowInvoiceReport()
        {
            try
            {
                // 1. Load the report file from the solution folder (where the EXE runs)
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "InvoiceAbove2000.rpt");
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);

                // 2. Fetch data from MySQL
                string connStr = GlobalFunctions.ConnString;
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string query = @"SELECT id, donor_name, donation_amount, payment_mode, donation_date 
                                     FROM donations ORDER BY id DESC LIMIT 1"; // Example

                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable("donations"); // Set table name to match report
                    da.Fill(dt);

                    // 3. Set the data source for the report
                    rptDoc.SetDataSource(dt);

                    // 4. Assign report to viewer
                    crystalReportViewer1.ReportSource = rptDoc;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing report: " + ex.Message);
            }
        }

        }
    }
