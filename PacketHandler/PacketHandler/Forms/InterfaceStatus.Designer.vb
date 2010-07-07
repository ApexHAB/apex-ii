<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterfaceStatus
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
        Me.pnlStatuses = New System.Windows.Forms.Panel()
        Me.txtMessages = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnlStatuses
        '
        Me.pnlStatuses.AutoScroll = True
        Me.pnlStatuses.Location = New System.Drawing.Point(12, 12)
        Me.pnlStatuses.Name = "pnlStatuses"
        Me.pnlStatuses.Size = New System.Drawing.Size(311, 245)
        Me.pnlStatuses.TabIndex = 1
        '
        'txtMessages
        '
        Me.txtMessages.Location = New System.Drawing.Point(12, 263)
        Me.txtMessages.Multiline = True
        Me.txtMessages.Name = "txtMessages"
        Me.txtMessages.ReadOnly = True
        Me.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessages.Size = New System.Drawing.Size(311, 125)
        Me.txtMessages.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(248, 394)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'InterfaceStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 430)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtMessages)
        Me.Controls.Add(Me.pnlStatuses)
        Me.Name = "InterfaceStatus"
        Me.Text = "InterfaceStatus"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlStatuses As System.Windows.Forms.Panel
    Friend WithEvents txtMessages As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
