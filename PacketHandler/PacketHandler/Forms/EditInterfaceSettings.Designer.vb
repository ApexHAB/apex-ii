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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.chkFilter = New System.Windows.Forms.CheckBox()
        Me.lstFilter = New System.Windows.Forms.ListBox()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.txtFilterAdd = New System.Windows.Forms.TextBox()
        Me.btnRemoveFilter = New System.Windows.Forms.Button()
        Me.btnAddFilter = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtXMLpacket = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(98, 420)
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
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(12, 269)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 141)
        Me.Panel1.TabIndex = 9
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "XML Packet Config"
        '
        'txtXMLpacket
        '
        Me.txtXMLpacket.Location = New System.Drawing.Point(123, 241)
        Me.txtXMLpacket.Name = "txtXMLpacket"
        Me.txtXMLpacket.Size = New System.Drawing.Size(83, 20)
        Me.txtXMLpacket.TabIndex = 16
        '
        'EditInterfaceSettings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(256, 461)
        Me.Controls.Add(Me.txtXMLpacket)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkFilter)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.Panel1)
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilter As System.Windows.Forms.CheckBox
    Friend WithEvents lstFilter As System.Windows.Forms.ListBox
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents btnRemoveFilter As System.Windows.Forms.Button
    Friend WithEvents btnAddFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilterAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtXMLpacket As System.Windows.Forms.TextBox

End Class
