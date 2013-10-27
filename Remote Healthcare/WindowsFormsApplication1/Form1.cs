using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<int> heartBeat = new List<int>();

        public enum TestStates
        {
            STOPPED,
            WARMINGUP,
            TESTING,
            COOLINGDOWN
        }
        
        public Form1()
        {
            InitializeComponent();
            connect = Program.connect;
            comboBoxSelectReciever.SelectedIndex = 0;
            comboBoxPower.SelectedIndex = 0;
            astrandGewicht = new Dictionary<int, int> { {80, 80} };
            astrandLeeftijd.Add(15, 1.10);
            astrandLeeftijd.Add(20, 1.05);
            astrandLeeftijd.Add(25, 1.0);
            astrandLeeftijd.Add(30, 0.94);
            astrandLeeftijd.Add(35, 0.87);
            astrandLeeftijd.Add(40, 0.83); 
            astrandLeeftijd.Add(45, 0.78);
            astrandLeeftijd.Add(50, 0.75);
            astrandLeeftijd.Add(55, 0.71); 
            astrandLeeftijd.Add(60, 0.68);
            astrandLeeftijd.Add(65, 0.65);
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
            if ((listBox1.SelectedIndex >= 0 && e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Enter && comboBoxSelectReciever.SelectedIndex == 1))

            {
                if (comboBoxSelectReciever.SelectedIndex == 1)
                {
                    connect.sendMessage(textBox1.Text, "ALL");
                    chatArea.Text += "[" + DateTime.Now.ToShortTimeString() + "] Me (to all): " + textBox1.Text + "\n";
                    foreach (Client client in Program.clients)
                    {
                        client.recieveChat(textBox1.Text, "Me ( to all )");
                    //nee
                    }
                    textBox1.Text = "";
                }
                else 
                { 
                    connect.sendMessage(textBox1.Text, this.listBox1.SelectedItem.ToString());
                    Program.clients[selectedReciever].recieveChat(textBox1.Text, "Me");
                    chatArea.Text = Program.clients[selectedReciever].getChat();
                    textBox1.Text = "";
                }
                
                
                
            }
        }

        private void buttonSetDistance_Click(object sender, EventArgs e)
        {
            if(textBoxSetDistance != null)
            {
                connect.sendCommand("PD" + textBoxSetDistance.Text, this.listBox1.SelectedItem.ToString());
            }
        }

        private void buttonSetEnergy_Click(object sender, EventArgs e)
        {
            if(textBoxSetEnergy != null)
            {
                connect.sendCommand("PE" + textBoxSetEnergy.Text, this.listBox1.SelectedItem.ToString());
            }
        
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxSetTime != null)
            {
                connect.sendCommand("PT" + textBoxSetTime.Text, this.listBox1.SelectedItem.ToString());
            }
        }

        private void buttonSetPower_Click(object sender, EventArgs e)
        {
            if(textBoxSetTime != null)
            {
                connect.sendCommand("PW " + comboBoxPower.Text.Split(' ')[0], this.listBox1.SelectedItem.ToString());
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            connect.sendCommand("RS", this.listBox1.SelectedItem.ToString());
            clientChart.Series["Heartbeat"].Points.Clear();
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
            List<Client> clients = new List<Client>();
            foreach (Client client in Program.clients)
            {
                if (!users.Contains(client.getName()))
                {
                    this.listBox1.Items.Remove(client.getName());
                    clients.Add(client);
                }
            }

            foreach (String user in users)
            {
                
                if (!listBox1.Items.Contains(user))
                {
                    this.listBox1.Items.Add(user);
                    Program.clients.Add(new Client(user));
                }

            }
            foreach (Client client in clients)
            {
                Program.clients.Remove(client);
            } 
           
            
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            selectedReciever = this.listBox1.SelectedIndex;
            if (selectedReciever < Program.clients.Count() && selectedReciever != -1)
            {
                chatArea.Text = Program.clients[selectedReciever].getChat();
                astrandClient = Program.clients[selectedReciever];
            }
            else
            {
                this.listBox1.SelectedIndex = -1;
                selectedReciever = -1;
                //chatArea.Text = Program.clients[selectedReciever].getChat();
            }
        }

        internal void setValues(Kettler_X7_Lib.Objects.Value val)
        {
            if (val != null)
            {
                //Debug.WriteLine(val.Pulse);
                label1.Text = "Heartbeat " + val.Pulse;
                label2.Text = "RPM " + val.RPM;
                label3.Text = "Speed " + val.Speed/10.0;
                label4.Text = "Distance " + val.Distance/10.0;
                label5.Text = "Time " + val.Time;
                label6.Text = "Power " + val.RequestedPower;
                label7.Text = "Energy " + val.Energy;
                clientChart.Series["Heartbeat"].Points.AddXY(val.Time.TotalSeconds, val.Pulse);
                if (astrandClient.astrandRunning && val.Pulse >= 120 && val.Pulse <= 170 && !buttonTestBegin.Enabled)
                {
                    buttonTestBegin.Enabled = true;
                    buttonTestBegin.Text = "Finish warmup";
                    labelTestClientStatus.Text = "Click on the \"Finish warmup\" button \n to continue to the main test";

                }
                else if (astrandClient.astrandRunning && (val.Pulse < 120 || val.Pulse > 170))
                {
                    labelTestClientStatus.Text = "Pulse is too high or too low,\ncannot finish warmup";
                    if (buttonTestBegin.Enabled) buttonTestBegin.Enabled = false;
                }
            }
        }

        internal void refreshChat()
        {
            if (selectedReciever != null)
            {
                chatArea.Text = Program.clients[selectedReciever].getChat();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        internal void updateVals()
        {
            if (selectedReciever != -1)
            {
                try
                {
                    setValues(Program.clients[selectedReciever].getVal());
                }
                catch { }
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connect.sendCommand("CM", this.listBox1.SelectedItem.ToString());
        }

        private void buttonLoadOldData_Click(object sender, EventArgs e)
        {
            Program.form3.Show();
            if (Program.form3.InvokeRequired)
            {
                Program.form3.Invoke(new Action(() => Program.form3.init(listBox1.SelectedItem.ToString(), connect)));
            }
            else
            {
                try
                {
                    Program.form3.init(listBox1.SelectedItem.ToString(), connect);
                }
                catch
                {
                    MessageBox.Show("Please select an user before requesting old data.", "No selected user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void buttonLock_Click(object sender, EventArgs e)
        {
            connect.sendCommand("LB", this.listBox1.SelectedItem.ToString());
        }

        private void buttonStartTest_Click(object sender, EventArgs e)
        {
            groupBoxRealContent.Visible = !groupBoxRealContent.Visible;
            if (astrandClient.astrandRunning) toggleAstrand(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonTestBegin_Click(object sender, EventArgs e)
        {
            if (astrandClient.testState == TestStates.WARMINGUP)
            {
                astrandClient.testState = TestStates.TESTING;
                progressBarTest.Value = 33;
                buttonTestBegin.Enabled = false;
                buttonTestBegin.Text = "Start Åstrand test";
                astrandMainTest();
            }
            toggleAstrand();
            
        }

        private void toggleAstrand(bool nood=false)
        {
            //TODO add imposibility to start test when the 3 client values are not entered correctly
            if (!astrandClient.astrandRunning)
            {
                astrandClient.astrandRunning = true;
                buttonTestBegin.Enabled = false;
                textBoxTestClientAge.Enabled = false;
                textBoxTestClientWeight.Enabled = false;
                labelTestClientStatus.Text = "Warming up is bezig";
                buttonTestNoodstop.Visible = true;
                connect.sendCommand("RS", astrandClient.getName());
                System.Threading.Thread.Sleep(2000); //Wait for bike to reboot
                connect.sendCommand("CM", astrandClient.getName());
                astrandClient.testState = TestStates.WARMINGUP;
            }
            else if (astrandClient.astrandRunning && nood)
            {
                astrandClient.astrandRunning = false;
                buttonTestBegin.Enabled = true;
                textBoxTestClientAge.Enabled = true;
                textBoxTestClientWeight.Enabled = true;
                labelTestClientStatus.Text = "Åstrand test is geannuleerd";
                buttonTestNoodstop.Visible = false;
                connect.sendCommand("RS", astrandClient.getName());
                astrandClient.testState = TestStates.STOPPED;
            }

        }

        private void astrandMainTest()
        {
            
            double tempValueVO2Max = 0;
            double VO2max = 0;
            int age = 25;
            double ageCorrection = 0.0;

            //TODO <IMPORTANT> warning for Doctor AND Client when client's RMP drops below 57 or above 63!! 
            labelTestClientStatusTitle.Text = "Åstrand test in progress.\n Client is cycling with a RPM of 60.";
            DateTime beginTestTijd = DateTime.Now;
            startAstrandTestTimer();
            if (DateTime.Now <= beginTestTijd.AddMinutes(6))
            {
                eindPulse = Convert.ToInt32(astrandClient.getVal().Pulse);
                workload = (float) (astrandClient.getVal().RequestedPower * 6.12);
                age = calculateUsableAge(Convert.ToInt32(textBoxTestClientAge.Text));
                foreach(KeyValuePair<int,double> cor in astrandLeeftijd)
                {
                    if (cor.Key==age)
                    {
                        ageCorrection = cor.Value;
                        break;
                    }
                }
                double HRss = heartBeat.Average();
                astrandClient.testState = TestStates.COOLINGDOWN;
                labelTestClientStatusTitle.Text = "Åstrand is completed. Client is cooling down.";
                if(comboBox1.SelectedValue.ToString().Equals("Vrouw") )tempValueVO2Max = (0.00193 * workload + 0.326) / (0.769 * HRss - 56.1) * 100;
                else if (comboBox1.SelectedValue.ToString().Equals("Man")) tempValueVO2Max = (0.00212 * workload + 0.299) / (0.769 * HRss - 48.5) * 100;
                VO2max = (tempValueVO2Max * ageCorrection * 1000)/Convert.ToInt32(textBoxTestClientWeight.Text);
                astrandClient.VO2Max = Math.Round(VO2max*10)/10;
            }
        }
        Timer astrandTestTimer;
        private void startAstrandTestTimer()
        {
            astrandTestTimer = new Timer();
            astrandTestTimer.Tick += new EventHandler(astrandTestTimer_Tick);
            astrandTestTimer.Interval = 1000;
            astrandTestTimer.Start();
        }
        internal Dictionary<int, double> astrandLeeftijd;
        internal Client astrandClient { get; set; }
        public int eindPulse { get; set; }
        
        private void buttonTestEmergencyBreak_Click(object sender, EventArgs e)
        {
            connect.sendCommand("RS", astrandClient.getName());
			System.Threading.Thread.Sleep(20); // waiting so the connection doesn't spam packets.
			connect.sendCommand("CM", astrandClient.getName());
			System.Threading.Thread.Sleep(20);
			connect.sendCommand("PW 25", astrandClient.getName());
			System.Threading.Thread.Sleep(20);
			connect.sendMessage("===============",astrandClient.getName());
			System.Threading.Thread.Sleep(20);
			connect.sendMessage("EMERGENCY BREAK",astrandClient.getName());
			System.Threading.Thread.Sleep(20);
			connect.sendMessage("===============",astrandClient.getName());
			System.Threading.Thread.Sleep(20);
        }

        private int calculateUsableAge(int age)
        {
            if (age >= 65)
            {
                return 65;
            }
            else if (age % 5 == 0)
            {
                return age;
            }
            else if (age % 5 != 0)
            {
                return calculateUsableAge(++age);
            }
            else return 25;
        }

        public float workload { get; set; }

        public int timerCount { get; set; }
            private void astrandTestTimer_Tick(object sender, EventArgs e)
            {
                heartBeat.Add(Convert.ToInt32(astrandClient.getVal().Pulse));
                ++timerCount;
                if (timerCount == 6) astrandTestTimer.Stop();
            }
    }

}
