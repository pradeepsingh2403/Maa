using Maa_v2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maa
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addRolePermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            //frmDashboard dashboard = new frmDashboard();
            //dashboard.MdiParent = this;   // set MDI parent
            //dashboard.WindowState = FormWindowState.Maximized; // optional (fill parent)
            //dashboard.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.MdiParent = this;   // set MDI parent
            dashboard.WindowState = FormWindowState.Maximized; // optional (fill parent)
            dashboard.Show();
        }

        private void addDonationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddDonationForm dashboard = new frmAddDonationForm();
            dashboard.MdiParent = this;   // set MDI parent
            dashboard.WindowState = FormWindowState.Maximized; // optional (fill parent)
            dashboard.Show();
        }
        private void listDonationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonationList dashboard = new frmDonationList();
            dashboard.MdiParent = this;   // set MDI parent
            dashboard.WindowState = FormWindowState.Maximized; // optional (fill parent)
            dashboard.Show();
        }
        private void addRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRole role = new frmRole();
            role.MdiParent = this;   // set MDI parent
            role.WindowState = FormWindowState.Normal; // optional (fill parent)
            role.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers users = new frmUsers();
            users.MdiParent = this;   // set MDI parent
            users.WindowState = FormWindowState.Normal; // optional (fill parent)
            users.Show();
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddScheme schema = new frmAddScheme  ();
            schema.MdiParent = this;   // set MDI parent
            schema.WindowState = FormWindowState.Normal; // optional (fill parent)
            schema.Show();
        }

        private void addRolePermissionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmRolePermission rolePermission = new frmRolePermission();
            rolePermission.MdiParent = this;   // set MDI parent
            rolePermission.WindowState = FormWindowState.Normal; // optional (fill parent)
            rolePermission.Show();
        }
    }
}
