<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterfaceStatusUC
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
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lbstatus = New System.Windows.Forms.Label()
        Me.lbName = New System.Windows.Forms.Label()
        Me.txtMessages = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(190, 26)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(86, 26)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lbstatus
        '
        Me.lbstatus.AutoSize = True
        Me.lbstatus.Location = New System.Drawing.Point(3, 33)
        Me.lbstatus.Name = "lbstatus"
        Me.lbstatus.Size = New System.Drawing.Size(37, 13)
        Me.lbstatus.TabIndex = 2
        Me.lbstatus.Text = "Status"
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.Location = New System.Drawing.Point(3, 10)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(49, 16)
        Me.lbName.TabIndex = 3
        Me.lbName.Text = "Name"
        '
        'txtMessages
        '
        Me.txtMessages.Location = New System.Drawing.Point(6, 58)
        Me.txtMessages.Multiline = True
        Me.txtMessages.Name = "txtMessages"
        Me.txtMessages.ReadOnly = True
        Me.txtMessages.Size = New System.Drawing.Size(270, 85)
        Me.txtMessages.TabIndex = 4
        Me.txtMessages.WordWrap = False
        '
        'InterfaceStatusUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtMessages)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.lbstatus)
        Me.Controls.Add(Me.btnConnect)
        Me.Name = "InterfaceStatusUC"
        Me.Size = New System.Drawing.Size(286, 151)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents lbstatus As System.Windows.Forms.Label
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents txtMessages As System.Windows.Forms.TextBox

End Class
