using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace YCEP_Listener
{
    public partial class Service : ServiceBase
    {
        // MODIFY CONFIGURATION AS NEEDED
        private int localPort = 10000;
        private int remotePort = 8000;
        private string remoteHostIP = "192.168.1.11";
        TcpClient tcpClient;
        EventLog eventLog;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), localPort);
            tcpClient = new TcpClient(localEndPoint);
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

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs eventArgs)
        {            
            NetworkStream tcpStream = null;
            while (true)
            {
                try
                {
                    tcpClient.Connect(remoteHostIP, remotePort);
                    tcpStream = tcpClient.GetStream();
                }
                catch (Exception e)
                {
                    eventLog.WriteEntry(e.Message, EventLogEntryType.Information);
                }

                byte[] buffer = new byte[2048];
                var memStream = new MemoryStream();
                if (tcpClient.Connected)
                {
                    Thread.Sleep(3000); // Allow some time for data to arrive
                    if (tcpStream.DataAvailable)
                    {
                        int readSize = tcpStream.Read(buffer, 0, buffer.Length);
                        memStream.Write(buffer, 0, readSize);
                        string readData = Encoding.ASCII.GetString(memStream.ToArray());
                        eventLog.WriteEntry(readData, EventLogEntryType.Information);

                        // Clean up
                        tcpClient.Close();
                        tcpClient.Dispose();
                        memStream.Close();
                        memStream.Dispose();
                    }
                }
                Thread.Sleep(300000); // Sleep for 5 minutes
            }
        }
    }
}
