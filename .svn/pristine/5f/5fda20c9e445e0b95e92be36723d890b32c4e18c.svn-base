using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_App.Classes
{
    class Data
    {
        private List<Kettler_X7_Lib.Objects.Value> valueList;
        private Kettler_X7_Lib.Networking.Client client;

        public Data()
        {
            valueList = new List<Kettler_X7_Lib.Objects.Value>();
            client = ((Form1)System.Windows.Forms.Application.OpenForms[0]).getClient();
            client.DataReceived += client_DataReceived;
        }

        void client_DataReceived(object sender, Kettler_X7_Lib.Networking.Server.DataReceivedEventArgs e)
        {
            if (((Kettler_X7_Lib.Objects.Packet)e.PacketData).Flag == Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES)
            {
                valueList = (List<Kettler_X7_Lib.Objects.Value>)((Kettler_X7_Lib.Objects.Packet)e.PacketData).Data;
            }
        }

        public void addData(Kettler_X7_Lib.Objects.Value newValue)
        {
            lock (valueList)
            {
                valueList.Add(newValue);
            }
        }

        public void sendData()
        {
            client.routeToServer(new Kettler_X7_Lib.Objects.Packet()
            {
                Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES,
                Data = valueList
            });
        }
    }
}
