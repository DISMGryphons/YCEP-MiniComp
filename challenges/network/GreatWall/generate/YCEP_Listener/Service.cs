using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YCEP_Listener
{

    public struct Config
    {
        public IPEndPoint localPort;
        public string remoteHost;
        public int remotePort;

        public Config(int userLocalPort, string userRemoteHost, int userRemotePort)
        {
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            localPort = new IPEndPoint(localAddress, userLocalPort);
            remoteHost = userRemoteHost;
            remotePort = userRemotePort;
        }
    }

    public partial class Service : ServiceBase
    {
        // MODIFY CONFIGURATION AS NEEDED
        private Config config = new Config(10000, "127.0.0.1", 8000);
        TcpClient tcpClient;
        EventLog eventLog;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            tcpClient = new TcpClient(config.localPort);
            
            eventLog = new EventLog();
            if (!EventLog.SourceExists("Great Wall"))
            {
                EventLog.CreateEventSource("Great Wall", "Application");
            }
            eventLog.Source = "Great Wall";
            eventLog.Log = "Application";

            backgroundWorker.RunWorkerAsync();
        }

        protected override void OnStop()
        {
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            NetworkStream tcpStream = null;
            while (!tcpClient.Connected)
            {
                try
                {
                    tcpClient.Connect(config.remoteHost, config.remotePort);
                    tcpStream = tcpClient.GetStream();
                }
                catch (Exception bg_E)
                {
                    eventLog.WriteEntry(bg_E.Message, EventLogEntryType.Information);
                    Thread.Sleep(870000); // Sleep for 14.5 minutes ~ 15 minutes
                }
            }

            byte[] buffer = new byte[2048];
            var memStream = new MemoryStream();
            while (tcpStream.DataAvailable || !tcpClient.Connected)
            {
                if (tcpStream.DataAvailable)
                {
                    int readSize = tcpStream.Read(buffer, 0, buffer.Length);
                    memStream.Write(buffer, 0, readSize);
                    string readData = Encoding.ASCII.GetString(memStream.ToArray());
                    eventLog.WriteEntry(readData, EventLogEntryType.Information);
                }

                if (!tcpClient.Connected)
                {
                    break;
                }
            }

            // Clean up
            tcpClient.Close();
            tcpClient.Dispose();
            memStream.Close();
            memStream.Dispose();
        }
    }
}
