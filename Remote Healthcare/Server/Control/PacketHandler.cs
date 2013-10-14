using System;
using Kettler_X7_Lib.Objects;

namespace Server.Control
{
    class PacketHandler
    {
        ///<summary>
        ///Handles datapackets received by clients.
        ///</summary>
        public static void getPacket(ServerControl serverControl, Client client, Packet pack)
        {
            switch (pack.Flag)
            {
                case Packet.PacketFlag.PACKETFLAG_VALUES:
                    serverControl.writeToModel(client, (Value)pack.Data);
                    serverControl.ForwardedValuePacket(client, pack);
                    break;

                case Packet.PacketFlag.PACKETFLAG_CHAT:
                    serverControl.forwardMessage(pack, client);
                    break;

                case Packet.PacketFlag.PACKETFLAG_BIKECONTROL:
                    serverControl.forwardBikeCommand(pack);
                    break;

                case Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE:
                    setUsernamePassword(client, pack);
                    serverControl.handshakeResponse(client, (Handshake)pack.Data);
                    break;

                case Packet.PacketFlag.PACKETFLAG_REQUEST_VALUES:
                    client.sendHandler(serverControl.requestSpecifiedClientData((RequestValue)pack.Data));
                    break;
                case Packet.PacketFlag.PACKETFLAG_REQUEST_USERLIST:
                    client.sendHandler(serverControl.getOnlineClientListPacket());
                    break;
                default:
                    Console.WriteLine("Error: unhandled Packet received - {0}", pack.Flag);
                    break;
            }
        }

        ///<summary>
        ///Forwards client-credentials.
        ///</summary>
        public static void setUsernamePassword(Client client, Packet pack)
        {
            client.setUsernamePassword(((Handshake)pack.Data).Username, ((Handshake)pack.Data).Password);
            client.isDoctor = ((Handshake) pack.Data).ClientFlag == Kettler_X7_Lib.Objects.Client.ClientFlag.CLIENTFLAG_DOCTORAPP;
        }
    }
}
