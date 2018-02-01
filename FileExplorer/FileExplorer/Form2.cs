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
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
using System.IO;
using System.Management;

namespace FileExplorer
{
       
    public partial class Form2 : Form
    {   

        public Form2()
        {
            InitializeComponent();
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        BackgroundWorker bg;
        

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.Write(e.Result);
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Device> devices = new List<Device>();
            InTheHand.Net.Sockets.BluetoothClient bc = new InTheHand.Net.Sockets.BluetoothClient();
            InTheHand.Net.Sockets.BluetoothDeviceInfo[] array = bc.DiscoverDevices();
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                Device device = new Device(array[i]);
                devices.Add(device);
            }
            e.Result = devices;
        }

        private void btn_find_Click(object sender, RoutedEventArgs e)
        {
           
        }
        

        private void regDevice_Click(object sender, EventArgs e)
        {
            if (!bg.IsBusy)
            {
                bg.RunWorkerAsync();
            }
        }
        //Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        


    }
    public class Device
    {
        public string DeviceName { get; set; }
        public bool Authenticated { get; set; }
        public bool Connected { get; set; }
        public ushort Nap { get; set; }
        public uint Sap { get; set; }
        public DateTime LastSeen { get; set; }
        public DateTime LastUsed { get; set; }
        public bool Remembered { get; set; }

        public Device(BluetoothDeviceInfo device_info)
        {
            this.Authenticated = device_info.Authenticated;
            this.Connected = device_info.Connected;
            this.DeviceName = device_info.DeviceName;
            this.LastSeen = device_info.LastSeen;
            this.LastUsed = device_info.LastUsed;
            this.Nap = device_info.DeviceAddress.Nap;
            this.Sap = device_info.DeviceAddress.Sap;
            this.Remembered = device_info.Remembered;
        }

        public override string ToString()
        {
            return this.DeviceName;
        }
    }


}
