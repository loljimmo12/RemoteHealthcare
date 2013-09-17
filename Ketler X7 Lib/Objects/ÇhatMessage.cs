using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Objects
{
    [Serializable]
    public class ÇhatMessage
    {
        /// <summary>
        /// The sender of the packet
        /// </summary>
        public Client.ClientFlag Sender { get; set; }

        /// <summary>
        /// The receiver of the packet
        /// </summary>
        public Client.ClientFlag Receiver { get; set; }

        /// <summary>
        /// The chat message
        /// </summary>
        public string Message { get; set; }
    }
}
