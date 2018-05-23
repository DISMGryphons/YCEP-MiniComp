using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createEvent();
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            createEvent();
        }

        private void createEvent()
        {
            string source = "MC";
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, "TUN7RVYzTjdfVjEzVzNSfQo=", EventLogEntryType.Information);
            timer1.Enabled = true;

        }

        private void deleteEvent()
        {
            try
            {
                string log = "Application";
                EventLog.Delete(log);
            }
            catch (Exception e) { }
            timer1.Enabled = false;
            

        }
    }
}
