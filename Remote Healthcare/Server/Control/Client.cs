//using Server.Model;

using System;
using System.Collections.Generic;
using System.IO;
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
            Kettler_X7_Lib.Objects.Packet pack = null;
            Server.Model.ServerModel sModel = new Server.Model.ServerModel();

            serverIsListening = true;
            Server.View.ServerView.writeToConsole("Connected.");

            for (; ; )
            {
                pack = (Kettler_X7_Lib.Objects.Packet)formatter.Deserialize(clientStream);

                if (pack.Flag == Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES)
                {
                   sModel.writeBikeData(tcpClient.ToString(), pack.Data);
                }
                if (serverIsListening)
                {
                    
                }
                if (serverIsSending)
                if (clientExited)
                {
                    tcpClient.Close();
                    listenThread.Abort();
                }

                Thread.Sleep(100);
            }
        }
    }
}
