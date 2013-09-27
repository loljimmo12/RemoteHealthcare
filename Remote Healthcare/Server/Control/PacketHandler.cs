using Server.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Control
{
    class PacketHandler
    {
        ///<summary>
        ///Handles datapackets received by clients.
        ///</summary>
        public static void getPacket(ServerControl serverControl, Client client, Kettler_X7_Lib.Objects.Packet pack)
        {
            switch (pack.Flag)
            {
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES:
                    serverControl.writeToModel(client, (Kettler_X7_Lib.Objects.Value)pack.Data);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT:
                    serverControl.forwardMessage(pack);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL:
                    serverControl.forwardBikeCommand(pack);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE:
                    setUsernamePassword(client, pack);
                    serverControl.handshakeResponse(client, (Kettler_X7_Lib.Objects.Handshake)pack.Data);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_VALUES:
                    client.sendHandler(serverControl.requestSpecifiedClientData((Kettler_X7_Lib.Objects.RequestValue)pack.Data));
                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_USERLIST:
                    client.sendHandler(serverControl.getOnlineClientListPacket());
                    Console.WriteLine("send a list of online users!");
                    break;
                default:
                    break;
            }
        }

        ///<summary>
        ///Forwards client-credentials.
        ///</summary>
        public static void setUsernamePassword(Client client, Kettler_X7_Lib.Objects.Packet pack)
        {
            client.setUsernamePassword(((Kettler_X7_Lib.Objects.Handshake)pack.Data).Username, ((Kettler_X7_Lib.Objects.Handshake)pack.Data).Password); 
        }
    }
}
