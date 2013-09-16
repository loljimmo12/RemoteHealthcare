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

            for (; ; )
            {
                try
                {
                    pack = formatter.Deserialize(clientStream) as Kettler_X7_Lib.Objects.Packet;

                    switch(pack.Flag)
                    {
                        case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES:             
                            sModel.writeBikeData(tcpClient.ToString(), pack.Data);
                            break;

                        case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT:

                            break;

                        case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL:

                            break;

                        case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE:

                            break;

                        case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_RESPONSE_HANDSHAKE:

                            break;

                        default:
                            break;
                    }
                }
                catch (IOException)
                {
                }
                finally
                {
                    sModel.finalizeData();
                    tcpClient.Close();
                    listenThread.Abort();
                }
                
                Thread.Sleep(100);
            }


        }
    }
}
