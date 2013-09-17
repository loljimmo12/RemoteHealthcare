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
                }
                catch (Exception)
                {
                }
                finally
                {
                    serverView.writeToConsole("Online clients in list: " + serverModel.onlineClients.Count.ToString());
                }

                Thread.Sleep(10);
            }
        }
        
        public void acceptAClient(TcpClient client)
        {
            new Client(client, this);
        }

        public void addClientToList(Client client)
        {
            serverModel.writeBikeData(client, null);
        }

        public void changeClientStatus(Client client, String status)
        {
            serverModel.changeClientStatus(client, status);
        }

        public void forwardMessage(Kettler_X7_Lib.Objects.Packet pack)
        {
            Kettler_X7_Lib.Objects.ChatMessage message = (Kettler_X7_Lib.Objects.ChatMessage)pack.Data;
            foreach ( Client client in serverModel.onlineClients)
            {
                if (client.userName == message.Receiver)
                {
                    client.sendHandler(pack);
                }
            }
        }

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

        public void writeToModel(Client client, Object data)
        {
            serverModel.writeBikeData(client, data);
        }

        public void finalizeClient()
        {
            serverModel.finalizeData();
        }
    }
}
