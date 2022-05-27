using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCIL.Socket.Client;
using System.Threading;
namespace MicroScanTest
{
    class MicroScan
    {
        Thread th;
        public bool IsRunning { get; set; }
        public delegate void delDataRecevie(SocketService Client, string barcode);
        public event delDataRecevie OnDataReceive;
        public MicroScan(string ScannerIp, Int32 ScaanerPort)
        {
            try
            {
                this.Ip = ScannerIp;
                this.Port = ScaanerPort;
                IsRunning = true;
                Start();
                th = new Thread(new ThreadStart(RunThread));
                th.Start();
            }
            catch (Exception ex)
            {
                //.AppLog.LogMessage(BcilLib.EventNotice.EventTypes.evtError, "(MicroScan)(MicroScan)", ex.Message);
                throw;
            }
        }
        void RunThread()
        {
            try
            {
                while (IsRunning)
                {
                    Thread.Sleep(1000);
                    System.Windows.Forms.Application.DoEvents();
                    System.Windows.Forms.Application.DoEvents();
                }
                Close();
                OnStopThread(Ip);
            }
            catch (Exception)
            {
                // ClsGlobalClass.AppLog.LogMessage(BcilLib.EventNotice.EventTypes.evtError, "(MicroScan)(RunThread)", ex.Message);                
            }
        }

        public delegate void delStopThread(string ip);
        public event delStopThread OnStopThread;
        SocketFactory _SocketFactory = new SocketFactory();
        SocketConfig _SocketConfig = new SocketConfig();
        public String Ip { get; set; }
        public Int32 Port { get; set; }
        public void Start()
        {
            try
            {
                _SocketConfig.ID = Ip;
                _SocketConfig.RemoteIP = Ip;
                _SocketConfig.Port = Port;
                _SocketConfig.EOM = "\r\n";
                _SocketConfig.SOM = "";
                _SocketFactory.CreateClient(_SocketConfig);
                _SocketFactory.OnClientData += new SocketFactory.NewClientData(SocketFactory_OnClientData);
                _SocketFactory.StartService(Ip);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Close()
        {
            try
            {
                _SocketFactory.StopService(Ip);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        void SocketFactory_OnClientData(object sender, string Message)
        {
            try
            {
                SocketService _SocketService = (SocketService)sender;
                //OnDataReceive(client.Config.RemoteIP, Message);
                OnDataReceive(_SocketService, Message);
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
