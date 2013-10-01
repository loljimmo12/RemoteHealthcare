using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Connection connect;
        public int selectedReciever;
        private System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
            connect = Program.connect;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timerElapse);
            timer.AutoReset = true;
            timer.Start();
        }

        private void timerElapse(Object source, System.Timers.ElapsedEventArgs args)
        {
            if (selectedReciever != null)
            {
                try
                {
                    connect.requestData(Program.clients[selectedReciever].getName());
                }
                catch
                {
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void toolTipSetDistance_Popup(object sender, PopupEventArgs e)
        {

        }

        

        private void textBoxSetPower_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                connect.sendMessage(textBox1.Text, this.listBox1.SelectedItem.ToString());
                Program.clients[selectedReciever].recieveChat(textBox1.Text, "Me");
                chatArea.Text = Program.clients[selectedReciever].getChat();
                if (chatArea.Text.Equals("GOLD")) {
                    textBox1.ResetText(); textBox1.Text = "Always believe in your soul ";
                }
                else textBox1.ResetText();
                
            }
        }

        private void buttonSetDistance_Click(object sender, EventArgs e)
        {
            if(textBoxSetDistance != null)
            {
                connect.sendCommand("PD"+textBoxSetDistance.Text);
            }
        }

        private void buttonSetEnergy_Click(object sender, EventArgs e)
        {
            if(textBoxSetEnergy != null)
            {
                connect.sendCommand("PE"+textBoxSetEnergy.Text);
            }
        
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxSetTime != null)
            {
                connect.sendCommand("PT"+textBoxSetTime.Text);
            }
        }

        private void buttonSetPower_Click(object sender, EventArgs e)
        {
            if(textBoxSetTime != null)
            {
                connect.sendCommand("PW" + comboBoxPower.Text);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            connect.sendCommand("RS");
            connect.requestUsers();
        }

        private void textBoxSetDistance_Click(object sender, EventArgs e)
        {
            textBoxSetDistance.Clear();
        }

        private void textBoxSetEnergy_Click(object sender, EventArgs e)
        {
            textBoxSetEnergy.Clear();
        }

        private void textBoxSetTime_Click(object sender, EventArgs e)
        {
            textBoxSetTime.Clear();
        }




        public void updateUsers(List<string> users)
        {
            foreach (String user in users)
            {

                if (!listBox1.Items.Contains(user))
                {
                    this.listBox1.Items.Add(user);
                    Program.clients.Add(new Client(user));
                }
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedReciever = this.listBox1.SelectedIndex;
            chatArea.Text = Program.clients[selectedReciever].getChat();
        }

        internal void setValues(Kettler_X7_Lib.Objects.ResponseValue vals)
        {
            if (vals.ValueList.Count > 0)
            {
                Kettler_X7_Lib.Objects.Value val = vals.ValueList[0];
                label1.Text = "Heartbeat " + val.Pulse;
                label2.Text = "RPM " + val.RPM;
                label3.Text = "Speed " + val.Speed;
                label4.Text = "Distance" + val.Distance;
                label5.Text = "Time" + val.Time;
                label6.Text = "Power " + val.RequestedPower;
                label7.Text = "Energy" + val.Energy;
            }
        }

        internal void refreshChat()
        {
            if (selectedReciever != null)
            {
                chatArea.Text = Program.clients[selectedReciever].getChat();
            }
        }
    }
}
