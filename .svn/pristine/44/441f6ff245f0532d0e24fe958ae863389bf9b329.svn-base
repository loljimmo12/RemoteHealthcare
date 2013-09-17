using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketler_X7_Lib.Networking
{
    public class Server
    {
        /// <summary>
        /// Event args for the ClientConnected event
        /// </summary>
        public class ClientConnectedEventArgs : EventArgs
        {
            public Objects.Client Client { get; set; }
        }

        /// <summary>
        /// Event args for the DataReceived event
        /// </summary>
        public class DataReceivedEventArgs : EventArgs
        {
            //public Objects.Client Sender { get; set; }
            public object PacketData { get; set; }
        }

        /// <summary>
        /// The TCP listener
        /// </summary>
        private System.Net.Sockets.TcpListener m_pTcpListener;

        /// <summary>
        /// The workerthread associated with accepting clients
        /// </summary>
        private System.Threading.Thread m_pWorkerThead;

        /// <summary>
        /// The client list associated with this server
        /// </summary>
        private List<Objects.Client> m_pClientList;

        /// <summary>
        /// The client connected event
        /// </summary>
        public event onClientConnected ClientConnected;

        /// <summary>
        /// The data received event
        /// </summary>
        public event onDataReceived DataReceived;

        /// <summary>
        /// The delegate for our ClientConnected event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void onClientConnected(object sender, ClientConnectedEventArgs e);

        /// <summary>
        /// The delegate for our DataReceived event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void onDataReceived(object sender, DataReceivedEventArgs e);

        /// <summary>
        /// Attempts to start TCP server at given port
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        public bool bind(int nPort)
        {
            m_pTcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, nPort);
            m_pWorkerThead = new System.Threading.Thread(workerThread);
            m_pClientList = new List<Objects.Client>();

            try
            {
                m_pTcpListener.Start(64);
                m_pWorkerThead.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Routes data to all connected clients. Data should NOT be serialized
        /// </summary>
        /// <param name="pPacket"></param>
        public void routeToAllClients(Objects.Packet pPacket)
        {
            lock (m_pClientList)
            {
                foreach (Objects.Client pClient in m_pClientList)
                {
                    pClient.routeToClient(pPacket);
                }
            }
        }

        /// <summary>
        /// Adds client to client list
        /// </summary>
        /// <param name="pClient"></param>
        private void addClient(Objects.Client pClient)
        {
            lock (m_pClientList)
            {
                m_pClientList.Add(pClient);
            }
        }

        /// <summary>
        /// The workerthread that deals with accepting clients
        /// </summary>
        private void workerThread()
        {
            while (true)
            {
                System.Net.Sockets.TcpClient pTcpClient = null;

                try
                {
                    pTcpClient = m_pTcpListener.AcceptTcpClient();
                }
                catch
                {
                }

                if (pTcpClient != null)
                {
                    Objects.Client pClient = new Objects.Client(pTcpClient);
                    addClient(pClient);

                    if (ClientConnected != null)
                    {
                        ClientConnected(this, new ClientConnectedEventArgs()
                        {
                            Client = pClient
                        });

                        pClient.DataReceived += pClient_DataReceived;
                    }
                }
            }
        }

        /// <summary>
        /// Event for whenever data is received from a client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pClient_DataReceived(object sender, Server.DataReceivedEventArgs e)
        {
            // Verify packet data
            if (!(e.PacketData is Objects.Packet))
            {
                return;
            }

            // TO DO: verify packet data with reflection

            bool bHandled = false;
            Objects.Packet pPacket = (Objects.Packet)e.PacketData;

            switch (pPacket.Flag)
            {
                case Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE:
                    ((Objects.Client)sender).setClientFlag(((Objects.Handshake)pPacket.Data).ClientFlag);
                    bHandled = true;
                    break;
            }

            if (bHandled)
            {
                return;
            }

            if (DataReceived != null)
            {
                DataReceived(sender, e);
            }
        }
    }
}
