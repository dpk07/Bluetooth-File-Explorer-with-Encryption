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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\login.mdf;Integrated Security=True;Connect Timeout=5");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into login(username,password) values('" + username.Text + "','" + password.Text + "');", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registered Successfully");
            conn.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
