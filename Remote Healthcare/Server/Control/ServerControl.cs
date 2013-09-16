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
                    Server.View.ServerView.writeToConsole("Listening..");
                    handleAClient(tcpListener.AcceptTcpClient());
                }
                catch (Exception)
                {
                    throw;
                }

                Thread.Sleep(10);
            }
        }

        public void handleAClient(TcpClient client)
        {
            new Server.Control.Client(client);
        }

    }
}
