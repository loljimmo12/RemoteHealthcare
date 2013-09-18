using Server.Model;
using Server.View;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace Server.Control
{
    class ServerControl
    {
        private ServerModel serverModel;
        private ServerView serverView;

        private TcpListener tcpListener;

        public ServerControl()
        {
            serverModel = new ServerModel();
            serverView = new ServerView(serverModel);
            this.tcpListener = new TcpListener(System.Net.IPAddress.Any, 31337);
            listenForClients();
        }

        ///<summary>
        ///Start listening for connecting TcpClients.
        ///</summary>
        public void listenForClients()
        {
            tcpListener.Start();
            TcpClient tempClient;

            for (; ; )
            {
                try
                {
                    serverView.writeToConsole("Listening..");
                    tempClient = tcpListener.AcceptTcpClient();
                    acceptAClient(tempClient);
                    serverView.writeToConsole("Connected.");
                    serverView.writeToConsole("Online clients in list: " + serverModel.onlineClients.Count.ToString());
                }
                catch (Exception)
                {
                }
               
                Thread.Sleep(10);
            }
        }

        ///<summary>
        ///Instantiate a Clientobject for a connected TcpClient.
        ///</summary>
        public void acceptAClient(TcpClient client)
        {
            new Client(client, this);
        }

        ///<summary>
        ///Forward client to servermodel's dictionary.
        ///</summary>
        public void addClientToList(Client client)
        {
            serverModel.writeBikeData(client, null);
        }

        ///<summary>
        ///Change desired online/offline status for a client.
        ///</summary>
        public void changeClientStatus(Client client, String status)
        {
            serverModel.changeClientStatus(client, status);
        }

        ///<summary>
        ///Forward chatmessage received from client to servermodel.
        ///</summary>
        public void forwardMessage(Kettler_X7_Lib.Objects.Packet pack)
        {
            Kettler_X7_Lib.Objects.ChatMessage message = (Kettler_X7_Lib.Objects.ChatMessage)pack.Data;

            serverView.writeToConsole(message.Message);

            foreach ( Client client in serverModel.onlineClients)
            {
                if (client.userName == message.Receiver)
                {
                    client.sendHandler(pack);
                }
            }
        }

        ///<summary>
        ///Forward bikecommand received from client to servermodel.
        ///</summary>
        public void forwardBikeCommand(Kettler_X7_Lib.Objects.Packet pack)
        {
            //Kettler_X7_Lib.Objects.BikeControl bikeControl = (Kettler_X7_Lib.Objects.BikeControl) pack.Data;
            //foreach (Client client in serverModel.onlineClients)
            //{
            //    if (client.userName == bikeControl.Receiver)
            //    {
            //        client.sendHandler(pack);
            //   }
            //}
        }

        ///<summary>
        ///Forward client data to servermodel.
        ///</summary>
        public void writeToModel(Client client, Object data)
        {
            serverModel.writeBikeData(client, data);
        }

        ///<summary>
        ///Tell servermodel to finalize data after a client has disconnected.
        ///</summary>
        public void finalizeClient()
        {
            serverModel.finalizeData();
        }
    }
}
