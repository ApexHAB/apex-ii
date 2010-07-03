<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditInterfaceSettings
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbInterfaceTypes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDirection = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDataFormat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.chkFilter = New System.Windows.Forms.CheckBox()
        Me.lstFilter = New System.Windows.Forms.ListBox()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.txtFilterAdd = New System.Windows.Forms.TextBox()
        Me.btnRemoveFilter = New System.Windows.Forms.Button()
        Me.btnAddFilter = New System.Windows.Forms.Button()
        Me.txtXMLpacket = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gpTCP = New System.Windows.Forms.GroupBox()
        Me.txtTCPPort = New System.Windows.Forms.TextBox()
        Me.txtTCPHost = New System.Windows.Forms.TextBox()
        Me.gpSerial = New System.Windows.Forms.GroupBox()
        Me.cmbsParity = New System.Windows.Forms.ComboBox()
        Me.cmbsStop = New System.Windows.Forms.ComboBox()
        Me.cmbsPort = New System.Windows.Forms.ComboBox()
        Me.txtDataBits = New System.Windows.Forms.TextBox()
        Me.txtsBaud = New System.Windows.Forms.TextBox()
        Me.gpXML = New System.Windows.Forms.GroupBox()
        Me.btnFindXML = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.gpTCP.SuspendLayout()
        Me.gpSerial.SuspendLayout()
        Me.gpXML.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(98, 561)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Interface Type"
        '
        'cmbInterfaceTypes
        '
        Me.cmbInterfaceTypes.FormattingEnabled = True
        Me.cmbInterfaceTypes.Location = New System.Drawing.Point(113, 39)
        Me.cmbInterfaceTypes.Name = "cmbInterfaceTypes"
        Me.cmbInterfaceTypes.Size = New System.Drawing.Size(131, 21)
        Me.cmbInterfaceTypes.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Direction"
        '
        'cmbDirection
        '
        Me.cmbDirection.FormattingEnabled = True
        Me.cmbDirection.Location = New System.Drawing.Point(113, 66)
        Me.cmbDirection.Name = "cmbDirection"
        Me.cmbDirection.Size = New System.Drawing.Size(131, 21)
        Me.cmbDirection.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Data Format"
        '
        'cmbDataFormat
        '
        Me.cmbDataFormat.FormattingEnabled = True
        Me.cmbDataFormat.Location = New System.Drawing.Point(113, 93)
        Me.cmbDataFormat.Name = "cmbDataFormat"
        Me.cmbDataFormat.Size = New System.Drawing.Size(131, 21)
        Me.cmbDataFormat.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(113, 13)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(131, 20)
        Me.txtName.TabIndex = 8
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(87, 120)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(65, 17)
        Me.chkEnabled.TabIndex = 10
        Me.chkEnabled.Text = "Enabled"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'chkFilter
        '
        Me.chkFilter.AutoSize = True
        Me.chkFilter.Location = New System.Drawing.Point(158, 120)
        Me.chkFilter.Name = "chkFilter"
        Me.chkFilter.Size = New System.Drawing.Size(86, 17)
        Me.chkFilter.TabIndex = 12
        Me.chkFilter.Text = "Filter Results"
        Me.chkFilter.UseVisualStyleBackColor = True
        '
        'lstFilter
        '
        Me.lstFilter.FormattingEnabled = True
        Me.lstFilter.Location = New System.Drawing.Point(101, 3)
        Me.lstFilter.Name = "lstFilter"
        Me.lstFilter.Size = New System.Drawing.Size(131, 82)
        Me.lstFilter.TabIndex = 13
        '
        'pnlFilter
        '
        Me.pnlFilter.Controls.Add(Me.txtFilterAdd)
        Me.pnlFilter.Controls.Add(Me.btnRemoveFilter)
        Me.pnlFilter.Controls.Add(Me.btnAddFilter)
        Me.pnlFilter.Controls.Add(Me.lstFilter)
        Me.pnlFilter.Enabled = False
        Me.pnlFilter.Location = New System.Drawing.Point(12, 143)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(244, 92)
        Me.pnlFilter.TabIndex = 14
        '
        'txtFilterAdd
        '
        Me.txtFilterAdd.Location = New System.Drawing.Point(9, 7)
        Me.txtFilterAdd.Name = "txtFilterAdd"
        Me.txtFilterAdd.Size = New System.Drawing.Size(59, 20)
        Me.txtFilterAdd.TabIndex = 16
        '
        'btnRemoveFilter
        '
        Me.btnRemoveFilter.Location = New System.Drawing.Point(9, 62)
        Me.btnRemoveFilter.Name = "btnRemoveFilter"
        Me.btnRemoveFilter.Size = New System.Drawing.Size(59, 23)
        Me.btnRemoveFilter.TabIndex = 15
        Me.btnRemoveFilter.Text = "Remove"
        Me.btnRemoveFilter.UseVisualStyleBackColor = True
        '
        'btnAddFilter
        '
        Me.btnAddFilter.Location = New System.Drawing.Point(9, 33)
        Me.btnAddFilter.Name = "btnAddFilter"
        Me.btnAddFilter.Size = New System.Drawing.Size(59, 23)
        Me.btnAddFilter.TabIndex = 14
        Me.btnAddFilter.Text = "Add"
        Me.btnAddFilter.UseVisualStyleBackColor = True
        '
        'txtXMLpacket
        '
        Me.txtXMLpacket.Location = New System.Drawing.Point(6, 19)
        Me.txtXMLpacket.Name = "txtXMLpacket"
        Me.txtXMLpacket.Size = New System.Drawing.Size(188, 20)
        Me.txtXMLpacket.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Host"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Port"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Port"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Baud"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Parity"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "DataBits"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "StopBits"
        '
        'gpTCP
        '
        Me.gpTCP.Controls.Add(Me.txtTCPPort)
        Me.gpTCP.Controls.Add(Me.txtTCPHost)
        Me.gpTCP.Controls.Add(Me.Label6)
        Me.gpTCP.Controls.Add(Me.Label7)
        Me.gpTCP.Enabled = False
        Me.gpTCP.Location = New System.Drawing.Point(12, 305)
        Me.gpTCP.Name = "gpTCP"
        Me.gpTCP.Size = New System.Drawing.Size(232, 88)
        Me.gpTCP.TabIndex = 24
        Me.gpTCP.TabStop = False
        Me.gpTCP.Text = "TCP Connection"
        '
        'txtTCPPort
        '
        Me.txtTCPPort.Location = New System.Drawing.Point(101, 51)
        Me.txtTCPPort.Name = "txtTCPPort"
        Me.txtTCPPort.Size = New System.Drawing.Size(80, 20)
        Me.txtTCPPort.TabIndex = 20
        Me.txtTCPPort.Text = "7322"
        '
        'txtTCPHost
        '
        Me.txtTCPHost.Location = New System.Drawing.Point(101, 25)
        Me.txtTCPHost.Name = "txtTCPHost"
        Me.txtTCPHost.Size = New System.Drawing.Size(125, 20)
        Me.txtTCPHost.TabIndex = 19
        Me.txtTCPHost.Text = "127.0.0.1"
        '
        'gpSerial
        '
        Me.gpSerial.Controls.Add(Me.cmbsParity)
        Me.gpSerial.Controls.Add(Me.cmbsStop)
        Me.gpSerial.Controls.Add(Me.cmbsPort)
        Me.gpSerial.Controls.Add(Me.txtDataBits)
        Me.gpSerial.Controls.Add(Me.txtsBaud)
        Me.gpSerial.Controls.Add(Me.Label8)
        Me.gpSerial.Controls.Add(Me.Label9)
        Me.gpSerial.Controls.Add(Me.Label10)
        Me.gpSerial.Controls.Add(Me.Label12)
        Me.gpSerial.Controls.Add(Me.Label11)
        Me.gpSerial.Enabled = False
        Me.gpSerial.Location = New System.Drawing.Point(9, 399)
        Me.gpSerial.Name = "gpSerial"
        Me.gpSerial.Size = New System.Drawing.Size(235, 156)
        Me.gpSerial.TabIndex = 25
        Me.gpSerial.TabStop = False
        Me.gpSerial.Text = "Serial Port"
        '
        'cmbsParity
        '
        Me.cmbsParity.FormattingEnabled = True
        Me.cmbsParity.Items.AddRange(New Object() {"None", "Odd", "Even", "Mark", "Space"})
        Me.cmbsParity.Location = New System.Drawing.Point(101, 125)
        Me.cmbsParity.Name = "cmbsParity"
        Me.cmbsParity.Size = New System.Drawing.Size(80, 21)
        Me.cmbsParity.TabIndex = 31
        Me.cmbsParity.Text = "none"
        '
        'cmbsStop
        '
        Me.cmbsStop.FormattingEnabled = True
        Me.cmbsStop.Items.AddRange(New Object() {"0", "1", "2", "1.5"})
        Me.cmbsStop.Location = New System.Drawing.Point(101, 98)
        Me.cmbsStop.Name = "cmbsStop"
        Me.cmbsStop.Size = New System.Drawing.Size(80, 21)
        Me.cmbsStop.TabIndex = 30
        Me.cmbsStop.Text = "1"
        '
        'cmbsPort
        '
        Me.cmbsPort.FormattingEnabled = True
        Me.cmbsPort.Location = New System.Drawing.Point(101, 19)
        Me.cmbsPort.Name = "cmbsPort"
        Me.cmbsPort.Size = New System.Drawing.Size(80, 21)
        Me.cmbsPort.TabIndex = 29
        '
        'txtDataBits
        '
        Me.txtDataBits.Location = New System.Drawing.Point(101, 46)
        Me.txtDataBits.Name = "txtDataBits"
        Me.txtDataBits.Size = New System.Drawing.Size(80, 20)
        Me.txtDataBits.TabIndex = 26
        Me.txtDataBits.Text = "2400"
        '
        'txtsBaud
        '
        Me.txtsBaud.Location = New System.Drawing.Point(101, 72)
        Me.txtsBaud.Name = "txtsBaud"
        Me.txtsBaud.Size = New System.Drawing.Size(80, 20)
        Me.txtsBaud.TabIndex = 25
        Me.txtsBaud.Text = "8"
        '
        'gpXML
        '
        Me.gpXML.Controls.Add(Me.btnFindXML)
        Me.gpXML.Controls.Add(Me.txtXMLpacket)
        Me.gpXML.Location = New System.Drawing.Point(12, 243)
        Me.gpXML.Name = "gpXML"
        Me.gpXML.Size = New System.Drawing.Size(232, 56)
        Me.gpXML.TabIndex = 26
        Me.gpXML.TabStop = False
        Me.gpXML.Text = "XML Packet Config"
        '
        'btnFindXML
        '
        Me.btnFindXML.Location = New System.Drawing.Point(200, 16)
        Me.btnFindXML.Name = "btnFindXML"
        Me.btnFindXML.Size = New System.Drawing.Size(26, 23)
        Me.btnFindXML.TabIndex = 17
        Me.btnFindXML.Text = "..."
        Me.btnFindXML.UseVisualStyleBackColor = True
        '
        'EditInterfaceSettings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(256, 602)
        Me.Controls.Add(Me.gpXML)
        Me.Controls.Add(Me.gpSerial)
        Me.Controls.Add(Me.gpTCP)
        Me.Controls.Add(Me.chkFilter)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbDataFormat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbDirection)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbInterfaceTypes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditInterfaceSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.gpTCP.ResumeLayout(False)
        Me.gpTCP.PerformLayout()
        Me.gpSerial.ResumeLayout(False)
        Me.gpSerial.PerformLayout()
        Me.gpXML.ResumeLayout(False)
        Me.gpXML.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbInterfaceTypes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDirection As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDataFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilter As System.Windows.Forms.CheckBox
    Friend WithEvents lstFilter As System.Windows.Forms.ListBox
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents btnRemoveFilter As System.Windows.Forms.Button
    Friend WithEvents btnAddFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilterAdd As System.Windows.Forms.TextBox
    Friend WithEvents txtXMLpacket As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gpTCP As System.Windows.Forms.GroupBox
    Friend WithEvents txtTCPPort As System.Windows.Forms.TextBox
    Friend WithEvents gpSerial As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataBits As System.Windows.Forms.TextBox
    Friend WithEvents txtsBaud As System.Windows.Forms.TextBox
    Friend WithEvents txtTCPHost As System.Windows.Forms.TextBox
    Friend WithEvents cmbsPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsParity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsStop As System.Windows.Forms.ComboBox
    Friend WithEvents gpXML As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindXML As System.Windows.Forms.Button

End Class
