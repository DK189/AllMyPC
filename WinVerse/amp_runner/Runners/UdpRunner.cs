using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace amp_runner.Runners
{
    partial class UdpRunner : ServiceBase
    {
        public const int PORT = 34123;

        private UdpClient Udp;

        public UdpRunner()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Udp = new UdpClient();
            Udp.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));
            Udp_Receiving();
            Worker.RunWorkerAsync();
        }

        IPEndPoint from;

        private void Udp_Receiving(IAsyncResult ar = null)
        {
            try
            {
                if (ar != null)
                {
                    var buffer = Udp.EndReceive(ar, ref from);
                    Received(from, buffer);
                }
            }
            catch
            {

            }
            try
            {
                Udp.BeginReceive(Udp_Receiving, Udp);
            }
            catch
            {

            }
        }

        private void Received(IPEndPoint from, byte[] buffer)
        {
            Console.WriteLine($"{from}: {Encoding.UTF8.GetString(buffer)}\n\r");
            Udp.Send(buffer, buffer.Length, from);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            try
            {
                Udp.Close();
            }
            catch
            {

            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //while(!Worker.CancellationPending)
            //{
            //    try
            //    {

            //    }
            //    catch
            //    {

            //    }
            //}
        }
    }
}
