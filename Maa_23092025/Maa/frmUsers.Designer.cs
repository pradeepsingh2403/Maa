namespace Maa
{
    partial class frmUsers
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
            groupBox1 = new GroupBox();
            cmbStatus = new ComboBox();
            cmbRole = new ComboBox();
            txtPassword = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtUserName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnUpdate = new Button();
            btnAdd = new Button();
            groupBox3 = new GroupBox();
            dgv = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(cmbRole);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(767, 538);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(228, 227);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(350, 33);
            cmbStatus.TabIndex = 5;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(228, 174);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(350, 33);
            cmbRole.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(228, 281);
            txtPassword.MaxLength = 25;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(350, 31);
            txtPassword.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(228, 130);
            txtPhone.MaxLength = 10;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(350, 31);
            txtPhone.TabIndex = 3;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(228, 83);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 31);
            txtEmail.TabIndex = 2;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(228, 38);
            txtUserName.MaxLength = 50;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(350, 31);
            txtUserName.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 281);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 0;
            label6.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 227);
            label5.Name = "label5";
            label5.Size = new Size(60, 25);
            label5.TabIndex = 0;
            label5.Text = "Status";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 177);
            label4.Name = "label4";
            label4.Size = new Size(46, 25);
            label4.TabIndex = 0;
            label4.Text = "Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 130);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 0;
            label3.Text = "Phone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 83);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 0;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(btnAdd);
            groupBox2.Location = new Point(12, 445);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(767, 103);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(579, 44);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(448, 44);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ButtonHighlight;
            groupBox3.Controls.Add(dgv);
            groupBox3.Location = new Point(790, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(908, 546);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(14, 27);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 62;
            dgv.Size = new Size(889, 508);
            dgv.TabIndex = 0;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1700, 556);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmUsers";
            Text = "Users";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtUserName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbStatus;
        private ComboBox cmbRole;
        private GroupBox groupBox2;
        private Button btnUpdate;
        private Button btnAdd;
        private GroupBox groupBox3;
        private DataGridView dgv;
        private TextBox txtPassword;
        private Label label6;
    }
}