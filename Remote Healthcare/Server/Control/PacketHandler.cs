
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
                    serverControl.ForwardedValuePacket(client, pack);
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT:
                    serverControl.forwardMessage(pack, client);
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
            client.isDoctor = ((Kettler_X7_Lib.Objects.Handshake) pack.Data).ClientFlag ==
                              Kettler_X7_Lib.Objects.Client.ClientFlag.CLIENTFLAG_DOCTORAPP;
        }
    }
}
