﻿namespace Modbus.Common
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
        protected void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonPauseLog = new System.Windows.Forms.Button();
            this.listBoxCommLog = new System.Windows.Forms.ListBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSlaveDelay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSlaveID = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonLED = new System.Windows.Forms.RadioButton();
            this.radioButtonInteger = new System.Windows.Forms.RadioButton();
            this.radioButtonHex = new System.Windows.Forms.RadioButton();
            this.radioButtonBinary = new System.Windows.Forms.RadioButton();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.groupBoxRTU = new System.Windows.Forms.GroupBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.labelParity = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonRTU = new System.Windows.Forms.RadioButton();
            this.radioButtonUDP = new System.Windows.Forms.RadioButton();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.groupBoxTCP = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataTab1 = new Modbus.Common.DataTab();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataTab2 = new Modbus.Common.DataTab();
            this.grpExchange = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpStart.SuspendLayout();
            this.groupBoxRTU.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxTCP.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpExchange.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonPauseLog);
            this.groupBox4.Controls.Add(this.listBoxCommLog);
            this.groupBox4.Controls.Add(this.buttonClear);
            this.groupBox4.Location = new System.Drawing.Point(9, 860);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1145, 239);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Communication Log";
            // 
            // buttonPauseLog
            // 
            this.buttonPauseLog.Location = new System.Drawing.Point(880, 23);
            this.buttonPauseLog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPauseLog.Name = "buttonPauseLog";
            this.buttonPauseLog.Size = new System.Drawing.Size(115, 34);
            this.buttonPauseLog.TabIndex = 25;
            this.buttonPauseLog.Text = "Pause";
            this.buttonPauseLog.Click += new System.EventHandler(this.buttonPauseLog_Click);
            // 
            // listBoxCommLog
            // 
            this.listBoxCommLog.BackColor = System.Drawing.Color.Black;
            this.listBoxCommLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.listBoxCommLog.FormattingEnabled = true;
            this.listBoxCommLog.HorizontalScrollbar = true;
            this.listBoxCommLog.ItemHeight = 16;
            this.listBoxCommLog.Location = new System.Drawing.Point(4, 66);
            this.listBoxCommLog.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxCommLog.Name = "listBoxCommLog";
            this.listBoxCommLog.Size = new System.Drawing.Size(1128, 164);
            this.listBoxCommLog.TabIndex = 3;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(1003, 23);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(115, 34);
            this.buttonClear.TabIndex = 24;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.ButtonClearLogClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(37, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Slave delay (ms)";
            // 
            // textBoxSlaveDelay
            // 
            this.textBoxSlaveDelay.Location = new System.Drawing.Point(160, 49);
            this.textBoxSlaveDelay.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSlaveDelay.Name = "textBoxSlaveDelay";
            this.textBoxSlaveDelay.Size = new System.Drawing.Size(52, 22);
            this.textBoxSlaveDelay.TabIndex = 29;
            this.textBoxSlaveDelay.Text = "1";
            this.textBoxSlaveDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(37, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Slave ID";
            // 
            // textBoxSlaveID
            // 
            this.textBoxSlaveID.Location = new System.Drawing.Point(160, 25);
            this.textBoxSlaveID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSlaveID.Name = "textBoxSlaveID";
            this.textBoxSlaveID.Size = new System.Drawing.Size(52, 22);
            this.textBoxSlaveID.TabIndex = 27;
            this.textBoxSlaveID.Text = "1";
            this.textBoxSlaveID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonLED);
            this.groupBox3.Controls.Add(this.radioButtonInteger);
            this.groupBox3.Controls.Add(this.radioButtonHex);
            this.groupBox3.Controls.Add(this.radioButtonBinary);
            this.groupBox3.Location = new System.Drawing.Point(9, 177);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(221, 135);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display Format";
            // 
            // radioButtonLED
            // 
            this.radioButtonLED.Location = new System.Drawing.Point(17, 23);
            this.radioButtonLED.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonLED.Name = "radioButtonLED";
            this.radioButtonLED.Size = new System.Drawing.Size(89, 26);
            this.radioButtonLED.TabIndex = 1;
            this.radioButtonLED.Tag = "LED";
            this.radioButtonLED.Text = "LED";
            this.radioButtonLED.Click += new System.EventHandler(this.RadioButtonDisplayFormatCheckedChanged);
            // 
            // radioButtonInteger
            // 
            this.radioButtonInteger.Checked = true;
            this.radioButtonInteger.Location = new System.Drawing.Point(17, 100);
            this.radioButtonInteger.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonInteger.Name = "radioButtonInteger";
            this.radioButtonInteger.Size = new System.Drawing.Size(89, 26);
            this.radioButtonInteger.TabIndex = 2;
            this.radioButtonInteger.TabStop = true;
            this.radioButtonInteger.Tag = "Integer";
            this.radioButtonInteger.Text = "Integer";
            this.radioButtonInteger.Click += new System.EventHandler(this.RadioButtonDisplayFormatCheckedChanged);
            // 
            // radioButtonHex
            // 
            this.radioButtonHex.Location = new System.Drawing.Point(17, 75);
            this.radioButtonHex.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonHex.Name = "radioButtonHex";
            this.radioButtonHex.Size = new System.Drawing.Size(89, 25);
            this.radioButtonHex.TabIndex = 1;
            this.radioButtonHex.Tag = "Hex";
            this.radioButtonHex.Text = "Hex";
            this.radioButtonHex.Click += new System.EventHandler(this.RadioButtonDisplayFormatCheckedChanged);
            // 
            // radioButtonBinary
            // 
            this.radioButtonBinary.Location = new System.Drawing.Point(17, 49);
            this.radioButtonBinary.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonBinary.Name = "radioButtonBinary";
            this.radioButtonBinary.Size = new System.Drawing.Size(89, 26);
            this.radioButtonBinary.TabIndex = 0;
            this.radioButtonBinary.Tag = "Binary";
            this.radioButtonBinary.Text = "Binary";
            this.radioButtonBinary.Click += new System.EventHandler(this.RadioButtonDisplayFormatCheckedChanged);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(251, 18);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(115, 34);
            this.buttonImport.TabIndex = 26;
            this.buttonImport.Text = "Import";
            this.buttonImport.Click += new System.EventHandler(this.ButtonImportClick);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(251, 62);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(115, 34);
            this.buttonExport.TabIndex = 25;
            this.buttonExport.Text = "Export";
            this.buttonExport.Click += new System.EventHandler(this.ButtonExportClick);
            // 
            // grpStart
            // 
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.groupBoxRTU);
            this.grpStart.Controls.Add(this.groupBoxMode);
            this.grpStart.Controls.Add(this.groupBoxTCP);
            this.grpStart.Location = new System.Drawing.Point(9, 15);
            this.grpStart.Margin = new System.Windows.Forms.Padding(4);
            this.grpStart.Name = "grpStart";
            this.grpStart.Padding = new System.Windows.Forms.Padding(4);
            this.grpStart.Size = new System.Drawing.Size(887, 155);
            this.grpStart.TabIndex = 18;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "Communication";
            // 
            // groupBoxRTU
            // 
            this.groupBoxRTU.Controls.Add(this.comboBoxStopBits);
            this.groupBoxRTU.Controls.Add(this.label10);
            this.groupBoxRTU.Controls.Add(this.comboBoxDataBits);
            this.groupBoxRTU.Controls.Add(this.label9);
            this.groupBoxRTU.Controls.Add(this.comboBoxParity);
            this.groupBoxRTU.Controls.Add(this.labelParity);
            this.groupBoxRTU.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxRTU.Controls.Add(this.comboBoxSerialPorts);
            this.groupBoxRTU.Controls.Add(this.label4);
            this.groupBoxRTU.Controls.Add(this.label5);
            this.groupBoxRTU.Enabled = false;
            this.groupBoxRTU.Location = new System.Drawing.Point(388, 16);
            this.groupBoxRTU.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxRTU.Name = "groupBoxRTU";
            this.groupBoxRTU.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxRTU.Size = new System.Drawing.Size(503, 130);
            this.groupBoxRTU.TabIndex = 25;
            this.groupBoxRTU.TabStop = false;
            this.groupBoxRTU.Text = "RTU";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "None",
            "1 Bit",
            "1.5 Bits",
            "2 Bits"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(373, 59);
            this.comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(124, 24);
            this.comboBoxStopBits.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 64);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Stop Bits =";
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "7 Bits",
            "8 Bits"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(373, 25);
            this.comboBoxDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(124, 24);
            this.comboBoxDataBits.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Data Bits =";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(107, 91);
            this.comboBoxParity.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(124, 24);
            this.comboBoxParity.TabIndex = 23;
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(48, 96);
            this.labelParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(56, 17);
            this.labelParity.TabIndex = 22;
            this.labelParity.Text = "Parity =";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "128000",
            "155200",
            "57600",
            "38400",
            "19200",
            "14400",
            "9600",
            "7200",
            "4800",
            "2400",
            "1800",
            "1200",
            "600",
            "300",
            "150"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(107, 58);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(124, 24);
            this.comboBoxBaudRate.TabIndex = 21;
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(107, 23);
            this.comboBoxSerialPorts.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(124, 24);
            this.comboBoxSerialPorts.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Port Name =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Baud =";
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButtonRTU);
            this.groupBoxMode.Controls.Add(this.radioButtonUDP);
            this.groupBoxMode.Controls.Add(this.radioButtonTCP);
            this.groupBoxMode.Location = new System.Drawing.Point(8, 23);
            this.groupBoxMode.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMode.Size = new System.Drawing.Size(108, 123);
            this.groupBoxMode.TabIndex = 0;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // radioButtonRTU
            // 
            this.radioButtonRTU.AutoSize = true;
            this.radioButtonRTU.Location = new System.Drawing.Point(8, 73);
            this.radioButtonRTU.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonRTU.Name = "radioButtonRTU";
            this.radioButtonRTU.Size = new System.Drawing.Size(58, 21);
            this.radioButtonRTU.TabIndex = 3;
            this.radioButtonRTU.Text = "RTU";
            this.radioButtonRTU.UseVisualStyleBackColor = true;
            this.radioButtonRTU.CheckedChanged += new System.EventHandler(this.RadioButtonModeChanged);
            // 
            // radioButtonUDP
            // 
            this.radioButtonUDP.AutoSize = true;
            this.radioButtonUDP.Location = new System.Drawing.Point(8, 48);
            this.radioButtonUDP.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonUDP.Name = "radioButtonUDP";
            this.radioButtonUDP.Size = new System.Drawing.Size(58, 21);
            this.radioButtonUDP.TabIndex = 2;
            this.radioButtonUDP.Text = "UDP";
            this.radioButtonUDP.UseVisualStyleBackColor = true;
            this.radioButtonUDP.CheckedChanged += new System.EventHandler(this.RadioButtonModeChanged);
            // 
            // radioButtonTCP
            // 
            this.radioButtonTCP.AutoSize = true;
            this.radioButtonTCP.Checked = true;
            this.radioButtonTCP.Location = new System.Drawing.Point(8, 23);
            this.radioButtonTCP.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(56, 21);
            this.radioButtonTCP.TabIndex = 1;
            this.radioButtonTCP.TabStop = true;
            this.radioButtonTCP.Text = "TCP";
            this.radioButtonTCP.UseVisualStyleBackColor = true;
            this.radioButtonTCP.CheckedChanged += new System.EventHandler(this.RadioButtonModeChanged);
            // 
            // groupBoxTCP
            // 
            this.groupBoxTCP.Controls.Add(this.label8);
            this.groupBoxTCP.Controls.Add(this.txtIP);
            this.groupBoxTCP.Controls.Add(this.label6);
            this.groupBoxTCP.Controls.Add(this.textBoxPort);
            this.groupBoxTCP.Location = new System.Drawing.Point(124, 16);
            this.groupBoxTCP.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTCP.Name = "groupBoxTCP";
            this.groupBoxTCP.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTCP.Size = new System.Drawing.Size(256, 130);
            this.groupBoxTCP.TabIndex = 0;
            this.groupBoxTCP.TabStop = false;
            this.groupBoxTCP.Text = "TCP";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 62);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "IP Address";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(105, 58);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(128, 22);
            this.txtIP.TabIndex = 10;
            this.txtIP.Text = "127.0.0.1";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(105, 23);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(57, 22);
            this.textBoxPort.TabIndex = 8;
            this.textBoxPort.Text = "502";
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 320);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1145, 538);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataTab1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1137, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Address1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataTab1
            // 
            this.dataTab1.DataLength = ((ushort)(127));
            this.dataTab1.DisplayFormat = Modbus.Common.DisplayFormat.Integer;
            this.dataTab1.Location = new System.Drawing.Point(4, 4);
            this.dataTab1.Margin = new System.Windows.Forms.Padding(5);
            this.dataTab1.Name = "dataTab1";
            this.dataTab1.RegisterData = null;
            this.dataTab1.ShowDataLength = false;
            this.dataTab1.Size = new System.Drawing.Size(1119, 500);
            this.dataTab1.StartAddress = ((ushort)(4100));
            this.dataTab1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataTab2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1137, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataTab2
            // 
            this.dataTab2.DataLength = ((ushort)(127));
            this.dataTab2.DisplayFormat = Modbus.Common.DisplayFormat.LED;
            this.dataTab2.Location = new System.Drawing.Point(4, 4);
            this.dataTab2.Margin = new System.Windows.Forms.Padding(5);
            this.dataTab2.Name = "dataTab2";
            this.dataTab2.RegisterData = null;
            this.dataTab2.ShowDataLength = false;
            this.dataTab2.Size = new System.Drawing.Size(1119, 500);
            this.dataTab2.StartAddress = ((ushort)(4100));
            this.dataTab2.TabIndex = 0;
            // 
            // grpExchange
            // 
            this.grpExchange.Controls.Add(this.buttonImport);
            this.grpExchange.Controls.Add(this.textBoxSlaveID);
            this.grpExchange.Controls.Add(this.buttonExport);
            this.grpExchange.Controls.Add(this.label1);
            this.grpExchange.Controls.Add(this.label7);
            this.grpExchange.Controls.Add(this.textBoxSlaveDelay);
            this.grpExchange.Location = new System.Drawing.Point(761, 177);
            this.grpExchange.Margin = new System.Windows.Forms.Padding(4);
            this.grpExchange.Name = "grpExchange";
            this.grpExchange.Padding = new System.Windows.Forms.Padding(4);
            this.grpExchange.Size = new System.Drawing.Size(385, 135);
            this.grpExchange.TabIndex = 36;
            this.grpExchange.TabStop = false;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 1055);
            this.Controls.Add(this.grpExchange);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpStart);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaseForm";
            this.Text = "Modbus Slave";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseFormClosing);
            this.Load += new System.EventHandler(this.BaseFormLoading);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.grpStart.ResumeLayout(false);
            this.groupBoxRTU.ResumeLayout(false);
            this.groupBoxRTU.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.groupBoxTCP.ResumeLayout(false);
            this.groupBoxTCP.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grpExchange.ResumeLayout(false);
            this.grpExchange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox4;
        protected System.Windows.Forms.ListBox listBoxCommLog;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox textBoxSlaveID;
        protected System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.RadioButton radioButtonLED;
        protected System.Windows.Forms.RadioButton radioButtonInteger;
        protected System.Windows.Forms.RadioButton radioButtonHex;
        protected System.Windows.Forms.RadioButton radioButtonBinary;
        protected System.Windows.Forms.Button buttonClear;
        protected System.Windows.Forms.Button buttonImport;
        protected System.Windows.Forms.Button buttonExport;
        protected System.Windows.Forms.GroupBox grpStart;
        protected System.Windows.Forms.GroupBox groupBoxRTU;
        protected System.Windows.Forms.ComboBox comboBoxSerialPorts;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.GroupBox groupBoxMode;
        protected System.Windows.Forms.RadioButton radioButtonUDP;
        protected System.Windows.Forms.RadioButton radioButtonTCP;
        protected System.Windows.Forms.GroupBox groupBoxTCP;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox textBoxPort;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox textBoxSlaveDelay;
        protected System.Windows.Forms.ComboBox comboBoxBaudRate;
        protected System.Windows.Forms.RadioButton radioButtonRTU;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txtIP;
        protected System.Windows.Forms.ComboBox comboBoxStopBits;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.ComboBox comboBoxDataBits;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.ComboBox comboBoxParity;
        protected System.Windows.Forms.Label labelParity;
        protected System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.TabPage tabPage2;
        protected DataTab dataTab1;
        protected DataTab dataTab2;
        protected System.Windows.Forms.GroupBox grpExchange;
        protected System.Windows.Forms.Button buttonPauseLog;
    }
}