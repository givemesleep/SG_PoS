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
using System.IO;

namespace sgpos.BackEnd
{
    public partial class frmAdUserInfo : Form
    {
        static string server = "localhost";
        static string dbase = "dbpos;";
        static string Uid = "root";
        static string passwd = ";";
        static string push = $"server={server}; database={dbase}; Uid={Uid}; password={passwd};";

        MySqlConnection konik = new MySqlConnection(push);
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlCommand cmd = new MySqlCommand();
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        DataSet ds = new DataSet();

        string query;

        public frmAdUserInfo()
        {
            InitializeComponent();
        }

        //Functions
        private void loadData()
        {
            query = "SELECT lname, fname, mint, email, connum, addr, dob, genderID, roleID, picture FROM tbusers";
            cmd = new MySqlCommand(query, konik);
            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            adUserdgv.DataSource = dt;
            
        }

        private void searchmo()
        {

            string itrimmo = txtAdSearch.Text.Trim();
            query = "SELECT lname, fname, mint, email, connum, addr, dob, genderID, roleID, picture FROM tbusers WHERE lname LIKE '%?%'";
            cmd = new MySqlCommand(query, konik);
            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
                                
            da.Fill(dt);
            adUserdgv.DataSource = dt;
            

        }

        
        private void frmAdUserInfo_Load(object sender, EventArgs e)
        {
            loadData();
            konik.Open();
            
            /*
            adUserdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            adUserdgv.RowTemplate.Height = 120;
            adUserdgv.AllowUserToAddRows = false;
            */
            //this.da.fill
        }

        private void kalatmo()
        {
            

        }


        //buttons

        private void txtAdSearch_TextChanged(object sender, EventArgs e)
        {
            loadData();
            searchmo();
            
        }

        private void adUserdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void adUserdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAdupload_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog f = new OpenFileDialog();
            if(f.ShowDialog() == DialogResult.OK)
            {
                pbimage.Image = Image.FromFile(f.FileName);

            }

        }

        private void btnAdadd_Click(object sender, EventArgs e)
        {

            try
            {
                // image
                MemoryStream ms = new MemoryStream();
                pbimage.Image.Save(ms, pbimage.Image.RawFormat);
                byte[] pho_arr = new byte[0];
                ms.Position = 0;
                ms.Read(pho_arr, 0, pho_arr.Length);

                query = "INSERT INTO tbusers(lname, fname, mint, email, connum, addr, dob, genderID, roleID, picture)VALUES(@lname, @fname, @mint, @email, @connum, @addr, @dob, @genderID, @roleID, @picture)";


                cmd = new MySqlCommand(query, konik);

                cmd.Parameters.AddWithValue("@lname", txtAdlname.Text);
                cmd.Parameters.AddWithValue("@fname", txtAdlname.Text);
                cmd.Parameters.AddWithValue("@mint", txtAdlname.Text);
                cmd.Parameters.AddWithValue("@email", txtAdlname.Text);
                cmd.Parameters.AddWithValue("@connum", txtAdlname.Text);
                cmd.Parameters.AddWithValue("@addr", txtAdlname.Text);
                cmd.Parameters.AddWithValue("@dob", dtAdbday.Value);
                cmd.Parameters.AddWithValue("@genderID", cbAdmale.Checked || cbAdfem.Checked);
                cmd.Parameters.AddWithValue("@roleID", cbAduser.Checked || cbAdadmin.Checked);
                cmd.Parameters.AddWithValue("@picture", pho_arr);

                da = new MySqlDataAdapter(query, konik);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {

            }
        }
    }
}
