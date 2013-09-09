﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketler_X7_Lib.Classes
{
    public class Ketler_X7
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
        /// The serial port the Ketler is connected to
        /// </summary>
        private System.IO.Ports.SerialPort m_pSerialPort;

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
        /// The workerthread that receives the values
        /// </summary>
        private System.Threading.Thread m_pWorkerThread;

        /// <summary>
        /// Attempts to connect to the ketler at given port
        /// </summary>
        /// <param name="strPort">The serialport to which the device is connected (E.g. COM1)</param>
        /// <returns></returns>
        public bool connect(string strPort)
        {
            m_pSerialPort = new System.IO.Ports.SerialPort(strPort);

            try
            {
                m_pSerialPort.Open();
            }
            catch
            {
                return false;
            }

            return true;
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
                Objects.Value pValue = parseValues();

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

            try
            {
                m_pSerialPort.WriteLine(COMMAND_LIST[nCommand] + (strValue != null ? strValue : ""));
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
        /// <param name="nCommand">The command to execute</param>
        /// <returns>null on failure</returns>
        public string sendReturnCommand(Command nCommand)
        {
            if (!nCommand.ToString().StartsWith("RETURN"))
            {
                // No return is required for this command
                return null;
            }

            if (!sendCommand(nCommand))
            {
                // Could not execute command
                return null;
            }

            return m_pSerialPort.ReadLine();
        }

        /// <summary>
        /// Parses the current values of the device into an object
        /// </summary>
        /// <returns></returns>
        public Objects.Value parseValues()
        {
            string strValues = sendReturnCommand(Command.RETURN_CURRENT_VALUES);

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
