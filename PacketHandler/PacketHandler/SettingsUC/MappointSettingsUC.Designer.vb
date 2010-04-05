<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MappointSettingsUC
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
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(40, 29)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(50, 20)
        Me.txtPort.TabIndex = 7
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(40, 3)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(125, 20)
        Me.txtHost.TabIndex = 6
        Me.txtHost.Text = "127.0.0.1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Host"
        '
        'MappointSettingsUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MappointSettingsUC"
        Me.Size = New System.Drawing.Size(203, 145)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
