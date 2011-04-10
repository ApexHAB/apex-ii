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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrm))
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.tabData = New System.Windows.Forms.TabControl()
        Me.tpAllData = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnBalloonUplink = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.GPSFormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox2 = New System.Windows.Forms.ToolStripComboBox()
        Me.StatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPacketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UplinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TempToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanedDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HuD_UC1 = New PacketHandler.HUD_UC()
        Me.KMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabData.SuspendLayout()
        Me.tpAllData.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(382, 498)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(63, 26)
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
        Me.Button1.Location = New System.Drawing.Point(182, 498)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 26)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Manual"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnBalloonUplink
        '
        Me.btnBalloonUplink.Location = New System.Drawing.Point(320, 498)
        Me.btnBalloonUplink.Name = "btnBalloonUplink"
        Me.btnBalloonUplink.Size = New System.Drawing.Size(56, 26)
        Me.btnBalloonUplink.TabIndex = 3
        Me.btnBalloonUplink.Text = "Uplink"
        Me.btnBalloonUplink.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(65, 493)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 16)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(17, 507)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 16)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(17, 493)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 12)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(251, 498)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(63, 26)
        Me.btnLoad.TabIndex = 9
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(113, 498)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(63, 26)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Status"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem, Me.ManualToolStripMenuItem, Me.SendToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.TempToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(455, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisplayToolStripMenuItem, Me.StatusToolStripMenuItem, Me.DataToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'DisplayToolStripMenuItem
        '
        Me.DisplayToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.GPSFormatToolStripMenuItem})
        Me.DisplayToolStripMenuItem.Name = "DisplayToolStripMenuItem"
        Me.DisplayToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.DisplayToolStripMenuItem.Text = "Display"
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1})
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"'All'", "'Only Valid'", "'Valid' and 'Failed with GPS'"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(152, 23)
        Me.ToolStripComboBox1.Text = "'Valid' and 'Failed with GPS'"
        '
        'GPSFormatToolStripMenuItem
        '
        Me.GPSFormatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox2})
        Me.GPSFormatToolStripMenuItem.Name = "GPSFormatToolStripMenuItem"
        Me.GPSFormatToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.GPSFormatToolStripMenuItem.Text = "GPS Format"
        '
        'ToolStripComboBox2
        '
        Me.ToolStripComboBox2.Items.AddRange(New Object() {"Decimal", "DMS"})
        Me.ToolStripComboBox2.Name = "ToolStripComboBox2"
        Me.ToolStripComboBox2.Size = New System.Drawing.Size(121, 23)
        '
        'StatusToolStripMenuItem
        '
        Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
        Me.StatusToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.StatusToolStripMenuItem.Text = "Status"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'ManualToolStripMenuItem
        '
        Me.ManualToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadFileToolStripMenuItem, Me.AddPacketToolStripMenuItem, Me.AddPointToolStripMenuItem})
        Me.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem"
        Me.ManualToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ManualToolStripMenuItem.Text = "Manual"
        '
        'LoadFileToolStripMenuItem
        '
        Me.LoadFileToolStripMenuItem.Name = "LoadFileToolStripMenuItem"
        Me.LoadFileToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.LoadFileToolStripMenuItem.Text = "Load File"
        '
        'AddPacketToolStripMenuItem
        '
        Me.AddPacketToolStripMenuItem.Name = "AddPacketToolStripMenuItem"
        Me.AddPacketToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.AddPacketToolStripMenuItem.Text = "Add Packet"
        '
        'AddPointToolStripMenuItem
        '
        Me.AddPointToolStripMenuItem.Name = "AddPointToolStripMenuItem"
        Me.AddPointToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.AddPointToolStripMenuItem.Text = "Add Point"
        '
        'SendToolStripMenuItem
        '
        Me.SendToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UplinkToolStripMenuItem})
        Me.SendToolStripMenuItem.Name = "SendToolStripMenuItem"
        Me.SendToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.SendToolStripMenuItem.Text = "Send"
        '
        'UplinkToolStripMenuItem
        '
        Me.UplinkToolStripMenuItem.Name = "UplinkToolStripMenuItem"
        Me.UplinkToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.UplinkToolStripMenuItem.Text = "Uplink"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'TempToolStripMenuItem
        '
        Me.TempToolStripMenuItem.Name = "TempToolStripMenuItem"
        Me.TempToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.TempToolStripMenuItem.Text = "temp"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CleanedDataToolStripMenuItem, Me.KMLToolStripMenuItem})
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'CleanedDataToolStripMenuItem
        '
        Me.CleanedDataToolStripMenuItem.Name = "CleanedDataToolStripMenuItem"
        Me.CleanedDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CleanedDataToolStripMenuItem.Text = "Cleaned Data"
        '
        'HuD_UC1
        '
        Me.HuD_UC1.DisplayAllPackets = False
        Me.HuD_UC1.DisplayIfGPS = True
        Me.HuD_UC1.ForeColor = System.Drawing.Color.Black
        Me.HuD_UC1.Location = New System.Drawing.Point(7, 30)
        Me.HuD_UC1.Name = "HuD_UC1"
        Me.HuD_UC1.Size = New System.Drawing.Size(436, 187)
        Me.HuD_UC1.TabIndex = 12
        '
        'KMLToolStripMenuItem
        '
        Me.KMLToolStripMenuItem.Name = "KMLToolStripMenuItem"
        Me.KMLToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.KMLToolStripMenuItem.Text = "KML"
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 481)
        Me.Controls.Add(Me.HuD_UC1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnBalloonUplink)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tabData)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(471, 519)
        Me.MinimumSize = New System.Drawing.Size(471, 257)
        Me.Name = "MainFrm"
        Me.Text = "Packet Handler"
        Me.tabData.ResumeLayout(False)
        Me.tpAllData.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents tabData As System.Windows.Forms.TabControl
    Friend WithEvents tpAllData As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnBalloonUplink As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddPacketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddPointToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UplinkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisplayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GPSFormatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents StatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents DataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HuD_UC1 As PacketHandler.HUD_UC
    Friend WithEvents TempToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CleanedDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem


End Class
