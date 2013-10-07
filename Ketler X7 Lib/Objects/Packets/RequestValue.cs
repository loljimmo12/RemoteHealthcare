using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Objects
{
    [Serializable]
    public class RequestValue
    {
        /// <summary>
        /// The name of the client of which the data should be returned
        /// Should be omitted if sent from client
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// The start of the requested values
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// The end of the requested values
        /// </summary>
        public DateTime End { get; set; }
    }
}
