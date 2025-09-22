namespace Maa
{
    partial class frmAddSchema
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(985, 172);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(324, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(421, 33);
            comboBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(324, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(421, 31);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 81);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 0;
            label2.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 27);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 0;
            label1.Text = "Schema Name";
            // 
            // button1
            // 
            button1.Location = new Point(776, 18);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(776, 58);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 3;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(776, 98);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 3;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // frmAddSchema
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1697, 564);
            Controls.Add(groupBox1);
            Name = "frmAddSchema";
            Text = "Add Schema";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label2;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}