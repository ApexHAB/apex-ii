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
        Me.nudTimeZone = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkUTC = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudTimeZone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstInterfaces
        '
        Me.lstInterfaces.FormattingEnabled = True
        Me.lstInterfaces.Location = New System.Drawing.Point(20, 21)
        Me.lstInterfaces.Name = "lstInterfaces"
        Me.lstInterfaces.Size = New System.Drawing.Size(195, 108)
        Me.lstInterfaces.TabIndex = 0
        '
        'btninterfaceAdd
        '
        Me.btninterfaceAdd.Location = New System.Drawing.Point(20, 135)
        Me.btninterfaceAdd.Name = "btninterfaceAdd"
        Me.btninterfaceAdd.Size = New System.Drawing.Size(61, 29)
        Me.btninterfaceAdd.TabIndex = 1
        Me.btninterfaceAdd.Text = "Add"
        Me.btninterfaceAdd.UseVisualStyleBackColor = True
        '
        'btnInterfaceEdit
        '
        Me.btnInterfaceEdit.Location = New System.Drawing.Point(87, 135)
        Me.btnInterfaceEdit.Name = "btnInterfaceEdit"
        Me.btnInterfaceEdit.Size = New System.Drawing.Size(61, 29)
        Me.btnInterfaceEdit.TabIndex = 2
        Me.btnInterfaceEdit.Text = "Edit"
        Me.btnInterfaceEdit.UseVisualStyleBackColor = True
        '
        'btnInterfaceDel
        '
        Me.btnInterfaceDel.Location = New System.Drawing.Point(154, 135)
        Me.btnInterfaceDel.Name = "btnInterfaceDel"
        Me.btnInterfaceDel.Size = New System.Drawing.Size(61, 29)
        Me.btnInterfaceDel.TabIndex = 3
        Me.btnInterfaceDel.Text = "Delete"
        Me.btnInterfaceDel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnInterfaceDel)
        Me.GroupBox1.Controls.Add(Me.btnInterfaceEdit)
        Me.GroupBox1.Controls.Add(Me.btninterfaceAdd)
        Me.GroupBox1.Controls.Add(Me.lstInterfaces)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 175)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Interfaces"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkUTC)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.nudTimeZone)
        Me.GroupBox2.Location = New System.Drawing.Point(247, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 86)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Time Settings"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Time Zone"
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(265, 324)
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
        'settingsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 365)
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
End Class
