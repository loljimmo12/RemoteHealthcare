using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
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

        ///<summary>
        ///Forwards incoming clientdata to PacketHandler.
        ///</summary>
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
                catch {
                    disconnect();
                }
                finally
                {
                }
                
                Thread.Sleep(10);
            }
        }

        private void disconnect()
        {
            serverControl.changeClientStatus(this, "offline");
            serverControl.finalizeClient();
            tcpClient.Close();
            listenThread.Abort();
        }

        ///<summary>
        ///Handles outgoing clientdata.
        ///</summary>
        public void sendHandler(Kettler_X7_Lib.Objects.Packet pack)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(tcpClient.GetStream(), pack);
        }

        ///<summary>
        ///Sets client-credentials.
        ///</summary>
        public void setUsernamePassword(String userName, String password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
