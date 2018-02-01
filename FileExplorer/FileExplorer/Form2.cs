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
using InTheHand.Windows.Forms;
using System.IO;
using System.Management;

namespace FileExplorer
{
    


    public partial class Form2 : Form
    {   

        public Form2()
        {
            InitializeComponent();
            

    }

        private BluetoothAddress m_deviceAddr;
        private String DeviceName;
        private String DeviceAddress;
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
    private void regDevice_Click(object sender, EventArgs e)
        {
         
            SelectBluetoothDeviceDialog selDia;

            selDia = new SelectBluetoothDeviceDialog();

            if (selDia.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            m_deviceAddr = selDia.SelectedDevice.DeviceAddress;
            //m_deviceTextbox.Text = selDia.SelectedDevice.DeviceName;
            DeviceName = selDia.SelectedDevice.DeviceName;
            DeviceAddress =
                selDia.SelectedDevice.DeviceAddress.ToString();
            result.AppendText(DeviceName + DeviceAddress);
        }



    }
        


    }



