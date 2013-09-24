using Server.Control;
using Server.Model;
using Server.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    ///<summary>
    ///The base class for the Model.
    ///</summary>
    class ServerModel
    {
        private static String logFileName = "logData.bin";
        private static String clientFile  = "clientFile.bin";
        public List<Client> onlineClients { get; set; }
        public List<DoctorCredentials> doctors { get; set; }
        List<Log> logs { get; set; }
        Dictionary<string, Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value>> allClients { get; set; }

        ///<summary>
        ///initalization of a Model object.
        ///</summary>
        public ServerModel()
        {
            onlineClients = new List<Client>();

            if (File.Exists(clientFile))
            {
                allClients = readAllClientData();
            }
            else
            {
                allClients = new Dictionary<string, Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value>>();
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
        ///<summary>
        ///Writes the data from a Value into the Dictionary
        ///</summary>
        public void writeBikeData(Client client, Kettler_X7_Lib.Objects.Value values)
        {
            if (allClients.ContainsKey(client.userName))
            {
                allClients[client.userName].Add(System.DateTime.Now, values);
            }
            else
            {
                Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value> clientData = new Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value>();
                clientData.Add(System.DateTime.Now, values);                
                allClients.Add(client.userName, clientData);
            }
        }

        ///<summary>
        ///Reads the field containing all client data and returns the Dictionary.
        ///<summary>
        public Dictionary<String, Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value>> readAllClientData()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(clientFile))
            {
                Dictionary<String, Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value>> allClients = (Dictionary<String, Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value>>)serializer.Deserialize(stream);
                return allClients;
            }
        }

        ///<summary>
        ///Returns the list to the specified client, because normal getters are boring.
        ///</summary>
        public List<Kettler_X7_Lib.Objects.Value> readBikeData(Client client)
        {
            Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value> allClientData = allClients[client.userName];
            return allClientData.Values.ToList<Kettler_X7_Lib.Objects.Value>();
        }

        /// <summary>
        ///Returns the requested datalist, between begintime and endtime for 1 specific client
        /// </summary>
        public List<Kettler_X7_Lib.Objects.Value> readSpecifiedBikeData(String clientUsername, System.DateTime beginTime, System.DateTime endTime)
        {
            Dictionary<System.DateTime, Kettler_X7_Lib.Objects.Value> dataDict = allClients[clientUsername];
            List<Kettler_X7_Lib.Objects.Value> dataList = null;
          
            foreach(KeyValuePair<System.DateTime, Kettler_X7_Lib.Objects.Value> entry in dataDict)
            {
                if (entry.Key.CompareTo(beginTime) >= 0 && entry.Key.CompareTo(endTime) <= 0)
                {
                    dataList.Add(entry.Value);
                }
            }
            return dataList;
        }

        ///<summary>
        ///Reads the logFile and puts the data in the List.
        ///returns the created List.
        ///</summary>
        private List<Log> readLogData()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(logFileName))
            {
                List<Log> logData = (List<Log>)serializer.Deserialize(stream);
                return logData;
            }
        }

        ///<summary>
        ///The method to add a single Log object to the List.
        ///The old logFile will be overwritten with the new List.
        ///</summary>
        public void saveLog(Log log)
        {
            logs.Add(log);
        }

        ///<summary>
        ///Adds online or removes offline clients form onlineClients list. 
        ///</summary>
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
            ServerView.writeToConsole("Online clients in list: " + onlineClients.Count);
            
        }

        ///<summary>
        ///
        ///</summary>
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
