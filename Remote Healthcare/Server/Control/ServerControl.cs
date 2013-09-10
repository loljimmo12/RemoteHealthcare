using Server.View;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace Server.Controller
{
    class ServerControl
    {
        private TcpListener tcpListener;

        public ServerControl()
        {
            this.tcpListener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 31337);
            listenForClients();
        }

        public void listenForClients()
        {
            tcpListener.Start();

            for (; ; )
            {

                try
                {
                    new Server.Model.Client(tcpListener.AcceptTcpClient());
                }
                catch (Exception)
                {
                    throw;
                }

                ServerView.writeToConsole("bla");
                Thread.Sleep(10);
            }
        }

        public void handleAClient(Object client)
        {

        }

    }
}
