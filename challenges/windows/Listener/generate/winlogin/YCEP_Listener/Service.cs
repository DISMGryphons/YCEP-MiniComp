using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;

namespace YCEP_Listener
{
    public partial class Service : ServiceBase
    {
        // MODIFY CONFIGURATION AS NEEDED
        private int localPort = 10000;
        TcpListener tcpServer;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), localPort);
            tcpServer = new TcpListener(localEndPoint);
            tcpServer.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
