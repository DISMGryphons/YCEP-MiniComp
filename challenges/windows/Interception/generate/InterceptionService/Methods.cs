

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace InterceptionService
{

    partial class Service
    {
        EventLog eventLog = null;
        private void CreateLog()
        {
            eventLog = new EventLog();
            if (!EventLog.SourceExists("Interception Service"))
            {
                EventLog.CreateEventSource("Interception Service", "Application");
            }
            eventLog.Source = "Interception Service";
            eventLog.Log = "Application";
        }

        private void Start()
        {
            IPAddress localAddr = IPAddress.Parse("0.0.0.0");
            IPEndPoint localEndPoint = new IPEndPoint(localAddr, 15000);
            TcpClient client = new TcpClient(localEndPoint);
            NetworkStream ns = null;

            try
            {
                client.Connect("chal.gryphonctf.com", 9000);


                if (client.Connected)
                {
                    ns = client.GetStream();
                    byte[] buffer = new byte[512];

                    buffer = Encoding.ASCII.GetBytes("940bc2aaf7d4fe6766781af41d639de7f2f9ca07");
                    ns.Write(buffer, 0, buffer.Length);

                    ns.Read(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                if (ns != null) { ns.Close(); }
            }
            client.Close();
        }
    }
}
