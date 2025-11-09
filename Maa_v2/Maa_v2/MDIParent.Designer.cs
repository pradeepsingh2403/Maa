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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dashbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRolePermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDonationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donationListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.syncDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashbToolStripMenuItem,
            this.fileMenu,
            this.editMenu,
            this.syncDataToolStripMenuItem,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // dashbToolStripMenuItem
            // 
            this.dashbToolStripMenuItem.Name = "dashbToolStripMenuItem";
            this.dashbToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.dashbToolStripMenuItem.Text = "Dashboard";
            this.dashbToolStripMenuItem.Click += new System.EventHandler(this.dashbToolStripMenuItem_Click);
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRoleToolStripMenuItem,
            this.addUserToolStripMenuItem,
            this.addRolePermissionToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(55, 22);
            this.fileMenu.Text = "&Master";
            // 
            // addRoleToolStripMenuItem
            // 
            this.addRoleToolStripMenuItem.Name = "addRoleToolStripMenuItem";
            this.addRoleToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addRoleToolStripMenuItem.Text = "&Role";
            this.addRoleToolStripMenuItem.Click += new System.EventHandler(this.addRoleToolStripMenuItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addUserToolStripMenuItem.Text = "&User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // addRolePermissionToolStripMenuItem
            // 
            this.addRolePermissionToolStripMenuItem.Name = "addRolePermissionToolStripMenuItem";
            this.addRolePermissionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addRolePermissionToolStripMenuItem.Text = "&Role Permission";
            this.addRolePermissionToolStripMenuItem.Click += new System.EventHandler(this.addRolePermissionToolStripMenuItem_Click_1);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.addSchemaToolStripMenuItem,
            this.addDonationToolStripMenuItem,
            this.donationListToolStripMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(42, 22);
            this.editMenu.Text = "&User";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // addSchemaToolStripMenuItem
            // 
            this.addSchemaToolStripMenuItem.Name = "addSchemaToolStripMenuItem";
            this.addSchemaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addSchemaToolStripMenuItem.Text = "&Scheme";
            this.addSchemaToolStripMenuItem.Click += new System.EventHandler(this.addSchemaToolStripMenuItem_Click);
            // 
            // addDonationToolStripMenuItem
            // 
            this.addDonationToolStripMenuItem.Name = "addDonationToolStripMenuItem";
            this.addDonationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addDonationToolStripMenuItem.Text = "&Donation";
            this.addDonationToolStripMenuItem.Click += new System.EventHandler(this.addDonationToolStripMenuItem_Click);
            // 
            // donationListToolStripMenuItem
            // 
            this.donationListToolStripMenuItem.Name = "donationListToolStripMenuItem";
            this.donationListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.donationListToolStripMenuItem.Text = "Donation &List";
            this.donationListToolStripMenuItem.Click += new System.EventHandler(this.listDonationToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(38, 22);
            this.helpMenu.Text = "&Exit";
            this.helpMenu.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // syncDataToolStripMenuItem
            // 
            this.syncDataToolStripMenuItem.Name = "syncDataToolStripMenuItem";
            this.syncDataToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.syncDataToolStripMenuItem.Text = "&Sync Data";
            this.syncDataToolStripMenuItem.Click += new System.EventHandler(this.syncDataToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1136, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent";
            this.Text = "SRI ANNAPURNA MANDIR CHARITABLE TRUST";
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
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem addSchemaToolStripMenuItem;
        private ToolStripMenuItem addDonationToolStripMenuItem;
        private ToolStripMenuItem donationListToolStripMenuItem;
        private ToolStripMenuItem dashbToolStripMenuItem;
        private ToolStripMenuItem syncDataToolStripMenuItem;
    }
}



