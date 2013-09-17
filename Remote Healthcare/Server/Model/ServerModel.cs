using Server.Control;
using Server.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    // The base class for the Model.
    class ServerModel
    {
        private static String logFileName = "logData.bin";
        private static String clientFile  = "clientFile.bin";
        List<Client> onlineClients;
        List<Log> logs { get; set; }
        Dictionary<string, List<object>> allClients { get; set; }

        // initalization of a Model object.
        public ServerModel()
        {
            onlineClients = new List<Client>();

            if (File.Exists(clientFile))
            {
                allClients = readAllClientData();
            }
            else
            {
                allClients = new Dictionary<string, List<object>>();
            }
            if (File.Exists(logFileName))
            {
                logs = readLogData();
            }
            else
            {
                logs = new List<Log>();
            }
        }

        // Writes the data from a Value into the Dictionary
        public void writeBikeData(String client, Object data)
        {
            if (allClients.ContainsKey(client))
            {
                allClients[client].Add(data);
            }
            else
            {
                List<Object> clientData = new List<Object>();
                clientData.Add(data);
                allClients.Add(client, clientData);
            }
        }

        // Reads the fiel containing all client data and returns the Dictionary.
        public Dictionary<String, List<Object>> readAllClientData()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(clientFile))
            {
                Dictionary<String, List<Object>> allClients = (Dictionary<String, List<Object>>)serializer.Deserialize(stream);
                return allClients;
            }
        }

        // Returns the list to the specified client, because normal getters are boring.
        public List<Object> readBikeData(String client)
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
        }

        public void changeClientStatus(Client client, String status)
        {
            if (status == "online")
            {
                onlineClients.Add(client);
            }
            if (status == "offline")
            {
                onlineClients.Remove(client);
            }
        }

        public void finalizeData()
        {
            using (FileStream stream = File.Open(clientFile, FileMode.Append))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, allClients);
            }
            using (FileStream stream = File.Open(logFileName, FileMode.Append))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, logs);
            }
        }
    }
}
