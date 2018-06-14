using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace FormEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        public List<String> list = new List<String>();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i<10; i++)
            {
                list.Add(generateName(8));
                
            }
            createRNGEvent();
            createEvent();
        }

        public string generateName(int x)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            var stringChars = new char[x];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rand.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            createEvent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            createRNGEvent();
        }

        private void createEvent()
        {
            string source = "MC FLAG";
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, ":galf eht s'ereh dna hO !esrever ni epyt ot ekil I \n" + "}R3W31V_7N3VE{CM", EventLogEntryType.Information);

        }

        public void createRNGEvent()
        {
            
            int txt = rand.Next(0, list.Count);
            string source = list[txt];
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, generateName(23) + "=", EventLogEntryType.Information);

        }

    }
}
