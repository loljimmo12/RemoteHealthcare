using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kettler_X7_Lib.Classes;
using Kettler_X7_Lib.Objects;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    static class Program
    {
        public static Form1 form1;
        public static Form2 form2;
        public static Connection connect;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form2 = new Form2();
            Application.Run(form2);
        }
    }

    class Connection
    {
        private TcpClient tcpClient;

        public void Login(string login, string password, string ip)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Packet();
            Pack.Flag = Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE;
            Pack.Data = new Kettler_X7_Lib.Objects.Handshake()
            {
                ClientFlag = Client.ClientFlag.CLIENTFLAG_DOCTORAPP,
                Username = login,
                Password = password

            };
             tcpClient = new TcpClient(ip, 3000);
             BinaryFormatter format = new BinaryFormatter();
             format.Serialize(tcpClient.GetStream(), Pack);
             Thread Comm = new Thread(new ParameterizedThreadStart(HandleCommunication));
             Comm.Start(tcpClient);
             
            //temp code for testing without server
            //Program.form2.denied(2);
            Program.form2.Close();
            //clientStream.Write(), 0, );
        }

        public void HandleCommunication(object tcp)
        {
            TcpClient tcpClient = (TcpClient)tcp;
            

            while (true)
            {
                Packet packet;
                if (tcpClient.GetStream() != null && tcpClient.GetStream().CanRead)
                {
                    try
                    {
                        packet = (Packet)new BinaryFormatter().Deserialize(tcpClient.GetStream());
                        handlePacket(packet);
                    }

                    catch
                    {
                    }
                }

            }

            //tcpClient.Close();
        }

        private void handlePacket(Packet packet)
        {
            switch (packet.Flag)
            {
                case Packet.PacketFlag.PACKETFLAG_CHAT:
                    ChatMessage chatMess = (ChatMessage)packet.Data;
                    chatMess.Sender.ToString();
                    break;
                case Packet.PacketFlag.PACKETFLAG_BIKECONTROL:
                    break;
                case Packet.PacketFlag.PACKETFLAG_RESPONSE_HANDSHAKE:
                    ResponseHandshake handshake = (ResponseHandshake)packet.Data;

                switch (handshake.Result)
                    {
                        case ResponseHandshake.ResultType.RESULTTYPE_ACCESSDENIED:
                            Program.form2.denied(1);
                            break;
                        case ResponseHandshake.ResultType.RESULTTYPE_INVALIDCREDENTIALS:
                            Program.form2.denied(2);
                            break;
                        case ResponseHandshake.ResultType.RESULTTYPE_OK:
                            Program.form2.Dispose();
                            Program.form1.Activate();
                            break;
                    }
                    break;
                
                case Packet.PacketFlag.PACKETFLAG_RESPONSE_VALUES:
                    break;
                case Packet.PacketFlag.PACKETFLAG_VALUES:
                    break;
                default:
                    break;
            }
        }


        public void sendMessage(string message, string reciever)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Packet();
            Pack.Flag = Packet.PacketFlag.PACKETFLAG_CHAT;
            Pack.Data = new Kettler_X7_Lib.Objects.ChatMessage()
            {
                Receiver = reciever,
                Sender = "anon",
                Message = message
            };
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(tcpClient.GetStream(), Pack);
        }

        public void sendCommand(string command)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Packet();
            Pack.Flag = Packet.PacketFlag.PACKETFLAG_BIKECONTROL;
            Pack.Data = new Kettler_X7_Lib.Objects.BikeControl()
            {
               Command = command 
            };
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(tcpClient.GetStream(), Pack);
        }
    }

}
