using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Networking
{
    public class Client
    {
        /// <summary>
        /// The type that specifies what the client is meant to receive / send
        /// </summary>
        public enum ClientType
        {
            CLIENTTYPE_STRING,
            CLIENTTYPE_SERIALIZEDOBJECT
        }

        /// <summary>
        /// The DataReceived event
        /// </summary>
        public event Server.onDataReceived DataReceived;

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
        /// Whether or not SSL is enabled for this client
        /// </summary>
        private bool m_bSslEnabled;

        /// <summary>
        /// The type that specifies what the client is about to receive / send
        /// </summary>
        private ClientType m_nClientType;

        /// <summary>
        /// Object that handles the incoming and outgoing data, can be StreamReader or BinaryFormatter depending on the client type
        /// </summary>
        private object m_pInHandlerObj, m_pOutHandlerObj;

        /// <summary>
        /// Attempts to connect to given server
        /// </summary>
        /// <param name="strIPAddress"></param>
        /// <param name="nPort"></param>
        /// <param name="bSslEnabled"></param>
        /// <param name="nClientRecvType"></param>
        /// <returns></returns>
        public bool connect(string strIPAddress, int nPort, bool bSslEnabled = true, ClientType nClientType = ClientType.CLIENTTYPE_SERIALIZEDOBJECT)
        {
            m_pTcpClient = new System.Net.Sockets.TcpClient();
            m_bSslEnabled = bSslEnabled;
            m_nClientType = nClientType;

            try
            {
                m_pTcpClient.Connect(strIPAddress, nPort);
            }
            catch
            {
                return false;
            }

            if (m_bSslEnabled)
            {
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
            }

            // Initialize handler object
            switch (m_nClientType)
            {
                case ClientType.CLIENTTYPE_SERIALIZEDOBJECT:

                    m_pInHandlerObj = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    m_pOutHandlerObj = m_pInHandlerObj;

                    break;
                case ClientType.CLIENTTYPE_STRING:

                    m_pInHandlerObj = new System.IO.StreamReader(getStream());
                    m_pOutHandlerObj = new System.IO.StreamWriter(getStream());

                    break;
            }

            m_pWorkerThread = new System.Threading.Thread(workerThread);
            m_pWorkerThread.Start();

            return true;
        }

        /// <summary>
        /// Authenticates client to server
        /// </summary>
        /// <param name="nClientFlag"></param>
        /// <param name="strUsername"></param>
        /// <param name="strPassword"></param>
        public void authenticate(Objects.Client.ClientFlag nClientFlag, string strUsername, string strPassword)
        {
            routeToServer(new Objects.Packet()
            {
                Flag = Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE,
                Data = new Objects.Handshake()
                {
                    ClientFlag = nClientFlag,
                    Username = strUsername,
                    Password = strPassword
                }
            });
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
        /// Returns the stream for this client
        /// </summary>
        /// <returns></returns>
        private System.IO.Stream getStream()
        {
            if (m_bSslEnabled && m_pSslStream != null)
            {
                return m_pSslStream;
            }

            return m_pTcpClient.GetStream();
        }

        /// <summary>
        /// Attempts to send object to server
        /// </summary>
        /// <param name="pPacket"></param>
        /// <returns></returns>
        public bool routeToServer(object pData)
        {
            try
            {
                switch (m_nClientType)
                {
                    case ClientType.CLIENTTYPE_SERIALIZEDOBJECT:

                        ((System.Runtime.Serialization.Formatters.Binary.BinaryFormatter)m_pOutHandlerObj).Serialize(getStream(), pData);

                        break;
                    case ClientType.CLIENTTYPE_STRING:

                        ((System.IO.StreamWriter)m_pOutHandlerObj).WriteLine(pData);

                        break;
                }
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
                System.IO.Stream pStream = getStream();

                if (pStream.CanRead)
                {
                    object pData = null;

                    // Handle data according to client type
                    try
                    {
                        switch (m_nClientType)
                        {
                            case ClientType.CLIENTTYPE_SERIALIZEDOBJECT:

                                pData = ((System.Runtime.Serialization.Formatters.Binary.BinaryFormatter)m_pInHandlerObj).Deserialize(pStream);

                                break;
                            case ClientType.CLIENTTYPE_STRING:

                                pData = ((System.IO.StreamReader)m_pInHandlerObj).ReadToEnd();

                                break;
                        }
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
