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
        Me.btnSettings = New System.Windows.Forms.Button
        Me.tabData = New System.Windows.Forms.TabControl
        Me.tpAllData = New System.Windows.Forms.TabPage
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnBalloonUplink = New System.Windows.Forms.Button
        Me.HuD_UC1 = New PacketHandler.HUD_UC
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
        Me.Button1.Visible = False
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
        'HuD_UC1
        '
        Me.HuD_UC1.Location = New System.Drawing.Point(12, 44)
        Me.HuD_UC1.Name = "HuD_UC1"
        Me.HuD_UC1.Size = New System.Drawing.Size(438, 189)
        Me.HuD_UC1.TabIndex = 4
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 488)
        Me.Controls.Add(Me.HuD_UC1)
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
    Friend WithEvents HuD_UC1 As PacketHandler.HUD_UC

End Class
