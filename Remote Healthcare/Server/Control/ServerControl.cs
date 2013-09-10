using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Controller
{
    class ServerControl
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public ServerControl()
        {
            this.tcpListener = new TcpListener(System.Net.IPAddress.Broadcast, 80);
            this.listenThread = new Thread(new ThreadStart(listenForClients));
            this.listenThread.Start();
        }

        public void listenForClients()
        {
            this.tcpListener.Start();

            for (; ; )
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(handleAClient));
                clientThread.Start(client);
            }
        }

        public void handleAClient(Object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            bool clientExited = false;

            for (; ; )
            {
                if (clientExited) tcpClient.Close();
            }

        }

    }
}
