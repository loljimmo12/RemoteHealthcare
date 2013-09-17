using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Objects
{
    [Serializable]
    public class Packet
    {
        /// <summary>
        /// The packet flag
        /// </summary>
        public enum PacketFlag
        {
            PACKETFLAG_REQUEST_HANDSHAKE,
            PACKETFLAG_RESPONSE_HANDSHAKE,
            PACKETFLAG_CHAT,
            PACKETFLAG_BIKECONTROL,
            PACKETFLAG_VALUES
        }

        /// <summary>
        /// The packet data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// The flag of the packet
        /// </summary>
        public PacketFlag Flag { get; set; }
    }
}
