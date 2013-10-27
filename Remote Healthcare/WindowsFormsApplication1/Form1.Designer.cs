namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clientChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chatArea = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSetDistance = new System.Windows.Forms.Button();
            this.buttonSetEnergy = new System.Windows.Forms.Button();
            this.buttonSetTime = new System.Windows.Forms.Button();
            this.buttonSetPower = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxSetDistance = new System.Windows.Forms.TextBox();
            this.textBoxSetEnergy = new System.Windows.Forms.TextBox();
            this.textBoxSetTime = new System.Windows.Forms.TextBox();
            this.comboBoxPower = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectReciever = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonLoadOldData = new System.Windows.Forms.Button();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonStartTestEnvironment = new System.Windows.Forms.Button();
            this.groupBoxAstrandTest = new System.Windows.Forms.GroupBox();
            this.groupBoxRealContent = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labeTestlDescriptionProgressBar = new System.Windows.Forms.Label();
            this.buttonTestBegin = new System.Windows.Forms.Button();
            this.labelTestClientStatus = new System.Windows.Forms.Label();
            this.labelTestClientStatusTitle = new System.Windows.Forms.Label();
            this.progressBarTest = new System.Windows.Forms.ProgressBar();
            this.labelTestClientAge = new System.Windows.Forms.Label();
            this.labelTestClientWeight = new System.Windows.Forms.Label();
            this.textBoxTestClientAge = new System.Windows.Forms.TextBox();
            this.textBoxTestClientWeight = new System.Windows.Forms.TextBox();
            this.buttonTestNoodstop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientChart)).BeginInit();
            this.groupBoxAstrandTest.SuspendLayout();
            this.groupBoxRealContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(87, 407);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(105, 399);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // clientChart
            // 
            chartArea1.Name = "ChartArea1";
            this.clientChart.ChartAreas.Add(chartArea1);
            this.clientChart.Location = new System.Drawing.Point(105, 12);
            this.clientChart.Name = "clientChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Heartbeat";
            this.clientChart.Series.Add(series1);
            this.clientChart.Size = new System.Drawing.Size(283, 157);
            this.clientChart.TabIndex = 2;
            this.clientChart.Text = "Client";
            this.clientChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chatArea
            // 
            this.chatArea.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chatArea.Location = new System.Drawing.Point(105, 262);
            this.chatArea.Name = "chatArea";
            this.chatArea.ReadOnly = true;
            this.chatArea.Size = new System.Drawing.Size(470, 131);
            this.chatArea.TabIndex = 3;
            this.chatArea.Text = "";
            this.chatArea.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(102, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Heartbeat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "RPM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Distance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Power";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Energy";
            // 
            // buttonSetDistance
            // 
            this.buttonSetDistance.Location = new System.Drawing.Point(493, 42);
            this.buttonSetDistance.Name = "buttonSetDistance";
            this.buttonSetDistance.Size = new System.Drawing.Size(82, 23);
            this.buttonSetDistance.TabIndex = 10;
            this.buttonSetDistance.Text = "Set distance";
            this.buttonSetDistance.UseVisualStyleBackColor = true;
            this.buttonSetDistance.Click += new System.EventHandler(this.buttonSetDistance_Click);
            // 
            // buttonSetEnergy
            // 
            this.buttonSetEnergy.Location = new System.Drawing.Point(493, 71);
            this.buttonSetEnergy.Name = "buttonSetEnergy";
            this.buttonSetEnergy.Size = new System.Drawing.Size(82, 23);
            this.buttonSetEnergy.TabIndex = 11;
            this.buttonSetEnergy.Text = "Set energy";
            this.buttonSetEnergy.UseVisualStyleBackColor = true;
            this.buttonSetEnergy.Click += new System.EventHandler(this.buttonSetEnergy_Click);
            // 
            // buttonSetTime
            // 
            this.buttonSetTime.Location = new System.Drawing.Point(493, 100);
            this.buttonSetTime.Name = "buttonSetTime";
            this.buttonSetTime.Size = new System.Drawing.Size(82, 23);
            this.buttonSetTime.TabIndex = 12;
            this.buttonSetTime.Text = "Set time";
            this.buttonSetTime.UseVisualStyleBackColor = true;
            this.buttonSetTime.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSetPower
            // 
            this.buttonSetPower.Location = new System.Drawing.Point(493, 130);
            this.buttonSetPower.Name = "buttonSetPower";
            this.buttonSetPower.Size = new System.Drawing.Size(82, 23);
            this.buttonSetPower.TabIndex = 13;
            this.buttonSetPower.Text = "Set resistance";
            this.buttonSetPower.UseVisualStyleBackColor = true;
            this.buttonSetPower.Click += new System.EventHandler(this.buttonSetPower_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(493, 159);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(82, 23);
            this.buttonReset.TabIndex = 14;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxSetDistance
            // 
            this.textBoxSetDistance.Location = new System.Drawing.Point(394, 45);
            this.textBoxSetDistance.Name = "textBoxSetDistance";
            this.textBoxSetDistance.Size = new System.Drawing.Size(81, 20);
            this.textBoxSetDistance.TabIndex = 15;
            this.textBoxSetDistance.Text = "In hectometers";
            this.textBoxSetDistance.Click += new System.EventHandler(this.textBoxSetDistance_Click);
            // 
            // textBoxSetEnergy
            // 
            this.textBoxSetEnergy.Location = new System.Drawing.Point(394, 73);
            this.textBoxSetEnergy.Name = "textBoxSetEnergy";
            this.textBoxSetEnergy.Size = new System.Drawing.Size(81, 20);
            this.textBoxSetEnergy.TabIndex = 16;
            this.textBoxSetEnergy.Text = "In kJ";
            this.textBoxSetEnergy.Click += new System.EventHandler(this.textBoxSetEnergy_Click);
            // 
            // textBoxSetTime
            // 
            this.textBoxSetTime.Location = new System.Drawing.Point(394, 102);
            this.textBoxSetTime.Name = "textBoxSetTime";
            this.textBoxSetTime.Size = new System.Drawing.Size(81, 20);
            this.textBoxSetTime.TabIndex = 17;
            this.textBoxSetTime.Text = "In seconds";
            this.textBoxSetTime.Click += new System.EventHandler(this.textBoxSetTime_Click);
            // 
            // comboBoxPower
            // 
            this.comboBoxPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPower.FormattingEnabled = true;
            this.comboBoxPower.Items.AddRange(new object[] {
            "25 Power",
            "50 Power",
            "75 Power",
            "100 Power",
            "125 Power",
            "150 Power",
            "175 Power",
            "200 Power",
            "225 Power",
            "250 Power",
            "275 Power",
            "300 Power",
            "325 Power",
            "350 Power",
            "375 Power",
            "400 Power"});
            this.comboBoxPower.Location = new System.Drawing.Point(394, 132);
            this.comboBoxPower.Name = "comboBoxPower";
            this.comboBoxPower.Size = new System.Drawing.Size(81, 21);
            this.comboBoxPower.TabIndex = 18;
            this.comboBoxPower.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxSelectReciever
            // 
            this.comboBoxSelectReciever.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectReciever.FormattingEnabled = true;
            this.comboBoxSelectReciever.Items.AddRange(new object[] {
            "One user",
            "All users"});
            this.comboBoxSelectReciever.Location = new System.Drawing.Point(482, 400);
            this.comboBoxSelectReciever.Name = "comboBoxSelectReciever";
            this.comboBoxSelectReciever.Size = new System.Drawing.Size(93, 21);
            this.comboBoxSelectReciever.TabIndex = 19;
            this.comboBoxSelectReciever.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Enable Commands";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonLoadOldData
            // 
            this.buttonLoadOldData.Location = new System.Drawing.Point(484, 233);
            this.buttonLoadOldData.Name = "buttonLoadOldData";
            this.buttonLoadOldData.Size = new System.Drawing.Size(91, 23);
            this.buttonLoadOldData.TabIndex = 21;
            this.buttonLoadOldData.Text = "Load old data";
            this.buttonLoadOldData.UseVisualStyleBackColor = true;
            this.buttonLoadOldData.Click += new System.EventHandler(this.buttonLoadOldData_Click);
            // 
            // buttonLock
            // 
            this.buttonLock.Location = new System.Drawing.Point(394, 159);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(81, 23);
            this.buttonLock.TabIndex = 22;
            this.buttonLock.Text = "Lock bicycle";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // buttonStartTestEnvironment
            // 
            this.buttonStartTestEnvironment.Location = new System.Drawing.Point(6, 19);
            this.buttonStartTestEnvironment.Name = "buttonStartTestEnvironment";
            this.buttonStartTestEnvironment.Size = new System.Drawing.Size(136, 23);
            this.buttonStartTestEnvironment.TabIndex = 23;
            this.buttonStartTestEnvironment.Text = "Open Åstrand omgeving";
            this.buttonStartTestEnvironment.UseVisualStyleBackColor = true;
            this.buttonStartTestEnvironment.Click += new System.EventHandler(this.buttonStartTest_Click);
            // 
            // groupBoxAstrandTest
            // 
            this.groupBoxAstrandTest.Controls.Add(this.groupBoxRealContent);
            this.groupBoxAstrandTest.Controls.Add(this.buttonStartTestEnvironment);
            this.groupBoxAstrandTest.Location = new System.Drawing.Point(581, 12);
            this.groupBoxAstrandTest.Name = "groupBoxAstrandTest";
            this.groupBoxAstrandTest.Size = new System.Drawing.Size(445, 381);
            this.groupBoxAstrandTest.TabIndex = 24;
            this.groupBoxAstrandTest.TabStop = false;
            this.groupBoxAstrandTest.Text = "Åstrand test";
            // 
            // groupBoxRealContent
            // 
            this.groupBoxRealContent.Controls.Add(this.label8);
            this.groupBoxRealContent.Controls.Add(this.comboBox1);
            this.groupBoxRealContent.Controls.Add(this.labeTestlDescriptionProgressBar);
            this.groupBoxRealContent.Controls.Add(this.buttonTestBegin);
            this.groupBoxRealContent.Controls.Add(this.labelTestClientStatus);
            this.groupBoxRealContent.Controls.Add(this.labelTestClientStatusTitle);
            this.groupBoxRealContent.Controls.Add(this.progressBarTest);
            this.groupBoxRealContent.Controls.Add(this.labelTestClientAge);
            this.groupBoxRealContent.Controls.Add(this.labelTestClientWeight);
            this.groupBoxRealContent.Controls.Add(this.textBoxTestClientAge);
            this.groupBoxRealContent.Controls.Add(this.textBoxTestClientWeight);
            this.groupBoxRealContent.Controls.Add(this.buttonTestNoodstop);
            this.groupBoxRealContent.Location = new System.Drawing.Point(7, 49);
            this.groupBoxRealContent.Name = "groupBoxRealContent";
            this.groupBoxRealContent.Size = new System.Drawing.Size(432, 326);
            this.groupBoxRealContent.TabIndex = 24;
            this.groupBoxRealContent.TabStop = false;
            this.groupBoxRealContent.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Geslacht van de cliënt";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Man",
            "Vrouw"});
            this.comboBox1.Location = new System.Drawing.Point(155, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // labeTestlDescriptionProgressBar
            // 
            this.labeTestlDescriptionProgressBar.AutoSize = true;
            this.labeTestlDescriptionProgressBar.Location = new System.Drawing.Point(6, 278);
            this.labeTestlDescriptionProgressBar.Name = "labeTestlDescriptionProgressBar";
            this.labeTestlDescriptionProgressBar.Size = new System.Drawing.Size(153, 13);
            this.labeTestlDescriptionProgressBar.TabIndex = 8;
            this.labeTestlDescriptionProgressBar.Text = "Voortgang van inspanningstest";
            // 
            // buttonTestBegin
            // 
            this.buttonTestBegin.Location = new System.Drawing.Point(316, 19);
            this.buttonTestBegin.Name = "buttonTestBegin";
            this.buttonTestBegin.Size = new System.Drawing.Size(110, 45);
            this.buttonTestBegin.TabIndex = 7;
            this.buttonTestBegin.Text = "Start Åstrand test";
            this.buttonTestBegin.UseVisualStyleBackColor = true;
            this.buttonTestBegin.Click += new System.EventHandler(this.buttonTestBegin_Click);
            // 
            // labelTestClientStatus
            // 
            this.labelTestClientStatus.AutoSize = true;
            this.labelTestClientStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestClientStatus.Location = new System.Drawing.Point(10, 127);
            this.labelTestClientStatus.Name = "labelTestClientStatus";
            this.labelTestClientStatus.Size = new System.Drawing.Size(94, 16);
            this.labelTestClientStatus.TabIndex = 6;
            this.labelTestClientStatus.Text = "Test niet actief";
            // 
            // labelTestClientStatusTitle
            // 
            this.labelTestClientStatusTitle.AutoSize = true;
            this.labelTestClientStatusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestClientStatusTitle.Location = new System.Drawing.Point(6, 98);
            this.labelTestClientStatusTitle.Name = "labelTestClientStatusTitle";
            this.labelTestClientStatusTitle.Size = new System.Drawing.Size(113, 20);
            this.labelTestClientStatusTitle.TabIndex = 5;
            this.labelTestClientStatusTitle.Text = "Status Client";
            // 
            // progressBarTest
            // 
            this.progressBarTest.Location = new System.Drawing.Point(6, 297);
            this.progressBarTest.Name = "progressBarTest";
            this.progressBarTest.Size = new System.Drawing.Size(420, 23);
            this.progressBarTest.TabIndex = 4;
            // 
            // labelTestClientAge
            // 
            this.labelTestClientAge.AutoSize = true;
            this.labelTestClientAge.Location = new System.Drawing.Point(6, 47);
            this.labelTestClientAge.Name = "labelTestClientAge";
            this.labelTestClientAge.Size = new System.Drawing.Size(148, 13);
            this.labelTestClientAge.TabIndex = 3;
            this.labelTestClientAge.Text = "Leeftijd van de cliënt (in jaren)";
            // 
            // labelTestClientWeight
            // 
            this.labelTestClientWeight.AutoSize = true;
            this.labelTestClientWeight.Location = new System.Drawing.Point(6, 22);
            this.labelTestClientWeight.Name = "labelTestClientWeight";
            this.labelTestClientWeight.Size = new System.Drawing.Size(143, 13);
            this.labelTestClientWeight.TabIndex = 2;
            this.labelTestClientWeight.Text = "Gewicht van de cliënt (in Kg)";
            // 
            // textBoxTestClientAge
            // 
            this.textBoxTestClientAge.Location = new System.Drawing.Point(155, 44);
            this.textBoxTestClientAge.Name = "textBoxTestClientAge";
            this.textBoxTestClientAge.Size = new System.Drawing.Size(110, 20);
            this.textBoxTestClientAge.TabIndex = 1;
            // 
            // textBoxTestClientWeight
            // 
            this.textBoxTestClientWeight.Location = new System.Drawing.Point(155, 19);
            this.textBoxTestClientWeight.Name = "textBoxTestClientWeight";
            this.textBoxTestClientWeight.Size = new System.Drawing.Size(110, 20);
            this.textBoxTestClientWeight.TabIndex = 0;
            // 
            // buttonTestNoodstop
            // 
            this.buttonTestNoodstop.BackColor = System.Drawing.Color.Red;
            this.buttonTestNoodstop.Location = new System.Drawing.Point(302, 172);
            this.buttonTestNoodstop.Name = "buttonTestNoodstop";
            this.buttonTestNoodstop.Size = new System.Drawing.Size(124, 116);
            this.buttonTestNoodstop.TabIndex = 0;
            this.buttonTestNoodstop.Text = "Noodstop";
            this.buttonTestNoodstop.UseVisualStyleBackColor = false;
            this.buttonTestNoodstop.Click += new System.EventHandler(this.buttonTestNoodstop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 433);
            this.Controls.Add(this.groupBoxAstrandTest);
            this.Controls.Add(this.buttonLock);
            this.Controls.Add(this.buttonLoadOldData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxSelectReciever);
            this.Controls.Add(this.comboBoxPower);
            this.Controls.Add(this.textBoxSetTime);
            this.Controls.Add(this.textBoxSetEnergy);
            this.Controls.Add(this.textBoxSetDistance);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSetPower);
            this.Controls.Add(this.buttonSetTime);
            this.Controls.Add(this.buttonSetEnergy);
            this.Controls.Add(this.buttonSetDistance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatArea);
            this.Controls.Add(this.clientChart);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Doctor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientChart)).EndInit();
            this.groupBoxAstrandTest.ResumeLayout(false);
            this.groupBoxRealContent.ResumeLayout(false);
            this.groupBoxRealContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart clientChart;
        private System.Windows.Forms.RichTextBox chatArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSetDistance;
        private System.Windows.Forms.Button buttonSetEnergy;
        private System.Windows.Forms.Button buttonSetTime;
        private System.Windows.Forms.Button buttonSetPower;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxSetDistance;
        private System.Windows.Forms.TextBox textBoxSetEnergy;
        private System.Windows.Forms.TextBox textBoxSetTime;
        private System.Windows.Forms.ComboBox comboBoxPower;
        private System.Windows.Forms.ComboBox comboBoxSelectReciever;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonLoadOldData;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonStartTestEnvironment;
        private System.Windows.Forms.GroupBox groupBoxAstrandTest;
        private System.Windows.Forms.GroupBox groupBoxRealContent;
        private System.Windows.Forms.Button buttonTestNoodstop;
        private System.Windows.Forms.TextBox textBoxTestClientAge;
        private System.Windows.Forms.TextBox textBoxTestClientWeight;
        private System.Windows.Forms.ProgressBar progressBarTest;
        private System.Windows.Forms.Label labelTestClientAge;
        private System.Windows.Forms.Label labelTestClientWeight;
        private System.Windows.Forms.Label labelTestClientStatusTitle;
        private System.Windows.Forms.Label labelTestClientStatus;
        private System.Windows.Forms.Label labeTestlDescriptionProgressBar;
        private System.Windows.Forms.Button buttonTestBegin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}

