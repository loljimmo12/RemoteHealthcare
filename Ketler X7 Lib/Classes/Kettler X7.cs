using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Classes
{
    public class Kettler_X7
    {
        /// <summary>
        /// Event args for the KettlerX7ValuesParsed event
        /// </summary>
        public class ValuesParsedEventArgs : EventArgs
        {
            public Objects.Value Value { get; set; }
        }

        /// <summary>
        /// Enumeration of commands that can be send to the device
        /// </summary>
        public enum Command 
        {
            TAKE_CONTROL,
            INCREASE_ENERGYCOUNTER,
            OPEN_CALIBRRATION_MENU,
            RESET,
            LOCK_DEVICE,
            CHANGE_DISTANCE,
            CHANGE_ENERGY,
            CHANGE_TIME,
            CHANGE_FORCE,
            CHANGE_BRAKE_FORCE,
            RETURN_DEVICE_ID,
            RETURN_DEVICE_INFO,
            RETURN_SHOW_FILES,
            RETURN_CONFIGURATION,
            RETURN_CURRENT_VALUES,
            RETURN_CURRENT_DATETIME,
            RETURN_DEVICE_VERSION
        };

        /// <summary>
        /// The type of source
        /// </summary>
        public enum Source
        {
            SOURCE_SERIALPORT,
            SOURCE_SIMULATOR
        }

        /// <summary>
        /// The list of string commands that can be send to the server
        /// </summary>
        public static Dictionary<Command, String> COMMAND_LIST = new Dictionary<Command, string>() 
        {
            { Command.TAKE_CONTROL, "CM" },
            { Command.INCREASE_ENERGYCOUNTER, "EE" },
            { Command.OPEN_CALIBRRATION_MENU, "OP" },
            { Command.RESET, "RS" },
            { Command.LOCK_DEVICE, "LB" },
            { Command.CHANGE_DISTANCE, "PD " },
            { Command.CHANGE_ENERGY, "PE " },
            { Command.CHANGE_TIME, "PT " },
            { Command.CHANGE_FORCE, "PW " },
            { Command.CHANGE_BRAKE_FORCE, "VS " },
            { Command.RETURN_DEVICE_ID, "ID" },
            { Command.RETURN_DEVICE_INFO, "KI" },
            { Command.RETURN_SHOW_FILES, "RF " },
            { Command.RETURN_CONFIGURATION, "RD" },
            { Command.RETURN_CURRENT_VALUES, "ST" },
            { Command.RETURN_CURRENT_DATETIME, "TR" },
            { Command.RETURN_DEVICE_VERSION, "VE" },
        };

        /// <summary>
        /// The values parsed event
        /// </summary>
        public event onValuesParsed ValuesParsed;

        /// <summary>
        /// The delegate for the value parsed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void onValuesParsed(object sender, ValuesParsedEventArgs e);

        /// <summary>
        /// The object that is read from or written to, dependant on the source
        /// </summary>
        private object m_pHandler;

        /// <summary>
        /// The workerthread that receives the values, only used in case of serialport
        /// </summary>
        private System.Threading.Thread m_pWorkerThread;

        /// <summary>
        /// The source associated with this kettler class
        /// </summary>
        private Source m_nSource;

        /// <summary>
        /// Attempts to connect to the ketler at given port
        /// </summary>
        /// <param name="strPort">The serialport to which the device is connected (E.g. COM1)</param>
        /// <returns></returns>
        public bool connect(string strPort, string strIPAddress = null, int nPort = 0, Source nSource = Source.SOURCE_SERIALPORT)
        {
            m_nSource = nSource;

            try
            {
                switch (m_nSource)
                {
                    case Source.SOURCE_SERIALPORT:

                        m_pHandler = new System.IO.Ports.SerialPort(strPort);
                        ((System.IO.Ports.SerialPort)m_pHandler).Open();

                        break;
                    case Source.SOURCE_SIMULATOR:

                        m_pHandler = new Networking.Client();

                        if (!((Networking.Client)m_pHandler).connect(strIPAddress, nPort, false, Networking.Client.ClientType.CLIENTTYPE_STRING))
                        {

                            throw new Exception("Could not create TCP connection.");
                        }

                        ((Networking.Client)m_pHandler).DataReceived += Kettler_X7_DataReceived;

                        break;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Triggered when data from simulator is received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Kettler_X7_DataReceived(object sender, Networking.Server.DataReceivedEventArgs e)
        {
            Objects.Value pValue = parseValues(e.PacketData.ToString());

            if (pValue != null && ValuesParsed != null)
            {
                ValuesParsed(null, new ValuesParsedEventArgs()
                {
                    Value = pValue
                });
            }
        }

        /// <summary>
        /// Starts parsing values at given interval
        /// </summary>
        /// <param name="nInterval"></param>
        public void startParsingValues(int nInterval)
        {
            m_pWorkerThread = new System.Threading.Thread(workerThread);
            m_pWorkerThread.Start();
        }

        /// <summary>
        /// The workerthread
        /// </summary>
        private void workerThread()
        {
            while (true)
            {
                // Considering thread should not be started when serialport is not initialized
                Objects.Value pValue = parseValues(sendReturnCommand(Command.RETURN_CURRENT_VALUES));

                if (pValue != null && ValuesParsed != null)
                {
                    ValuesParsed(null, new ValuesParsedEventArgs()
                    {
                        Value = pValue
                    });
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Should be called on close, aborts workerthread and cleans resources
        /// </summary>
        public void onClose()
        {
            // Abort workerthread
            if (m_pWorkerThread != null && m_pWorkerThread.IsAlive)
            {
                m_pWorkerThread.Abort();
            }

            if (m_pHandler != null)
            {
                switch (m_nSource)
                {
                    case Source.SOURCE_SERIALPORT:

                        System.IO.Ports.SerialPort pSerialPort = (System.IO.Ports.SerialPort)m_pHandler;

                        if (pSerialPort.IsOpen)
                        {
                            pSerialPort.Close();
                        }

                        break;
                    case Source.SOURCE_SIMULATOR:

                        ((Networking.Client)m_pHandler).disconnect();

                        break;
                }
            }

            // Close serial port
            // TO DO :F ASIFJSAOIFJAOIJFSAOIJFSIAO J!
            /*if (m_pSerialPort != null && m_pSerialPort.IsOpen)
            {
                m_pSerialPort.Close();
            }*/
        }

        /// <summary>
        /// Attempts to send command to device
        /// </summary>
        /// <param name="nCommand">The command to execute</param>
        /// <param name="strValue">The value to send with the command, null if the command doesn't require one</param>
        /// <returns></returns>
        public bool sendCommand(Command nCommand, string strValue = null)
        {
            string strCommand = COMMAND_LIST[nCommand];

            if ((strValue == null || strValue == "") && strCommand[(strCommand.Length - 1)] == ' ')
            {
                // Command does require a value but a value was not set by caller function
                return false;
            }

            string strSendCommand = COMMAND_LIST[nCommand] + (strValue != null ? strValue : "");

            try
            {
                switch (m_nSource)
                {
                    case Source.SOURCE_SERIALPORT:

                        ((System.IO.Ports.SerialPort)m_pHandler).WriteLine(strSendCommand);

                        break;
                    case Source.SOURCE_SIMULATOR:

                        ((Networking.Client)m_pHandler).routeToServer(strSendCommand);

                        break;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to send command to device and return the result
        /// </summary>
        /// <param name="nCommand"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public string sendReturnCommand(Command nCommand, string strValue = null)
        {
            if (!nCommand.ToString().StartsWith("RETURN"))
            {
                // No return is required for this command
                return null;
            }

            if (!sendCommand(nCommand, strValue))
            {
                // Could not execute command
                return null;
            }

			// Return straight in case of serialport
			if (m_nSource == Source.SOURCE_SERIALPORT)
            {
				return ((System.IO.Ports.SerialPort)m_pHandler).ReadLine();
			}
			
			// Otherwise, nothing we can do
			return null;
        }

        /// <summary>
        /// Sends raw command to bike, result is not parsed
        /// </summary>
        /// <param name="strCommand"></param>
        public void sendRawCommand(string strCommand)
        {
            string strPreCommand = strCommand;

            // Strip pre command in case of arguments
            if (strCommand.Contains(' '))
            {
                strPreCommand = strCommand.Substring(0, (strCommand.IndexOf(' ') + 1));
            }

            Command nCommand = COMMAND_LIST.FirstOrDefault(x => (x.Value == strPreCommand)).Key;
        }

        public void SendShit(string henk)
        {
            try
            {
                ((System.IO.Ports.SerialPort)m_pHandler).WriteLine(henk);
            }
            catch
            {
                // Return straight in case of serialport
                if (m_nSource == Source.SOURCE_SERIALPORT)
                {
                    ((System.IO.Ports.SerialPort)m_pHandler).ReadLine();
                }
            }
        }

        /// <summary>
        /// Parses the current values of the device into an object
        /// </summary>
        /// <returns></returns>
        public Objects.Value parseValues(string strValues)
        {
            if (strValues == null)
            {
                return null;
            }

            string[] rgstrValues = strValues.Split(new string[] { "	" }, StringSplitOptions.None);

            if (rgstrValues.Length != 8)
            {
                return null;
            }

            string[] rgstrTime = rgstrValues[6].Split(':');

            if (rgstrTime.Length != 2)
            {
                return null;
            }

            int nMinutes = Convert.ToInt32(rgstrTime[0]), nSeconds = Convert.ToInt32(rgstrTime[1]);

            // Let's go
            return new Objects.Value()
            {
                Pulse = Convert.ToUInt32(rgstrValues[0]),
                RPM = Convert.ToUInt32(rgstrValues[1]),
                Speed = Convert.ToUInt32(rgstrValues[2]),
                Distance = Convert.ToUInt32(rgstrValues[3]),
                RequestedPower = Convert.ToUInt32(rgstrValues[4]),
                Energy = Convert.ToUInt32(rgstrValues[5]),
                Time = new TimeSpan((nMinutes / 60), (nMinutes % 60), nSeconds),
                ActualPower = Convert.ToUInt32(rgstrValues[7])
            };
        }
    }
}
