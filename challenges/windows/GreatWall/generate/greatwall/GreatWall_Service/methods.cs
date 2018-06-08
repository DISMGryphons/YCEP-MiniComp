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
            imageFileName = null;
            ipVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_V4;
            this.portNumber = portNumber;
            localAddress = null;
            ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
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
            Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwMgr");
            INetFwMgr FWManager = (INetFwMgr)Activator.CreateInstance(FWManagerType);

            // Set profile interface, makes life easier
            INetFwProfile profile = FWManager.LocalPolicy.CurrentProfile;

            if (!profile.FirewallEnabled)
            {
                return false;
            }

            // Declare ports to check
            int[] allowedPorts = { 9050, 9437, 9928 };
            List<int> allowedPortList = new List<int>(allowedPorts),
                notAllowedPortList = new List<int>(3);

            int i = 0;
            Random random = new Random();
            while (i < notAllowedPortList.Capacity)
            {
                int randint = random.Next(9001, 10001);
                if (!notAllowedPortList.Contains(randint))
                {
                    notAllowedPortList.Add(randint);
                    i++;
                }
            }

            foreach (int port in allowedPortList)
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
                    // 10013 is error code when port is blocked
                    // action not permissible
                    if (e.ErrorCode == 10013)
                    {
                        return false;
                    }
                }
            }

            foreach (int port in notAllowedPortList)
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

            foreach (int portNumber in allowedPortList)
            {
                PortInfo port = new PortInfo(portNumber);
                FWManager.IsPortAllowed(port.imageFileName, port.ipVersion, port.portNumber, port.localAddress, port.ipProtocol, out object Allowed, out object Restricted);
                // eventLog.WriteEntry("Port " + portNumber + ": " + Allowed + " " + Restricted);

                if (!(bool)Allowed)
                {
                    return false;
                }
            }

            foreach (int portNumber in notAllowedPortList)
            {
                PortInfo port = new PortInfo(portNumber);
                FWManager.IsPortAllowed(port.imageFileName, port.ipVersion, port.portNumber, port.localAddress, port.ipProtocol, out object Allowed, out object Restricted);

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