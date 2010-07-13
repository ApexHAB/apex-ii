<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Graphs
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
        Me.chpnl = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'chpnl
        '
        Me.chpnl.AutoScroll = True
        Me.chpnl.BackColor = System.Drawing.Color.White
        Me.chpnl.Location = New System.Drawing.Point(-1, 0)
        Me.chpnl.Name = "chpnl"
        Me.chpnl.Size = New System.Drawing.Size(616, 529)
        Me.chpnl.TabIndex = 4
        '
        'Graphs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 529)
        Me.Controls.Add(Me.chpnl)
        Me.MaximumSize = New System.Drawing.Size(632, 1240)
        Me.MinimumSize = New System.Drawing.Size(632, 240)
        Me.Name = "Graphs"
        Me.Text = "Data"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chpnl As System.Windows.Forms.Panel
End Class
