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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtTithi = new System.Windows.Forms.TextBox();
            this.btnMonthViewStartDate = new System.Windows.Forms.Button();
            this.btnMonthViewTithi = new System.Windows.Forms.Button();
            this.btnMonthViewEndDate = new System.Windows.Forms.Button();
            this.mcStartDate = new System.Windows.Forms.MonthCalendar();
            this.mcEndDate = new System.Windows.Forms.MonthCalendar();
            this.mcTithi = new System.Windows.Forms.MonthCalendar();
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
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(187, 130);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(270, 28);
            this.cmbPaymentMode.TabIndex = 3;
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Location = new System.Drawing.Point(609, 138);
            this.txtIDNumber.MaxLength = 50;
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(270, 26);
            this.txtIDNumber.TabIndex = 8;
            // 
            // txtMaxAmount
            // 
            this.txtMaxAmount.Location = new System.Drawing.Point(609, 84);
            this.txtMaxAmount.MaxLength = 10;
            this.txtMaxAmount.Name = "txtMaxAmount";
            this.txtMaxAmount.Size = new System.Drawing.Size(270, 26);
            this.txtMaxAmount.TabIndex = 7;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(609, 37);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(270, 26);
            this.txtMobileNo.TabIndex = 6;
            // 
            // txtMinAmount
            // 
            this.txtMinAmount.Location = new System.Drawing.Point(187, 84);
            this.txtMinAmount.MaxLength = 10;
            this.txtMinAmount.Name = "txtMinAmount";
            this.txtMinAmount.Size = new System.Drawing.Size(270, 26);
            this.txtMinAmount.TabIndex = 2;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(187, 37);
            this.txtReceiptNo.MaxLength = 50;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(270, 26);
            this.txtReceiptNo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tithi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Start Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Payment Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(495, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Max Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Min Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mobile No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipt No";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(715, 423);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(189, 33);
            this.btnApplyFilter.TabIndex = 10;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(187, 180);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(234, 26);
            this.txtStartDate.TabIndex = 10;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(609, 186);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(234, 26);
            this.txtEndDate.TabIndex = 10;
            // 
            // txtTithi
            // 
            this.txtTithi.Location = new System.Drawing.Point(187, 224);
            this.txtTithi.Name = "txtTithi";
            this.txtTithi.Size = new System.Drawing.Size(234, 26);
            this.txtTithi.TabIndex = 10;
            // 
            // btnMonthViewStartDate
            // 
            this.btnMonthViewStartDate.Location = new System.Drawing.Point(427, 178);
            this.btnMonthViewStartDate.Name = "btnMonthViewStartDate";
            this.btnMonthViewStartDate.Size = new System.Drawing.Size(46, 32);
            this.btnMonthViewStartDate.TabIndex = 11;
            this.btnMonthViewStartDate.Text = "...";
            this.btnMonthViewStartDate.UseVisualStyleBackColor = true;
            this.btnMonthViewStartDate.Click += new System.EventHandler(this.btnMonthViewStartDate_Click);
            // 
            // btnMonthViewTithi
            // 
            this.btnMonthViewTithi.Location = new System.Drawing.Point(427, 221);
            this.btnMonthViewTithi.Name = "btnMonthViewTithi";
            this.btnMonthViewTithi.Size = new System.Drawing.Size(46, 32);
            this.btnMonthViewTithi.TabIndex = 11;
            this.btnMonthViewTithi.Text = "...";
            this.btnMonthViewTithi.UseVisualStyleBackColor = true;
            this.btnMonthViewTithi.Click += new System.EventHandler(this.btnMonthViewTithi_Click);
            // 
            // btnMonthViewEndDate
            // 
            this.btnMonthViewEndDate.Location = new System.Drawing.Point(849, 180);
            this.btnMonthViewEndDate.Name = "btnMonthViewEndDate";
            this.btnMonthViewEndDate.Size = new System.Drawing.Size(42, 32);
            this.btnMonthViewEndDate.TabIndex = 11;
            this.btnMonthViewEndDate.Text = "...";
            this.btnMonthViewEndDate.UseVisualStyleBackColor = true;
            this.btnMonthViewEndDate.Click += new System.EventHandler(this.btnMonthViewEndDate_Click);
            // 
            // mcStartDate
            // 
            this.mcStartDate.Location = new System.Drawing.Point(79, 96);
            this.mcStartDate.Name = "mcStartDate";
            this.mcStartDate.TabIndex = 12;
            this.mcStartDate.Visible = false;
            this.mcStartDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcStartDate_DateSelected);
            // 
            // mcEndDate
            // 
            this.mcEndDate.Location = new System.Drawing.Point(79, 130);
            this.mcEndDate.Name = "mcEndDate";
            this.mcEndDate.TabIndex = 12;
            this.mcEndDate.Visible = false;
            this.mcEndDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcEndDate_DateSelected);
            // 
            // mcTithi
            // 
            this.mcTithi.Location = new System.Drawing.Point(79, 167);
            this.mcTithi.Name = "mcTithi";
            this.mcTithi.TabIndex = 12;
            this.mcTithi.Visible = false;
            this.mcTithi.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcTithi_DateSelected);
            // 
            // frmApplyFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 471);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.groupBox1);
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