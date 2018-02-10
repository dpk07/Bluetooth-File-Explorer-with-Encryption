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


        String deviceAddr;
        BluetoothDeviceInfo di = null;
        BluetoothClient bc = new BluetoothClient();
        DeviceScanner ds;
        Thread tr;
        String deviceName;
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
            catch (Exception e)
            {
                //ExceptionHandler(e);
                Environment.Exit(-1);
            }
        }

        private void ServiceThread()
        {
            var t = new System.Threading.Timer(o => check(), null, 0, 10000);
            

        }
        
        
        public void check()
        {
            if (ds.DeviceInRange)
                setText("Device is in range ");
            else
                setText("Device is not in range ");

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
    }
    


}
