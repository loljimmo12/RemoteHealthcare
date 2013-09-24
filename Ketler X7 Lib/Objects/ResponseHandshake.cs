using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Objects
{
    [Serializable]
    public class ResponseHandshake
    {
        /// <summary>
        /// The result that responds to the request handshake
        /// </summary>
        public enum ResultType
        {
            RESULTTYPE_OK,
            RESULTTYPE_INVALIDCREDENTIALS,
            RESULTTYPE_ACCESSDENIED
        }

        /// <summary>
        /// The result to the handshake request
        /// </summary>
        public ResultType Result { get; set; }
    }
}
