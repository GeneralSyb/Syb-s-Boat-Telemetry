using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Syb_s_Telemetry_Program
{
    
    public partial class SybsTelemetry : Form
    {
        public async Task ComPortLoop()
        {
            string[] lastPorts = { };
            while (true)
            {
                //Serial port listing
                string[] ports = SerialPort.GetPortNames();

                if (ports != lastPorts)
                {
                    foreach (string port in ports)
                    {
                        if (!ComListBox.Items.Contains(port))
                        {
                            ComListBox.Items.Add(port);
                        }
                    }

                    foreach (string listPort in ComListBox.Items)
                    {
                        if (ports.Contains(listPort))
                        {
                            ComListBox.Items.Remove(listPort);
                        }
                    }
                }

                //500ms delay for loop speed
                await Task.Delay(500);
            }
        }

        public async Task ComReceiver()
        {
            await Task.Delay(0);
        }

        public void ConsoleLog(string message)
        {

        }

        public SybsTelemetry()
        {
            InitializeComponent();
            _ = ComPortLoop();
            _ = ComReceiver();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartSessionButton_Click(object sender, EventArgs e)
        {
            SelectFolder.ShowDialog();
        }

        

    }
}
