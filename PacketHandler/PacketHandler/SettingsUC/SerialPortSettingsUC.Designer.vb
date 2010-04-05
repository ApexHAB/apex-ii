<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SerialPortSettingsUC
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbPort = New System.Windows.Forms.ComboBox
        Me.txtBaud = New System.Windows.Forms.TextBox
        Me.txtDataBits = New System.Windows.Forms.TextBox
        Me.cmbStopBits = New System.Windows.Forms.ComboBox
        Me.cmbParity = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Baud"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Data Bits"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Stop Bits"
        '
        'cmbPort
        '
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(77, 4)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(85, 21)
        Me.cmbPort.TabIndex = 1
        '
        'txtBaud
        '
        Me.txtBaud.Location = New System.Drawing.Point(77, 31)
        Me.txtBaud.Name = "txtBaud"
        Me.txtBaud.Size = New System.Drawing.Size(85, 20)
        Me.txtBaud.TabIndex = 2
        '
        'txtDataBits
        '
        Me.txtDataBits.Location = New System.Drawing.Point(77, 57)
        Me.txtDataBits.Name = "txtDataBits"
        Me.txtDataBits.Size = New System.Drawing.Size(85, 20)
        Me.txtDataBits.TabIndex = 3
        '
        'cmbStopBits
        '
        Me.cmbStopBits.FormattingEnabled = True
        Me.cmbStopBits.Items.AddRange(New Object() {"0", "1", "2", "1.5"})
        Me.cmbStopBits.Location = New System.Drawing.Point(77, 83)
        Me.cmbStopBits.Name = "cmbStopBits"
        Me.cmbStopBits.Size = New System.Drawing.Size(85, 21)
        Me.cmbStopBits.TabIndex = 4
        '
        'cmbParity
        '
        Me.cmbParity.FormattingEnabled = True
        Me.cmbParity.Items.AddRange(New Object() {"None", "Odd", "Even", "Mark", "Space"})
        Me.cmbParity.Location = New System.Drawing.Point(77, 111)
        Me.cmbParity.Name = "cmbParity"
        Me.cmbParity.Size = New System.Drawing.Size(85, 21)
        Me.cmbParity.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Parity"
        '
        'SerialPortSettingsUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbParity)
        Me.Controls.Add(Me.cmbStopBits)
        Me.Controls.Add(Me.txtDataBits)
        Me.Controls.Add(Me.txtBaud)
        Me.Controls.Add(Me.cmbPort)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SerialPortSettingsUC"
        Me.Size = New System.Drawing.Size(212, 190)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents txtBaud As System.Windows.Forms.TextBox
    Friend WithEvents txtDataBits As System.Windows.Forms.TextBox
    Friend WithEvents cmbStopBits As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParity As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
