using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Kettler_X7_Lib.Networking.Server pServer = new Kettler_X7_Lib.Networking.Server();
            pServer.ClientConnected += pServer_ClientConnected;
            pServer.DataReceived += pServer_DataReceived;

            if (!pServer.bind(Kettler_X7_Lib.Classes.Global.TCPSERVER_PORT))
            {
                Console.WriteLine("Could not bind to port?");
            }
            else
            {
                Console.WriteLine("Bound to port");
            }

            Kettler_X7_Lib.Networking.Client pClient = new Kettler_X7_Lib.Networking.Client();

            pClient.DataReceived += pClient_DataReceived;

            if (!pClient.connect("127.0.0.1", Kettler_X7_Lib.Classes.Global.TCPSERVER_PORT))
            {
                Console.WriteLine("Failed to connect to server");
            }
            else
            {
                Console.WriteLine("Connected to server, SSL initialized");
            }

            /*for (; ; )
            {
                pServer.routeToAllClients(new Kettler_X7_Lib.Objects.Packet()
                {
                    Data = new Kettler_X7_Lib.Objects.Value()
                    {
                        ActualPower = 0,
                        Distance = 0,
                        Energy = 100,
                        Pulse = 10,
                        RequestedPower = 400,
                        RPM = 20,
                        Speed = 20,
                        Time = new TimeSpan(0, 3, 3)
                    },
                    Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES
                });


                System.Threading.Thread.Sleep(5000);
            }*/
           /* for (; ; )
            {
                pClient.routeToServer(new Kettler_X7_Lib.Objects.Packet()
                {
                    Data = new Kettler_X7_Lib.Objects.Value()
                    {
                        ActualPower = 0,
                        Distance = 0,
                        Energy = 100,
                        Pulse = 10,
                        RequestedPower = 400,
                        RPM = 20,
                        Speed = 20,
                        Time = new TimeSpan(0, 3, 3)
                    },
                    Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_HANDSHAKE
                });

                System.Threading.Thread.Sleep(1000);
            }*/

            Kettler_X7_Lib.Classes.Kettler_X7 pKetlerX7 = new Kettler_X7_Lib.Classes.Kettler_X7();
            pKetlerX7.connect("COM14");
            //pKetlerX7.startReceivingValues(1000);
            pKetlerX7.ValuesParsed += pKetlerX7_ValuesParsed;
        }

        static void pServer_DataReceived(object sender, Kettler_X7_Lib.Networking.Server.DataReceivedEventArgs e)
        {
            Console.WriteLine("Got data!");
        }

        static void pKetlerX7_ValuesParsed(object sender, Kettler_X7_Lib.Classes.Kettler_X7.ValuesParsedEventArgs e)
        {
            Console.WriteLine(e.Value);
        }

        static void pClient_DataReceived(object sender, Kettler_X7_Lib.Networking.Server.DataReceivedEventArgs e)
        {
            Console.WriteLine("Got " + e.PacketData.ToString());
        }

        static void pServer_ClientConnected(object sender, Kettler_X7_Lib.Networking.Server.ClientConnectedEventArgs e)
        {
            Console.WriteLine("Client connected?");
        }
    }
}
