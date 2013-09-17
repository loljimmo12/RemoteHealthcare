using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketler_X7_Lib.Objects
{
    [Serializable]
    public class Value
    {
        /// <summary>
        /// The current pulse of the device
        /// </summary>
        public uint Pulse { get; set; }

        /// <summary>
        /// The current RPM of the device
        /// </summary>
        public uint RPM { get; set; }

        /// <summary>
        /// The current speed of the device * 10
        /// </summary>
        public uint Speed { get; set; }

        /// <summary>
        /// The current distance of the device
        /// </summary>
        public uint Distance { get; set; }

        /// <summary>
        /// The current requested power of the device
        /// </summary>
        public uint RequestedPower { get; set; }

        /// <summary>
        /// The current energy of the device
        /// </summary>
        public uint Energy { get; set; }

        /// <summary>
        /// The current exercise time of the device
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// The actual power of the device
        /// </summary>
        public uint ActualPower { get; set; }

        /// <summary>
        /// Fancy ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Pulse: " + Pulse + Environment.NewLine +
                "RPM: " + RPM + Environment.NewLine +
                "Speed: " + Speed + Environment.NewLine +
                "Distance: " + Distance + Environment.NewLine +
                "Requested Power: " + RequestedPower + Environment.NewLine +
                "Energy: " + Energy + Environment.NewLine +
                "Time: " + Time.ToString() + Environment.NewLine +
                "Actual Power: " + ActualPower + Environment.NewLine + Environment.NewLine;
        }
    }
}
