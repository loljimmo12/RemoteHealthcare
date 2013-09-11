using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator
{
    class Program
    {


        private TcpListener tcpListener;
        private Thread listenThread;

        public Program()
        {
          this.tcpListener = new TcpListener(IPAddress.Any, 3000);
          this.listenThread = new Thread(new ThreadStart(ListenForClients));
          this.listenThread.Start();
          Console.WriteLine("Server start");
        }

        static void Main(string[] args)
        {
            Program p = new Program();
        }

        

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Console.WriteLine("Client Accepted");
                //make thread for clienthandling
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;
            simulate sim = new simulate();
            sim.startingValues();
            while (true)
            {
                bytesRead = 0;

                try
                {
                    //block until read
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //connection broke/interrupted
                    break;
                }

                if (bytesRead == 0)
                {
                    //disconnect
                    break;
                }

                ASCIIEncoding encoder = new ASCIIEncoding();
                string cm = encoder.GetString(message, 0, bytesRead);
                Console.WriteLine("Client said: " + cm);
                byte[] myWriteBuffer = Encoding.ASCII.GetBytes(sim.HandleCommand(cm));
                clientStream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
            }

            tcpClient.Close();
        }

        }
    }

    class simulate
    {
        private int powerBreak { get; set; }
        private int heartBeat { get; set; }
        private int revolutionsPerMinute;
        private int versionNumber { get; set; }
        private int kiloJoules { get; set; }
        private int distance { get; set; }
        private int timeSeconds { get; set; }
        private int deviceID { get; set; }
        private bool locked { get; set; }
        private bool commandMode;
        public static string notImplemented = "NOTIMP";
        public static string acknowledged = "ACK";
        public static string error = "ERR";

        public void startingValues()
        {
            powerBreak = 25;
            heartBeat = 70;
            revolutionsPerMinute = 0;
            versionNumber = 1337;
            kiloJoules = 0;
            distance = 0;
            timeSeconds = 0;
            revolutionsPerMinute = 0;
            deviceID = 12345;
            locked = false;
            commandMode = false;
        }
       
        public string HandleCommand(string command)
        {
            switch (command.Replace("\n", "").Split(' ')[0])
            {
                case "CM":
                    commandMode = true;
                    return acknowledged;
                case "ID":
                    return versionNumber.ToString();
                case "KI":
                    return deviceID.ToString(); 
                case "RD":
                    return notImplemented;
                case "OP":
                    return notImplemented;
                case "RS":
                    startingValues();
                    return acknowledged;
                case "PW":
                    if (commandMode && command.Contains(" "))
                    {
                        powerBreak = int.Parse(command.Split(' ')[1]);
                        return acknowledged;
                    }
                    return error;
                case "PT":
                    if (commandMode && command.Contains(" "))
                    {
                        timeSeconds = int.Parse(command.Split(' ')[1]);
                        return acknowledged;
                    }
                    return error;
                case "PE":
                    if (commandMode && command.Contains(" "))
                    {
                        kiloJoules = int.Parse(command.Split(' ')[1]);
                        return acknowledged;
                    }
                    return error;
                case "PD":
                    if (commandMode && command.Contains(" "))
                    {
                        distance = int.Parse(command.Split(' ')[1]);
                        return acknowledged;
                    }
                    return error;
                case "VS":
                    if (commandMode && command.Contains(" "))
                    {
                        powerBreak = int.Parse(command.Split(' ')[1]);
                        return acknowledged;
                    }
                    return error;
                case "TR":
                    return DateTime.Now.ToString("h:mm tt");
                case "LB":
                    locked = true;
                    return acknowledged;
                default:
                    return error;
            }
        }


        

    }