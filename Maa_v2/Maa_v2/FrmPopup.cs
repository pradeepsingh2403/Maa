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
    public partial class FrmPopup : Form
    {
        public FrmPopup()
        {
            InitializeComponent();

            // Remove Minimize button
            this.MinimizeBox = false;

            // Keep/Remove Maximize as you want
            this.MaximizeBox = false;

            // Keep control box (title bar) but disable Close
            this.ControlBox = true;

            // Open in the center of screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmPopup_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
