using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller
{
    class ServerModel
    {
        private static String logFileName = "logData.bin";

        public ServerModel()
        {
        }

        public void saveLog(Log log)
        {
            using (FileStream filestream = new FileStream(logFileName, FileMode.Append, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filestream, log);
            }
        }
    }

    struct Log
    {
        String clientName { get; set; }
        DateTime startSession { get; set; }
        DateTime endSession { get; set; }

        public Log(String clientName, DateTime startSession, DateTime endSession)
        {
            this.clientName = clientName;
            this.startSession = startSession;
            this.endSession = endSession;
        }
    }
}
