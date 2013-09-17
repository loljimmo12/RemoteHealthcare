using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Control
{
    class PacketHandler
    {
        public static void getPacket(ServerControl serverControl, Client client, Kettler_X7_Lib.Objects.Packet pack)
        {
            switch (pack.Flag)
            {
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES:
                    serverControl.writeToModel(client, pack.Data);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT:
                    forwardChat(serverControl, client, pack);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL:

                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE:
                    setUsernamePassword(client, pack);
                    serverControl.addClientToList(client);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_RESPONSE_HANDSHAKE:
                    
                    break;

                //case Doctorcontrols

                default:
                    break;
            }
        }

        public static void setUsernamePassword(Client client, Kettler_X7_Lib.Objects.Packet pack)
        {
            client.setUsernamePassword(((Kettler_X7_Lib.Objects.Handshake)pack.Data).Username, ((Kettler_X7_Lib.Objects.Handshake)pack.Data).Password); 
        }

        public static void forwardChat(ServerControl serverControl, Client client, Kettler_X7_Lib.Objects.Packet pack)
        {
            serverControl.forwardMessage(pack);
        }
    }
}
