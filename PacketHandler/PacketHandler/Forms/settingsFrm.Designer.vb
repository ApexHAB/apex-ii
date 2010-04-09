<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settingsFrm
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
        Me.lstInterfaces = New System.Windows.Forms.ListBox
        Me.btninterfaceAdd = New System.Windows.Forms.Button
        Me.btnInterfaceEdit = New System.Windows.Forms.Button
        Me.btnInterfaceDel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkUTC = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudTimeZone = New System.Windows.Forms.NumericUpDown
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lstSensors = New System.Windows.Forms.ListBox
        Me.btnSensorAdd = New System.Windows.Forms.Button
        Me.btnSensorEdit = New System.Windows.Forms.Button
        Me.btnSensorRemove = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudTimeZone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstInterfaces
        '
        Me.lstInterfaces.FormattingEnabled = True
        Me.lstInterfaces.Location = New System.Drawing.Point(65, 19)
        Me.lstInterfaces.Name = "lstInterfaces"
        Me.lstInterfaces.Size = New System.Drawing.Size(120, 95)
        Me.lstInterfaces.TabIndex = 0
        '
        'btninterfaceAdd
        '
        Me.btninterfaceAdd.Location = New System.Drawing.Point(6, 18)
        Me.btninterfaceAdd.Name = "btninterfaceAdd"
        Me.btninterfaceAdd.Size = New System.Drawing.Size(53, 28)
        Me.btninterfaceAdd.TabIndex = 1
        Me.btninterfaceAdd.Text = "Add"
        Me.btninterfaceAdd.UseVisualStyleBackColor = True
        '
        'btnInterfaceEdit
        '
        Me.btnInterfaceEdit.Location = New System.Drawing.Point(6, 52)
        Me.btnInterfaceEdit.Name = "btnInterfaceEdit"
        Me.btnInterfaceEdit.Size = New System.Drawing.Size(53, 28)
        Me.btnInterfaceEdit.TabIndex = 2
        Me.btnInterfaceEdit.Text = "Edit"
        Me.btnInterfaceEdit.UseVisualStyleBackColor = True
        '
        'btnInterfaceDel
        '
        Me.btnInterfaceDel.Location = New System.Drawing.Point(6, 86)
        Me.btnInterfaceDel.Name = "btnInterfaceDel"
        Me.btnInterfaceDel.Size = New System.Drawing.Size(53, 28)
        Me.btnInterfaceDel.TabIndex = 3
        Me.btnInterfaceDel.Text = "Delete"
        Me.btnInterfaceDel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnInterfaceDel)
        Me.GroupBox1.Controls.Add(Me.lstInterfaces)
        Me.GroupBox1.Controls.Add(Me.btninterfaceAdd)
        Me.GroupBox1.Controls.Add(Me.btnInterfaceEdit)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 131)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Interfaces"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkUTC)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.nudTimeZone)
        Me.GroupBox2.Location = New System.Drawing.Point(220, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 86)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Time Settings"
        '
        'chkUTC
        '
        Me.chkUTC.AutoSize = True
        Me.chkUTC.Location = New System.Drawing.Point(9, 19)
        Me.chkUTC.Name = "chkUTC"
        Me.chkUTC.Size = New System.Drawing.Size(70, 17)
        Me.chkUTC.TabIndex = 2
        Me.chkUTC.Text = "Use UTC"
        Me.chkUTC.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Time Zone"
        '
        'nudTimeZone
        '
        Me.nudTimeZone.Location = New System.Drawing.Point(70, 46)
        Me.nudTimeZone.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudTimeZone.Minimum = New Decimal(New Integer() {12, 0, 0, -2147483648})
        Me.nudTimeZone.Name = "nudTimeZone"
        Me.nudTimeZone.Size = New System.Drawing.Size(48, 20)
        Me.nudTimeZone.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(16, 38)
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnOK, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(229, 247)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Location = New System.Drawing.Point(3, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(67, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(76, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSensorRemove)
        Me.GroupBox3.Controls.Add(Me.btnSensorEdit)
        Me.GroupBox3.Controls.Add(Me.btnSensorAdd)
        Me.GroupBox3.Controls.Add(Me.lstSensors)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 149)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 131)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Variables"
        '
        'lstSensors
        '
        Me.lstSensors.FormattingEnabled = True
        Me.lstSensors.Location = New System.Drawing.Point(65, 19)
        Me.lstSensors.Name = "lstSensors"
        Me.lstSensors.Size = New System.Drawing.Size(120, 95)
        Me.lstSensors.TabIndex = 1
        '
        'btnSensorAdd
        '
        Me.btnSensorAdd.Location = New System.Drawing.Point(6, 19)
        Me.btnSensorAdd.Name = "btnSensorAdd"
        Me.btnSensorAdd.Size = New System.Drawing.Size(53, 28)
        Me.btnSensorAdd.TabIndex = 2
        Me.btnSensorAdd.Text = "Add"
        Me.btnSensorAdd.UseVisualStyleBackColor = True
        '
        'btnSensorEdit
        '
        Me.btnSensorEdit.Location = New System.Drawing.Point(6, 53)
        Me.btnSensorEdit.Name = "btnSensorEdit"
        Me.btnSensorEdit.Size = New System.Drawing.Size(53, 28)
        Me.btnSensorEdit.TabIndex = 3
        Me.btnSensorEdit.Text = "Edit"
        Me.btnSensorEdit.UseVisualStyleBackColor = True
        '
        'btnSensorRemove
        '
        Me.btnSensorRemove.Location = New System.Drawing.Point(6, 86)
        Me.btnSensorRemove.Name = "btnSensorRemove"
        Me.btnSensorRemove.Size = New System.Drawing.Size(53, 28)
        Me.btnSensorRemove.TabIndex = 4
        Me.btnSensorRemove.Text = "Delete"
        Me.btnSensorRemove.UseVisualStyleBackColor = True
        '
        'settingsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 288)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "settingsFrm"
        Me.Text = "settingsFrm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudTimeZone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstInterfaces As System.Windows.Forms.ListBox
    Friend WithEvents btninterfaceAdd As System.Windows.Forms.Button
    Friend WithEvents btnInterfaceEdit As System.Windows.Forms.Button
    Friend WithEvents btnInterfaceDel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudTimeZone As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkUTC As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSensorRemove As System.Windows.Forms.Button
    Friend WithEvents btnSensorEdit As System.Windows.Forms.Button
    Friend WithEvents btnSensorAdd As System.Windows.Forms.Button
    Friend WithEvents lstSensors As System.Windows.Forms.ListBox
End Class
