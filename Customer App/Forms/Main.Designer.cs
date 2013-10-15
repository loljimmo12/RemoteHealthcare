namespace Customer_App
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
            this.tpCurrentStats = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.lblTimeText = new System.Windows.Forms.Label();
            this.lblEnergyValue = new System.Windows.Forms.Label();
            this.lblEnergyText = new System.Windows.Forms.Label();
            this.lblActPowerValue = new System.Windows.Forms.Label();
            this.lblActPowerText = new System.Windows.Forms.Label();
            this.lblReqPowerValue = new System.Windows.Forms.Label();
            this.lblReqPowerText = new System.Windows.Forms.Label();
            this.lblDistanceValue = new System.Windows.Forms.Label();
            this.lblDistanceText = new System.Windows.Forms.Label();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.lblSpeedText = new System.Windows.Forms.Label();
            this.lblRPMValue = new System.Windows.Forms.Label();
            this.lblRPMText = new System.Windows.Forms.Label();
            this.lblPulseValue = new System.Windows.Forms.Label();
            this.lblPulseText = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.lblChatMessage = new System.Windows.Forms.Label();
            this.txtChatMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblValues = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tpCurrentStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpCurrentStats
            // 
            this.tpCurrentStats.ColumnCount = 2;
            this.tpCurrentStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.61637F));
            this.tpCurrentStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.38363F));
            this.tpCurrentStats.Controls.Add(this.lblTimeValue, 1, 7);
            this.tpCurrentStats.Controls.Add(this.lblTimeText, 0, 7);
            this.tpCurrentStats.Controls.Add(this.lblEnergyValue, 1, 6);
            this.tpCurrentStats.Controls.Add(this.lblEnergyText, 0, 6);
            this.tpCurrentStats.Controls.Add(this.lblActPowerValue, 1, 5);
            this.tpCurrentStats.Controls.Add(this.lblActPowerText, 0, 5);
            this.tpCurrentStats.Controls.Add(this.lblReqPowerValue, 1, 4);
            this.tpCurrentStats.Controls.Add(this.lblReqPowerText, 0, 4);
            this.tpCurrentStats.Controls.Add(this.lblDistanceValue, 1, 3);
            this.tpCurrentStats.Controls.Add(this.lblDistanceText, 0, 3);
            this.tpCurrentStats.Controls.Add(this.lblSpeedValue, 1, 2);
            this.tpCurrentStats.Controls.Add(this.lblSpeedText, 0, 2);
            this.tpCurrentStats.Controls.Add(this.lblRPMValue, 1, 1);
            this.tpCurrentStats.Controls.Add(this.lblRPMText, 0, 1);
            this.tpCurrentStats.Controls.Add(this.lblPulseValue, 1, 0);
            this.tpCurrentStats.Controls.Add(this.lblPulseText, 0, 0);
            this.tpCurrentStats.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCurrentStats.Location = new System.Drawing.Point(12, 45);
            this.tpCurrentStats.Name = "tpCurrentStats";
            this.tpCurrentStats.RowCount = 8;
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpCurrentStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpCurrentStats.Size = new System.Drawing.Size(391, 165);
            this.tpCurrentStats.TabIndex = 0;
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.AutoSize = true;
            this.lblTimeValue.Location = new System.Drawing.Point(197, 144);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(0, 19);
            this.lblTimeValue.TabIndex = 15;
            // 
            // lblTimeText
            // 
            this.lblTimeText.AutoSize = true;
            this.lblTimeText.Location = new System.Drawing.Point(3, 144);
            this.lblTimeText.Name = "lblTimeText";
            this.lblTimeText.Size = new System.Drawing.Size(33, 19);
            this.lblTimeText.TabIndex = 14;
            this.lblTimeText.Text = "Tijd";
            // 
            // lblEnergyValue
            // 
            this.lblEnergyValue.AutoSize = true;
            this.lblEnergyValue.Location = new System.Drawing.Point(197, 124);
            this.lblEnergyValue.Name = "lblEnergyValue";
            this.lblEnergyValue.Size = new System.Drawing.Size(0, 19);
            this.lblEnergyValue.TabIndex = 13;
            // 
            // lblEnergyText
            // 
            this.lblEnergyText.AutoSize = true;
            this.lblEnergyText.Location = new System.Drawing.Point(3, 124);
            this.lblEnergyText.Name = "lblEnergyText";
            this.lblEnergyText.Size = new System.Drawing.Size(58, 19);
            this.lblEnergyText.TabIndex = 12;
            this.lblEnergyText.Text = "Energie";
            // 
            // lblActPowerValue
            // 
            this.lblActPowerValue.AutoSize = true;
            this.lblActPowerValue.Location = new System.Drawing.Point(197, 104);
            this.lblActPowerValue.Name = "lblActPowerValue";
            this.lblActPowerValue.Size = new System.Drawing.Size(0, 19);
            this.lblActPowerValue.TabIndex = 11;
            // 
            // lblActPowerText
            // 
            this.lblActPowerText.AutoSize = true;
            this.lblActPowerText.Location = new System.Drawing.Point(3, 104);
            this.lblActPowerText.Name = "lblActPowerText";
            this.lblActPowerText.Size = new System.Drawing.Size(119, 19);
            this.lblActPowerText.TabIndex = 10;
            this.lblActPowerText.Text = "Geleverde kracht";
            // 
            // lblReqPowerValue
            // 
            this.lblReqPowerValue.AutoSize = true;
            this.lblReqPowerValue.Location = new System.Drawing.Point(197, 84);
            this.lblReqPowerValue.Name = "lblReqPowerValue";
            this.lblReqPowerValue.Size = new System.Drawing.Size(0, 19);
            this.lblReqPowerValue.TabIndex = 9;
            // 
            // lblReqPowerText
            // 
            this.lblReqPowerText.AutoSize = true;
            this.lblReqPowerText.Location = new System.Drawing.Point(3, 84);
            this.lblReqPowerText.Name = "lblReqPowerText";
            this.lblReqPowerText.Size = new System.Drawing.Size(123, 19);
            this.lblReqPowerText.TabIndex = 8;
            this.lblReqPowerText.Text = "Gevraagde kracht";
            // 
            // lblDistanceValue
            // 
            this.lblDistanceValue.AutoSize = true;
            this.lblDistanceValue.Location = new System.Drawing.Point(197, 64);
            this.lblDistanceValue.Name = "lblDistanceValue";
            this.lblDistanceValue.Size = new System.Drawing.Size(0, 19);
            this.lblDistanceValue.TabIndex = 7;
            // 
            // lblDistanceText
            // 
            this.lblDistanceText.AutoSize = true;
            this.lblDistanceText.Location = new System.Drawing.Point(3, 64);
            this.lblDistanceText.Name = "lblDistanceText";
            this.lblDistanceText.Size = new System.Drawing.Size(59, 19);
            this.lblDistanceText.TabIndex = 6;
            this.lblDistanceText.Text = "Afstand";
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Location = new System.Drawing.Point(197, 44);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(0, 19);
            this.lblSpeedValue.TabIndex = 5;
            // 
            // lblSpeedText
            // 
            this.lblSpeedText.AutoSize = true;
            this.lblSpeedText.Location = new System.Drawing.Point(3, 44);
            this.lblSpeedText.Name = "lblSpeedText";
            this.lblSpeedText.Size = new System.Drawing.Size(64, 19);
            this.lblSpeedText.TabIndex = 4;
            this.lblSpeedText.Text = "Snelheid";
            // 
            // lblRPMValue
            // 
            this.lblRPMValue.AutoSize = true;
            this.lblRPMValue.Location = new System.Drawing.Point(197, 22);
            this.lblRPMValue.Name = "lblRPMValue";
            this.lblRPMValue.Size = new System.Drawing.Size(0, 19);
            this.lblRPMValue.TabIndex = 3;
            // 
            // lblRPMText
            // 
            this.lblRPMText.AutoSize = true;
            this.lblRPMText.Location = new System.Drawing.Point(3, 22);
            this.lblRPMText.Name = "lblRPMText";
            this.lblRPMText.Size = new System.Drawing.Size(39, 19);
            this.lblRPMText.TabIndex = 2;
            this.lblRPMText.Text = "RPM";
            // 
            // lblPulseValue
            // 
            this.lblPulseValue.AutoSize = true;
            this.lblPulseValue.Location = new System.Drawing.Point(197, 0);
            this.lblPulseValue.Name = "lblPulseValue";
            this.lblPulseValue.Size = new System.Drawing.Size(0, 19);
            this.lblPulseValue.TabIndex = 1;
            // 
            // lblPulseText
            // 
            this.lblPulseText.AutoSize = true;
            this.lblPulseText.Location = new System.Drawing.Point(3, 0);
            this.lblPulseText.Name = "lblPulseText";
            this.lblPulseText.Size = new System.Drawing.Size(64, 19);
            this.lblPulseText.TabIndex = 0;
            this.lblPulseText.Text = "Hartslag";
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(410, 45);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(581, 451);
            this.txtChat.TabIndex = 7;
            // 
            // lblChatMessage
            // 
            this.lblChatMessage.AutoSize = true;
            this.lblChatMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatMessage.Location = new System.Drawing.Point(406, 9);
            this.lblChatMessage.Name = "lblChatMessage";
            this.lblChatMessage.Size = new System.Drawing.Size(47, 20);
            this.lblChatMessage.TabIndex = 8;
            this.lblChatMessage.Text = "Chat";
            // 
            // txtChatMessage
            // 
            this.txtChatMessage.Location = new System.Drawing.Point(410, 502);
            this.txtChatMessage.Name = "txtChatMessage";
            this.txtChatMessage.Size = new System.Drawing.Size(467, 20);
            this.txtChatMessage.TabIndex = 9;
            this.txtChatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatMessage_KeyDown);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(884, 499);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(107, 23);
            this.btnSendMessage.TabIndex = 10;
            this.btnSendMessage.Text = "Verzenden";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblValues
            // 
            this.lblValues.AutoSize = true;
            this.lblValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValues.Location = new System.Drawing.Point(8, 9);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(143, 20);
            this.lblValues.TabIndex = 11;
            this.lblValues.Text = "Huidige waarden";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(391, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Start Astrand Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 530);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblValues);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtChatMessage);
            this.Controls.Add(this.lblChatMessage);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.tpCurrentStats);
            this.Name = "Form1";
            this.Text = "Customer App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tpCurrentStats.ResumeLayout(false);
            this.tpCurrentStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpCurrentStats;
        private System.Windows.Forms.Label lblTimeValue;
        private System.Windows.Forms.Label lblTimeText;
        private System.Windows.Forms.Label lblEnergyValue;
        private System.Windows.Forms.Label lblEnergyText;
        private System.Windows.Forms.Label lblActPowerValue;
        private System.Windows.Forms.Label lblActPowerText;
        private System.Windows.Forms.Label lblReqPowerValue;
        private System.Windows.Forms.Label lblReqPowerText;
        private System.Windows.Forms.Label lblDistanceValue;
        private System.Windows.Forms.Label lblDistanceText;
        private System.Windows.Forms.Label lblSpeedValue;
        private System.Windows.Forms.Label lblSpeedText;
        private System.Windows.Forms.Label lblRPMValue;
        private System.Windows.Forms.Label lblRPMText;
        private System.Windows.Forms.Label lblPulseValue;
        private System.Windows.Forms.Label lblPulseText;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label lblChatMessage;
        private System.Windows.Forms.TextBox txtChatMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label lblValues;
        private System.Windows.Forms.Button button1;

    }
}

