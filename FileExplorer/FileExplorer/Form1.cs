using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;using InTheHand.Net.Sockets;
namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
                webBrowser1.GoBack();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    webBrowser1.Show();
                    webBrowser1.Url = new Uri(fbd.SelectedPath);
                    txtPath.Text = fbd.SelectedPath;
                }
            }


        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
                webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Hide();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please enable bluetooth of your laptop.");
            try
            {
                BluetoothClient bc = new BluetoothClient();
                Form fc = Application.OpenForms["Form2"];

                if (fc != null)
                    fc.Close();
                Form2 f2 = new Form2();
                f2.Show();
            }
            catch (System.PlatformNotSupportedException)
            {
                MessageBox.Show("Bluetooth not enabled. Please enable bluetooth of your laptop.");

            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //System.Windows.Forms.Application.Exit();
        }
    }
}
