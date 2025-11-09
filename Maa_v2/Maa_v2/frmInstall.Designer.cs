namespace Maa_v2
{
    partial class frmInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstall));
            this.btnInstal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInstal
            // 
            this.btnInstal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstal.Location = new System.Drawing.Point(173, 66);
            this.btnInstal.Name = "btnInstal";
            this.btnInstal.Size = new System.Drawing.Size(75, 37);
            this.btnInstal.TabIndex = 0;
            this.btnInstal.Text = "Install";
            this.btnInstal.UseVisualStyleBackColor = true;
            this.btnInstal.Click += new System.EventHandler(this.btnInstal_Click);
            // 
            // frmInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 184);
            this.Controls.Add(this.btnInstal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmInstall";
            this.Text = "Install";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstal;
    }
}