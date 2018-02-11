using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace FileExplorer
{
    internal class DeviceScanner
    {
        /// <summary>
        /// worker thread of this scanner
        /// </summary>
        private Thread m_worker;

        

        /// <summary>
        /// request scanner shutdown
        /// </summary>
        private bool m_shutdownRequsted;

        /// <summary>
        /// handle used to wake up the thread in case of shutdown request
        /// </summary>
        private readonly object m_shutdownWaitHandle;

        /// <summary>
        /// address of the device used by this scanner
        /// </summary>
        private readonly BluetoothAddress m_deviceAddress;

        /// <summary>
        /// client used to work with the device
        /// </summary>
        private readonly BluetoothClient m_btClient;

        /// <summary>
        /// default constructor of the scanner
        /// </summary>
        ///
        /// <param name="deviceAddr">
        /// address of the required device
        /// </param>
        public DeviceScanner(string deviceAddr)
        {
            m_worker = null;
            var isAddrParsed = BluetoothAddress.TryParse(
                deviceAddr, out m_deviceAddress);
            if (!isAddrParsed)
            {
                m_deviceAddress = null;
            }

            m_btClient = new BluetoothClient();

            m_shutdownRequsted = false;
            m_shutdownWaitHandle = new object();
        }

        /// <summary>
        /// is the device currently in range?
        /// </summary>
        public bool DeviceInRange { get; private set; }

        /// <summary>
        /// actual worker of the scanner
        /// </summary>
        private void ScannerWorker()
        {
            /* device information used */
            BluetoothDeviceInfo di = null;

            while (!m_shutdownRequsted)
            {
                di = RefreshDeviceInfo(di);
                DeviceInRange = di != null && IsInRange(di);
                lock (m_shutdownWaitHandle)
                {
                    Monitor.Wait(m_shutdownWaitHandle,
                        TimeSpan.FromSeconds(10));
                }
            }
        }

        /// <summary>
        /// worker wrapper used to catch exceptions
        /// </summary>
        private void Run()
        {
            try
            {
                ScannerWorker();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format("{0}: {1}", e.GetType(), e.Message),
                    @"Critical scanner error");
                throw;
            }
        }

        /// <summary>
        /// start the scanner
        /// </summary>
        public void Start()
        {
            lock (this)
            {
                /* if the thread is already running, do nothing */
                if (m_worker != null)
                {
                    return;
                }

                m_worker = new Thread(Run);
                m_shutdownRequsted = false;
                m_worker.Start();
            }
        }

        /// <summary>
        /// stop the scanner
        /// </summary>
        public void Stop()
        {
            lock (this)
            {
                /* if the thread is not running already, do nothing */
                m_shutdownRequsted = true;
                m_worker = null;

                /* wake up waiting thread */
                lock (m_shutdownWaitHandle)
                {
                    Monitor.Pulse(m_shutdownWaitHandle);
                }
            }
        }


        /// <summary>
        /// refresh device information or find the device requred
        /// </summary>
        ///
        /// <param name="myDevInfo">
        /// initial device information to be used
        /// </param>
        ///
        /// <returns>
        /// updated device information
        /// </returns>
        private BluetoothDeviceInfo RefreshDeviceInfo(
            BluetoothDeviceInfo myDevInfo)
        {
            /* devices discovered by single scan */
            BluetoothDeviceInfo[] infos;

            /* if the device info is already set, just refresh it */
            if (myDevInfo != null)
            {
                myDevInfo.Refresh();
                return myDevInfo;
            }

            infos = m_btClient.DiscoverDevices();
            return infos.FirstOrDefault(inf =>
                inf.DeviceAddress.Equals(m_deviceAddress));
        }

        /// <summary>
        /// test if the device specified by "deviceAddress" is connected
        /// </summary>
        ///
        /// <param name="info">
        /// device being monitored
        /// </param>
        ///
        /// <returns>
        /// true if the device is connected */
        /// </returns>
        private bool IsInRange(BluetoothDeviceInfo info)
        {

            /* no device -> no connection */
            if (info == null)
            {
                return false;
            }

            info.Refresh();

            /* if this device is already connected -> we are good */
            if (info.Connected)
            {
                return true;
            }

            for (var retries = 0; ; retries++)
            {
                try
                {
                    info.GetServiceRecords(BluetoothService.Headset);
                    break;
                }
                catch (SocketException)
                {
                    if (retries >= 3)
                    {
                        return false;
                    }
                    retries++;
                    continue;
                }
            }

            return true;
        }
    }
}
