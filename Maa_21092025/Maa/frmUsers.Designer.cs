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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            groupBox2 = new GroupBox();
            btnAdd = new Button();
            btnUpdate = new Button();
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
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "Name";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 130);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 0;
            label3.Text = "Phone";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 227);
            label5.Name = "label5";
            label5.Size = new Size(60, 25);
            label5.TabIndex = 0;
            label5.Text = "Status";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(228, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 31);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(228, 83);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(350, 31);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(228, 130);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(350, 31);
            textBox3.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(228, 174);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(350, 33);
            comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(228, 227);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(350, 33);
            comboBox2.TabIndex = 2;
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
            // btnAdd
            // 
            btnAdd.Location = new Point(448, 44);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(579, 44);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
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
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private Button btnUpdate;
        private Button btnAdd;
        private GroupBox groupBox3;
        private DataGridView dgv;
    }
}