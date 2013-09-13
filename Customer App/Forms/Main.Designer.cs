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
            this.lblSendCommand = new System.Windows.Forms.Label();
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblSendValue = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpCurrentStats.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.tpCurrentStats.Location = new System.Drawing.Point(12, 30);
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
            this.lblTimeValue.Size = new System.Drawing.Size(0, 13);
            this.lblTimeValue.TabIndex = 15;
            // 
            // lblTimeText
            // 
            this.lblTimeText.AutoSize = true;
            this.lblTimeText.Location = new System.Drawing.Point(3, 144);
            this.lblTimeText.Name = "lblTimeText";
            this.lblTimeText.Size = new System.Drawing.Size(24, 13);
            this.lblTimeText.TabIndex = 14;
            this.lblTimeText.Text = "Tijd";
            // 
            // lblEnergyValue
            // 
            this.lblEnergyValue.AutoSize = true;
            this.lblEnergyValue.Location = new System.Drawing.Point(197, 124);
            this.lblEnergyValue.Name = "lblEnergyValue";
            this.lblEnergyValue.Size = new System.Drawing.Size(0, 13);
            this.lblEnergyValue.TabIndex = 13;
            // 
            // lblEnergyText
            // 
            this.lblEnergyText.AutoSize = true;
            this.lblEnergyText.Location = new System.Drawing.Point(3, 124);
            this.lblEnergyText.Name = "lblEnergyText";
            this.lblEnergyText.Size = new System.Drawing.Size(43, 13);
            this.lblEnergyText.TabIndex = 12;
            this.lblEnergyText.Text = "Energie";
            // 
            // lblActPowerValue
            // 
            this.lblActPowerValue.AutoSize = true;
            this.lblActPowerValue.Location = new System.Drawing.Point(197, 104);
            this.lblActPowerValue.Name = "lblActPowerValue";
            this.lblActPowerValue.Size = new System.Drawing.Size(0, 13);
            this.lblActPowerValue.TabIndex = 11;
            // 
            // lblActPowerText
            // 
            this.lblActPowerText.AutoSize = true;
            this.lblActPowerText.Location = new System.Drawing.Point(3, 104);
            this.lblActPowerText.Name = "lblActPowerText";
            this.lblActPowerText.Size = new System.Drawing.Size(89, 13);
            this.lblActPowerText.TabIndex = 10;
            this.lblActPowerText.Text = "Geleverde kracht";
            // 
            // lblReqPowerValue
            // 
            this.lblReqPowerValue.AutoSize = true;
            this.lblReqPowerValue.Location = new System.Drawing.Point(197, 84);
            this.lblReqPowerValue.Name = "lblReqPowerValue";
            this.lblReqPowerValue.Size = new System.Drawing.Size(0, 13);
            this.lblReqPowerValue.TabIndex = 9;
            // 
            // lblReqPowerText
            // 
            this.lblReqPowerText.AutoSize = true;
            this.lblReqPowerText.Location = new System.Drawing.Point(3, 84);
            this.lblReqPowerText.Name = "lblReqPowerText";
            this.lblReqPowerText.Size = new System.Drawing.Size(93, 13);
            this.lblReqPowerText.TabIndex = 8;
            this.lblReqPowerText.Text = "Gevraagde kracht";
            // 
            // lblDistanceValue
            // 
            this.lblDistanceValue.AutoSize = true;
            this.lblDistanceValue.Location = new System.Drawing.Point(197, 64);
            this.lblDistanceValue.Name = "lblDistanceValue";
            this.lblDistanceValue.Size = new System.Drawing.Size(0, 13);
            this.lblDistanceValue.TabIndex = 7;
            // 
            // lblDistanceText
            // 
            this.lblDistanceText.AutoSize = true;
            this.lblDistanceText.Location = new System.Drawing.Point(3, 64);
            this.lblDistanceText.Name = "lblDistanceText";
            this.lblDistanceText.Size = new System.Drawing.Size(43, 13);
            this.lblDistanceText.TabIndex = 6;
            this.lblDistanceText.Text = "Afstand";
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Location = new System.Drawing.Point(197, 44);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(0, 13);
            this.lblSpeedValue.TabIndex = 5;
            // 
            // lblSpeedText
            // 
            this.lblSpeedText.AutoSize = true;
            this.lblSpeedText.Location = new System.Drawing.Point(3, 44);
            this.lblSpeedText.Name = "lblSpeedText";
            this.lblSpeedText.Size = new System.Drawing.Size(48, 13);
            this.lblSpeedText.TabIndex = 4;
            this.lblSpeedText.Text = "Snelheid";
            // 
            // lblRPMValue
            // 
            this.lblRPMValue.AutoSize = true;
            this.lblRPMValue.Location = new System.Drawing.Point(197, 22);
            this.lblRPMValue.Name = "lblRPMValue";
            this.lblRPMValue.Size = new System.Drawing.Size(0, 13);
            this.lblRPMValue.TabIndex = 3;
            // 
            // lblRPMText
            // 
            this.lblRPMText.AutoSize = true;
            this.lblRPMText.Location = new System.Drawing.Point(3, 22);
            this.lblRPMText.Name = "lblRPMText";
            this.lblRPMText.Size = new System.Drawing.Size(31, 13);
            this.lblRPMText.TabIndex = 2;
            this.lblRPMText.Text = "RPM";
            // 
            // lblPulseValue
            // 
            this.lblPulseValue.AutoSize = true;
            this.lblPulseValue.Location = new System.Drawing.Point(197, 0);
            this.lblPulseValue.Name = "lblPulseValue";
            this.lblPulseValue.Size = new System.Drawing.Size(0, 13);
            this.lblPulseValue.TabIndex = 1;
            // 
            // lblPulseText
            // 
            this.lblPulseText.AutoSize = true;
            this.lblPulseText.Location = new System.Drawing.Point(3, 0);
            this.lblPulseText.Name = "lblPulseText";
            this.lblPulseText.Size = new System.Drawing.Size(46, 13);
            this.lblPulseText.TabIndex = 0;
            this.lblPulseText.Text = "Hartslag";
            // 
            // lblSendCommand
            // 
            this.lblSendCommand.AutoSize = true;
            this.lblSendCommand.Location = new System.Drawing.Point(12, 198);
            this.lblSendCommand.Name = "lblSendCommand";
            this.lblSendCommand.Size = new System.Drawing.Size(171, 13);
            this.lblSendCommand.TabIndex = 1;
            this.lblSendCommand.Text = "Commando naar de fiets versturen:";
            // 
            // lstCommands
            // 
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.Location = new System.Drawing.Point(15, 214);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(257, 303);
            this.lstCommands.TabIndex = 2;
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(279, 493);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(75, 23);
            this.btnSendCommand.TabIndex = 3;
            this.btnSendCommand.Text = "Versturen";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(279, 467);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(192, 20);
            this.txtCommand.TabIndex = 4;
            // 
            // lblSendValue
            // 
            this.lblSendValue.AutoSize = true;
            this.lblSendValue.Location = new System.Drawing.Point(276, 451);
            this.lblSendValue.Name = "lblSendValue";
            this.lblSendValue.Size = new System.Drawing.Size(48, 13);
            this.lblSendValue.TabIndex = 5;
            this.lblSendValue.Text = "Waarde:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1003, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 536);
            this.Controls.Add(this.lblSendValue);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.lstCommands);
            this.Controls.Add(this.lblSendCommand);
            this.Controls.Add(this.tpCurrentStats);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Customer App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tpCurrentStats.ResumeLayout(false);
            this.tpCurrentStats.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label lblSendCommand;
        private System.Windows.Forms.ListBox lstCommands;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblSendValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;

    }
}

