

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
            client.Connect("chal.gryphonctf.com", 8000);
            NetworkStream ns = null;

            try
            {
                if (client.Connected)
                {
                    ns = client.GetStream();
                    byte[] buffer = new byte[512];

                    buffer = Encoding.ASCII.GetBytes("Hi!");
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
