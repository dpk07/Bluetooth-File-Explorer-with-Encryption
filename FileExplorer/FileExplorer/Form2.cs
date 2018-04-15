using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Bluetooth.Widcomm;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
using System.IO;
using System.Management;
using InTheHand.Windows.Forms;


namespace FileExplorer
{

    public partial class Form2 : Form
    {
        BluetoothClient bc;
        SelectBluetoothDeviceDialog selDia;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                BluetoothClient bc = new BluetoothClient();
            }
            catch (System.PlatformNotSupportedException)
            {
                MessageBox.Show("Bluetooth not enabled. Please enable bluetooth of your laptop.");
                Form fc = Application.OpenForms["Form2"];

                if (fc != null)
                    fc.Close();
                Form2 f2 = new Form2();
                f2.Show();
            }
            finally
            {
                result.Text= "1.Click on select device if your device is already paired, else click on new device.\r\n2.To encrypt or decrypt once select the options on the second row.\r\n3.To encrypt your files based on bluetooth select the Check Connection option.\r\n4.Navigate to your required folder and select it.\r\n5.Click stop once you're done.";
            }


        }

        int count = 0, count2 = 0;
        String deviceAddr;
        String path;
        
        
        DeviceScanner ds;
        
        String deviceName;
        myencryption en = new myencryption();
        private void regDevice_Click(object sender, EventArgs e)
        {
            

            selDia = new SelectBluetoothDeviceDialog();
            //selDia.ShowUnknown = true;
            //selDia.AddNewDeviceWizard = true;
            //selDia.ShowDialog();
            selDia.AddNewDeviceWizard = false;

            if (selDia.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            deviceAddr = (selDia.SelectedDevice.DeviceAddress).ToString();
            deviceName = selDia.SelectedDevice.DeviceName;
            result.AppendText(deviceAddr + " " + deviceName);
            ds =new DeviceScanner(deviceAddr);
            ds.Start();

        }
        

        
        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 15000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            check();
        }


        public void check()
        {
            result.Text = null;
            if (ds.DeviceInRange)
            {
                setText(" Device is in range ");
                setText(" Decrypting");
                
                if (count == 0)
                {

                    //maximize();
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipText = "Device in range, unlocking files";
                    notifyIcon1.ShowBalloonTip(300);
                    notifyIcon1.Visible = false;


                    decrypt(path);
                    
                    count2 = 0;
                    count++;
                }
            }
            else
            {
                setText(" Device is not in range ");
                setText(" Encrypting");
                


                if (count2 == 0)
                {

                    //minimize();
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipText = "Device out of range, locking files";
                    notifyIcon1.ShowBalloonTip(300);
                    notifyIcon1.Visible = false;

                    encrypt(path);
                          
                    count2++;
                    count = 0;
                }
            }
        }

        public void minimize()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(minimize), new object[] {});
                return;
            }
            WindowState = FormWindowState.Minimized;


        }
        public void maximize()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(maximize), new object[] { });
                return;
            }
            WindowState = FormWindowState.Normal;


        }
        public void encrypt(String path1)
        {
            string[] dirs = Directory.GetFiles(path1, "*");
            for (var i = 0; i < dirs.Length; i++)
            {
                en.FileEncrypt(dirs[i], "deepak");
            }
        }

        public void decrypt(String path1)
        {
            string[] dirs = Directory.GetFiles(path1, "*");
            for (var i = 0; i < dirs.Length; i++)
            {
                en.FileDecrypt(dirs[i], dirs[i].Substring(0, dirs[i].Length - 4), "deepak");
            }


        }
        public void setText(String s)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(setText), new object[] { s });
                return;
            }
            result.AppendText(s);

        }
        private void btn4_Click(object sender, EventArgs e)
        {
            if (deviceAddr != null)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {

                        path = fbd.SelectedPath;
                    }
                }
                InitTimer();
            }
            else MessageBox.Show("Please select a device.");
           
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if(timer1!=null)
            timer1.Stop();

        }

        private void lockFile_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {

                    path = fbd.SelectedPath;
                }
            }
            encrypt(path);
        }

        private void unlockFile_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {

                    path = fbd.SelectedPath;
                }
            }
            decrypt(path);
        }

        

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnNewDevice_Click(object sender, EventArgs e)
        {

            selDia = new SelectBluetoothDeviceDialog();
            selDia.ShowUnknown = true;
            selDia.AddNewDeviceWizard = true;
            selDia.ShowDialog();
            selDia.AddNewDeviceWizard = false;
            selDia.ShowDialog();
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
            }
        }
    }
}
