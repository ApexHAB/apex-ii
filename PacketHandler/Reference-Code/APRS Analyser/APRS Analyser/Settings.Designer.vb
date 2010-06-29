<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRAll = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txtAdd = New System.Windows.Forms.TextBox
        Me.lstfilter = New System.Windows.Forms.ListBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClearPath = New System.Windows.Forms.Button
        Me.btnChangePath = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbpath = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbClearFiltPath = New System.Windows.Forms.Button
        Me.lbChangeFiltPath = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbfiltpath = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btnMessDe = New System.Windows.Forms.Button
        Me.txtmessStart = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btnClearCSV = New System.Windows.Forms.Button
        Me.btnChangeCSV = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbCSVPath = New System.Windows.Forms.Label
        Me.ckhIgnoreZ = New System.Windows.Forms.CheckBox
        Me.NUDTimeZone = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtFLPort = New System.Windows.Forms.TextBox
        Me.txtFLHost = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.NUDTimeZone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRAll)
        Me.GroupBox1.Controls.Add(Me.btnRemove)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.txtAdd)
        Me.GroupBox1.Controls.Add(Me.lstfilter)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 152)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'btnRAll
        '
        Me.btnRAll.Location = New System.Drawing.Point(97, 74)
        Me.btnRAll.Name = "btnRAll"
        Me.btnRAll.Size = New System.Drawing.Size(65, 36)
        Me.btnRAll.TabIndex = 4
        Me.btnRAll.Text = "Remove All"
        Me.btnRAll.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(97, 45)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(65, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(97, 17)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(65, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(6, 19)
        Me.txtAdd.MaxLength = 10
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(85, 20)
        Me.txtAdd.TabIndex = 1
        '
        'lstfilter
        '
        Me.lstfilter.FormattingEnabled = True
        Me.lstfilter.Location = New System.Drawing.Point(6, 45)
        Me.lstfilter.Name = "lstfilter"
        Me.lstfilter.Size = New System.Drawing.Size(85, 95)
        Me.lstfilter.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(324, 315)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(61, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(391, 315)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(61, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPort)
        Me.GroupBox2.Controls.Add(Me.txtHost)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(171, 101)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "AGWPE Connection"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(44, 59)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(60, 20)
        Me.txtPort.TabIndex = 4
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(44, 33)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(121, 20)
        Me.txtHost.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Host"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Port"
        '
        'btnClearPath
        '
        Me.btnClearPath.Location = New System.Drawing.Point(68, 41)
        Me.btnClearPath.Name = "btnClearPath"
        Me.btnClearPath.Size = New System.Drawing.Size(56, 27)
        Me.btnClearPath.TabIndex = 12
        Me.btnClearPath.Text = "Clear"
        Me.btnClearPath.UseVisualStyleBackColor = True
        '
        'btnChangePath
        '
        Me.btnChangePath.Location = New System.Drawing.Point(6, 40)
        Me.btnChangePath.Name = "btnChangePath"
        Me.btnChangePath.Size = New System.Drawing.Size(56, 28)
        Me.btnChangePath.TabIndex = 11
        Me.btnChangePath.Text = "Change"
        Me.btnChangePath.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Save Path:"
        '
        'lbpath
        '
        Me.lbpath.AutoSize = True
        Me.lbpath.Location = New System.Drawing.Point(72, 24)
        Me.lbpath.Name = "lbpath"
        Me.lbpath.Size = New System.Drawing.Size(0, 13)
        Me.lbpath.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnClearPath)
        Me.GroupBox3.Controls.Add(Me.btnChangePath)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.lbpath)
        Me.GroupBox3.Location = New System.Drawing.Point(189, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(263, 87)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "All Data Save Path"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbClearFiltPath)
        Me.GroupBox4.Controls.Add(Me.lbChangeFiltPath)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.lbfiltpath)
        Me.GroupBox4.Location = New System.Drawing.Point(189, 105)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(263, 87)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtered Save Path"
        '
        'lbClearFiltPath
        '
        Me.lbClearFiltPath.Location = New System.Drawing.Point(68, 41)
        Me.lbClearFiltPath.Name = "lbClearFiltPath"
        Me.lbClearFiltPath.Size = New System.Drawing.Size(56, 27)
        Me.lbClearFiltPath.TabIndex = 12
        Me.lbClearFiltPath.Text = "Clear"
        Me.lbClearFiltPath.UseVisualStyleBackColor = True
        '
        'lbChangeFiltPath
        '
        Me.lbChangeFiltPath.Location = New System.Drawing.Point(6, 40)
        Me.lbChangeFiltPath.Name = "lbChangeFiltPath"
        Me.lbChangeFiltPath.Size = New System.Drawing.Size(56, 28)
        Me.lbChangeFiltPath.TabIndex = 11
        Me.lbChangeFiltPath.Text = "Change"
        Me.lbChangeFiltPath.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Save Path:"
        '
        'lbfiltpath
        '
        Me.lbfiltpath.AutoSize = True
        Me.lbfiltpath.Location = New System.Drawing.Point(72, 24)
        Me.lbfiltpath.Name = "lbfiltpath"
        Me.lbfiltpath.Size = New System.Drawing.Size(0, 13)
        Me.lbfiltpath.TabIndex = 9
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnMessDe)
        Me.GroupBox5.Controls.Add(Me.txtmessStart)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 359)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(171, 62)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Message Start String"
        '
        'btnMessDe
        '
        Me.btnMessDe.Location = New System.Drawing.Point(99, 24)
        Me.btnMessDe.Name = "btnMessDe"
        Me.btnMessDe.Size = New System.Drawing.Size(63, 25)
        Me.btnMessDe.TabIndex = 1
        Me.btnMessDe.Text = "Default"
        Me.btnMessDe.UseVisualStyleBackColor = True
        '
        'txtmessStart
        '
        Me.txtmessStart.Location = New System.Drawing.Point(6, 27)
        Me.txtmessStart.MaxLength = 11
        Me.txtmessStart.Name = "txtmessStart"
        Me.txtmessStart.Size = New System.Drawing.Size(87, 20)
        Me.txtmessStart.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnClearCSV)
        Me.GroupBox6.Controls.Add(Me.btnChangeCSV)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.lbCSVPath)
        Me.GroupBox6.Location = New System.Drawing.Point(189, 198)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(263, 87)
        Me.GroupBox6.TabIndex = 15
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Sensor Save Path"
        '
        'btnClearCSV
        '
        Me.btnClearCSV.Location = New System.Drawing.Point(68, 41)
        Me.btnClearCSV.Name = "btnClearCSV"
        Me.btnClearCSV.Size = New System.Drawing.Size(56, 27)
        Me.btnClearCSV.TabIndex = 12
        Me.btnClearCSV.Text = "Clear"
        Me.btnClearCSV.UseVisualStyleBackColor = True
        '
        'btnChangeCSV
        '
        Me.btnChangeCSV.Location = New System.Drawing.Point(6, 40)
        Me.btnChangeCSV.Name = "btnChangeCSV"
        Me.btnChangeCSV.Size = New System.Drawing.Size(56, 28)
        Me.btnChangeCSV.TabIndex = 11
        Me.btnChangeCSV.Text = "Change"
        Me.btnChangeCSV.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Save Path:"
        '
        'lbCSVPath
        '
        Me.lbCSVPath.AutoSize = True
        Me.lbCSVPath.Location = New System.Drawing.Point(72, 24)
        Me.lbCSVPath.Name = "lbCSVPath"
        Me.lbCSVPath.Size = New System.Drawing.Size(0, 13)
        Me.lbCSVPath.TabIndex = 9
        '
        'ckhIgnoreZ
        '
        Me.ckhIgnoreZ.AutoSize = True
        Me.ckhIgnoreZ.Location = New System.Drawing.Point(324, 291)
        Me.ckhIgnoreZ.Name = "ckhIgnoreZ"
        Me.ckhIgnoreZ.Size = New System.Drawing.Size(90, 17)
        Me.ckhIgnoreZ.TabIndex = 16
        Me.ckhIgnoreZ.Text = "Ignore Height"
        Me.ckhIgnoreZ.UseVisualStyleBackColor = True
        '
        'NUDTimeZone
        '
        Me.NUDTimeZone.Location = New System.Drawing.Point(253, 290)
        Me.NUDTimeZone.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NUDTimeZone.Minimum = New Decimal(New Integer() {12, 0, 0, -2147483648})
        Me.NUDTimeZone.Name = "NUDTimeZone"
        Me.NUDTimeZone.Size = New System.Drawing.Size(37, 20)
        Me.NUDTimeZone.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(189, 293)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Time Zone"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtFLPort)
        Me.GroupBox7.Controls.Add(Me.txtFLHost)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 277)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(171, 76)
        Me.GroupBox7.TabIndex = 20
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "FLDigi Connection"
        '
        'txtFLPort
        '
        Me.txtFLPort.Location = New System.Drawing.Point(44, 45)
        Me.txtFLPort.Name = "txtFLPort"
        Me.txtFLPort.Size = New System.Drawing.Size(60, 20)
        Me.txtFLPort.TabIndex = 6
        '
        'txtFLHost
        '
        Me.txtFLHost.Location = New System.Drawing.Point(44, 19)
        Me.txtFLHost.Name = "txtFLHost"
        Me.txtFLHost.Size = New System.Drawing.Size(121, 20)
        Me.txtFLHost.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Host"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Port"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(464, 428)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.NUDTimeZone)
        Me.Controls.Add(Me.ckhIgnoreZ)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.NUDTimeZone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstfilter As System.Windows.Forms.ListBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtAdd As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRAll As System.Windows.Forms.Button
    Friend WithEvents btnClearPath As System.Windows.Forms.Button
    Friend WithEvents btnChangePath As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbpath As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbClearFiltPath As System.Windows.Forms.Button
    Friend WithEvents lbChangeFiltPath As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbfiltpath As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmessStart As System.Windows.Forms.TextBox
    Friend WithEvents btnMessDe As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearCSV As System.Windows.Forms.Button
    Friend WithEvents btnChangeCSV As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbCSVPath As System.Windows.Forms.Label
    Friend WithEvents ckhIgnoreZ As System.Windows.Forms.CheckBox
    Friend WithEvents NUDTimeZone As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFLPort As System.Windows.Forms.TextBox
    Friend WithEvents txtFLHost As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
