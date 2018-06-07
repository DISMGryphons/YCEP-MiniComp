using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace GreatWall_Service
{
    // Unused struct, will be implemented if DLL is completed
    struct PortInfo
    {
        public string imageFileName;
        public dynamic ipVersion;
        public long portNumber;
        public string localAddress;
        public dynamic ipProtocol;
    }

    // Ports to check
    partial class Service
    {
        // Define a few constants regarding
        // to be used when using firewall
        // interface manager.
        // DO NOT MODIFY!
        // Currently unused, will implement if
        // DLL is completed
        private dynamic
            NET_FW_IP_VERSION_V4 = 0,
            NET_FW_IP_VERSION_V6 = 1,
            NET_FW_IP_VERSION_ANY = 2,
            NET_FW_IP_PROTOCOL_UDP = 17,
            NET_FW_IP_PROTOCOL_TCP = 6;

        // Declare GLOBAL array to store structs
        PortInfo[] enumeratePorts = new PortInfo[2];
        
        private void PopulatePortInfo()
        {
            // Port 80
            enumeratePorts[0].imageFileName = null;
            enumeratePorts[0].ipVersion = NET_FW_IP_VERSION_ANY;
            enumeratePorts[0].portNumber = 80;
            enumeratePorts[0].localAddress = null;
            enumeratePorts[0].ipProtocol = NET_FW_IP_PROTOCOL_TCP;

            // Port 443
            enumeratePorts[0].imageFileName = null;
            enumeratePorts[0].ipVersion = NET_FW_IP_VERSION_ANY;
            enumeratePorts[0].portNumber = 443;
            enumeratePorts[0].localAddress = null;
            enumeratePorts[0].ipProtocol = NET_FW_IP_PROTOCOL_TCP;
        }


    }

    // Methods
    partial class Service
    {
        private EventLog eventLog;
        private void CreateLog()
        {
            eventLog = new EventLog();
            if (!EventLog.SourceExists("Great Wall Service"))
            {
                EventLog.CreateEventSource("Great Wall Service", "Application");
            }
            eventLog.Source = "Great Wall Service";
            eventLog.Log = "Application";
        }

        private bool CheckPorts()
        {
            CreateLog();
            Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwMgr");
            dynamic FWManager = Activator.CreateInstance(FWManagerType);

            // Set profile interface, makes life easier
            dynamic profile = FWManager.LocalPolicy.CurrentProfile;

            if (!profile.FirewallEnabled)
            {
                return false;
            }

            // Declare ports to check
            int localPort = 50000;
            int allowedPortMin = 5050,
                allowedPortMax = 5055;
            int notAllowedPortMin = 5056,
                notAllowedPortMax = 5060;
            IPAddress ipAddress = IPAddress.Parse("0.0.0.0");

            for (int port = allowedPortMin; port <= allowedPortMax; port++)
            {
                // Attempt to connect to remote port, should work
                try
                {
                    IPEndPoint endPoint = new IPEndPoint(ipAddress, localPort);
                    TcpClient client = new TcpClient(endPoint);
                    client.Connect("chal.gryphonctf.com", port);
                    continue;
                }
                catch (SocketException e)
                {
                    eventLog.WriteEntry("Port " + port + ": " + e.Message);
                    return false;
                }
                
            }

            for (int port = notAllowedPortMin; port <= notAllowedPortMax; port++)
            {
                // Attempt to connect to remote port, should not work
                try
                {
                    IPEndPoint endPoint = new IPEndPoint(ipAddress, localPort);
                    TcpClient client = new TcpClient(endPoint);
                    client.Connect("chal.gryphonctf.com", port);
                    return false;
                }
                catch (SocketException e)
                {
                    eventLog.WriteEntry("Port " + port + ": " + e.Message);
                    continue;
                }

            }

            // pretty good, passed all filters
            return true;
        }
    }
}