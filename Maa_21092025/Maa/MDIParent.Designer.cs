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
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            addRoleToolStripMenuItem = new ToolStripMenuItem();
            addUserToolStripMenuItem = new ToolStripMenuItem();
            addRolePermissionToolStripMenuItem = new ToolStripMenuItem();
            editMenu = new ToolStripMenuItem();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            addSchemaToolStripMenuItem = new ToolStripMenuItem();
            addDonationToolStripMenuItem = new ToolStripMenuItem();
            donationListToolStripMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, helpMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(10, 4, 0, 4);
            menuStrip.Size = new Size(1053, 37);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { addRoleToolStripMenuItem, addUserToolStripMenuItem, addRolePermissionToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(81, 29);
            fileMenu.Text = "&Admin";
            // 
            // addRoleToolStripMenuItem
            // 
            addRoleToolStripMenuItem.Name = "addRoleToolStripMenuItem";
            addRoleToolStripMenuItem.Size = new Size(277, 34);
            addRoleToolStripMenuItem.Text = "Add &Role";
            addRoleToolStripMenuItem.Click += addRoleToolStripMenuItem_Click;
            // 
            // addUserToolStripMenuItem
            // 
            addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            addUserToolStripMenuItem.Size = new Size(277, 34);
            addUserToolStripMenuItem.Text = "Add U&ser";
            // 
            // addRolePermissionToolStripMenuItem
            // 
            addRolePermissionToolStripMenuItem.Name = "addRolePermissionToolStripMenuItem";
            addRolePermissionToolStripMenuItem.Size = new Size(277, 34);
            addRolePermissionToolStripMenuItem.Text = "Add Role &Permission";
            addRolePermissionToolStripMenuItem.Click += addRolePermissionToolStripMenuItem_Click;
            // 
            // editMenu
            // 
            editMenu.DropDownItems.AddRange(new ToolStripItem[] { dashboardToolStripMenuItem, toolStripMenuItem1, addSchemaToolStripMenuItem, addDonationToolStripMenuItem, donationListToolStripMenuItem });
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(63, 29);
            editMenu.Text = "&User";
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(270, 34);
            dashboardToolStripMenuItem.Text = "Dash&board";
            dashboardToolStripMenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(267, 6);
            // 
            // addSchemaToolStripMenuItem
            // 
            addSchemaToolStripMenuItem.Name = "addSchemaToolStripMenuItem";
            addSchemaToolStripMenuItem.Size = new Size(270, 34);
            addSchemaToolStripMenuItem.Text = "Add &Schema";
            // 
            // addDonationToolStripMenuItem
            // 
            addDonationToolStripMenuItem.Name = "addDonationToolStripMenuItem";
            addDonationToolStripMenuItem.Size = new Size(270, 34);
            addDonationToolStripMenuItem.Text = "Add &Donation";
            // 
            // donationListToolStripMenuItem
            // 
            donationListToolStripMenuItem.Name = "donationListToolStripMenuItem";
            donationListToolStripMenuItem.Size = new Size(270, 34);
            donationListToolStripMenuItem.Text = "Donation &List";
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator8 });
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(55, 29);
            helpMenu.Text = "&Exit";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(87, 6);
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 839);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 23, 0);
            statusStrip.Size = new Size(1053, 32);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(60, 25);
            toolStripStatusLabel.Text = "Status";
            // 
            // MDIParent
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 871);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MDIParent";
            Text = "MDIParent";
            WindowState = FormWindowState.Maximized;
            Load += MDIParent_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
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



