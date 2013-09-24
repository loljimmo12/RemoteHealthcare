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
                    serverControl.writeToModel(client, pack.Data);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT:
                    serverControl.forwardMessage(pack);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL:
                    serverControl.forwardBikeCommand(pack);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE:
                    setUsernamePassword(client, pack);
                    serverControl.addClientToList(client);
                    //TODO: send a Response_Handshake
                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_VALUES:
                    //TODO: look at the Request and send a Response Values pack.
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
