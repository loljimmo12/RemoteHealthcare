using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public static List<Client> clients;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form2 = new Form2();
            form1 = new Form1();
            Application.Run(form2);
        }
    }

    class Connection
    {
        private TcpClient tcpClient;

        public void Login(string login, string password, string ip)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Kettler_X7_Lib.Objects.Packet();
            Pack.Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_HANDSHAKE;
            Pack.Data = new Kettler_X7_Lib.Objects.Handshake()
            {
                ClientFlag = Kettler_X7_Lib.Objects.Client.ClientFlag.CLIENTFLAG_DOCTORAPP,
                Username = login,
                Password = password

            };
             tcpClient = new TcpClient(ip, 31337);
             this.ip = ip;
             BinaryFormatter format = new BinaryFormatter();
             format.Serialize(tcpClient.GetStream(), Pack);
             Thread Comm = new Thread(new ParameterizedThreadStart(HandleCommunication));
             Comm.Start(tcpClient);
             
            //temp code for testing without server
            //Program.form2.denied(2);
            Program.form2.Close();
            //clientStream.Write(), 0, );
        }

        private void form2()
        {
            Application.Run(Program.form1);
        }

        public void HandleCommunication(object tcp)
        {
            TcpClient tcpClient = (TcpClient)tcp;
            

            while (true)
            {
                Kettler_X7_Lib.Objects.Packet packet;
                try
                {
                    if (tcpClient.GetStream() != null)
                    {
                        if (tcpClient.GetStream().CanRead)
                        {
                            try
                            {
                                packet = (Kettler_X7_Lib.Objects.Packet)new BinaryFormatter().Deserialize(tcpClient.GetStream());
                                handlePacket(packet);
                            }

                            catch
                            {
                                Console.WriteLine("Packet lost");
                            }
                        }
                        else
                        {
                            Console.WriteLine("broke connection");
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("broke connection");
                        break;
                    }
                }
                catch
                {
                    tcpClient = new TcpClient(ip, 31337);
                    Console.WriteLine("socket was dropped");
                }

            }

            //tcpClient.Close();
        }

        private void handlePacket(Kettler_X7_Lib.Objects.Packet packet)
        {
            switch (packet.Flag)
            {
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_RESPONSE_USERLIST:
                    List<String> users = (List<String>)packet.Data;
                    if (Program.form1.InvokeRequired)
                    {
                        Program.form1.Invoke(new Action(() => Program.form1.updateUsers(users)));
                    }
                    
                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT:
                    Kettler_X7_Lib.Objects.ChatMessage chatMess = (Kettler_X7_Lib.Objects.ChatMessage)packet.Data;
                    Console.WriteLine(chatMess.Sender.ToString());
                    foreach (Client client in Program.clients)
                    {
                        if (client.getName().Equals(chatMess.Sender.ToString()))
                        {
                            client.recieveChat(chatMess.Message, chatMess.Sender.ToString());
                            int o = 0;
                            for (int i = 0; i < Program.clients.Count; i++)
                            {
                                if (Program.clients[i].getName().Equals(chatMess.Sender))
                                {
                                    o = i;
                                    break;
                                }
                            }
                            if (Program.form1.selectedReciever == o)
                            {
                                if (Program.form1.InvokeRequired)
                                {
                                    Program.form1.Invoke(new Action(() => Program.form1.refreshChat()));
                                }
                            }
                        }
                    }
                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL:
                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_RESPONSE_HANDSHAKE:
                    Kettler_X7_Lib.Objects.ResponseHandshake handshake = (Kettler_X7_Lib.Objects.ResponseHandshake)packet.Data;

                switch (handshake.Result)
                    {
                        case Kettler_X7_Lib.Objects.ResponseHandshake.ResultType.RESULTTYPE_ACCESSDENIED:
                            Program.form2.denied(2);
                            break;
                        case Kettler_X7_Lib.Objects.ResponseHandshake.ResultType.RESULTTYPE_INVALIDCREDENTIALS:
                            Program.form2.denied(1);
                            break;
                        case Kettler_X7_Lib.Objects.ResponseHandshake.ResultType.RESULTTYPE_OK:
                            Program.form2.Hide();
                            Thread Comm = new Thread(form2);
                            Comm.Start();
                            Program.clients = new List<Client>();
                            requestUsers();
                            break;
                    }
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_RESPONSE_VALUES:
                    Kettler_X7_Lib.Objects.ResponseValue vals = (Kettler_X7_Lib.Objects.ResponseValue)packet.Data;
                    try
                    {
                        if (Program.form1.InvokeRequired)
                        {
                            Program.form1.Invoke(new Action(() => Program.form1.setValues(vals)));
                        }
                    }
                    catch
                    {
                    }
                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES:
                    break;
                default:
                    Console.WriteLine("packet not recognized");
                    break;
            }
        }

        public void requestUsers()
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Kettler_X7_Lib.Objects.Packet();
            Pack.Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_USERLIST;
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(tcpClient.GetStream(), Pack);
        }


        public void sendMessage(string message, string reciever)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Kettler_X7_Lib.Objects.Packet();
            Pack.Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT;
            Pack.Data = new Kettler_X7_Lib.Objects.ChatMessage()
            {
                Receiver = reciever,
                Sender = "Jim",
                Message = message
            };
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(tcpClient.GetStream(), Pack);
        }

        public void sendCommand(string command)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Kettler_X7_Lib.Objects.Packet();
            Pack.Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL;
            Pack.Data = new Kettler_X7_Lib.Objects.BikeControl()
            {
               Command = command 
            };
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(tcpClient.GetStream(), Pack);
        }



        internal void requestData(string user)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Kettler_X7_Lib.Objects.Packet();
            Pack.Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES;
            Pack.Data = new Kettler_X7_Lib.Objects.RequestValue()
            {
                ClientName = user,
                Start = DateTime.Now,
                End = DateTime.Now
            };
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(tcpClient.GetStream(), Pack);
        }

        public string ip { get; set; }
    }
     class Client
     {
         protected string naam;
         protected string chatLog;
         
         public Client(string naam)
         {
             this.naam = naam;
             chatLog = "";
         }

         public void recieveChat(string message, string sender)
         {
             this.chatLog += "[" + DateTime.Now.ToShortTimeString() + "] " + sender + ": "+ message + "\n";
         }

         public string getChat()
         {
             return chatLog;
         }

         public string getName()
         {
             return naam;
         }
     }

}
