﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Classes
{
    public class Global
    {
        /// <summary>
        /// The simulator's IP address
        /// </summary>
        public const string SIMULATOR_IP = "localhost";

        /// <summary>
        /// The simulator's port
        /// </summary>
        public const int SIMULATOR_PORT = 3000;

        /// <summary>
        /// The server's IP address
        /// </summary>
        public const string TCPSERVER_IP = "localhost";

        /// <summary>
        /// The server's port
        /// </summary>
        public const int TCPSERVER_PORT = 31337;

        /// <summary>
        /// The name of this client
        /// </summary>
        public static string CLIENT_NAME;
    }
}
