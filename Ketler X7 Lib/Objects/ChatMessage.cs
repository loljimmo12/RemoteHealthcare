using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Objects
{
    [Serializable]
    public class ChatMessage
    {
        /// <summary>
        /// The sender of the packet
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// The chat message
        /// </summary>
        public string Message { get; set; }
    }
}
