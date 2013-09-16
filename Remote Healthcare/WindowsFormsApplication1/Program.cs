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
            /*tcpClient = new TcpClient(ip, 3000);
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(tcpClient.GetStream(), Pack);
            Thread Comm = new Thread(new ParameterizedThreadStart(HandleCommunication));
            Comm.Start(tcpClient);*/
            //temp code for testing without server
            Program.form2.Close();
           // clientStream.Write(), 0, );
        }

        public void HandleCommunication(object tcp)
        {
            TcpClient tcpClient = (TcpClient)tcp;
            StreamReader reader = new StreamReader(tcpClient.GetStream());

            while (true)
            {
                if (tcpClient.GetStream().DataAvailable)
                {
                    //analyze packet type and handle
                    reader.ReadToEnd();
                }

            }

            tcpClient.Close();
        }


        public void sendMessage(string message)
        {
            StreamWriter write = new StreamWriter(tcpClient.GetStream());
            write.WriteLine(message);
        }

        public void sendCommand(string command)
        {
            StreamWriter write = new StreamWriter(tcpClient.GetStream());
            write.WriteLine(command);
        }
    }
}
