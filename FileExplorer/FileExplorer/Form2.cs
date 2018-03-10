using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
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

        public Form2()
        {
            InitializeComponent();
            }

        private void Form2_Load(object sender, EventArgs e)
        {
           

        }

        int count=0,count2=0;
        String deviceAddr;
        

        BluetoothClient bc = new BluetoothClient();
        DeviceScanner ds;
        Thread tr;
        String deviceName;
        myencryption en = new myencryption();
        private void regDevice_Click(object sender, EventArgs e)
        {
            SelectBluetoothDeviceDialog selDia;

            selDia = new SelectBluetoothDeviceDialog();
            //selDia.ShowUnknown = true;
            //selDia.AddNewDeviceWizard = true;
            //selDia.ShowDialog();
            //selDia.AddNewDeviceWizard = false;

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
        private void ServiceThreadWrapper()
        {
            try
            {
                ServiceThread();
            }
            catch (Exception)
            {
                //ExceptionHandler(e);
                Environment.Exit(-1);
            }
        }

        private void ServiceThread()
        {
            var t = new System.Threading.Timer(o => check(), null, 0, 5000);
            

        }
        
        
        public void check()
        {
            if (ds.DeviceInRange)
            {
                if (count == 0)
                {
                    setText(" Device is in range ");
                    //maximize();
                    
                    setText(" Decry");
                    decrypt();
                    
                    //count2 = 0;

                    setText("Device is in range ");
                    //maximize();
                    
                    setText("   decry");
                    
                    
                    count2 = 0;
                    //count++;
                }
            }
            else
            {
                if (count2 == 0)
                {
                    setText(" Device is not in range ");
                    //minimize();
                    setText(" Encry");
                    encrypt();
                          
                    //count2++;
                    //count = 0;

                    setText("Device is not in range ");
                    //minimize();
                    
                    setText("  encry");
                    string[] dirs = Directory.GetFiles(@"C:\Users\DPk\Desktop\Bluetooth\test", "*");
                    for (var i = 0; i < dirs.Length; i++)
                    {
                        en.FileEncrypt(dirs[i], "deepak");
                    }


                    //count2++;
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
        public void encrypt()
        {
            string[] dirs = Directory.GetFiles(@"D:\My Files\Projects\BE\FileExplorer(23 commits)\test", "*");

            string[] dirs = Directory.GetFiles(@"C:\Users\DPk\Desktop\Bluetooth\test", "*");

            for (var i = 0; i < dirs.Length; i++)
            {
                en.FileEncrypt(dirs[i], "deepak");
            }
        }

        public void decrypt()
        {

            string[] dirs = Directory.GetFiles(@"D:\My Files\Projects\BE\FileExplorer(23 commits)\test", "*");

            string[] dirs = Directory.GetFiles(@"C:\Users\DPk\Desktop\Bluetooth\test", "*");

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
            
            
            tr = new Thread(ServiceThreadWrapper);
            tr.Start();

            //ds.Stop();
        }

        private void stop_Click(object sender, EventArgs e)
        {   
            System.Environment.Exit(1);

        }

        private void lockFile_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(encrypt);
            thread.Start();
        }

        private void unlockFile_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(decrypt);
            thread.Start();
        }

        

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            this.Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.BalloonTipText = "Form maximized";
            notifyIcon1.ShowBalloonTip(1000);
            notifyIcon1.Visible = false;
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Device out of range, locking files";
                notifyIcon1.ShowBalloonTip(1000);
                this.Hide();
            }
          
            
        }

        




    }
}
