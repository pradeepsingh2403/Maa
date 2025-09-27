using System.Windows.Forms;
using System.Drawing;

namespace Maa
{
    partial class MDIParent
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRolePermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDonationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donationListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(948, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRoleToolStripMenuItem,
            this.addUserToolStripMenuItem,
            this.addRolePermissionToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(81, 29);
            this.fileMenu.Text = "&Admin";
            // 
            // addRoleToolStripMenuItem
            // 
            this.addRoleToolStripMenuItem.Name = "addRoleToolStripMenuItem";
            this.addRoleToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.addRoleToolStripMenuItem.Text = "Add &Role";
            this.addRoleToolStripMenuItem.Click += new System.EventHandler(this.addRoleToolStripMenuItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.addUserToolStripMenuItem.Text = "Add U&ser";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // addRolePermissionToolStripMenuItem
            // 
            this.addRolePermissionToolStripMenuItem.Name = "addRolePermissionToolStripMenuItem";
            this.addRolePermissionToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.addRolePermissionToolStripMenuItem.Text = "Add Role &Permission";
            this.addRolePermissionToolStripMenuItem.Click += new System.EventHandler(this.addRolePermissionToolStripMenuItem_Click_1);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addSchemaToolStripMenuItem,
            this.addDonationToolStripMenuItem,
            this.donationListToolStripMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(63, 29);
            this.editMenu.Text = "&User";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.dashboardToolStripMenuItem.Text = "Dash&board";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
            // 
            // addSchemaToolStripMenuItem
            // 
            this.addSchemaToolStripMenuItem.Name = "addSchemaToolStripMenuItem";
            this.addSchemaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.addSchemaToolStripMenuItem.Text = "Add &Scheme";
            this.addSchemaToolStripMenuItem.Click += new System.EventHandler(this.addSchemaToolStripMenuItem_Click);
            // 
            // addDonationToolStripMenuItem
            // 
            this.addDonationToolStripMenuItem.Name = "addDonationToolStripMenuItem";
            this.addDonationToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.addDonationToolStripMenuItem.Text = "Add &Donation";
            this.addDonationToolStripMenuItem.Click += new System.EventHandler(this.addDonationToolStripMenuItem_Click);
            // 
            // donationListToolStripMenuItem
            // 
            this.donationListToolStripMenuItem.Name = "donationListToolStripMenuItem";
            this.donationListToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.donationListToolStripMenuItem.Text = "Donation &List";
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(55, 29);
            this.helpMenu.Text = "&Exit";
            this.helpMenu.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 665);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(948, 32);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(60, 25);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MDIParent";
            this.Text = "MDIParent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem addRoleToolStripMenuItem;
        private ToolStripMenuItem addUserToolStripMenuItem;
        private ToolStripMenuItem addRolePermissionToolStripMenuItem;
        private ToolStripMenuItem dashboardToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem addSchemaToolStripMenuItem;
        private ToolStripMenuItem addDonationToolStripMenuItem;
        private ToolStripMenuItem donationListToolStripMenuItem;
    }
}



