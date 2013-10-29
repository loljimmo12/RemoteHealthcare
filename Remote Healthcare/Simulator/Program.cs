﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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
          //simulate simu = new simulate();
          //simu.simulateUser();
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
            //NetworkStream clientStream = tcpClient.GetStream();

            //byte[] message = new byte[4096];
            //int bytesRead;
            simulate sim = new simulate();
            sim.startingValues();
            Thread simulationThread = new Thread(new ParameterizedThreadStart(SimulateTime));
            simulationThread.Start(sim);
            StreamReader reader = new StreamReader(tcpClient.GetStream());
            string cm;
            StreamWriter writer = new StreamWriter(tcpClient.GetStream());
            writer.AutoFlush = true;

            while (true)
            {
                if (tcpClient.GetStream().DataAvailable)
                {
                    //Console.WriteLine(reader.ReadLine());
                    cm = reader.ReadLine();
                    if (cm == null)
                    {
                        Console.WriteLine("Client lost");
                        tcpClient.Close();
                        break;
                    }
                    Console.WriteLine("Client said: " + cm);
                    //byte[] myWriteBuffer = Encoding.ASCII.GetBytes(sim.HandleCommand(cm));
                    writer.WriteLine(sim.HandleCommand(cm).Replace(",", "."));
                }
                Thread.Sleep(10);
                
                
               
            }

            tcpClient.Close();
        }

        private void SimulateTime(object Simulator)
        {
            simulate sim = (simulate)Simulator;
            while (true)
            {
                sim.simulateUser();
                Thread.Sleep(1000);
            }
        }
    }
}

    class simulate
    {
        private int powerBreak { get; set; }
        private int heartBeat { get; set; }
        private int revolutionsPerMinute;
        private int versionNumber { get; set; }
        private int distance { get; set; }
        private int timeSeconds { get; set; }
        private int deviceID { get; set; }
        private double velocity { get; set; }
        private double kiloJoules { get; set; }
        private string power { get; set; }
        private bool locked { get; set; }
        private bool commandMode;
        private bool timeCountdown;
        private bool energyCountdown;
        public static string notImplemented = "NOTIMP";
        public static string acknowledged = "ACK";
        public static string error = "ERROR";
        private int prevbreak;

        public void startingValues()
        {
            powerBreak = 25;
            heartBeat = 70;
            revolutionsPerMinute = 0;
            versionNumber = 1337;
            kiloJoules = 0;
            distance = 0;
            timeSeconds = -1;
            revolutionsPerMinute = 0;
            velocity = 0;
            deviceID = 12345;
            locked = false;
            commandMode = false;
            timeCountdown = false;
            prevbreak = 0;
        }
        private string timeStamp()
        {
            int seconds = timeSeconds % 60;
            int minutes = timeSeconds / 60;
            if (minutes<10 && seconds>10) return "0"+ minutes + ":" + seconds;
            else if (minutes < 10 && seconds < 10) return "0" + minutes + ":" + "0"+seconds;
            else if (minutes > 10 && seconds < 10) return minutes + ":" + "0"+seconds;
            else return minutes + ":" + seconds;
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
                        if(int.Parse(command.Split(' ')[1]) > 400) powerBreak = 400;
                        if (int.Parse(command.Split(' ')[1]) < 25) powerBreak = 25;
                        if(int.Parse(command.Split(' ')[1]) <= 400 && int.Parse(command.Split(' ')[1]) >=25) powerBreak = int.Parse(command.Split(' ')[1]);
                        return acknowledged;
                    }
                    return error;
                case "PT":
                    if (commandMode && command.Contains(" "))
                    {
                        timeSeconds = int.Parse(command.Split(' ')[1]);
                        energyCountdown = true;
                        return acknowledged;
                    }
                    return error;
                case "PE":
                    if (commandMode && command.Contains(" "))
                    {
                        kiloJoules = int.Parse(command.Split(' ')[1]);
                        timeCountdown = true;
                        return acknowledged;
                    }
                    return error;
                case "PD":
                    if (commandMode && command.Contains(" "))
                    {
                        distance = int.Parse(command.Split(' ')[1]);
                        if (powerBreak < 100) power = "0" + powerBreak.ToString();
                        else power = powerBreak.ToString();
                        return heartBeat.ToString() + "\t" + revolutionsPerMinute.ToString() + "\t" + velocity + "\t" + (distance * 10).ToString() + "\t" + power + "\t" + (Math.Floor(kiloJoules * 10) / 10).ToString("0.#") + "\t" + timeStamp() + "\t" + powerBreak.ToString();    
                    }
                    return error;
                case "EE":
                    return acknowledged;
                case "SP":
                    return notImplemented;
                case "RF":
                    return notImplemented;
                case "VS":
                    if (commandMode && command.Contains(" "))
                    {
                        powerBreak = int.Parse(command.Split(' ')[1]);
                        return revolutionsPerMinute.ToString();
                    }
                    return error;
                case "TR":
                    return DateTime.Now.ToString("h:mm tt");
                case "LB":
                    locked = true;
                    return acknowledged;
                case "ST":
                    if (timeSeconds == -1) timeSeconds = 0;
                    if(powerBreak < 100) power = "0" + powerBreak.ToString();
                        else power = powerBreak.ToString();
                    return heartBeat.ToString() + "\t" + revolutionsPerMinute.ToString() + "\t" + (int) velocity + "\t" + (distance * 10).ToString() + "\t" + power + "\t" + (Math.Floor(kiloJoules * 10) / 10).ToString("0.#") + "\t" + timeStamp() + "\t" + powerBreak.ToString();
                default:
                    return error;
            }
        }


        public void simulateUser()
        {
            var random = new Random();
            int rand = random.Next(5) - 2;
            if (powerBreak <= 150)
                revolutionsPerMinute = 90 + rand;
            if (powerBreak <= 200 && powerBreak > 150)
                revolutionsPerMinute = 60 + rand;
            else revolutionsPerMinute = 50 + rand;
            velocity = revolutionsPerMinute * 0.36 * 10.0;
            timeSeconds++;
            
            if (timeSeconds % 3 == 0)
                kiloJoules = kiloJoules + powerBreak/25;
            if (heartBeat <= 150) heartBeat = heartBeat + ((prevbreak > powerBreak)?-(powerBreak / 25 / 2):(powerBreak / 25 / 2));
            if (heartBeat >= 70) heartBeat = heartBeat + ((rand<0)?rand*2:rand);
            if (heartBeat < 70) heartBeat = 70;
            if (heartBeat > 150) heartBeat = 150;
            prevbreak = powerBreak; 
            distance = Convert.ToInt32(velocity * (timeSeconds/60.0/60.0));
            if (timeSeconds > 360)
                heartBeat += 5;
            if (timeSeconds > 720)
                heartBeat += 5;
        }
    }