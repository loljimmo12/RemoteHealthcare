using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketler_X7_Lib.Objects
{
    public class Client
    {
        /// <summary>
        /// The flag of the client, should be obtained from the handshake packet
        /// </summary>
        public enum ClientFlag
        {
            CLIENTFLAG_CUSTOMERAPP,
            CLIENTFLAG_DOCTORAPP,
            CLIENTFLAG_END
        }

        /// <summary>
        /// The TCP client associated with this networking client
        /// </summary>
        private System.Net.Sockets.TcpClient m_pTcpClient;

        /// <summary>
        /// The SSL stream used for securing the connection
        /// </summary>
        private System.Net.Security.SslStream m_pSslStream;

        /// <summary>
        /// The workerthread associated with this networking client
        /// </summary>
        private System.Threading.Thread m_pWorkerThread;

        /// <summary>
        /// The client flag associated with the client
        /// </summary>
        private ClientFlag m_nClientFlag;

        /// <summary>
        /// The data received event
        /// </summary>
        public event Networking.Server.onDataReceived DataReceived;

        /// <summary>
        /// Generates a new instance
        /// </summary>
        /// <param name="pTcpClient"></param>
        public Client(System.Net.Sockets.TcpClient pTcpClient)
        {
            m_pTcpClient = pTcpClient;
            m_pWorkerThread = new System.Threading.Thread(workerThread);
            
            // Initialize the SSL connection
            m_pSslStream = new System.Net.Security.SslStream(m_pTcpClient.GetStream(), false);
            m_pSslStream.AuthenticateAsServer(System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile("Resources/Certificate.cer"), false, System.Security.Authentication.SslProtocols.Tls, false);

            m_pWorkerThread.Start();
        }

        /// <summary>
        /// Attempts to route packet to client. Data should NOT be serialized
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        public bool routeToClient(object pData)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter pBinaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            try
            {
                pBinaryFormatter.Serialize(m_pSslStream, pData);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The workerthread
        /// </summary>
        private void workerThread()
        {
            while (true)
            {
                if (m_pSslStream.CanRead)
                {
                    object pData = null;
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter pBinaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    try
                    {
                        pData = pBinaryFormatter.Deserialize(m_pSslStream);
                    }
                    catch 
                    {
                    }

                    if (pData != null && DataReceived != null)
                    {
                        DataReceived(this, new Networking.Server.DataReceivedEventArgs()
                        {
                            PacketData = pData
                        });
                    }
                }

                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
