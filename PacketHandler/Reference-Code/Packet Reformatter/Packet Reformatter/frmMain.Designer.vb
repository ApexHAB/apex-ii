<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblPort = New System.Windows.Forms.Label
        Me.nbrPort = New System.Windows.Forms.NumericUpDown
        Me.nbrIP4 = New System.Windows.Forms.NumericUpDown
        Me.nbrIP3 = New System.Windows.Forms.NumericUpDown
        Me.nbrIP2 = New System.Windows.Forms.NumericUpDown
        Me.nbrIP1 = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblConnect = New System.Windows.Forms.Label
        Me.lstMessages = New System.Windows.Forms.ListBox
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lstPorts = New System.Windows.Forms.ListBox
        Me.lstCapabilities = New System.Windows.Forms.ListBox
        Me.lblCallsign = New System.Windows.Forms.Label
        Me.txtCallsign = New System.Windows.Forms.TextBox
        Me.lblCallto = New System.Windows.Forms.Label
        Me.txtCallTo = New System.Windows.Forms.TextBox
        Me.btnAuto = New System.Windows.Forms.Button
        Me.lblSettings = New System.Windows.Forms.Label
        Me.chkDefaultPort = New System.Windows.Forms.CheckBox
        Me.nbrDefaultPort = New System.Windows.Forms.NumericUpDown
        Me.chkAuto = New System.Windows.Forms.CheckBox
        Me.lblSerialPort = New System.Windows.Forms.Label
        Me.cmbSerialPorts = New System.Windows.Forms.ComboBox
        Me.lblBaud = New System.Windows.Forms.Label
        Me.lblSerial = New System.Windows.Forms.Label
        Me.nbrBaud = New System.Windows.Forms.NumericUpDown
        Me.lblStopBits = New System.Windows.Forms.Label
        Me.lblParity = New System.Windows.Forms.Label
        Me.cmbStopBits = New System.Windows.Forms.ComboBox
        Me.cmbParity = New System.Windows.Forms.ComboBox
        Me.grpManual = New System.Windows.Forms.GroupBox
        Me.btnSerial = New System.Windows.Forms.Button
        Me.btnDecode = New System.Windows.Forms.Button
        Me.lblUKHAS = New System.Windows.Forms.Label
        Me.txtUKHAS = New System.Windows.Forms.TextBox
        Me.lblCustom = New System.Windows.Forms.Label
        Me.lblAltitude = New System.Windows.Forms.Label
        Me.lblSpeed = New System.Windows.Forms.Label
        Me.lblHeading = New System.Windows.Forms.Label
        Me.lblLongS = New System.Windows.Forms.Label
        Me.lblLongM = New System.Windows.Forms.Label
        Me.lblLongD = New System.Windows.Forms.Label
        Me.lblLatS = New System.Windows.Forms.Label
        Me.lblLatM = New System.Windows.Forms.Label
        Me.lblLatD = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.txtCustom = New System.Windows.Forms.TextBox
        Me.txtAltitude = New System.Windows.Forms.TextBox
        Me.txtSpeed = New System.Windows.Forms.TextBox
        Me.txtHeading = New System.Windows.Forms.TextBox
        Me.txtLongS = New System.Windows.Forms.TextBox
        Me.txtLongM = New System.Windows.Forms.TextBox
        Me.txtLongD = New System.Windows.Forms.TextBox
        Me.txtLatS = New System.Windows.Forms.TextBox
        Me.txtLatM = New System.Windows.Forms.TextBox
        Me.txtLatD = New System.Windows.Forms.TextBox
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.txtPosition = New System.Windows.Forms.TextBox
        Me.lblPosition = New System.Windows.Forms.Label
        Me.cmbFrameSelect = New System.Windows.Forms.ComboBox
        Me.btnDisconnect = New System.Windows.Forms.Button
        Me.btnSend = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.chkManual = New System.Windows.Forms.CheckBox
        Me.lblSerialConnect = New System.Windows.Forms.Label
        Me.lblSave = New System.Windows.Forms.Label
        Me.dlogSave = New System.Windows.Forms.SaveFileDialog
        Me.txtSave = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.grpManualM = New System.Windows.Forms.GroupBox
        Me.optManual = New System.Windows.Forms.RadioButton
        Me.optAssemble = New System.Windows.Forms.RadioButton
        CType(Me.nbrPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrIP4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrIP3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrIP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrIP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrDefaultPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrBaud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpManual.SuspendLayout()
        Me.grpManualM.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(14, 70)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(66, 13)
        Me.lblPort.TabIndex = 4
        Me.lblPort.Text = "Port Number"
        '
        'nbrPort
        '
        Me.nbrPort.Location = New System.Drawing.Point(86, 68)
        Me.nbrPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nbrPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrPort.Name = "nbrPort"
        Me.nbrPort.Size = New System.Drawing.Size(68, 20)
        Me.nbrPort.TabIndex = 5
        Me.nbrPort.Value = New Decimal(New Integer() {8000, 0, 0, 0})
        '
        'nbrIP4
        '
        Me.nbrIP4.Location = New System.Drawing.Point(218, 42)
        Me.nbrIP4.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nbrIP4.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrIP4.Name = "nbrIP4"
        Me.nbrIP4.Size = New System.Drawing.Size(38, 20)
        Me.nbrIP4.TabIndex = 26
        Me.nbrIP4.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nbrIP3
        '
        Me.nbrIP3.Location = New System.Drawing.Point(174, 42)
        Me.nbrIP3.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nbrIP3.Name = "nbrIP3"
        Me.nbrIP3.Size = New System.Drawing.Size(38, 20)
        Me.nbrIP3.TabIndex = 25
        '
        'nbrIP2
        '
        Me.nbrIP2.Location = New System.Drawing.Point(130, 42)
        Me.nbrIP2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nbrIP2.Name = "nbrIP2"
        Me.nbrIP2.Size = New System.Drawing.Size(38, 20)
        Me.nbrIP2.TabIndex = 24
        '
        'nbrIP1
        '
        Me.nbrIP1.Location = New System.Drawing.Point(86, 42)
        Me.nbrIP1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nbrIP1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrIP1.Name = "nbrIP1"
        Me.nbrIP1.Size = New System.Drawing.Size(38, 20)
        Me.nbrIP1.TabIndex = 23
        Me.nbrIP1.Value = New Decimal(New Integer() {127, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "IP Address"
        '
        'lblConnect
        '
        Me.lblConnect.AutoSize = True
        Me.lblConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnect.Location = New System.Drawing.Point(14, 496)
        Me.lblConnect.Name = "lblConnect"
        Me.lblConnect.Size = New System.Drawing.Size(228, 25)
        Me.lblConnect.TabIndex = 27
        Me.lblConnect.Text = "AGWPE CONNECTED"
        Me.lblConnect.Visible = False
        '
        'lstMessages
        '
        Me.lstMessages.FormattingEnabled = True
        Me.lstMessages.HorizontalScrollbar = True
        Me.lstMessages.Items.AddRange(New Object() {"Messages:"})
        Me.lstMessages.Location = New System.Drawing.Point(250, 300)
        Me.lstMessages.Name = "lstMessages"
        Me.lstMessages.Size = New System.Drawing.Size(292, 238)
        Me.lstMessages.TabIndex = 35
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(340, 102)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(74, 13)
        Me.lblVersion.TabIndex = 36
        Me.lblVersion.Text = "AGWPE Vers."
        '
        'lstPorts
        '
        Me.lstPorts.FormattingEnabled = True
        Me.lstPorts.Items.AddRange(New Object() {"Available Ports"})
        Me.lstPorts.Location = New System.Drawing.Point(343, 124)
        Me.lstPorts.Name = "lstPorts"
        Me.lstPorts.Size = New System.Drawing.Size(199, 56)
        Me.lstPorts.TabIndex = 37
        '
        'lstCapabilities
        '
        Me.lstCapabilities.FormattingEnabled = True
        Me.lstCapabilities.Location = New System.Drawing.Point(343, 186)
        Me.lstCapabilities.Name = "lstCapabilities"
        Me.lstCapabilities.Size = New System.Drawing.Size(199, 108)
        Me.lstCapabilities.TabIndex = 38
        '
        'lblCallsign
        '
        Me.lblCallsign.AutoSize = True
        Me.lblCallsign.Location = New System.Drawing.Point(14, 144)
        Me.lblCallsign.Name = "lblCallsign"
        Me.lblCallsign.Size = New System.Drawing.Size(60, 13)
        Me.lblCallsign.TabIndex = 39
        Me.lblCallsign.Text = "My Callsign"
        '
        'txtCallsign
        '
        Me.txtCallsign.Location = New System.Drawing.Point(86, 141)
        Me.txtCallsign.Name = "txtCallsign"
        Me.txtCallsign.Size = New System.Drawing.Size(92, 20)
        Me.txtCallsign.TabIndex = 40
        Me.txtCallsign.Text = "M6VXO  "
        '
        'lblCallto
        '
        Me.lblCallto.AutoSize = True
        Me.lblCallto.Location = New System.Drawing.Point(14, 173)
        Me.lblCallto.Name = "lblCallto"
        Me.lblCallto.Size = New System.Drawing.Size(40, 13)
        Me.lblCallto.TabIndex = 41
        Me.lblCallto.Text = "Call To"
        '
        'txtCallTo
        '
        Me.txtCallTo.Location = New System.Drawing.Point(86, 170)
        Me.txtCallTo.Name = "txtCallTo"
        Me.txtCallTo.Size = New System.Drawing.Size(92, 20)
        Me.txtCallTo.TabIndex = 42
        Me.txtCallTo.Text = "TESTRM2"
        '
        'btnAuto
        '
        Me.btnAuto.Location = New System.Drawing.Point(15, 456)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.Size = New System.Drawing.Size(100, 26)
        Me.btnAuto.TabIndex = 49
        Me.btnAuto.Text = "Auto Connect"
        Me.btnAuto.UseVisualStyleBackColor = True
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettings.Location = New System.Drawing.Point(12, 9)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(90, 25)
        Me.lblSettings.TabIndex = 50
        Me.lblSettings.Text = "Settings"
        '
        'chkDefaultPort
        '
        Me.chkDefaultPort.AutoSize = True
        Me.chkDefaultPort.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDefaultPort.Checked = True
        Me.chkDefaultPort.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDefaultPort.Location = New System.Drawing.Point(12, 110)
        Me.chkDefaultPort.Name = "chkDefaultPort"
        Me.chkDefaultPort.Size = New System.Drawing.Size(82, 17)
        Me.chkDefaultPort.TabIndex = 51
        Me.chkDefaultPort.Text = "Default Port"
        Me.chkDefaultPort.UseVisualStyleBackColor = True
        '
        'nbrDefaultPort
        '
        Me.nbrDefaultPort.Location = New System.Drawing.Point(105, 109)
        Me.nbrDefaultPort.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nbrDefaultPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrDefaultPort.Name = "nbrDefaultPort"
        Me.nbrDefaultPort.Size = New System.Drawing.Size(32, 20)
        Me.nbrDefaultPort.TabIndex = 52
        Me.nbrDefaultPort.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Checked = True
        Me.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAuto.Location = New System.Drawing.Point(124, 459)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(67, 17)
        Me.chkAuto.TabIndex = 53
        Me.chkAuto.Text = "Full Auto"
        Me.chkAuto.UseVisualStyleBackColor = True
        '
        'lblSerialPort
        '
        Me.lblSerialPort.AutoSize = True
        Me.lblSerialPort.Location = New System.Drawing.Point(14, 277)
        Me.lblSerialPort.Name = "lblSerialPort"
        Me.lblSerialPort.Size = New System.Drawing.Size(26, 13)
        Me.lblSerialPort.TabIndex = 82
        Me.lblSerialPort.Text = "Port"
        '
        'cmbSerialPorts
        '
        Me.cmbSerialPorts.FormattingEnabled = True
        Me.cmbSerialPorts.Location = New System.Drawing.Point(86, 274)
        Me.cmbSerialPorts.Name = "cmbSerialPorts"
        Me.cmbSerialPorts.Size = New System.Drawing.Size(92, 21)
        Me.cmbSerialPorts.TabIndex = 83
        Me.cmbSerialPorts.Text = "COM1"
        '
        'lblBaud
        '
        Me.lblBaud.AutoSize = True
        Me.lblBaud.Location = New System.Drawing.Point(14, 303)
        Me.lblBaud.Name = "lblBaud"
        Me.lblBaud.Size = New System.Drawing.Size(32, 13)
        Me.lblBaud.TabIndex = 84
        Me.lblBaud.Text = "Baud"
        '
        'lblSerial
        '
        Me.lblSerial.AutoSize = True
        Me.lblSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerial.Location = New System.Drawing.Point(12, 247)
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.Size = New System.Drawing.Size(49, 20)
        Me.lblSerial.TabIndex = 85
        Me.lblSerial.Text = "Serial"
        '
        'nbrBaud
        '
        Me.nbrBaud.Location = New System.Drawing.Point(86, 301)
        Me.nbrBaud.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nbrBaud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrBaud.Name = "nbrBaud"
        Me.nbrBaud.Size = New System.Drawing.Size(92, 20)
        Me.nbrBaud.TabIndex = 86
        Me.nbrBaud.Value = New Decimal(New Integer() {9600, 0, 0, 0})
        '
        'lblStopBits
        '
        Me.lblStopBits.AutoSize = True
        Me.lblStopBits.Location = New System.Drawing.Point(14, 330)
        Me.lblStopBits.Name = "lblStopBits"
        Me.lblStopBits.Size = New System.Drawing.Size(49, 13)
        Me.lblStopBits.TabIndex = 87
        Me.lblStopBits.Text = "Stop Bits"
        '
        'lblParity
        '
        Me.lblParity.AutoSize = True
        Me.lblParity.Location = New System.Drawing.Point(14, 357)
        Me.lblParity.Name = "lblParity"
        Me.lblParity.Size = New System.Drawing.Size(33, 13)
        Me.lblParity.TabIndex = 89
        Me.lblParity.Text = "Parity"
        '
        'cmbStopBits
        '
        Me.cmbStopBits.FormattingEnabled = True
        Me.cmbStopBits.Items.AddRange(New Object() {"One", "OnePointFive", "Two"})
        Me.cmbStopBits.Location = New System.Drawing.Point(86, 327)
        Me.cmbStopBits.Name = "cmbStopBits"
        Me.cmbStopBits.Size = New System.Drawing.Size(92, 21)
        Me.cmbStopBits.TabIndex = 90
        Me.cmbStopBits.Text = "One"
        '
        'cmbParity
        '
        Me.cmbParity.FormattingEnabled = True
        Me.cmbParity.Items.AddRange(New Object() {"None", "Odd", "Even", "Mark", "Space"})
        Me.cmbParity.Location = New System.Drawing.Point(86, 354)
        Me.cmbParity.Name = "cmbParity"
        Me.cmbParity.Size = New System.Drawing.Size(92, 21)
        Me.cmbParity.TabIndex = 91
        Me.cmbParity.Text = "None"
        '
        'grpManual
        '
        Me.grpManual.Controls.Add(Me.btnSerial)
        Me.grpManual.Controls.Add(Me.grpManualM)
        Me.grpManual.Controls.Add(Me.btnDecode)
        Me.grpManual.Controls.Add(Me.lblUKHAS)
        Me.grpManual.Controls.Add(Me.txtUKHAS)
        Me.grpManual.Controls.Add(Me.lblCustom)
        Me.grpManual.Controls.Add(Me.lblAltitude)
        Me.grpManual.Controls.Add(Me.lblSpeed)
        Me.grpManual.Controls.Add(Me.lblHeading)
        Me.grpManual.Controls.Add(Me.lblLongS)
        Me.grpManual.Controls.Add(Me.lblLongM)
        Me.grpManual.Controls.Add(Me.lblLongD)
        Me.grpManual.Controls.Add(Me.lblLatS)
        Me.grpManual.Controls.Add(Me.lblLatM)
        Me.grpManual.Controls.Add(Me.lblLatD)
        Me.grpManual.Controls.Add(Me.lblTime)
        Me.grpManual.Controls.Add(Me.txtCustom)
        Me.grpManual.Controls.Add(Me.txtAltitude)
        Me.grpManual.Controls.Add(Me.txtSpeed)
        Me.grpManual.Controls.Add(Me.txtHeading)
        Me.grpManual.Controls.Add(Me.txtLongS)
        Me.grpManual.Controls.Add(Me.txtLongM)
        Me.grpManual.Controls.Add(Me.txtLongD)
        Me.grpManual.Controls.Add(Me.txtLatS)
        Me.grpManual.Controls.Add(Me.txtLatM)
        Me.grpManual.Controls.Add(Me.txtLatD)
        Me.grpManual.Controls.Add(Me.txtTime)
        Me.grpManual.Controls.Add(Me.btnRefresh)
        Me.grpManual.Controls.Add(Me.txtPosition)
        Me.grpManual.Controls.Add(Me.lblPosition)
        Me.grpManual.Controls.Add(Me.cmbFrameSelect)
        Me.grpManual.Controls.Add(Me.btnDisconnect)
        Me.grpManual.Controls.Add(Me.btnSend)
        Me.grpManual.Controls.Add(Me.btnConnect)
        Me.grpManual.Enabled = False
        Me.grpManual.Location = New System.Drawing.Point(548, 10)
        Me.grpManual.Name = "grpManual"
        Me.grpManual.Size = New System.Drawing.Size(368, 530)
        Me.grpManual.TabIndex = 92
        Me.grpManual.TabStop = False
        Me.grpManual.Text = "Manual"
        '
        'btnSerial
        '
        Me.btnSerial.Location = New System.Drawing.Point(141, 147)
        Me.btnSerial.Name = "btnSerial"
        Me.btnSerial.Size = New System.Drawing.Size(100, 23)
        Me.btnSerial.TabIndex = 115
        Me.btnSerial.Text = "Serial Listen"
        Me.btnSerial.UseVisualStyleBackColor = True
        '
        'btnDecode
        '
        Me.btnDecode.Location = New System.Drawing.Point(26, 147)
        Me.btnDecode.Name = "btnDecode"
        Me.btnDecode.Size = New System.Drawing.Size(100, 23)
        Me.btnDecode.TabIndex = 114
        Me.btnDecode.Text = "Decode"
        Me.btnDecode.UseVisualStyleBackColor = True
        '
        'lblUKHAS
        '
        Me.lblUKHAS.AutoSize = True
        Me.lblUKHAS.Location = New System.Drawing.Point(7, 90)
        Me.lblUKHAS.Name = "lblUKHAS"
        Me.lblUKHAS.Size = New System.Drawing.Size(81, 13)
        Me.lblUKHAS.TabIndex = 113
        Me.lblUKHAS.Text = "UKHAS Packet"
        '
        'txtUKHAS
        '
        Me.txtUKHAS.Location = New System.Drawing.Point(98, 87)
        Me.txtUKHAS.Multiline = True
        Me.txtUKHAS.Name = "txtUKHAS"
        Me.txtUKHAS.Size = New System.Drawing.Size(258, 43)
        Me.txtUKHAS.TabIndex = 112
        Me.txtUKHAS.Text = "$$RIGEMO,1,13:01:09,23.123456,098.756483,00100,AVDATA-IT28OT25PP3536 SGSBALLOON"
        '
        'lblCustom
        '
        Me.lblCustom.AutoSize = True
        Me.lblCustom.Location = New System.Drawing.Point(5, 475)
        Me.lblCustom.Name = "lblCustom"
        Me.lblCustom.Size = New System.Drawing.Size(42, 13)
        Me.lblCustom.TabIndex = 111
        Me.lblCustom.Text = "Custom"
        '
        'lblAltitude
        '
        Me.lblAltitude.AutoSize = True
        Me.lblAltitude.Location = New System.Drawing.Point(186, 447)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(42, 13)
        Me.lblAltitude.TabIndex = 110
        Me.lblAltitude.Text = "Altitude"
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.Location = New System.Drawing.Point(6, 447)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(38, 13)
        Me.lblSpeed.TabIndex = 109
        Me.lblSpeed.Text = "Speed"
        '
        'lblHeading
        '
        Me.lblHeading.AutoSize = True
        Me.lblHeading.Location = New System.Drawing.Point(186, 421)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(47, 13)
        Me.lblHeading.TabIndex = 108
        Me.lblHeading.Text = "Heading"
        '
        'lblLongS
        '
        Me.lblLongS.AutoSize = True
        Me.lblLongS.Location = New System.Drawing.Point(5, 423)
        Me.lblLongS.Name = "lblLongS"
        Me.lblLongS.Size = New System.Drawing.Size(53, 13)
        Me.lblLongS.TabIndex = 107
        Me.lblLongS.Text = "Long Sec"
        '
        'lblLongM
        '
        Me.lblLongM.AutoSize = True
        Me.lblLongM.Location = New System.Drawing.Point(186, 395)
        Me.lblLongM.Name = "lblLongM"
        Me.lblLongM.Size = New System.Drawing.Size(51, 13)
        Me.lblLongM.TabIndex = 106
        Me.lblLongM.Text = "Long Min"
        '
        'lblLongD
        '
        Me.lblLongD.AutoSize = True
        Me.lblLongD.Location = New System.Drawing.Point(5, 396)
        Me.lblLongD.Name = "lblLongD"
        Me.lblLongD.Size = New System.Drawing.Size(54, 13)
        Me.lblLongD.TabIndex = 105
        Me.lblLongD.Text = "Long Deg"
        '
        'lblLatS
        '
        Me.lblLatS.AutoSize = True
        Me.lblLatS.Location = New System.Drawing.Point(186, 369)
        Me.lblLatS.Name = "lblLatS"
        Me.lblLatS.Size = New System.Drawing.Size(44, 13)
        Me.lblLatS.TabIndex = 104
        Me.lblLatS.Text = "Lat Sec"
        '
        'lblLatM
        '
        Me.lblLatM.AutoSize = True
        Me.lblLatM.Location = New System.Drawing.Point(5, 370)
        Me.lblLatM.Name = "lblLatM"
        Me.lblLatM.Size = New System.Drawing.Size(42, 13)
        Me.lblLatM.TabIndex = 103
        Me.lblLatM.Text = "Lat Min"
        '
        'lblLatD
        '
        Me.lblLatD.AutoSize = True
        Me.lblLatD.Location = New System.Drawing.Point(186, 343)
        Me.lblLatD.Name = "lblLatD"
        Me.lblLatD.Size = New System.Drawing.Size(45, 13)
        Me.lblLatD.TabIndex = 102
        Me.lblLatD.Text = "Lat Deg"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(5, 343)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(30, 13)
        Me.lblTime.TabIndex = 101
        Me.lblTime.Text = "Time"
        '
        'txtCustom
        '
        Me.txtCustom.Location = New System.Drawing.Point(65, 472)
        Me.txtCustom.Name = "txtCustom"
        Me.txtCustom.Size = New System.Drawing.Size(291, 20)
        Me.txtCustom.TabIndex = 100
        Me.txtCustom.Text = "AVDATA-IT28OT25PP3536 SGSBALLOON"
        '
        'txtAltitude
        '
        Me.txtAltitude.Location = New System.Drawing.Point(241, 444)
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(115, 20)
        Me.txtAltitude.TabIndex = 99
        Me.txtAltitude.Text = "000000"
        '
        'txtSpeed
        '
        Me.txtSpeed.Location = New System.Drawing.Point(65, 446)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(115, 20)
        Me.txtSpeed.TabIndex = 98
        Me.txtSpeed.Text = "000"
        '
        'txtHeading
        '
        Me.txtHeading.Location = New System.Drawing.Point(241, 418)
        Me.txtHeading.Name = "txtHeading"
        Me.txtHeading.Size = New System.Drawing.Size(115, 20)
        Me.txtHeading.TabIndex = 97
        Me.txtHeading.Text = "085"
        '
        'txtLongS
        '
        Me.txtLongS.Location = New System.Drawing.Point(65, 420)
        Me.txtLongS.Name = "txtLongS"
        Me.txtLongS.Size = New System.Drawing.Size(115, 20)
        Me.txtLongS.TabIndex = 96
        Me.txtLongS.Text = "03"
        '
        'txtLongM
        '
        Me.txtLongM.Location = New System.Drawing.Point(241, 392)
        Me.txtLongM.Name = "txtLongM"
        Me.txtLongM.Size = New System.Drawing.Size(115, 20)
        Me.txtLongM.TabIndex = 95
        Me.txtLongM.Text = "18"
        '
        'txtLongD
        '
        Me.txtLongD.Location = New System.Drawing.Point(65, 393)
        Me.txtLongD.Name = "txtLongD"
        Me.txtLongD.Size = New System.Drawing.Size(115, 20)
        Me.txtLongD.TabIndex = 94
        Me.txtLongD.Text = "000"
        '
        'txtLatS
        '
        Me.txtLatS.Location = New System.Drawing.Point(241, 366)
        Me.txtLatS.Name = "txtLatS"
        Me.txtLatS.Size = New System.Drawing.Size(115, 20)
        Me.txtLatS.TabIndex = 93
        Me.txtLatS.Text = "07"
        '
        'txtLatM
        '
        Me.txtLatM.Location = New System.Drawing.Point(65, 367)
        Me.txtLatM.Name = "txtLatM"
        Me.txtLatM.Size = New System.Drawing.Size(115, 20)
        Me.txtLatM.TabIndex = 92
        Me.txtLatM.Text = "19"
        '
        'txtLatD
        '
        Me.txtLatD.Location = New System.Drawing.Point(241, 340)
        Me.txtLatD.Name = "txtLatD"
        Me.txtLatD.Size = New System.Drawing.Size(115, 20)
        Me.txtLatD.TabIndex = 91
        Me.txtLatD.Text = "51"
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(65, 341)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(115, 20)
        Me.txtTime.TabIndex = 90
        Me.txtTime.Text = "125000"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(141, 60)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(62, 21)
        Me.btnRefresh.TabIndex = 87
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(63, 264)
        Me.txtPosition.Multiline = True
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(293, 48)
        Me.txtPosition.TabIndex = 86
        Me.txtPosition.Text = "@125001h5121.89N/00011.43W085/000/A=000000AVDATA-IT28OT25PP3536 SGSBALLOON"
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Location = New System.Drawing.Point(7, 267)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(44, 13)
        Me.lblPosition.TabIndex = 85
        Me.lblPosition.Text = "Position"
        '
        'cmbFrameSelect
        '
        Me.cmbFrameSelect.FormattingEnabled = True
        Me.cmbFrameSelect.Items.AddRange(New Object() {"R", "G", "g", "m", "M", "M*"})
        Me.cmbFrameSelect.Location = New System.Drawing.Point(10, 60)
        Me.cmbFrameSelect.Name = "cmbFrameSelect"
        Me.cmbFrameSelect.Size = New System.Drawing.Size(116, 21)
        Me.cmbFrameSelect.TabIndex = 84
        Me.cmbFrameSelect.Text = "Select Frame Type"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(218, 19)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(98, 32)
        Me.btnDisconnect.TabIndex = 83
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(114, 19)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(98, 32)
        Me.btnSend.TabIndex = 82
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(10, 19)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(98, 32)
        Me.btnConnect.TabIndex = 81
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'chkManual
        '
        Me.chkManual.AutoSize = True
        Me.chkManual.Location = New System.Drawing.Point(458, 17)
        Me.chkManual.Name = "chkManual"
        Me.chkManual.Size = New System.Drawing.Size(84, 17)
        Me.chkManual.TabIndex = 93
        Me.chkManual.Text = "Manual Op?"
        Me.chkManual.UseVisualStyleBackColor = True
        '
        'lblSerialConnect
        '
        Me.lblSerialConnect.AutoSize = True
        Me.lblSerialConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialConnect.Location = New System.Drawing.Point(14, 536)
        Me.lblSerialConnect.Name = "lblSerialConnect"
        Me.lblSerialConnect.Size = New System.Drawing.Size(151, 25)
        Me.lblSerialConnect.TabIndex = 94
        Me.lblSerialConnect.Text = "SERIAL OPEN"
        Me.lblSerialConnect.Visible = False
        '
        'lblSave
        '
        Me.lblSave.AutoSize = True
        Me.lblSave.Location = New System.Drawing.Point(14, 200)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(76, 13)
        Me.lblSave.TabIndex = 95
        Me.lblSave.Text = "Save Location"
        '
        'dlogSave
        '
        Me.dlogSave.DefaultExt = "txt"
        Me.dlogSave.FileName = "log.txt"
        Me.dlogSave.Filter = "Text Files|*.txt|All files|*.*"
        Me.dlogSave.Title = "Save"
        '
        'txtSave
        '
        Me.txtSave.Location = New System.Drawing.Point(96, 196)
        Me.txtSave.Name = "txtSave"
        Me.txtSave.Size = New System.Drawing.Size(98, 20)
        Me.txtSave.TabIndex = 96
        Me.txtSave.Text = "log.txt"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(203, 196)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(63, 20)
        Me.btnBrowse.TabIndex = 97
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(63, 381)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 26)
        Me.btnSave.TabIndex = 98
        Me.btnSave.Text = "Save Settings"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpManualM
        '
        Me.grpManualM.Controls.Add(Me.optAssemble)
        Me.grpManualM.Controls.Add(Me.optManual)
        Me.grpManualM.Location = New System.Drawing.Point(10, 186)
        Me.grpManualM.Name = "grpManualM"
        Me.grpManualM.Size = New System.Drawing.Size(190, 63)
        Me.grpManualM.TabIndex = 116
        Me.grpManualM.TabStop = False
        Me.grpManualM.Text = "M Frame mode"
        '
        'optManual
        '
        Me.optManual.AutoSize = True
        Me.optManual.Checked = True
        Me.optManual.Location = New System.Drawing.Point(6, 19)
        Me.optManual.Name = "optManual"
        Me.optManual.Size = New System.Drawing.Size(164, 17)
        Me.optManual.TabIndex = 0
        Me.optManual.TabStop = True
        Me.optManual.Text = "Full manual (Position text box)"
        Me.optManual.UseVisualStyleBackColor = True
        '
        'optAssemble
        '
        Me.optAssemble.AutoSize = True
        Me.optAssemble.Location = New System.Drawing.Point(6, 42)
        Me.optAssemble.Name = "optAssemble"
        Me.optAssemble.Size = New System.Drawing.Size(70, 17)
        Me.optAssemble.TabIndex = 1
        Me.optAssemble.Text = "Assemble"
        Me.optAssemble.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 578)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtSave)
        Me.Controls.Add(Me.lblSave)
        Me.Controls.Add(Me.lblSerialConnect)
        Me.Controls.Add(Me.chkManual)
        Me.Controls.Add(Me.cmbParity)
        Me.Controls.Add(Me.cmbStopBits)
        Me.Controls.Add(Me.lblParity)
        Me.Controls.Add(Me.lblStopBits)
        Me.Controls.Add(Me.nbrBaud)
        Me.Controls.Add(Me.lblSerial)
        Me.Controls.Add(Me.lblBaud)
        Me.Controls.Add(Me.cmbSerialPorts)
        Me.Controls.Add(Me.lblSerialPort)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.nbrDefaultPort)
        Me.Controls.Add(Me.chkDefaultPort)
        Me.Controls.Add(Me.lblSettings)
        Me.Controls.Add(Me.btnAuto)
        Me.Controls.Add(Me.txtCallTo)
        Me.Controls.Add(Me.lblCallto)
        Me.Controls.Add(Me.txtCallsign)
        Me.Controls.Add(Me.lblCallsign)
        Me.Controls.Add(Me.lstCapabilities)
        Me.Controls.Add(Me.lstPorts)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lstMessages)
        Me.Controls.Add(Me.lblConnect)
        Me.Controls.Add(Me.nbrIP4)
        Me.Controls.Add(Me.nbrIP3)
        Me.Controls.Add(Me.nbrIP2)
        Me.Controls.Add(Me.nbrIP1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nbrPort)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.grpManual)
        Me.Name = "frmMain"
        Me.Text = "Packet Main"
        CType(Me.nbrPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrIP4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrIP3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrIP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrIP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrDefaultPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrBaud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpManual.ResumeLayout(False)
        Me.grpManual.PerformLayout()
        Me.grpManualM.ResumeLayout(False)
        Me.grpManualM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents nbrPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrIP4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrIP3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrIP2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrIP1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblConnect As System.Windows.Forms.Label
    Friend WithEvents lstMessages As System.Windows.Forms.ListBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lstPorts As System.Windows.Forms.ListBox
    Friend WithEvents lstCapabilities As System.Windows.Forms.ListBox
    Friend WithEvents lblCallsign As System.Windows.Forms.Label
    Friend WithEvents txtCallsign As System.Windows.Forms.TextBox
    Friend WithEvents lblCallto As System.Windows.Forms.Label
    Friend WithEvents txtCallTo As System.Windows.Forms.TextBox
    Friend WithEvents btnAuto As System.Windows.Forms.Button
    Friend WithEvents lblSettings As System.Windows.Forms.Label
    Friend WithEvents chkDefaultPort As System.Windows.Forms.CheckBox
    Friend WithEvents nbrDefaultPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
    Friend WithEvents lblSerialPort As System.Windows.Forms.Label
    Friend WithEvents cmbSerialPorts As System.Windows.Forms.ComboBox
    Friend WithEvents lblBaud As System.Windows.Forms.Label
    Friend WithEvents lblSerial As System.Windows.Forms.Label
    Friend WithEvents nbrBaud As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStopBits As System.Windows.Forms.Label
    Friend WithEvents lblParity As System.Windows.Forms.Label
    Friend WithEvents cmbStopBits As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParity As System.Windows.Forms.ComboBox
    Friend WithEvents grpManual As System.Windows.Forms.GroupBox
    Friend WithEvents btnDecode As System.Windows.Forms.Button
    Friend WithEvents lblUKHAS As System.Windows.Forms.Label
    Friend WithEvents txtUKHAS As System.Windows.Forms.TextBox
    Friend WithEvents lblCustom As System.Windows.Forms.Label
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents lblLongS As System.Windows.Forms.Label
    Friend WithEvents lblLongM As System.Windows.Forms.Label
    Friend WithEvents lblLongD As System.Windows.Forms.Label
    Friend WithEvents lblLatS As System.Windows.Forms.Label
    Friend WithEvents lblLatM As System.Windows.Forms.Label
    Friend WithEvents lblLatD As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents txtCustom As System.Windows.Forms.TextBox
    Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
    Friend WithEvents txtSpeed As System.Windows.Forms.TextBox
    Friend WithEvents txtHeading As System.Windows.Forms.TextBox
    Friend WithEvents txtLongS As System.Windows.Forms.TextBox
    Friend WithEvents txtLongM As System.Windows.Forms.TextBox
    Friend WithEvents txtLongD As System.Windows.Forms.TextBox
    Friend WithEvents txtLatS As System.Windows.Forms.TextBox
    Friend WithEvents txtLatM As System.Windows.Forms.TextBox
    Friend WithEvents txtLatD As System.Windows.Forms.TextBox
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents cmbFrameSelect As System.Windows.Forms.ComboBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents chkManual As System.Windows.Forms.CheckBox
    Friend WithEvents lblSerialConnect As System.Windows.Forms.Label
    Friend WithEvents btnSerial As System.Windows.Forms.Button
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents dlogSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtSave As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpManualM As System.Windows.Forms.GroupBox
    Friend WithEvents optAssemble As System.Windows.Forms.RadioButton
    Friend WithEvents optManual As System.Windows.Forms.RadioButton

End Class
