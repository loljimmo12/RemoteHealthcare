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
        private static String clientFile  = "clientFile.bin";
        List<Log> logs { get; set; }
        Dictionary<String, List<Value>> allClients { get; set; }

        // initalization of a Model object.
        public ServerModel()
        {
            logs = readLogData();
            allClients = readAllClientData();
        }

        // Reads the fiel containing all client data and returns the Dictionary.
        public Dictionary<String, List<Value>> readAllClientData()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(clientFile))
            {
                Dictionary<String, List<Value>> allClients = (Dictionary<String, List<Value>>)serializer.Deserialize(stream);
                return allClients;
            }
        }

        // Returns the list to the specified client, because normal getters are boring.
        public List<Value> readBikeData(String client)
        {
            return allClients[client];
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
