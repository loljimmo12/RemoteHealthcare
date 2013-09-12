//using Server.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Control
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
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Server.Model.Packet pack = null;
            Server.Model.ServerModel sModel = new Server.Model.ServerModel();
            for (; ; )
            {
                pack = (Server.Model.Packet)formatter.Deserialize(clientStream);
                if (pack.Data is Server.Model.Value)
                {
                    sModel.writeBikeData(tcpClient.ToString(), pack.Data);
                }
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
