<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrm
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
        Dim Frame1 As PacketHandler.Frame = New PacketHandler.Frame()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.tabData = New System.Windows.Forms.TabControl()
        Me.tpAllData = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnBalloonUplink = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.HuD_UC1 = New PacketHandler.HUD_UC()
        Me.tabData.SuspendLayout()
        Me.tpAllData.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(393, 12)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(56, 26)
        Me.btnSettings.TabIndex = 0
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'tabData
        '
        Me.tabData.Controls.Add(Me.tpAllData)
        Me.tabData.Location = New System.Drawing.Point(12, 244)
        Me.tabData.Name = "tabData"
        Me.tabData.SelectedIndex = 0
        Me.tabData.Size = New System.Drawing.Size(437, 232)
        Me.tabData.TabIndex = 1
        '
        'tpAllData
        '
        Me.tpAllData.Controls.Add(Me.RichTextBox1)
        Me.tpAllData.Location = New System.Drawing.Point(4, 22)
        Me.tpAllData.Name = "tpAllData"
        Me.tpAllData.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAllData.Size = New System.Drawing.Size(429, 206)
        Me.tpAllData.TabIndex = 0
        Me.tpAllData.Text = "All Data"
        Me.tpAllData.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(423, 200)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(260, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 26)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnBalloonUplink
        '
        Me.btnBalloonUplink.Location = New System.Drawing.Point(331, 12)
        Me.btnBalloonUplink.Name = "btnBalloonUplink"
        Me.btnBalloonUplink.Size = New System.Drawing.Size(56, 26)
        Me.btnBalloonUplink.TabIndex = 3
        Me.btnBalloonUplink.Text = "Send"
        Me.btnBalloonUplink.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(189, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 26)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(28, 21)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 16)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(120, 25)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 12)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'HuD_UC1
        '
        Frame1.Callsign = Nothing
        Frame1.PcktCounter = 0
        Frame1.Sats = 0
        Frame1.StatusPacketStartText = "sgsballoon:"
        Frame1.TimeZone = 0
        Me.HuD_UC1.FrameToDisplay = Frame1
        Me.HuD_UC1.Location = New System.Drawing.Point(19, 57)
        Me.HuD_UC1.Name = "HuD_UC1"
        Me.HuD_UC1.Size = New System.Drawing.Size(430, 181)
        Me.HuD_UC1.TabIndex = 6
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 488)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.HuD_UC1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnBalloonUplink)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tabData)
        Me.Controls.Add(Me.btnSettings)
        Me.Name = "MainFrm"
        Me.Text = "hello"
        Me.tabData.ResumeLayout(False)
        Me.tpAllData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents tabData As System.Windows.Forms.TabControl
    Friend WithEvents tpAllData As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnBalloonUplink As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents HuD_UC1 As PacketHandler.HUD_UC
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button


End Class
