using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterceptionService
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            bgProcess.RunWorkerAsync();
        }

        protected override void OnStop()
        {
        }

        private void BgProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateLog();
            while (true)
            {
                Start();
                // "Ping" every 8 seconds
                Thread.Sleep(8000);
            }
        }
    }
}
