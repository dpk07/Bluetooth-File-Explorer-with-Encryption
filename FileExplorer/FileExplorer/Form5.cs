using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (masterPassword.Text == "dmce") {
                this.Hide();
                var form6 = new Form6();
                form6.Closed += (s, args) => this.Close();
                form6.Show();
            }

            else MessageBox.Show("Please enter correct master password");
        }
    }
}
