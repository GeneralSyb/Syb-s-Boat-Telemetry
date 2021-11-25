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

        private void port_DataReceived(object sender, EventArgs e)
        {
            ConsoleLog($"COMPort Data: {port.ReadExisting()}");
        }

        private void port_changed(object sender, EventArgs e)
        {
            bool validPort = ComListBox.SelectedItem != null;
            ConsoleLog($"Changed port to: {ComListBox.SelectedItem}, is valid: {validPort}");
            string lastPort = string.Empty;
            if (ComListBox.SelectedItem != null)
            {
                string selectedPort = ComListBox.SelectedItem.ToString();
                if (selectedPort != lastPort)
                {
                    if (port.IsOpen)
                    {
                        ConsoleLog("Port is still open, closing previous port...");
                        port.Close();
                    }
                    ConsoleLog("Setting up port and handler...");
                    port.PortName = selectedPort;
                    port.DataReceived += port_DataReceived;
                    port.Open();
                }
            }
        }

        public void ConsoleLog(string text)
        {
            var console = ConsoleWindow;
            if (console.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { ConsoleLog(text); };
                console.Invoke(safeWrite);
            }
            else
            {
                if (console.Text == "")
                {
                    console.Text = console.Text + text;
                }
                else
                {
                    console.Text = console.Text + "\n" + text;
                }
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
            //ComReceiver();
            ComListBox.SelectedValueChanged += port_changed;
        }

        private void StartSessionButton_Click(object sender, EventArgs e)
        {
            SelectFolder.ShowDialog();
            sessionStarted = true;
        }

        private void ConsoleWindow_TextChanged(object sender, EventArgs e)
        {
            var t = ConsoleWindow;
            if (AutoScrollButton.Checked)
            {
                // set the current caret position to the end
                t.SelectionStart = t.Text.Length;
                // scroll it automatically
                t.ScrollToCaret();
            }
        }
    }

    public static class ENV
    {
        public static int bautrate = 115200;
    }
}
