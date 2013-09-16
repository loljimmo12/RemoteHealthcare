﻿using Server.Model;
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

                Thread.Sleep(10);
            }
        }
        
        public void acceptAClient(TcpClient client)
        {
            new Server.Control.Client(client, this);
        }

        public void addClientToList(String clientName)
        {
            serverModel.writeBikeData(clientName, null);
        }

        public void writeToModel(String clientName, Object data)
        {
            serverModel.writeBikeData(clientName, data);
        }

        public void finalizeClient()
        {
            serverModel.finalizeData();
        }
    }
}
