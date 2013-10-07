using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Objects
{
    [Serializable]
    public class ResponseValue
    {
        /// <summary>
        /// The values
        /// </summary>
        public List<Value> ValueList { get; set; }
    }
}
