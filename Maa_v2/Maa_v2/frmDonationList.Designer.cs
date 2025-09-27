using System.Drawing;

namespace Maa_v2
{
    partial class frmDonationList
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView donationTableList;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExportExcel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.donationTableList = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.donationTableList)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.panelTop.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;

            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Text = "Export in Excel";
            this.btnExportExcel.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Width = 120;
            this.btnExportExcel.Height = 30;
            this.btnExportExcel.Click += BtnExportExcel_Click;

            // 
            // btnReset
            // 
            this.btnReset.Text = "Reset";
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Width = 80;
            this.btnReset.Height = 30;
            this.btnReset.Click += BtnReset_Click;

            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.Width = 100;
            this.btnApplyFilter.Height = 30;
            this.btnApplyFilter.Click += BtnApplyFilter_Click;

            // Add buttons to panel
            this.panelTop.Controls.Add(this.btnExportExcel);
            this.panelTop.Controls.Add(this.btnReset);
            this.panelTop.Controls.Add(this.btnApplyFilter);

            // 
            // donationTableList
            // 
            this.donationTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.donationTableList.BackgroundColor = System.Drawing.Color.White;
            this.donationTableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.donationTableList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.donationTableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.donationTableList.MultiSelect = false;
            this.donationTableList.ReadOnly = true;
            this.donationTableList.AllowUserToAddRows = false;
            this.donationTableList.AllowUserToDeleteRows = false;
            this.donationTableList.RowHeadersVisible = false;
            this.donationTableList.EnableHeadersVisualStyles = false;
            this.donationTableList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.donationTableList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.donationTableList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.donationTableList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            this.donationTableList.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);

            // 
            // FrmDonationList
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.donationTableList);
            this.Controls.Add(this.panelTop);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donation List";

            ((System.ComponentModel.ISupportInitialize)(this.donationTableList)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
