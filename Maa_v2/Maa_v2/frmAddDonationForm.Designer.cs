using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;


namespace Maa
{
    partial class frmAddDonationForm
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
            this.dtpDonationDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSchemeName = new System.Windows.Forms.ComboBox();
            this.cmbIDType = new System.Windows.Forms.ComboBox();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.txtReceiptNumber = new System.Windows.Forms.TextBox();
            this.txtDonationAmount = new System.Windows.Forms.TextBox();
            this.txtGotram = new System.Windows.Forms.TextBox();
            this.txWhatsAppNumber = new System.Windows.Forms.TextBox();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.txtAlternateNumber = new System.Windows.Forms.TextBox();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtFullAddress = new System.Windows.Forms.TextBox();
            this.txtInFaverOff = new System.Windows.Forms.TextBox();
            this.txtDonarName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.dtpDonationDate);
            this.groupBox1.Controls.Add(this.cmbSchemeName);
            this.groupBox1.Controls.Add(this.cmbIDType);
            this.groupBox1.Controls.Add(this.cmbPaymentMode);
            this.groupBox1.Controls.Add(this.txtReceiptNumber);
            this.groupBox1.Controls.Add(this.txtDonationAmount);
            this.groupBox1.Controls.Add(this.txtGotram);
            this.groupBox1.Controls.Add(this.txWhatsAppNumber);
            this.groupBox1.Controls.Add(this.txtMobileNumber);
            this.groupBox1.Controls.Add(this.txtAlternateNumber);
            this.groupBox1.Controls.Add(this.txtIDNumber);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.txtArea);
            this.groupBox1.Controls.Add(this.txtFullAddress);
            this.groupBox1.Controls.Add(this.txtInFaverOff);
            this.groupBox1.Controls.Add(this.txtDonarName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1336, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpDonationDate
            // 
            this.dtpDonationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDonationDate.Location = new System.Drawing.Point(924, 22);
            this.dtpDonationDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDonationDate.Name = "dtpDonationDate";
            this.dtpDonationDate.Size = new System.Drawing.Size(270, 26);
            this.dtpDonationDate.TabIndex = 49;
            // 
            // cmbSchemeName
            // 
            this.cmbSchemeName.FormattingEnabled = true;
            this.cmbSchemeName.Location = new System.Drawing.Point(924, 94);
            this.cmbSchemeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSchemeName.Name = "cmbSchemeName";
            this.cmbSchemeName.Size = new System.Drawing.Size(284, 28);
            this.cmbSchemeName.TabIndex = 11;
            // 
            // cmbIDType
            // 
            this.cmbIDType.FormattingEnabled = true;
            this.cmbIDType.ItemHeight = 20;
            this.cmbIDType.Location = new System.Drawing.Point(309, 242);
            this.cmbIDType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbIDType.Name = "cmbIDType";
            this.cmbIDType.Size = new System.Drawing.Size(284, 28);
            this.cmbIDType.TabIndex = 7;
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(309, 94);
            this.cmbPaymentMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(284, 28);
            this.cmbPaymentMode.TabIndex = 3;
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.Location = new System.Drawing.Point(924, 246);
            this.txtReceiptNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiptNumber.MaxLength = 10;
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.Size = new System.Drawing.Size(284, 26);
            this.txtReceiptNumber.TabIndex = 15;
            this.txtReceiptNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptNumber_KeyPress);
            // 
            // txtDonationAmount
            // 
            this.txtDonationAmount.Location = new System.Drawing.Point(924, 281);
            this.txtDonationAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDonationAmount.MaxLength = 10;
            this.txtDonationAmount.Name = "txtDonationAmount";
            this.txtDonationAmount.Size = new System.Drawing.Size(284, 26);
            this.txtDonationAmount.TabIndex = 16;
            this.txtDonationAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonationAmount_KeyPress);
            // 
            // txtGotram
            // 
            this.txtGotram.Location = new System.Drawing.Point(924, 56);
            this.txtGotram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGotram.MaxLength = 50;
            this.txtGotram.Name = "txtGotram";
            this.txtGotram.Size = new System.Drawing.Size(284, 26);
            this.txtGotram.TabIndex = 10;
            // 
            // txWhatsAppNumber
            // 
            this.txWhatsAppNumber.Location = new System.Drawing.Point(924, 174);
            this.txWhatsAppNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txWhatsAppNumber.MaxLength = 10;
            this.txWhatsAppNumber.Name = "txWhatsAppNumber";
            this.txWhatsAppNumber.Size = new System.Drawing.Size(284, 26);
            this.txWhatsAppNumber.TabIndex = 13;
            this.txWhatsAppNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txWhatsAppNumber_KeyPress);
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Location = new System.Drawing.Point(924, 137);
            this.txtMobileNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMobileNumber.MaxLength = 10;
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(284, 26);
            this.txtMobileNumber.TabIndex = 12;
            this.txtMobileNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNumber_KeyPress);
            // 
            // txtAlternateNumber
            // 
            this.txtAlternateNumber.Location = new System.Drawing.Point(924, 217);
            this.txtAlternateNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAlternateNumber.MaxLength = 10;
            this.txtAlternateNumber.Name = "txtAlternateNumber";
            this.txtAlternateNumber.Size = new System.Drawing.Size(284, 26);
            this.txtAlternateNumber.TabIndex = 14;
            this.txtAlternateNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlternateNumber_KeyPress);
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Location = new System.Drawing.Point(309, 278);
            this.txtIDNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDNumber.MaxLength = 50;
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(284, 26);
            this.txtIDNumber.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(309, 201);
            this.txtCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(284, 26);
            this.txtCity.TabIndex = 6;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(309, 164);
            this.txtArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtArea.MaxLength = 50;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(284, 26);
            this.txtArea.TabIndex = 5;
            // 
            // txtFullAddress
            // 
            this.txtFullAddress.Location = new System.Drawing.Point(309, 133);
            this.txtFullAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFullAddress.MaxLength = 150;
            this.txtFullAddress.Name = "txtFullAddress";
            this.txtFullAddress.Size = new System.Drawing.Size(284, 26);
            this.txtFullAddress.TabIndex = 4;
            // 
            // txtInFaverOff
            // 
            this.txtInFaverOff.Location = new System.Drawing.Point(309, 58);
            this.txtInFaverOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInFaverOff.MaxLength = 50;
            this.txtInFaverOff.Name = "txtInFaverOff";
            this.txtInFaverOff.Size = new System.Drawing.Size(284, 26);
            this.txtInFaverOff.TabIndex = 2;
            // 
            // txtDonarName
            // 
            this.txtDonarName.Location = new System.Drawing.Point(309, 26);
            this.txtDonarName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDonarName.MaxLength = 50;
            this.txtDonarName.Name = "txtDonarName";
            this.txtDonarName.Size = new System.Drawing.Size(284, 26);
            this.txtDonarName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(770, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Receipt Number";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(770, 283);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Donation Amount";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(773, 212);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(134, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Alternate Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "ID Number";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(773, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "WhatsApp Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(773, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Mobile Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "City";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Full Address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(773, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Scheme Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Area";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(773, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Gotram";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Payment Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "In Favour Of";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(773, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Donation Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Donar Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(827, 413);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 36);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1148, 413);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 36);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(934, 413);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 36);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1041, 413);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 36);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmAddDonationForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1356, 468);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAddDonationForm";
            this.Text = "frmAddDonationForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label18;
        private Label label17;
        private Label label7;
        private Label label16;
        private Label label6;
        private Label label15;
        private Label label5;
        private Label label14;
        private Label label4;
        private Label label13;
        private Label label3;
        private Label label12;
        private Label label2;
        private Label label11;
        private Label label1;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox txtIDNumber;
        private TextBox txtInFaverOff;
        private TextBox txtDonarName;
        private TextBox txtDonationAmount;
        private TextBox txtAlternateNumber;
        private TextBox textBox16;
        private TextBox textBox15;
        private TextBox textBox14;
        private TextBox textBox13;
        private TextBox textBox12;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dtpDonationDate;
        private TextBox txtFullAddress;
        private Label label10;
        private ComboBox cmbPaymentMode;
        private ComboBox cmbIDType;
        private ComboBox cmbSchemeName;
        private TextBox txtCity;
        private TextBox txtArea;
        private TextBox txtGotram;
        private TextBox txWhatsAppNumber;
        private TextBox txtMobileNumber;
        private TextBox txtReceiptNumber;
        private Label label8;
        private Button btnUpdate;
        private Button btnDelete;
    }
}