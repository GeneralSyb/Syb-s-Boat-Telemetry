using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Syb_s_Telemetry_Program
{
    public static class ENV
    {
        public static int bautrate = 11500;
    }
    
    public partial class SybsTelemetry : Form
    {
        public bool sessionStarted = false;
        public static SerialPort port = new SerialPort("COM1", ENV.bautrate, Parity.None, 8, StopBits.One);

        public async Task ComPortLoop()
        {
            string[] lastPorts = { };
            while (true)
            {
                //Serial port listing
                string[] ports = SerialPort.GetPortNames();

                foreach (string port in ports)
                {
                    //ConsoleLog($"Port found: {port}");
                    if (!lastPorts.Contains(port))
                    {
                        //ading port to list because it was not found in the previous loop
                        //ConsoleLog($"Adding: {port}");
                        ComListBox.Items.Add(port);
                    }
                }

                foreach (string port in lastPorts)
                {
                    if (!ports.Contains(port))
                    {
                        // removing because port was not found in the new list
                        //ConsoleLog($"Removing: {port}");
                        ComListBox.Items.Remove(port);
                    }
                }

                lastPorts = ports;
                //500ms delay for loop speed
                await Task.Delay(100);
            }
        }

        public async Task ComReceiver()
        {
            string lastPort = string.Empty;
            while (true)
            {
                if (ComListBox.SelectedItem != null)
                {
                    string selectedPort = ComListBox.SelectedItem.ToString();
                    if (selectedPort != lastPort && sessionStarted)
                    {
                        if (port.IsOpen)
                        {
                            port.Close();
                        }
                        port.PortName = selectedPort;
                        port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        port.Open();
                    }
                }
            }

            await Task.Delay(0);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ConsoleLog($"COMPort Data: {port.ReadExisting()}");
        }

        public void ConsoleLog(string message)
        {
            var console = ConsoleWindow;
            if (console.Text == "")
            {
                console.Text = console.Text + message;
            }
            else
            {
                console.Text = console.Text + "\n" + message;
            }
        }

        public void StartSession()
        {

        }
        
        public void StopSession()
        {

        }
        public SybsTelemetry()
        {
            InitializeComponent();
            ComPortLoop();
            ComReceiver();
        }

        private void StartSessionButton_Click(object sender, EventArgs e)
        {
            SelectFolder.ShowDialog();
            sessionStarted = true;
        }
    }
}
