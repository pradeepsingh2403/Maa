namespace Maa
{
    partial class FrmListDonations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // DataGridView declare करो
        private System.Windows.Forms.DataGridView donationTableList;

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
            donationTableList = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            button2 = new Button();
            button1 = new Button();
            applyFilter = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)donationTableList).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // donationTableList
            // 
            donationTableList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            donationTableList.BackgroundColor = Color.White;
            donationTableList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            donationTableList.Location = new Point(3, 89);
            donationTableList.Name = "donationTableList";
            donationTableList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            donationTableList.ScrollBars = ScrollBars.Vertical;
            donationTableList.Size = new Size(982, 498);
            donationTableList.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 41.9753075F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 58.0246925F));
            tableLayoutPanel1.Size = new Size(991, 81);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(button2, 2, 0);
            tableLayoutPanel2.Controls.Add(button1, 1, 0);
            tableLayoutPanel2.Controls.Add(applyFilter, 0, 0);
            tableLayoutPanel2.Location = new Point(594, 37);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(394, 41);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // button2
            // 
            button2.AccessibleName = "exportToExcel";
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.BackColor = Color.Green;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.ForeColor = Color.White;
            button2.Location = new Point(265, 3);
            button2.Name = "button2";
            button2.Padding = new Padding(5);
            button2.Size = new Size(126, 35);
            button2.TabIndex = 4;
            button2.Text = "Export To Excel";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.AccessibleName = "resetBtn";
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.Green;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.White;
            button1.Location = new Point(134, 3);
            button1.Name = "button1";
            button1.Padding = new Padding(5);
            button1.Size = new Size(125, 35);
            button1.TabIndex = 3;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = false;
            // 
            // applyFilter
            // 
            applyFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            applyFilter.BackColor = Color.Green;
            applyFilter.BackgroundImageLayout = ImageLayout.None;
            applyFilter.FlatAppearance.BorderSize = 0;
            applyFilter.ForeColor = Color.White;
            applyFilter.Location = new Point(3, 3);
            applyFilter.Name = "applyFilter";
            applyFilter.Padding = new Padding(5);
            applyFilter.Size = new Size(125, 35);
            applyFilter.TabIndex = 2;
            applyFilter.Text = "Apply Filter";
            applyFilter.UseVisualStyleBackColor = false;
            applyFilter.MouseClick += modalOpen;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(50, 0, 0, 0);
            label1.Size = new Size(489, 34);
            label1.TabIndex = 0;
            label1.Text = "List Donation";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmListDonations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 588);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(donationTableList);
            Name = "FrmListDonations";
            Text = "List of Donations";
            Load += FrmListDonations_Load;
            ((System.ComponentModel.ISupportInitialize)donationTableList).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button2;
        private Button button1;
        private Button applyFilter;
    }
}