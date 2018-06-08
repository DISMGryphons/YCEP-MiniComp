using NetFwTypeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace GreatWall_Service
{
    struct PortInfo
    {
        public string imageFileName;
        public NET_FW_IP_VERSION_ ipVersion;
        public int portNumber;
        public string localAddress;
        public NET_FW_IP_PROTOCOL_ ipProtocol;

        public PortInfo (int portNumber)
        {
            this.imageFileName = null;
            this.ipVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_V4;
            this.portNumber = portNumber;
            this.localAddress = null;
            this.ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
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
            INetFwMgr FWManager = (INetFwMgr)Activator.CreateInstance(FWManagerType);

            // Set profile interface, makes life easier
            INetFwProfile profile = FWManager.LocalPolicy.CurrentProfile;

            if (!profile.FirewallEnabled)
            {
                return false;
            }

            // Declare ports to check
            int allowedPortRemoteMin = 5050,
                allowedPortRemoteMax = 5055,
                notAllowedPortRemoteMin = 5056,
                notAllowedPortRemoteMax = 5060;
            IPAddress ipAddress = IPAddress.Parse("0.0.0.0");

            for (int port = allowedPortRemoteMin; port <= allowedPortRemoteMax; port++)
            {
                // Attempt to connect to remote port, should work
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect("chal.gryphonctf.com", port);
                    client.Close();
                }
                catch (SocketException e)
                {
                    if (e.ErrorCode == 10013)
                    {
                        return false;
                    }
                }

            }

            for (int port = notAllowedPortRemoteMin; port <= notAllowedPortRemoteMax; port++)
            {
                // Attempt to connect to remote port, should not work
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect("chal.gryphonctf.com", port);
                    client.Close();
                    return false;
                }
                catch (SocketException e)
                {
                    if (e.ErrorCode != 10013)
                    {
                        return false;
                    }
                }

            }

            ipAddress = IPAddress.Parse("127.0.0.1");
            int allowedPortLocalMin = 8000,
                allowedPortLocalMax = 8005,
                notAllowedPortLocalMin = 8006,
                notAllowedPortLocalMax = 8010;

            // Check if port are allowed for bind, should be
            for (int portNumber = allowedPortLocalMin; portNumber <= allowedPortLocalMax; portNumber++)
            {
                PortInfo port = new PortInfo(portNumber);
                FWManager.IsPortAllowed(port.imageFileName, port.ipVersion, port.portNumber, port.localAddress, port.ipProtocol, out object Allowed, out object Restricted);
                // in case needed:
                // eventLog.WriteEntry("Port " + portNumber + ": " + Allowed + " " + Restricted);

                if (!(bool)Allowed)
                {
                    return false;
                }
            }

            // Check if portNumbers are disallowed for bind, should be
            for (int portNumber = notAllowedPortLocalMin; portNumber <= notAllowedPortLocalMax; portNumber++)
            {
                PortInfo port = new PortInfo(portNumber);
                FWManager.IsPortAllowed(port.imageFileName, port.ipVersion, port.portNumber, port.localAddress, port.ipProtocol, out object Allowed, out object Restricted);
                eventLog.WriteEntry("Port " + portNumber + ": " + Allowed + " " + Restricted);
                if ((bool)Allowed)
                {
                    return false;
                }
            }

            // pretty good, passed all filters
            return true;
        }
    }
}