<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(panel))
        Me.Altitude1 = New APRS_Analyser.altitude
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Altitude1
        '
        Me.Altitude1.BackgroundImage = CType(resources.GetObject("Altitude1.BackgroundImage"), System.Drawing.Image)
        Me.Altitude1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Altitude1.Location = New System.Drawing.Point(50, 12)
        Me.Altitude1.Name = "Altitude1"
        Me.Altitude1.Size = New System.Drawing.Size(192, 196)
        Me.Altitude1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(91, 227)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 27)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Altitude1)
        Me.Name = "panel"
        Me.Text = "panel"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Altitude1 As APRS_Analyser.altitude
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
