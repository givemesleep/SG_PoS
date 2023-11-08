using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgpos.BackEnd
{
    public partial class frmMainBoard : Form
    {
        public frmMainBoard()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMainBoard_Load(object sender, EventArgs e)
        {
            frmAdHome home = new frmAdHome();
            home.MdiParent = this;
            home.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdHome home = new frmAdHome();
            home.MdiParent = this;
            home.Show();
        }

        private void uSERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdUser aduser = new frmAdUser();
            aduser.MdiParent = this;
            aduser.Show();
        }

        private void uSERINFORMATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdUserInfo userinfos = new frmAdUserInfo();
            userinfos.MdiParent = this;
            userinfos.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in ((ToolStrip)sender).Items)
            {
                if (item != e.ClickedItem)
                    item.Checked = false;
                else
                    item.Checked = true;
                item.ForeColor = Color.Black;
            }


            
        }
    }
}
