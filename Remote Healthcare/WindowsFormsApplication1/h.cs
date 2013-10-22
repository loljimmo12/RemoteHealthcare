using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class h : Form
    {
        Dictionary<Dictionary<Kettler_X7_Lib.Objects.Value, int>,int> valuesListList = new Dictionary<Dictionary<Kettler_X7_Lib.Objects.Value,int>,int>();
        ArrayList array = new ArrayList();
        int selectedIndex;
        int itemsCount;
 
        public h()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBoxHHEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHHBegin_Enter(object sender, EventArgs e)
        {
            if (textBoxHHBegin.Text.Equals("HH")) textBoxHHBegin.Text = "";
        }

        private void textBoxHHEnd_Enter(object sender, EventArgs e)
        {
            if (textBoxHHEnd.Text.Equals("HH")) textBoxHHEnd.Text = "";
        }

        private void textBoxMMBegin_Enter(object sender, EventArgs e)
        {
            if (textBoxMMBegin.Text.Equals("MM")) textBoxMMBegin.Text = "";
        }

        private void textBoxMMEnd_Enter(object sender, EventArgs e)
        {
            if (textBoxMMEnd.Text.Equals("MM")) textBoxMMEnd.Text = "";
        }

        private void textBoxSSBegin_Enter(object sender, EventArgs e)
        {
            if (textBoxSSBegin.Text.Equals("SS")) textBoxSSBegin.Text = "";
        }

        private void textBoxSSEnd_Enter(object sender, EventArgs e)
        {
            if (textBoxSSEnd.Text.Equals("SS")) textBoxSSEnd.Text = ""; } 

        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime firstDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, Convert.ToInt32(textBoxHHBegin.Text), Convert.ToInt32(textBoxMMBegin.Text), Convert.ToInt32(textBoxSSBegin.Text));
                DateTime secondDate = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, Convert.ToInt32(textBoxHHEnd.Text), Convert.ToInt32(textBoxMMEnd.Text), Convert.ToInt32(textBoxSSEnd.Text));
                conn.requestData(user, firstDate, secondDate);
                clearComboBoxes();
            }
            catch
            {
                MessageBox.Show("Not all fields are correct, please correct your values and try again.", "Please think", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void handleDataSet(List<Kettler_X7_Lib.Objects.Value> list)
        {
            Kettler_X7_Lib.Objects.Value oldValue = list[0];
            if (oldValue == null) oldValue = list[1];
            int iTotal = 0;
            int iSession = 0;
            clearComboBoxes();
            array.Clear();
            valuesListList.Clear();
            foreach (Kettler_X7_Lib.Objects.Value value in list)
            {
                if (value != null && value.Time != null)
                {
                    //Used to split the sessions into different sections
                    Console.WriteLine(value.Time.TotalSeconds);
                    Console.WriteLine(oldValue.Time.TotalSeconds);
                    if (value.Time.TotalSeconds-oldValue.Time.TotalSeconds<0 || iSession == 0)
                    {
                        // Adds the section to the comboBox for sections
                        ++iSession;
                        comboBoxSelectSection.Items.Add("Session: " + iSession);
                        iTotal = 0;
                        //comboBoxSelectSection.Refresh();
                    }
                    ++iTotal;

                    // Adds the value to the Dictionary
                    Dictionary<Kettler_X7_Lib.Objects.Value, int> valueAndIndex = new Dictionary<Kettler_X7_Lib.Objects.Value, int>();
                    valueAndIndex.Add(value, iTotal);
                    valuesListList.Add(valueAndIndex, iSession);
                    oldValue = value;
                }
            }


        }

        public string user { get; set; }

        internal Connection conn { get; set; }

        internal void init(string p, Connection connect)
        {
            this.user = p;
            this.conn = connect;
        }

        private void comboBoxSelectSection_SelectedIndexChanged(object sender, EventArgs e)
        {
	// This happens when the combobox is changed to a value
	// Adds the values to the forms arraylist, to be more easy to use
            
            clearSelectTime();
            array.Clear();
            foreach(KeyValuePair<Dictionary<Kettler_X7_Lib.Objects.Value, int>, int> dic in valuesListList)
            {
                string sessionNumber = "";
                if (true != comboBoxSelectSection.SelectedItem.Equals(""))
                {
                    
                        sessionNumber = comboBoxSelectSection.SelectedItem.ToString().Substring(comboBoxSelectSection.SelectedItem.ToString().Length - 1, 1);


                        if (dic.Value == int.Parse(sessionNumber))
                        {
                            foreach (Kettler_X7_Lib.Objects.Value vla in dic.Key.Keys)
                            {
                                array.Add(vla);
                            }
                        }
                    
                }
            }
            foreach(Kettler_X7_Lib.Objects.Value valu in array)
            {
                comboBoxSelectTime.Items.Add(valu.Time);
                
            }
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            foreach (Kettler_X7_Lib.Objects.Value valuee in array)
            {
                chart1.Series["Heartbeat"].Points.AddXY(valuee.Time.TotalSeconds, valuee.Pulse);
            }

        }

        private void comboBoxSelectTime_SelectedIndexChanged(object sender, EventArgs e)
        {
	// Loads the requested value in the labels when selecting a value using the comboBox
            foreach (Kettler_X7_Lib.Objects.Value valu in array)
            {
                    if (valu.Time.Equals(comboBoxSelectTime.SelectedItem))
                    {
                        labelSpeed.Text = "Speed " + valu.Speed;
                        labelHeartBeat.Text = "Heartbeat " + valu.Pulse.ToString();
                        labelRPM.Text = "RPM " + valu.RPM;
                        labelDistance.Text = "Distance " + valu.Distance;
                        labelTime.Text = "Time " + valu.Time;
                        labelPower.Text = "Power " + valu.RequestedPower;
                        labelEnergy.Text = "Energy " + valu.Energy;
                        break;
                    }
                
            }
        }

        private void buttonPlay_MouseDown(object sender, MouseEventArgs e)
        {
            selectedIndex = comboBoxSelectTime.SelectedIndex;
            itemsCount = comboBoxSelectTime.Items.Count;
            Thread play = new Thread(playData);

            play.Start();

        }

        public void playData()
        {

            while (selectedIndex + 1 < itemsCount)
            {
              
                    if (Program.form3.InvokeRequired)
                    {
                        try
                        {
                            Program.form3.Invoke(new Action(() => ++comboBoxSelectTime.SelectedIndex));
                        }
                        catch { }
                        ++selectedIndex;
                    } 
                    System.Threading.Thread.Sleep(60);
                    
            }
        }

        private void clearComboBoxes()
        {
            clearSelectTime();
            clearSelectSection();
        }

        private void clearSelectTime()
        {
            comboBoxSelectTime.Items.Clear();
            array.Clear();
        }

        private void clearSelectSection()
        {
            comboBoxSelectSection.Items.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearComboBoxes();
        }
    }
}

