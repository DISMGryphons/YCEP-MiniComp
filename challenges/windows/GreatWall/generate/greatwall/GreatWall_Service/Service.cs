using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;

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
            // UNIMPLEMENTED FUNCTION
            // PopulatePortInfo();

            // Run actual check
            while (true)
            {
                bool checkResult = CheckPorts();
                eventLog.WriteEntry(checkResult.ToString());

                // Desktop
                string desktopPath = @"C:\Users\jonjo\Desktop\";
                if (checkResult)
                {
                    try
                    {
                        // Desktop folder
                        int count = 1;
                        string filePath = desktopPath + @"Great_Wall_Flag.txt";

                        while (File.Exists(filePath))
                        {
                            filePath = string.Format(desktopPath + @"Great_Wall_Flag ({0}).txt", count);
                            count++;
                        }

                        // Create file
                        FileStream fs = File.Create(filePath);
                        fs.Close();

                        using (StreamWriter file = new StreamWriter(filePath))
                        {
                            file.WriteLine("MC{TH#_W4LL_15_D0WN}");
                        }
                        break;
                    }
                    catch (System.Exception f)
                    {
                        eventLog.WriteEntry(f.Message, EventLogEntryType.Error);
                    }
                }

                // Check every ~3 seconds
                Thread.Sleep(3000);
            }
            this.Stop();
        }
    }
}
