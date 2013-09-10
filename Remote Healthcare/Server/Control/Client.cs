using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Model
{
    class Client
    {
        private Thread listenThread;
        private TcpClient tcpClient;

        bool serverIsListening = false;
        bool serverIsSending = false;
        bool clientExited = false;

        public Client(TcpClient client)
        {
            this.tcpClient = client;
            this.listenThread = new Thread(new ThreadStart(handler));
            this.listenThread.Start();
        }

        public void handler()
        {
            NetworkStream clientStream = tcpClient.GetStream();

            for (; ; )
            {
                if (serverIsListening)
                if (serverIsSending)
                if (clientExited)
                {
                    tcpClient.Close();
                    //thread aborten
                }
            }

        }
    }
}
