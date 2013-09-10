using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    // The base class for a Log, 
    // containing the client's name and the start- and endtime of the session.
    [Serializable]
    class Log
    {
        String clientName { get; set; }
        DateTime startSession { get; set; }
        DateTime endSession { get; set; }

        // initalization of a Log object.
        public Log(String name, DateTime start, DateTime end)
        {
            clientName = name;
            startSession = start;
            endSession = end;
        }
    }
}
