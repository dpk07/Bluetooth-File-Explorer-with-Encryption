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


        BluetoothAddress deviceAddr;
        String deviceName;
 private void regDevice_Click(object sender, EventArgs e)
        {
            SelectBluetoothDeviceDialog selDia;

            selDia = new SelectBluetoothDeviceDialog();
            selDia.ShowUnknown = true;
            selDia.AddNewDeviceWizard = true;
            selDia.ShowDialog();
            selDia.AddNewDeviceWizard = false;

            if (selDia.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            deviceAddr = selDia.SelectedDevice.DeviceAddress;
            deviceName = selDia.SelectedDevice.DeviceName;
            result.AppendText(deviceAddr + " " + deviceName);

        }



    }
    


}
