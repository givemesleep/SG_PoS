using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalPOS
{
    public partial class frmsignup : Form
    {
        public frmsignup()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Hide();
        }

        private void pnlDataEntry_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void data()
        {
            string lahatnabinigayko = txtfirstname.Text + txtlastname.Text + txtemail.Text + txtaddr.Text + txtnum.Text;
            if (string.IsNullOrEmpty(lahatnabinigayko))
            {
                MessageBox.Show("Please have inputs");
            }
        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            data();
        }
    }
}
