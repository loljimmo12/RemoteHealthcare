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
        List<Log> logs;

        public ServerModel()
        {
            logs = readLogData();
        }

        private List<Log> readLogData()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(logFileName))
            {
                List<Log> logData = (List<Log>)serializer.Deserialize(stream);
                return logData;
            }
        }

        public void saveLog(Log log)
        {
            logs.Add(log);
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenWrite(logFileName))
            {
                serializer.Serialize(stream, logs);
            }
        }
    }

    [Serializable]
    class Log 
    {
        String clientName { get; set; }
        DateTime startSession { get; set; }
        DateTime endSession { get; set; }

        public Log(String name, DateTime start, DateTime end)
        {
            clientName = name;
            startSession = start;
            endSession = end;
        }
    }
}
