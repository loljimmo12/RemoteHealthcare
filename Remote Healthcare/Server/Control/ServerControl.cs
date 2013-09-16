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
        private ServerModel serverModel = new ServerModel();
        private ServerView serverView = new ServerView();

        private TcpListener tcpListener;

        public ServerControl()
        {
            this.tcpListener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 31337);
            listenForClients();
        }

        public void listenForClients()
        {
            tcpListener.Start();
            TcpClient tempClient;


            for (; ; )
            {
                //serverView.writeToConsole(serverModel.readAllClientData().ToString());

                try
                {
                    serverView.writeToConsole("Listening..");
                    tempClient = tcpListener.AcceptTcpClient();
                    handleAClient(tempClient);
                    serverView.writeToConsole("Connected.");
                }
                catch (Exception)
                {
                    throw;
                }

                addClientToList(tempClient);

                Thread.Sleep(10);
            }
        }

        public void addClientToList(TcpClient client)
        {
            serverModel.writeBikeData(client.ToString(), null);
        }

        public void handleAClient(TcpClient client)
        {
            new Server.Control.Client(client);
        }

    }
}
