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
          //this.listenThread = new Thread(new ThreadStart(ListenForClients));
          this.listenThread.Start();
        }


        static void Main(string[] args)
        {

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

        static void Main(string[] args)
        {
        }



        
    }
}
