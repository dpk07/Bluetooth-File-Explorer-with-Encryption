using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FileExplorer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DPk\Desktop\Bluetooth\bluetooth\FileExplorer\FileExplorer\login.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter sda = new SqlDataAdapter("Select * from login where username='"+username.Text+"'and password='"+password.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count>0)
            {
                this.Hide();
                var form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();

            }
            else MessageBox.Show("Please enter correct username or password");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
