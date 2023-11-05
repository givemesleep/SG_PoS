using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SGpos.LogIn
{
    public partial class frmtestcon : Form
    {
        static string server = "localhost";
        static string dbase = "dbusers;";
        static string uid = "root";
        static string pass = ";";
        static string all = $"server={server}; database={dbase}; Uid={uid}; password={pass};";
        public frmtestcon()
        {
            InitializeComponent();
            lblfa.Visible = false;
            lblsu.Visible = false;
        }

        private void lblfa_Click(object sender, EventArgs e)
        {

        }

        private void G_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(all);

            try
            {
                con.Open();
                lblsu.Visible = true;
                lblfa.Visible = false;
            }
            catch
            {
                con.Open();
                lblfa.Visible = true;
                lblsu.Visible = false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
