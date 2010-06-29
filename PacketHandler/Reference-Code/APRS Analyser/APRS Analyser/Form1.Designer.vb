<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container
        Me.btnProcess = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lbIT = New System.Windows.Forms.Label
        Me.lbOT = New System.Windows.Forms.Label
        Me.lbPP = New System.Windows.Forms.Label
        Me.lbBV = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbTimer = New System.Windows.Forms.Label
        Me.lbError = New System.Windows.Forms.Label
        Me.lbcomment = New System.Windows.Forms.Label
        Me.lbCoordinates = New System.Windows.Forms.Label
        Me.lbHeading = New System.Windows.Forms.Label
        Me.lbAlt = New System.Windows.Forms.Label
        Me.lbSpeed = New System.Windows.Forms.Label
        Me.lbTime = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSaveKML = New System.Windows.Forms.Button
        Me.TC1 = New System.Windows.Forms.TabControl
        Me.TBAll = New System.Windows.Forms.TabPage
        Me.RTBAll = New System.Windows.Forms.RichTextBox
        Me.tbFiltered = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lstFiltered = New System.Windows.Forms.ListBox
        Me.LstStatus = New System.Windows.Forms.ListBox
        Me.btnSettings = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnResize = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TC1.SuspendLayout()
        Me.TBAll.SuspendLayout()
        Me.tbFiltered.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProcess
        '
        Me.btnProcess.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnProcess.Location = New System.Drawing.Point(333, 12)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(78, 25)
        Me.btnProcess.TabIndex = 9
        Me.btnProcess.Text = "Test"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbTimer)
        Me.GroupBox1.Controls.Add(Me.lbError)
        Me.GroupBox1.Controls.Add(Me.lbcomment)
        Me.GroupBox1.Controls.Add(Me.lbCoordinates)
        Me.GroupBox1.Controls.Add(Me.lbHeading)
        Me.GroupBox1.Controls.Add(Me.lbAlt)
        Me.GroupBox1.Controls.Add(Me.lbSpeed)
        Me.GroupBox1.Controls.Add(Me.lbTime)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 201)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(201, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Avionics and Sensor Data"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbIT)
        Me.Panel2.Controls.Add(Me.lbOT)
        Me.Panel2.Controls.Add(Me.lbPP)
        Me.Panel2.Controls.Add(Me.lbBV)
        Me.Panel2.Location = New System.Drawing.Point(334, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(83, 109)
        Me.Panel2.TabIndex = 15
        '
        'lbIT
        '
        Me.lbIT.AutoSize = True
        Me.lbIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbIT.Location = New System.Drawing.Point(3, 0)
        Me.lbIT.Name = "lbIT"
        Me.lbIT.Size = New System.Drawing.Size(0, 13)
        Me.lbIT.TabIndex = 7
        '
        'lbOT
        '
        Me.lbOT.AutoSize = True
        Me.lbOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbOT.Location = New System.Drawing.Point(4, 26)
        Me.lbOT.Name = "lbOT"
        Me.lbOT.Size = New System.Drawing.Size(0, 13)
        Me.lbOT.TabIndex = 8
        '
        'lbPP
        '
        Me.lbPP.AutoSize = True
        Me.lbPP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbPP.Location = New System.Drawing.Point(3, 51)
        Me.lbPP.Name = "lbPP"
        Me.lbPP.Size = New System.Drawing.Size(0, 13)
        Me.lbPP.TabIndex = 9
        '
        'lbBV
        '
        Me.lbBV.AutoSize = True
        Me.lbBV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbBV.Location = New System.Drawing.Point(4, 74)
        Me.lbBV.Name = "lbBV"
        Me.lbBV.Size = New System.Drawing.Size(0, 13)
        Me.lbBV.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(204, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(124, 105)
        Me.Panel1.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Inside Temp (C)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 15)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Battery Voltage (V)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Outside Temp (C)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Pressure (mb)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(204, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Time Since Last Update"
        '
        'lbTimer
        '
        Me.lbTimer.AutoSize = True
        Me.lbTimer.Location = New System.Drawing.Point(370, 147)
        Me.lbTimer.Name = "lbTimer"
        Me.lbTimer.Size = New System.Drawing.Size(0, 13)
        Me.lbTimer.TabIndex = 12
        '
        'lbError
        '
        Me.lbError.AutoSize = True
        Me.lbError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbError.Location = New System.Drawing.Point(15, 144)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(74, 16)
        Me.lbError.TabIndex = 11
        Me.lbError.Text = "ERROR!!!"
        Me.lbError.Visible = False
        '
        'lbcomment
        '
        Me.lbcomment.AutoSize = True
        Me.lbcomment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbcomment.Location = New System.Drawing.Point(15, 166)
        Me.lbcomment.Name = "lbcomment"
        Me.lbcomment.Size = New System.Drawing.Size(0, 13)
        Me.lbcomment.TabIndex = 6
        '
        'lbCoordinates
        '
        Me.lbCoordinates.AutoSize = True
        Me.lbCoordinates.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCoordinates.ForeColor = System.Drawing.Color.Navy
        Me.lbCoordinates.Location = New System.Drawing.Point(15, 41)
        Me.lbCoordinates.Name = "lbCoordinates"
        Me.lbCoordinates.Size = New System.Drawing.Size(0, 16)
        Me.lbCoordinates.TabIndex = 5
        '
        'lbHeading
        '
        Me.lbHeading.AutoSize = True
        Me.lbHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHeading.ForeColor = System.Drawing.Color.Navy
        Me.lbHeading.Location = New System.Drawing.Point(109, 117)
        Me.lbHeading.Name = "lbHeading"
        Me.lbHeading.Size = New System.Drawing.Size(0, 16)
        Me.lbHeading.TabIndex = 4
        '
        'lbAlt
        '
        Me.lbAlt.AutoSize = True
        Me.lbAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAlt.ForeColor = System.Drawing.Color.Navy
        Me.lbAlt.Location = New System.Drawing.Point(109, 91)
        Me.lbAlt.Name = "lbAlt"
        Me.lbAlt.Size = New System.Drawing.Size(0, 16)
        Me.lbAlt.TabIndex = 3
        '
        'lbSpeed
        '
        Me.lbSpeed.AutoSize = True
        Me.lbSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSpeed.ForeColor = System.Drawing.Color.Navy
        Me.lbSpeed.Location = New System.Drawing.Point(109, 65)
        Me.lbSpeed.Name = "lbSpeed"
        Me.lbSpeed.Size = New System.Drawing.Size(0, 16)
        Me.lbSpeed.TabIndex = 2
        '
        'lbTime
        '
        Me.lbTime.AutoSize = True
        Me.lbTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTime.ForeColor = System.Drawing.Color.Navy
        Me.lbTime.Location = New System.Drawing.Point(64, 16)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(0, 16)
        Me.lbTime.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Time"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Heading (°)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Altitude (ft)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Speed (kts)"
        '
        'btnSaveKML
        '
        Me.btnSaveKML.Location = New System.Drawing.Point(12, 12)
        Me.btnSaveKML.Name = "btnSaveKML"
        Me.btnSaveKML.Size = New System.Drawing.Size(78, 25)
        Me.btnSaveKML.TabIndex = 17
        Me.btnSaveKML.Text = "Save KML"
        Me.btnSaveKML.UseVisualStyleBackColor = True
        '
        'TC1
        '
        Me.TC1.Controls.Add(Me.TBAll)
        Me.TC1.Controls.Add(Me.tbFiltered)
        Me.TC1.Location = New System.Drawing.Point(9, 250)
        Me.TC1.Name = "TC1"
        Me.TC1.SelectedIndex = 0
        Me.TC1.Size = New System.Drawing.Size(440, 231)
        Me.TC1.TabIndex = 14
        '
        'TBAll
        '
        Me.TBAll.Controls.Add(Me.RTBAll)
        Me.TBAll.Location = New System.Drawing.Point(4, 22)
        Me.TBAll.Name = "TBAll"
        Me.TBAll.Padding = New System.Windows.Forms.Padding(3)
        Me.TBAll.Size = New System.Drawing.Size(432, 205)
        Me.TBAll.TabIndex = 0
        Me.TBAll.Text = "All Packets"
        Me.TBAll.UseVisualStyleBackColor = True
        '
        'RTBAll
        '
        Me.RTBAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RTBAll.Location = New System.Drawing.Point(3, 3)
        Me.RTBAll.Name = "RTBAll"
        Me.RTBAll.Size = New System.Drawing.Size(426, 199)
        Me.RTBAll.TabIndex = 0
        Me.RTBAll.Text = ""
        Me.RTBAll.WordWrap = False
        '
        'tbFiltered
        '
        Me.tbFiltered.Controls.Add(Me.SplitContainer1)
        Me.tbFiltered.Location = New System.Drawing.Point(4, 22)
        Me.tbFiltered.Name = "tbFiltered"
        Me.tbFiltered.Padding = New System.Windows.Forms.Padding(3)
        Me.tbFiltered.Size = New System.Drawing.Size(432, 205)
        Me.tbFiltered.TabIndex = 1
        Me.tbFiltered.Text = "Filtered Packets"
        Me.tbFiltered.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstFiltered)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LstStatus)
        Me.SplitContainer1.Size = New System.Drawing.Size(426, 199)
        Me.SplitContainer1.SplitterDistance = 190
        Me.SplitContainer1.TabIndex = 0
        '
        'lstFiltered
        '
        Me.lstFiltered.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFiltered.FormattingEnabled = True
        Me.lstFiltered.HorizontalScrollbar = True
        Me.lstFiltered.Location = New System.Drawing.Point(0, 0)
        Me.lstFiltered.Name = "lstFiltered"
        Me.lstFiltered.Size = New System.Drawing.Size(190, 199)
        Me.lstFiltered.TabIndex = 17
        '
        'LstStatus
        '
        Me.LstStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstStatus.FormattingEnabled = True
        Me.LstStatus.HorizontalScrollbar = True
        Me.LstStatus.Location = New System.Drawing.Point(0, 0)
        Me.LstStatus.Name = "LstStatus"
        Me.LstStatus.Size = New System.Drawing.Size(232, 199)
        Me.LstStatus.TabIndex = 0
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(249, 12)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(78, 25)
        Me.btnSettings.TabIndex = 15
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(165, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(78, 25)
        Me.btnLoad.TabIndex = 18
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 200
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 200
        Me.ToolTip1.ReshowDelay = 40
        '
        'btnResize
        '
        Me.btnResize.BackgroundImage = Global.APRS_Analyser.My.Resources.Resources.small
        Me.btnResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnResize.Location = New System.Drawing.Point(137, 12)
        Me.btnResize.Name = "btnResize"
        Me.btnResize.Size = New System.Drawing.Size(22, 25)
        Me.btnResize.TabIndex = 17
        Me.btnResize.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 484)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSaveKML)
        Me.Controls.Add(Me.btnResize)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.TC1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnProcess)
        Me.MaximumSize = New System.Drawing.Size(1024, 522)
        Me.MinimumSize = New System.Drawing.Size(462, 522)
        Me.Name = "MainForm"
        Me.Text = "APRS Analyser"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TC1.ResumeLayout(False)
        Me.TBAll.ResumeLayout(False)
        Me.tbFiltered.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbCoordinates As System.Windows.Forms.Label
    Friend WithEvents lbHeading As System.Windows.Forms.Label
    Friend WithEvents lbAlt As System.Windows.Forms.Label
    Friend WithEvents lbSpeed As System.Windows.Forms.Label
    Friend WithEvents lbTime As System.Windows.Forms.Label
    Friend WithEvents lbcomment As System.Windows.Forms.Label
    Friend WithEvents lbError As System.Windows.Forms.Label
    Friend WithEvents TC1 As System.Windows.Forms.TabControl
    Friend WithEvents TBAll As System.Windows.Forms.TabPage
    Friend WithEvents RTBAll As System.Windows.Forms.RichTextBox
    Friend WithEvents tbFiltered As System.Windows.Forms.TabPage
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbTimer As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbBV As System.Windows.Forms.Label
    Friend WithEvents lbPP As System.Windows.Forms.Label
    Friend WithEvents lbOT As System.Windows.Forms.Label
    Friend WithEvents lbIT As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnResize As System.Windows.Forms.Button
    Friend WithEvents btnSaveKML As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltered As System.Windows.Forms.ListBox
    Friend WithEvents LstStatus As System.Windows.Forms.ListBox

End Class
