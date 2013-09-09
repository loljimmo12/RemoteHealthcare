using System;
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
        private Ketler_X7_Lib.Classes.Ketler_X7 m_pKetlerX7;
        private List<Ketler_X7_Lib.Objects.Value> m_pValueList;

        public Form1()
        {
            m_pValueList = new List<Ketler_X7_Lib.Objects.Value>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_pKetlerX7 = new Ketler_X7_Lib.Classes.Ketler_X7();
            m_pKetlerX7.connect("COM14");
            m_pKetlerX7.startParsingValues(1000);

            m_pKetlerX7.ValuesParsed += pKetlerX7_ValuesParsed;
        }

        void pKetlerX7_ValuesParsed(object sender, Ketler_X7_Lib.Classes.Ketler_X7.ValuesParsedEventArgs e)
        {
            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblPulseValue, delegate
            {
                lblPulseValue.Text = e.Value.Pulse.ToString();
            });

            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblRPMValue, delegate
            {
                lblRPMValue.Text = e.Value.RPM.ToString();
            });

            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblSpeedValue, delegate
            {
                lblSpeedValue.Text = (e.Value.Speed / 10) + " km/h";
            });

            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblDistanceValue, delegate
            {
                lblDistanceValue.Text = (e.Value.Distance * 100) + " meter";
            });

            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblReqPowerValue, delegate
            {
                lblReqPowerValue.Text = e.Value.RequestedPower.ToString();
            });

            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblActPowerValue, delegate
            {
                lblActPowerValue.Text = e.Value.ActualPower.ToString();
            });

            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblEnergyValue, delegate
            {
                lblEnergyValue.Text = e.Value.Energy + " Kj";
            });

            Ketler_X7_Lib.Classes.GUI.safelyUpdateControl(lblTimeValue, delegate
            {
                lblTimeValue.Text = e.Value.Time.ToString();
            });

            /*lock (m_pValueList)
            {
                m_pValueList.Add(e.Value);

                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter pBinaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                using (System.IO.StreamWriter pStreamWriter = new System.IO.StreamWriter("data.dat", false))
                {
                    try
                    {
                        pBinaryFormatter.Serialize(pStreamWriter.BaseStream, m_pValueList);
                    }
                    catch
                    {
                    }
                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_pKetlerX7.sendCommand(Ketler_X7_Lib.Classes.Ketler_X7.Command.TAKE_CONTROL);
            m_pKetlerX7.sendCommand(Ketler_X7_Lib.Classes.Ketler_X7.Command.CHANGE_FORCE, textBox1.Text);
        }
    }
}
