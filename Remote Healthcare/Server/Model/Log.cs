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
        public DateTime login { get; set; }
        public bool accepted { get; set; }

        // initalization of a Log object.
        public Log(DateTime login, bool accepted)
        {
            this.login = login;
            this.accepted = accepted;
        }
    }
}
