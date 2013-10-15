﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_App
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The kettler input device class
        /// </summary>
        private Kettler_X7_Lib.Classes.Kettler_X7 m_pKettlerX7;

        /// <summary>
        /// The networking client that connects to the server
        /// </summary>
        private Kettler_X7_Lib.Networking.Client m_pNetworkClient;

        /// <summary>
        /// The list of values that were received from the bike
        /// </summary>
        private List<Kettler_X7_Lib.Objects.Value> m_pValueList;

        /// <summary>
        /// The data class used for saving and receiving data from the server
        /// </summary>
        private Classes.Data m_pData;

        /// <summary>
        /// Whether or not the easter egg is enabled
        /// </summary>
        private bool m_bEasterEggEnabled;

        public Form1()
        {
            InitializeComponent();

            // Initialize stuff
            m_pValueList = new List<Kettler_X7_Lib.Objects.Value>();
            m_pKettlerX7 = new Kettler_X7_Lib.Classes.Kettler_X7();
            m_pNetworkClient = new Kettler_X7_Lib.Networking.Client();
            m_pData = new Classes.Data(m_pNetworkClient);
            m_bEasterEggEnabled = true;
        }

        /// <summary>
        /// Returns the networking client
        /// </summary>
        /// <returns></returns>
        public Kettler_X7_Lib.Networking.Client getClient()
        {
            return m_pNetworkClient;
        }

        /// <summary>
        /// Adds message to chatbox
        /// </summary>
        /// <param name="strPrefix"></param>
        /// <param name="strMessage"></param>
        private void addToChat(string strPrefix, string strMessage)
        {
            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(txtChat, delegate
            {
                txtChat.AppendText("[" + DateTime.Now + "] " + strPrefix  + ": " + strMessage + Environment.NewLine);
            });
        }

        /// <summary>
        /// On form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Attempt to load Server IP from file
            string strServerIP = null;

            try
            {
                strServerIP = System.IO.File.ReadAllText("ServerIP.txt");
            }
            catch
            {
            }

            if (strServerIP == null)
            {
                strServerIP = Kettler_X7_Lib.Classes.Global.TCPSERVER_IP;
            }

            // Initialize networking client
            if (!m_pNetworkClient.connect(strServerIP, Kettler_X7_Lib.Classes.Global.TCPSERVER_PORT, false))
            {
                Kettler_X7_Lib.Classes.GUI.throwError("Kan geen verbinding met de server maken!");
            }
            else
            {
                m_pNetworkClient.authenticate(Kettler_X7_Lib.Objects.Client.ClientFlag.CLIENTFLAG_CUSTOMERAPP, Kettler_X7_Lib.Classes.Global.CLIENT_NAME, null);
                m_pNetworkClient.DataReceived += m_pNetworkClient_DataReceived;
            }

            // Initialize bike
            bool bConnected = false;
            
            if (!m_pKettlerX7.connect("COM11"))
            {
                Kettler_X7_Lib.Classes.GUI.throwError("Kan geen verbinding met de fiets maken!");

                /*if (!m_pKettlerX7.connect(null, Kettler_X7_Lib.Classes.Global.SIMULATOR_IP, Kettler_X7_Lib.Classes.Global.SIMULATOR_PORT, Kettler_X7_Lib.Classes.Kettler_X7.Source.SOURCE_SIMULATOR))
                {
                    Kettler_X7_Lib.Classes.GUI.throwError("Kan geen verbinding met de simulatie fiets maken!");
                }
                else
                {
                    bConnected = true;
                }*/
            }
            else
            {
                bConnected = true;
            }

            if (bConnected)
            {
                m_pKettlerX7.startParsingValues(1000);
                m_pKettlerX7.ValuesParsed += pKetlerX7_ValuesParsed;
            }
        }

        /// <summary>
        /// On data received rom server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_pNetworkClient_DataReceived(object sender, Kettler_X7_Lib.Networking.Server.DataReceivedEventArgs e)
        {
            Kettler_X7_Lib.Objects.Packet pPacket = ((Kettler_X7_Lib.Objects.Packet)e.PacketData);

            switch (pPacket.Flag)
            {
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_RESPONSE_HANDSHAKE:

                    System.Diagnostics.Debug.WriteLine(((Kettler_X7_Lib.Objects.ResponseHandshake)pPacket.Data).Result + " as a response to our handshake");

                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_BIKECONTROL:

                    m_pKettlerX7.sendRawCommand(((Kettler_X7_Lib.Objects.BikeControl)pPacket.Data).Command);

                    break;
                case Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT:

                    string strMessage = ((Kettler_X7_Lib.Objects.ChatMessage)pPacket.Data).Message;
                    addToChat("Dokter", strMessage);

                    if (m_bEasterEggEnabled)
                    {
                        Kettler_X7_Lib.Classes.Speech.textToSpeech(strMessage);
                    }

                    break;
            }
        }

        /// <summary>
        /// On values from bike or simulator parsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pKetlerX7_ValuesParsed(object sender, Kettler_X7_Lib.Classes.Kettler_X7.ValuesParsedEventArgs e)
        {
            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblPulseValue, delegate
            {
                lblPulseValue.Text = e.Value.Pulse.ToString();
            });

            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblRPMValue, delegate
            {
                lblRPMValue.Text = e.Value.RPM.ToString();
            });

            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblSpeedValue, delegate
            {
                lblSpeedValue.Text = (e.Value.Speed / 10) + " km/h";
            });

            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblDistanceValue, delegate
            {
                lblDistanceValue.Text = ((double)e.Value.Distance / 10) + " kilometer";
            });

            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblReqPowerValue, delegate
            {
                lblReqPowerValue.Text = e.Value.RequestedPower.ToString();
            });

            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblActPowerValue, delegate
            {
                lblActPowerValue.Text = e.Value.ActualPower.ToString();
            });

            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblEnergyValue, delegate
            {
                lblEnergyValue.Text = e.Value.Energy + " Kj";
            });

            Kettler_X7_Lib.Classes.GUI.safelyUpdateControl(lblTimeValue, delegate
            {
                lblTimeValue.Text = e.Value.Time.ToString();
            });

            // Set client name
            e.Value.Client = Kettler_X7_Lib.Classes.Global.CLIENT_NAME;

            // Route data to server
            if (!testing)
            {
                m_pNetworkClient.routeToServer(new Kettler_X7_Lib.Objects.Packet()
                {
                    Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_VALUES,
                    Data = e.Value
                });
            }
            else
            {
                if (TestingValues == null) { TestingValues = new List<Kettler_X7_Lib.Objects.Value>(); }
                TestingValues.Add(e.Value);
            }

            //m_pData.addData(e.Value);
        }
        
        /// <summary>
        /// When this form is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_pKettlerX7.onClose();
            m_pNetworkClient.disconnect();
        }

        /// <summary>
        /// Sends chat message to server
        /// </summary>
        private void sendChatMessage()
        {
            if (txtChatMessage.TextLength < 1)
            {
                return;
            }

            m_pNetworkClient.routeToServer(new Kettler_X7_Lib.Objects.Packet()
            {
                Flag = Kettler_X7_Lib.Objects.Packet.PacketFlag.PACKETFLAG_CHAT,
                Data = new Kettler_X7_Lib.Objects.ChatMessage()
                {
                    Sender = Kettler_X7_Lib.Classes.Global.CLIENT_NAME,
                    Message = txtChatMessage.Text
                }
            });

            addToChat("Jijzelf", txtChatMessage.Text);
            txtChatMessage.Text = "";
            txtChatMessage.Focus();
        }

        /// <summary>
        /// Triggered when user wants to send a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            sendChatMessage();
        }

        /// <summary>
        /// Keydown event at chat textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChatMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendChatMessage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testing = true;
        }

        public bool testing { get; set; }

        public List<Kettler_X7_Lib.Objects.Value> TestingValues { get; set; }
    }
}
