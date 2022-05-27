using System;
//using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace PC_Application
{
    class clsNetwork
    {
        public static Socket GtcpSocket;
        public static String DeviceIP;
        public static IPEndPoint serverEndPoint;
        public static Int32 intBytesToFetch = 1;
        public static bool m_isConnected;

        //Device Name
        public string strDeviceName;

        //The IPHostEntry class associates a Domain Name System (DNS) host name 
        //with an array of aliases and an array of matching IP addresses
        public static IPHostEntry DeviceInfo;

        //Device's IP Address
        public static IPAddress DeviceAddress;

        public static String strReceiveData;
        public static String[] strResult;



        public static Int16 InitializeTCPClient(IPAddress IP, Int32 PORT)
        {
            try
            {
                //
                DeviceInfo = Dns.Resolve(Dns.GetHostName());
                DeviceAddress = DeviceInfo.AddressList[0];
                DeviceIP = DeviceAddress.ToString();
                GtcpSocket = null;

                serverEndPoint = new IPEndPoint(IP, PORT);
                GtcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //connect to Server

                GtcpSocket.Connect(serverEndPoint);
                //SendDataToServer("IP~" + DeviceIP);
                int i = 0;
                while (i < 1000)
                {
                    //Application.DoEvents();
                    if (GtcpSocket.Connected == true)
                    {
                        m_isConnected = true;

                        break;
                    }

                }
                return 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;

            }

        }
      
        public static void TerminateTCPClient()
        {
            try
            {
                SendDataToServer("SHUTDOWN");
                GtcpSocket.Shutdown(SocketShutdown.Both);
                GtcpSocket.Close();
                GtcpSocket = null;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Could Not Connect to Server. Application Cannot Continue.", clsInit.GstrMsgApp, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);


            }


        }
        public static void SendDataToServer(string strData)
        {
            try
            {
                Byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes("");

                dataBuffer = System.Text.Encoding.ASCII.GetBytes(strData);
                GtcpSocket.Send(dataBuffer);
            }
            catch { }
        }



        public static string ReceiveDataFromServer()
        {
            Byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes("");
            String ReturnValue = "";
            Int32 NoOfBytes;
            string[] strArr;
            int i = 0;

            dataBuffer = new Byte[intBytesToFetch];
            GtcpSocket.ReceiveTimeout = 100;
            
            do
            {
                if (GtcpSocket.Connected == false)
                {
                    i = 1; break;
                }
                NoOfBytes = GtcpSocket.Receive(dataBuffer);
                ReturnValue = ReturnValue + System.Text.Encoding.ASCII.GetString(dataBuffer, 0, NoOfBytes);
                if (ReturnValue.Contains("*") || ReturnValue == string.Empty)
                {
                    ReturnValue = ReturnValue.Replace("||", "");
                    break;
                }
            }
            while (i == 1);
            return ReturnValue.Replace(":", "");
        }

       
    }
}
