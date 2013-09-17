using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Objects
{
    [Serializable]
    public class BikeControl
    {
        /// <summary>
        /// The command to be executed on the bike
        /// </summary>
        public string Command { get; set; }
    }
}
