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
        private String userName;
        private String password;
        private ServerControl serverControl;

        bool serverIsListening = false;
        bool isDoctor = false;

        public Client(TcpClient client, ServerControl sControl)
        {
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
            
            serverIsListening = true;

            for (; ; )
            {
                try
                {
                    pack = formatter.Deserialize(clientStream) as Kettler_X7_Lib.Objects.Packet;                 
                    
                }
                catch (IOException)
                {
                }
                finally
                {
                    serverControl.finalizeClient();
                    tcpClient.Close();
                    listenThread.Abort();
                }
                
                Thread.Sleep(100);
            }
        }

        public void setUsernamePassword(String userName, String password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
