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
        public String userName { get; set; }
        private String password;
        private ServerControl serverControl;

        public bool isDoctor { get; set; }

        public Client(TcpClient client, ServerControl sControl)
        {
            this.isDoctor = false;
            this.serverControl = sControl;
            this.tcpClient = client;
            this.listenThread = new Thread(new ThreadStart(handler));
            this.listenThread.Start();
        }

        public void handler()
        {
            NetworkStream clientStream = tcpClient.GetStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Kettler_X7_Lib.Objects.Packet pack = null;
            serverControl.changeClientStatus(this, "online");
           

            for (; ; )
            {
                try
                {
                    pack = formatter.Deserialize(clientStream) as Kettler_X7_Lib.Objects.Packet;
                    PacketHandler.getPacket(serverControl, this, pack);                    
                }
                catch (IOException)
                {
                }
                finally
                {
                    serverControl.changeClientStatus(this, "offline");
                    serverControl.finalizeClient();
                    tcpClient.Close();
                    listenThread.Abort();
                }
                
                Thread.Sleep(100);
            }
        }

        public void chatHandler(Kettler_X7_Lib.Objects.Packet pack)
        {
            NetworkStream clientStream = tcpClient.GetStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            try
            {
                
            }
        }

        public void setUsernamePassword(String userName, String password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
