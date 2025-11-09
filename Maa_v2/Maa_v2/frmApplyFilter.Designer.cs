namespace Maa
{
    partial class frmApplyFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApplyFilter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mcTithi = new System.Windows.Forms.MonthCalendar();
            this.mcEndDate = new System.Windows.Forms.MonthCalendar();
            this.mcStartDate = new System.Windows.Forms.MonthCalendar();
            this.btnMonthViewEndDate = new System.Windows.Forms.Button();
            this.btnMonthViewTithi = new System.Windows.Forms.Button();
            this.btnMonthViewStartDate = new System.Windows.Forms.Button();
            this.txtTithi = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.txtMaxAmount = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtMinAmount = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.mcTithi);
            this.groupBox1.Controls.Add(this.mcEndDate);
            this.groupBox1.Controls.Add(this.mcStartDate);
            this.groupBox1.Controls.Add(this.btnMonthViewEndDate);
            this.groupBox1.Controls.Add(this.btnMonthViewTithi);
            this.groupBox1.Controls.Add(this.btnMonthViewStartDate);
            this.groupBox1.Controls.Add(this.txtTithi);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.cmbPaymentMode);
            this.groupBox1.Controls.Add(this.txtIDNumber);
            this.groupBox1.Controls.Add(this.txtMaxAmount);
            this.groupBox1.Controls.Add(this.txtMobileNo);
            this.groupBox1.Controls.Add(this.txtMinAmount);
            this.groupBox1.Controls.Add(this.txtReceiptNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(629, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // mcTithi
            // 
            this.mcTithi.Location = new System.Drawing.Point(53, 109);
            this.mcTithi.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.mcTithi.Name = "mcTithi";
            this.mcTithi.TabIndex = 12;
            this.mcTithi.Visible = false;
            this.mcTithi.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcTithi_DateSelected);
            // 
            // mcEndDate
            // 
            this.mcEndDate.Location = new System.Drawing.Point(53, 84);
            this.mcEndDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.mcEndDate.Name = "mcEndDate";
            this.mcEndDate.TabIndex = 12;
            this.mcEndDate.Visible = false;
            this.mcEndDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcEndDate_DateSelected);
            // 
            // mcStartDate
            // 
            this.mcStartDate.Location = new System.Drawing.Point(53, 62);
            this.mcStartDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.mcStartDate.Name = "mcStartDate";
            this.mcStartDate.TabIndex = 12;
            this.mcStartDate.Visible = false;
            this.mcStartDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcStartDate_DateSelected);
            // 
            // btnMonthViewEndDate
            // 
            this.btnMonthViewEndDate.Location = new System.Drawing.Point(566, 117);
            this.btnMonthViewEndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMonthViewEndDate.Name = "btnMonthViewEndDate";
            this.btnMonthViewEndDate.Size = new System.Drawing.Size(28, 21);
            this.btnMonthViewEndDate.TabIndex = 11;
            this.btnMonthViewEndDate.Text = "...";
            this.btnMonthViewEndDate.UseVisualStyleBackColor = true;
            this.btnMonthViewEndDate.Click += new System.EventHandler(this.btnMonthViewEndDate_Click);
            // 
            // btnMonthViewTithi
            // 
            this.btnMonthViewTithi.Location = new System.Drawing.Point(285, 144);
            this.btnMonthViewTithi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMonthViewTithi.Name = "btnMonthViewTithi";
            this.btnMonthViewTithi.Size = new System.Drawing.Size(31, 21);
            this.btnMonthViewTithi.TabIndex = 11;
            this.btnMonthViewTithi.Text = "...";
            this.btnMonthViewTithi.UseVisualStyleBackColor = true;
            this.btnMonthViewTithi.Click += new System.EventHandler(this.btnMonthViewTithi_Click);
            // 
            // btnMonthViewStartDate
            // 
            this.btnMonthViewStartDate.Location = new System.Drawing.Point(285, 116);
            this.btnMonthViewStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMonthViewStartDate.Name = "btnMonthViewStartDate";
            this.btnMonthViewStartDate.Size = new System.Drawing.Size(31, 21);
            this.btnMonthViewStartDate.TabIndex = 11;
            this.btnMonthViewStartDate.Text = "...";
            this.btnMonthViewStartDate.UseVisualStyleBackColor = true;
            this.btnMonthViewStartDate.Click += new System.EventHandler(this.btnMonthViewStartDate_Click);
            // 
            // txtTithi
            // 
            this.txtTithi.Location = new System.Drawing.Point(125, 146);
            this.txtTithi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTithi.Name = "txtTithi";
            this.txtTithi.Size = new System.Drawing.Size(157, 20);
            this.txtTithi.TabIndex = 10;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(406, 121);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(157, 20);
            this.txtEndDate.TabIndex = 10;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(125, 117);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(157, 20);
            this.txtStartDate.TabIndex = 10;
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(125, 84);
            this.cmbPaymentMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(181, 21);
            this.cmbPaymentMode.TabIndex = 3;
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Location = new System.Drawing.Point(406, 90);
            this.txtIDNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIDNumber.MaxLength = 50;
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(181, 20);
            this.txtIDNumber.TabIndex = 8;
            // 
            // txtMaxAmount
            // 
            this.txtMaxAmount.Location = new System.Drawing.Point(406, 55);
            this.txtMaxAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaxAmount.MaxLength = 10;
            this.txtMaxAmount.Name = "txtMaxAmount";
            this.txtMaxAmount.Size = new System.Drawing.Size(181, 20);
            this.txtMaxAmount.TabIndex = 7;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(406, 24);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(181, 20);
            this.txtMobileNo.TabIndex = 6;
            // 
            // txtMinAmount
            // 
            this.txtMinAmount.Location = new System.Drawing.Point(125, 55);
            this.txtMinAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMinAmount.MaxLength = 10;
            this.txtMinAmount.Name = "txtMinAmount";
            this.txtMinAmount.Size = new System.Drawing.Size(181, 20);
            this.txtMinAmount.TabIndex = 2;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(125, 24);
            this.txtReceiptNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReceiptNo.MaxLength = 50;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(181, 20);
            this.txtReceiptNo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tithi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 121);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Start Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 90);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Payment Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Max Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Min Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mobile No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipt No";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(477, 275);
            this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(126, 21);
            this.btnApplyFilter.TabIndex = 10;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // frmApplyFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 306);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmApplyFilter";
            this.Text = "Apply Filter";
            this.Load += new System.EventHandler(this.frmApplyFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.TextBox txtMaxAmount;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtMinAmount;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtTithi;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Button btnMonthViewEndDate;
        private System.Windows.Forms.Button btnMonthViewTithi;
        private System.Windows.Forms.Button btnMonthViewStartDate;
        private System.Windows.Forms.MonthCalendar mcTithi;
        private System.Windows.Forms.MonthCalendar mcEndDate;
        private System.Windows.Forms.MonthCalendar mcStartDate;
    }
}