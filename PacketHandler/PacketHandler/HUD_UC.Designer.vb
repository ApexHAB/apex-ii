<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HUD_UC
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lbIT = New System.Windows.Forms.Label
        Me.lbOT = New System.Windows.Forms.Label
        Me.lbPP = New System.Windows.Forms.Label
        Me.lbBV = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbTimer = New System.Windows.Forms.Label
        Me.lbError = New System.Windows.Forms.Label
        Me.lbHeading = New System.Windows.Forms.Label
        Me.lbAlt = New System.Windows.Forms.Label
        Me.lbSpeed = New System.Windows.Forms.Label
        Me.lbTime = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(189, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Avionics and Sensor Data"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbIT)
        Me.Panel2.Controls.Add(Me.lbOT)
        Me.Panel2.Controls.Add(Me.lbPP)
        Me.Panel2.Controls.Add(Me.lbBV)
        Me.Panel2.Location = New System.Drawing.Point(322, 28)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(83, 109)
        Me.Panel2.TabIndex = 15
        '
        'lbIT
        '
        Me.lbIT.AutoSize = True
        Me.lbIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbIT.Location = New System.Drawing.Point(3, 0)
        Me.lbIT.Name = "lbIT"
        Me.lbIT.Size = New System.Drawing.Size(0, 13)
        Me.lbIT.TabIndex = 7
        '
        'lbOT
        '
        Me.lbOT.AutoSize = True
        Me.lbOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbOT.Location = New System.Drawing.Point(4, 26)
        Me.lbOT.Name = "lbOT"
        Me.lbOT.Size = New System.Drawing.Size(0, 13)
        Me.lbOT.TabIndex = 8
        '
        'lbPP
        '
        Me.lbPP.AutoSize = True
        Me.lbPP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbPP.Location = New System.Drawing.Point(3, 51)
        Me.lbPP.Name = "lbPP"
        Me.lbPP.Size = New System.Drawing.Size(0, 13)
        Me.lbPP.TabIndex = 9
        '
        'lbBV
        '
        Me.lbBV.AutoSize = True
        Me.lbBV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbBV.Location = New System.Drawing.Point(4, 74)
        Me.lbBV.Name = "lbBV"
        Me.lbBV.Size = New System.Drawing.Size(0, 13)
        Me.lbBV.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(192, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(124, 105)
        Me.Panel1.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Inside Temp (C)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 15)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Battery Voltage (V)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Outside Temp (C)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Pressure (mb)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(192, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Time Since Last Update"
        '
        'lbTimer
        '
        Me.lbTimer.AutoSize = True
        Me.lbTimer.Location = New System.Drawing.Point(358, 140)
        Me.lbTimer.Name = "lbTimer"
        Me.lbTimer.Size = New System.Drawing.Size(0, 13)
        Me.lbTimer.TabIndex = 12
        '
        'lbError
        '
        Me.lbError.AutoSize = True
        Me.lbError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbError.Location = New System.Drawing.Point(3, 137)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(74, 16)
        Me.lbError.TabIndex = 11
        Me.lbError.Text = "ERROR!!!"
        Me.lbError.Visible = False
        '
        'lbHeading
        '
        Me.lbHeading.AutoSize = True
        Me.lbHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHeading.ForeColor = System.Drawing.Color.Navy
        Me.lbHeading.Location = New System.Drawing.Point(97, 110)
        Me.lbHeading.Name = "lbHeading"
        Me.lbHeading.Size = New System.Drawing.Size(0, 16)
        Me.lbHeading.TabIndex = 4
        '
        'lbAlt
        '
        Me.lbAlt.AutoSize = True
        Me.lbAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAlt.ForeColor = System.Drawing.Color.Navy
        Me.lbAlt.Location = New System.Drawing.Point(97, 84)
        Me.lbAlt.Name = "lbAlt"
        Me.lbAlt.Size = New System.Drawing.Size(0, 16)
        Me.lbAlt.TabIndex = 3
        '
        'lbSpeed
        '
        Me.lbSpeed.AutoSize = True
        Me.lbSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSpeed.ForeColor = System.Drawing.Color.Navy
        Me.lbSpeed.Location = New System.Drawing.Point(97, 58)
        Me.lbSpeed.Name = "lbSpeed"
        Me.lbSpeed.Size = New System.Drawing.Size(0, 16)
        Me.lbSpeed.TabIndex = 2
        '
        'lbTime
        '
        Me.lbTime.AutoSize = True
        Me.lbTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTime.ForeColor = System.Drawing.Color.Navy
        Me.lbTime.Location = New System.Drawing.Point(52, 9)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(0, 16)
        Me.lbTime.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Time"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Heading (°)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Altitude (m)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Speed (kmph)"
        '
        'HUD_UC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbTimer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbError)
        Me.Controls.Add(Me.lbTime)
        Me.Controls.Add(Me.lbSpeed)
        Me.Controls.Add(Me.lbAlt)
        Me.Controls.Add(Me.lbHeading)
        Me.Name = "HUD_UC"
        Me.Size = New System.Drawing.Size(438, 189)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbIT As System.Windows.Forms.Label
    Friend WithEvents lbOT As System.Windows.Forms.Label
    Friend WithEvents lbPP As System.Windows.Forms.Label
    Friend WithEvents lbBV As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbTimer As System.Windows.Forms.Label
    Friend WithEvents lbError As System.Windows.Forms.Label
    Friend WithEvents lbHeading As System.Windows.Forms.Label
    Friend WithEvents lbAlt As System.Windows.Forms.Label
    Friend WithEvents lbSpeed As System.Windows.Forms.Label
    Friend WithEvents lbTime As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
