using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Net.Security;

namespace WindowsFormsApplication1
{
    static class Program
    {
        public static Form1 form1;
        public static Form2 form2;
        public static h form3;
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
            form3 = new h();
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
             stream = new SslStream(tcpClient.GetStream(), false, new System.Net.Security.RemoteCertificateValidationCallback(checkCert), null);
             try
             {
                 stream.AuthenticateAsClient(ip);
             }
             catch
             {
             }
             sendPacket(Pack);
             logged = true;
             Thread Comm = new Thread(new ParameterizedThreadStart(HandleCommunication));
             Comm.Start(tcpClient);
             lost = 0;
             this.login = login;
             this.pass = password;
             Console.WriteLine("Ik kom hier");
            //temp code for testing without server
            //Program.form2.denied(2);
            //Program.form2.Close();
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
                                packet = (Kettler_X7_Lib.Objects.Packet)new BinaryFormatter().Deserialize(stream);
                                handlePacket(packet);
                                lost = 0;
                            }

                            catch
                            {
                                if (logged)
                                {
                                    ++lost;
                                    Console.WriteLine("Packet lost");
                                    if (lost > 5)
                                    {
                                        logged = false;
                                        Program.connect.Login(login, pass, ip);
                                        break;
                                    }
                                }
                                else
                                {
                                    Program.form2.denied(3);
                                }
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
                            //Program.form2.Hide();
                            Thread Comm = new Thread(form2);
                            Comm.Start();
                            Program.clients = new List<Client>();
                            requestUsers();
                            break;
                    }
                    break;

                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_RESPONSE_VALUES:
                    Kettler_X7_Lib.Objects.ResponseValue vals = (Kettler_X7_Lib.Objects.ResponseValue)packet.Data;
                    //(lock)vals.ValueList;
                    //lock(vals.ValueList)
                    //foreach (Kettler_X7_Lib.Objects.Value value in vals.ValueList)
                    //{
                    //    Console.WriteLine(value.Client);
                    //}
                    //Console.WriteLine("amount of datas: " + vals.ValueList.Count);
                    if (Program.form3.InvokeRequired)
                    {
                        Program.form3.Invoke(new Action(() => Program.form3.handleDataSet(vals.ValueList)));
                    }
                    //try
                    //{
                    //    if (Program.form1.InvokeRequired)
                    //    {
                           // Program.form1.Invoke(new Action(() => Program.form1.setValues(vals)));
                    //    }
                    //}
                    //catch
                    //{		chatMess	null	Kettler_X7_Lib.Objects.ChatMessage

                    //}
                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES:
                    Kettler_X7_Lib.Objects.Value vales = (Kettler_X7_Lib.Objects.Value)packet.Data;
                    foreach (Client client in Program.clients)
                    {
                        if (client.getName().Equals(vales.Client.ToString()))
                        {
                            //client.recieveChat(val.Message, chatMess.Sender.ToString());
                            client.setVal(vales);
                            //int o = 0;
                            //for (int i = 0; i < Program.clients.Count; i++)
                            //{
                            //    if (Program.clients[i].getName().Equals(chatMess.Sender))
                            //    {
                            //        o = i;
                            //        break;
                            //    }
                            //}
                            //if (Program.form1.selectedReciever == o)
                            //{
                            //    if (Program.form1.InvokeRequired)
                            //    {
                            //        Program.form1.Invoke(new Action(() => Program.form1.refreshChat()));
                            //    }
                            //}
                            if (Program.form1.InvokeRequired)
                            {
                                Program.form1.Invoke(new Action(() => Program.form1.updateVals()));
                            }
                            
                        }
                    }
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
            sendPacket(Pack);
        }

        public void sendPacket(Kettler_X7_Lib.Objects.Packet packet)
        {
            if (packet != null)
            {
                BinaryFormatter format = new BinaryFormatter();
                format.Serialize(stream, packet);
            }
        }

        public bool checkCert(object pSender,
              System.Security.Cryptography.X509Certificates.X509Certificate pX509Certificate,
              System.Security.Cryptography.X509Certificates.X509Chain pX509Chain, System.Net.Security.SslPolicyErrors pSslPolicyErrors)
        {
            System.Security.Cryptography.X509Certificates.X509Certificate2 pX509Certificate2 = (System.Security.Cryptography.X509Certificates.X509Certificate2)pX509Certificate;
            Console.WriteLine(pX509Certificate2.Subject);
            Console.WriteLine(pX509Certificate2.Thumbprint);
            return (pX509Certificate2.Subject.StartsWith("CN=localhost") && pX509Certificate2.Thumbprint.Equals("A85BD88DB8119CB25AD1AE16E140B7CCCCB87255"));
            //return true;
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
            sendPacket(Pack);
        }

        public void sendCommand(string command, string client)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Kettler_X7_Lib.Objects.Packet();
            Pack.Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL;
            Pack.Data = new Kettler_X7_Lib.Objects.BikeControl()
            {
               Command = command ,
               Receiver = client
            };
            sendPacket(Pack);
        }



        internal void requestData(string user, DateTime start, DateTime end)
        {
            Kettler_X7_Lib.Objects.Packet Pack = new Kettler_X7_Lib.Objects.Packet();
            Pack.Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_REQUEST_VALUES;
            Pack.Data = new Kettler_X7_Lib.Objects.RequestValue()
            {
                ClientName = user,
                Start = start,
                End = end
            };
            sendPacket(Pack);
        }

        public string ip { get; set; }

        public SslStream stream { get; set; }

        public int lost { get; set; }

        public bool logged { get; set; }

        public string login { get; set; }

        public string pass { get; set; }
    }
     class Client
     {
         protected string naam;
         protected string chatLog;
         protected Kettler_X7_Lib.Objects.Value lastValue;
         
         public Client(string naam)
         {
             this.naam = naam;
             chatLog = "";
         }

         public void setVal(Kettler_X7_Lib.Objects.Value val)
         {
             lastValue = val;
         }

         public Kettler_X7_Lib.Objects.Value getVal()
         {
             return lastValue;
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

         internal void recieveChat(TextBox textBox1, string p)
         {
             throw new NotImplementedException();
         }
     }

}
