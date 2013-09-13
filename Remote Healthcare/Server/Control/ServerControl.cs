using Server.View;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace Server.Control
{
    class ServerControl
    {
        private TcpListener tcpListener;

        public ServerControl()
        {
            this.tcpListener = new TcpListener(System.Net.IPAddress.Any, 31337);
            listenForClients();
        }

        public void listenForClients()
        {
            tcpListener.Start();

            for (; ; )
            {
                try
                {
                    new Server.Control.Client(tcpListener.AcceptTcpClient());
                }
                catch (Exception)
                {
                    throw;
                }

                Console.WriteLine("hello, test!");
                Thread.Sleep(10);
            }
        }

        public void handleAClient(Object client)
        {

        }

    }
}
