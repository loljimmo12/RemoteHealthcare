using Server.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller
{
    // The base class for the Model.
    class ServerModel
    {
        private static String logFileName = "logData.bin";
        List<Log> logs;

        // initalization of a Model object.
        public ServerModel()
        {
            logs = readLogData();
        }

        // WiP
        // Reads the specified File and returns a List of Objects from the file.
        public List<Object> readBikeData(String clientFile)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(clientFile))
            {
                List<Object> clientData = (List<Object>)serializer.Deserialize(stream);
                return clientData;
            }
        }

        // Reads the logFile and puts the data in the List.
        // returns the created List.
        private List<Log> readLogData()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(logFileName))
            {
                List<Log> logData = (List<Log>)serializer.Deserialize(stream);
                return logData;
            }
        }

        // The method to add a single Log object to the List.
        // The old logFile will be overwritten with the new List.
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
}
