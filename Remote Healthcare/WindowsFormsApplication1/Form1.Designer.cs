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
            ((System.ComponentModel.ISupportInitialize)(this.clientChart)).BeginInit();
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
            this.textBox1.Size = new System.Drawing.Size(370, 20);
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
            series1.Name = "Series1";
            this.clientChart.Series.Add(series1);
            this.clientChart.Size = new System.Drawing.Size(283, 157);
            this.clientChart.TabIndex = 2;
            this.clientChart.Text = "Client";
            this.clientChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chatArea
            // 
            this.chatArea.Location = new System.Drawing.Point(105, 262);
            this.chatArea.Name = "chatArea";
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
            this.buttonSetDistance.Location = new System.Drawing.Point(493, 12);
            this.buttonSetDistance.Name = "buttonSetDistance";
            this.buttonSetDistance.Size = new System.Drawing.Size(82, 23);
            this.buttonSetDistance.TabIndex = 10;
            this.buttonSetDistance.Text = "Set distance";
            this.buttonSetDistance.UseVisualStyleBackColor = true;
            this.buttonSetDistance.Click += new System.EventHandler(this.buttonSetDistance_Click);
            // 
            // buttonSetEnergy
            // 
            this.buttonSetEnergy.Location = new System.Drawing.Point(493, 41);
            this.buttonSetEnergy.Name = "buttonSetEnergy";
            this.buttonSetEnergy.Size = new System.Drawing.Size(82, 23);
            this.buttonSetEnergy.TabIndex = 11;
            this.buttonSetEnergy.Text = "Set energy";
            this.buttonSetEnergy.UseVisualStyleBackColor = true;
            this.buttonSetEnergy.Click += new System.EventHandler(this.buttonSetEnergy_Click);
            // 
            // buttonSetTime
            // 
            this.buttonSetTime.Location = new System.Drawing.Point(493, 70);
            this.buttonSetTime.Name = "buttonSetTime";
            this.buttonSetTime.Size = new System.Drawing.Size(82, 23);
            this.buttonSetTime.TabIndex = 12;
            this.buttonSetTime.Text = "Set time";
            this.buttonSetTime.UseVisualStyleBackColor = true;
            this.buttonSetTime.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSetPower
            // 
            this.buttonSetPower.Location = new System.Drawing.Point(493, 100);
            this.buttonSetPower.Name = "buttonSetPower";
            this.buttonSetPower.Size = new System.Drawing.Size(82, 23);
            this.buttonSetPower.TabIndex = 13;
            this.buttonSetPower.Text = "Set resistance";
            this.buttonSetPower.UseVisualStyleBackColor = true;
            this.buttonSetPower.Click += new System.EventHandler(this.buttonSetPower_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(500, 146);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 14;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxSetDistance
            // 
            this.textBoxSetDistance.Location = new System.Drawing.Point(394, 15);
            this.textBoxSetDistance.Name = "textBoxSetDistance";
            this.textBoxSetDistance.Size = new System.Drawing.Size(81, 20);
            this.textBoxSetDistance.TabIndex = 15;
            this.textBoxSetDistance.Text = "In hectometers";
            this.textBoxSetDistance.Click += new System.EventHandler(this.textBoxSetDistance_Click);
            // 
            // textBoxSetEnergy
            // 
            this.textBoxSetEnergy.Location = new System.Drawing.Point(394, 43);
            this.textBoxSetEnergy.Name = "textBoxSetEnergy";
            this.textBoxSetEnergy.Size = new System.Drawing.Size(81, 20);
            this.textBoxSetEnergy.TabIndex = 16;
            this.textBoxSetEnergy.Text = "In kJ";
            this.textBoxSetEnergy.Click += new System.EventHandler(this.textBoxSetEnergy_Click);
            // 
            // textBoxSetTime
            // 
            this.textBoxSetTime.Location = new System.Drawing.Point(394, 72);
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
            this.comboBoxPower.Location = new System.Drawing.Point(394, 102);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 433);
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
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.clientChart)).EndInit();
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

    }
}

