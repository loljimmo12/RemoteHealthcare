using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketler_X7_Lib.Networking
{
    public class Client
    { 
        /// <summary>
        /// The TCP client
        /// </summary>
        private System.Net.Sockets.TcpClient m_pTcpClient;

        /// <summary>
        /// The workerthead associated with the client
        /// </summary>
        private System.Threading.Thread m_pWorkerThread;

        /// <summary>
        /// The SSL stream used for communicating with the server
        /// </summary>
        private System.Net.Security.SslStream m_pSslStream;

        /// <summary>
        /// The DataReceived event
        /// </summary>
        public event Server.onDataReceived DataReceived;

        /// <summary>
        /// Attempts to connect to given server
        /// </summary>
        /// <param name="strIPAddress"></param>
        /// <param name="nPort"></param>
        /// <returns></returns>
        public bool connect(string strIPAddress, int nPort)
        {
            m_pTcpClient = new System.Net.Sockets.TcpClient();

            try
            {
                m_pTcpClient.Connect(strIPAddress, nPort);
            }
            catch
            {
                return false;
            }

            // Initialize SSL
            m_pSslStream = new System.Net.Security.SslStream(m_pTcpClient.GetStream(), false, new System.Net.Security.RemoteCertificateValidationCallback(validateServerCertificate), null);

            try
            {
                m_pSslStream.AuthenticateAsClient(strIPAddress);
            }
            catch
            {
                return false;
            }

            m_pWorkerThread = new System.Threading.Thread(workerThread);
            m_pWorkerThread.Start();

            return true;
        }

        /// <summary>
        /// Callback for server certificate validation
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pX509Certificate"></param>
        /// <param name="pX509Chain"></param>
        /// <param name="pSslPolicyErrors"></param>
        /// <returns></returns>
        private bool validateServerCertificate(object pSender,
              System.Security.Cryptography.X509Certificates.X509Certificate pX509Certificate,
              System.Security.Cryptography.X509Certificates.X509Chain pX509Chain, System.Net.Security.SslPolicyErrors pSslPolicyErrors)
        {
            System.Security.Cryptography.X509Certificates.X509Certificate2 pX509Certificate2 = (System.Security.Cryptography.X509Certificates.X509Certificate2)pX509Certificate;
            
            // Verify certificate
            if (pX509Certificate2.Subject.StartsWith("CN=localhost") && pX509Certificate2.Thumbprint == "F02AB77F80CEA6D05EC4E739B36F49A2FCAD069C")
            {
                return true;
            }

            // We don't want a certificate that is not ours
            return false;
        }

        /// <summary>
        /// Attempts to send object to server. Data should NOT be serialized
        /// </summary>
        /// <param name="pPacket"></param>
        /// <returns></returns>
        public bool routeToServer(Objects.Packet pPacket)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter pBinaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            try
            {
                pBinaryFormatter.Serialize(m_pTcpClient.GetStream(), pPacket);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The workerthread associated with the client
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
                        DataReceived(this, new Server.DataReceivedEventArgs()
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
