namespace WindowsFormsApplication1
{
    partial class h
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxHHBegin = new System.Windows.Forms.TextBox();
            this.textBoxMMBegin = new System.Windows.Forms.TextBox();
            this.textBoxSSBegin = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBoxSSEnd = new System.Windows.Forms.TextBox();
            this.textBoxMMEnd = new System.Windows.Forms.TextBox();
            this.textBoxHHEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEnergy = new System.Windows.Forms.Label();
            this.labelPower = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelRPM = new System.Windows.Forms.Label();
            this.labelHeartBeat = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.comboBoxSelectSection = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectTime = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // textBoxHHBegin
            // 
            this.textBoxHHBegin.Location = new System.Drawing.Point(319, 13);
            this.textBoxHHBegin.Name = "textBoxHHBegin";
            this.textBoxHHBegin.Size = new System.Drawing.Size(22, 20);
            this.textBoxHHBegin.TabIndex = 1;
            this.textBoxHHBegin.Text = "HH";
            this.textBoxHHBegin.Enter += new System.EventHandler(this.textBoxHHBegin_Enter);
            // 
            // textBoxMMBegin
            // 
            this.textBoxMMBegin.Location = new System.Drawing.Point(354, 12);
            this.textBoxMMBegin.Name = "textBoxMMBegin";
            this.textBoxMMBegin.Size = new System.Drawing.Size(22, 20);
            this.textBoxMMBegin.TabIndex = 2;
            this.textBoxMMBegin.Text = "MM";
            this.textBoxMMBegin.Enter += new System.EventHandler(this.textBoxMMBegin_Enter);
            // 
            // textBoxSSBegin
            // 
            this.textBoxSSBegin.Location = new System.Drawing.Point(389, 12);
            this.textBoxSSBegin.Name = "textBoxSSBegin";
            this.textBoxSSBegin.Size = new System.Drawing.Size(22, 20);
            this.textBoxSSBegin.TabIndex = 3;
            this.textBoxSSBegin.Text = "SS";
            this.textBoxSSBegin.Enter += new System.EventHandler(this.textBoxSSBegin_Enter);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(102, 51);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // textBoxSSEnd
            // 
            this.textBoxSSEnd.Location = new System.Drawing.Point(389, 51);
            this.textBoxSSEnd.Name = "textBoxSSEnd";
            this.textBoxSSEnd.Size = new System.Drawing.Size(22, 20);
            this.textBoxSSEnd.TabIndex = 7;
            this.textBoxSSEnd.Text = "SS";
            this.textBoxSSEnd.Enter += new System.EventHandler(this.textBoxSSEnd_Enter);
            // 
            // textBoxMMEnd
            // 
            this.textBoxMMEnd.Location = new System.Drawing.Point(354, 51);
            this.textBoxMMEnd.Name = "textBoxMMEnd";
            this.textBoxMMEnd.Size = new System.Drawing.Size(22, 20);
            this.textBoxMMEnd.TabIndex = 6;
            this.textBoxMMEnd.Text = "MM";
            this.textBoxMMEnd.Enter += new System.EventHandler(this.textBoxMMEnd_Enter);
            // 
            // textBoxHHEnd
            // 
            this.textBoxHHEnd.Location = new System.Drawing.Point(319, 50);
            this.textBoxHHEnd.Name = "textBoxHHEnd";
            this.textBoxHHEnd.Size = new System.Drawing.Size(22, 20);
            this.textBoxHHEnd.TabIndex = 5;
            this.textBoxHHEnd.Text = "HH";
            this.textBoxHHEnd.TextChanged += new System.EventHandler(this.textBoxHHEnd_TextChanged);
            this.textBoxHHEnd.Enter += new System.EventHandler(this.textBoxHHEnd_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Begintijd";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Eindtijd";
            // 
            // labelEnergy
            // 
            this.labelEnergy.AutoSize = true;
            this.labelEnergy.Location = new System.Drawing.Point(202, 191);
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Size = new System.Drawing.Size(40, 13);
            this.labelEnergy.TabIndex = 16;
            this.labelEnergy.Text = "Energy";
            // 
            // labelPower
            // 
            this.labelPower.AutoSize = true;
            this.labelPower.Location = new System.Drawing.Point(202, 171);
            this.labelPower.Name = "labelPower";
            this.labelPower.Size = new System.Drawing.Size(37, 13);
            this.labelPower.TabIndex = 15;
            this.labelPower.Text = "Power";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(202, 150);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 14;
            this.labelTime.Text = "Time";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(26, 213);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(49, 13);
            this.labelDistance.TabIndex = 13;
            this.labelDistance.Text = "Distance";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(26, 191);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(38, 13);
            this.labelSpeed.TabIndex = 12;
            this.labelSpeed.Text = "Speed";
            // 
            // labelRPM
            // 
            this.labelRPM.AutoSize = true;
            this.labelRPM.Location = new System.Drawing.Point(26, 171);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(31, 13);
            this.labelRPM.TabIndex = 11;
            this.labelRPM.Text = "RPM";
            // 
            // labelHeartBeat
            // 
            this.labelHeartBeat.Location = new System.Drawing.Point(23, 150);
            this.labelHeartBeat.Name = "labelHeartBeat";
            this.labelHeartBeat.Size = new System.Drawing.Size(58, 13);
            this.labelHeartBeat.TabIndex = 10;
            this.labelHeartBeat.Text = "Heartbeat";
            this.labelHeartBeat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(12, 245);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(414, 214);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Location = new System.Drawing.Point(328, 77);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadData.TabIndex = 19;
            this.buttonLoadData.Text = "Load data";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // comboBoxSelectSection
            // 
            this.comboBoxSelectSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBoxSelectSection.SelectedText = "Select a section";
            this.comboBoxSelectSection.FormattingEnabled = true;
            this.comboBoxSelectSection.Location = new System.Drawing.Point(305, 150);
            this.comboBoxSelectSection.Name = "comboBoxSelectSection";
            this.comboBoxSelectSection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectSection.TabIndex = 20;
            this.comboBoxSelectSection.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectSection_SelectedIndexChanged);
            // 
            // comboBoxSelectTime
            // 
            this.comboBoxSelectTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBoxSelectTime.SelectedText = "Select a time";
            this.comboBoxSelectTime.FormattingEnabled = true;
            this.comboBoxSelectTime.Location = new System.Drawing.Point(305, 177);
            this.comboBoxSelectTime.Name = "comboBoxSelectTime";
            this.comboBoxSelectTime.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectTime.TabIndex = 21;
            this.comboBoxSelectTime.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectTime_SelectedIndexChanged);
            // 
            // h
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 471);
            this.Controls.Add(this.comboBoxSelectTime);
            this.Controls.Add(this.comboBoxSelectSection);
            this.Controls.Add(this.buttonLoadData);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelEnergy);
            this.Controls.Add(this.labelPower);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelRPM);
            this.Controls.Add(this.labelHeartBeat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSSEnd);
            this.Controls.Add(this.textBoxMMEnd);
            this.Controls.Add(this.textBoxHHEnd);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.textBoxSSBegin);
            this.Controls.Add(this.textBoxMMBegin);
            this.Controls.Add(this.textBoxHHBegin);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "h";
            this.Text = "Load old data";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxHHBegin;
        private System.Windows.Forms.TextBox textBoxMMBegin;
        private System.Windows.Forms.TextBox textBoxSSBegin;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBoxSSEnd;
        private System.Windows.Forms.TextBox textBoxMMEnd;
        private System.Windows.Forms.TextBox textBoxHHEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEnergy;
        private System.Windows.Forms.Label labelPower;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelRPM;
        private System.Windows.Forms.Label labelHeartBeat;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.ComboBox comboBoxSelectSection;
        private System.Windows.Forms.ComboBox comboBoxSelectTime;
    }
}
