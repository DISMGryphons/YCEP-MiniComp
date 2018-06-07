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

namespace GreatWall_Service
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

        private void BgProcess(object sender, DoWorkEventArgs e)
        {
            // Populate struct containing ports
            // to be checked first!
            // PopulatePortInfo();

            // Run actual check
            while (true)
            {
                bool checkResult = CheckPorts();
                eventLog.WriteEntry(checkResult.ToString());
                if (checkResult)
                {
                    break;
                }

                // Check every ~5 seconds
                Thread.Sleep(5000);
            }
            this.Stop();
        }
    }
}
