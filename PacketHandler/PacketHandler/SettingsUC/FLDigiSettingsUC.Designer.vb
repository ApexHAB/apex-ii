<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLDigiSettingsUC
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
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Port"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(41, 3)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(125, 20)
        Me.txtHost.TabIndex = 2
        Me.txtHost.Text = "127.0.0.1"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(41, 29)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(50, 20)
        Me.txtPort.TabIndex = 3
        '
        'FLDigiSettingsUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FLDigiSettingsUC"
        Me.Size = New System.Drawing.Size(208, 139)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox

End Class
