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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbTimer = New System.Windows.Forms.Label()
        Me.lbError = New System.Windows.Forms.Label()
        Me.lbHeading = New System.Windows.Forms.Label()
        Me.lbAlt = New System.Windows.Forms.Label()
        Me.lbSpeed = New System.Windows.Forms.Label()
        Me.lbTime = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.dgName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbcomm = New System.Windows.Forms.Label()
        Me.lbGPSpos = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.rctBorder = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(196, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Avionics and Sensor Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Time Since Last Update"
        '
        'lbTimer
        '
        Me.lbTimer.AutoSize = True
        Me.lbTimer.Location = New System.Drawing.Point(365, 142)
        Me.lbTimer.Name = "lbTimer"
        Me.lbTimer.Size = New System.Drawing.Size(0, 13)
        Me.lbTimer.TabIndex = 12
        '
        'lbError
        '
        Me.lbError.AutoSize = True
        Me.lbError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbError.Location = New System.Drawing.Point(10, 139)
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
        Me.lbHeading.Location = New System.Drawing.Point(104, 112)
        Me.lbHeading.Name = "lbHeading"
        Me.lbHeading.Size = New System.Drawing.Size(0, 16)
        Me.lbHeading.TabIndex = 4
        '
        'lbAlt
        '
        Me.lbAlt.AutoSize = True
        Me.lbAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAlt.ForeColor = System.Drawing.Color.Navy
        Me.lbAlt.Location = New System.Drawing.Point(104, 86)
        Me.lbAlt.Name = "lbAlt"
        Me.lbAlt.Size = New System.Drawing.Size(0, 16)
        Me.lbAlt.TabIndex = 3
        '
        'lbSpeed
        '
        Me.lbSpeed.AutoSize = True
        Me.lbSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSpeed.ForeColor = System.Drawing.Color.Navy
        Me.lbSpeed.Location = New System.Drawing.Point(118, 60)
        Me.lbSpeed.Name = "lbSpeed"
        Me.lbSpeed.Size = New System.Drawing.Size(0, 16)
        Me.lbSpeed.TabIndex = 2
        '
        'lbTime
        '
        Me.lbTime.AutoSize = True
        Me.lbTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTime.ForeColor = System.Drawing.Color.Navy
        Me.lbTime.Location = New System.Drawing.Point(59, 11)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(0, 16)
        Me.lbTime.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Time"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Heading (°)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Altitude (m)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Speed (kmph)"
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        Me.dgvData.BackgroundColor = Me.BackColor
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgName, Me.dgValue})
        Me.dgvData.GridColor = System.Drawing.SystemColors.Control
        Me.dgvData.Location = New System.Drawing.Point(199, 23)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.Size = New System.Drawing.Size(223, 109)
        Me.dgvData.TabIndex = 17
        '
        'dgName
        '
        Me.dgName.HeaderText = "Name"
        Me.dgName.Name = "dgName"
        Me.dgName.ReadOnly = True
        '
        'dgValue
        '
        Me.dgValue.HeaderText = "Value"
        Me.dgValue.Name = "dgValue"
        Me.dgValue.ReadOnly = True
        '
        'lbcomm
        '
        Me.lbcomm.AutoSize = True
        Me.lbcomm.Location = New System.Drawing.Point(14, 165)
        Me.lbcomm.Name = "lbcomm"
        Me.lbcomm.Size = New System.Drawing.Size(0, 13)
        Me.lbcomm.TabIndex = 18
        '
        'lbGPSpos
        '
        Me.lbGPSpos.AutoSize = True
        Me.lbGPSpos.Location = New System.Drawing.Point(20, 38)
        Me.lbGPSpos.Name = "lbGPSpos"
        Me.lbGPSpos.Size = New System.Drawing.Size(0, 13)
        Me.lbGPSpos.TabIndex = 19
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.rctBorder})
        Me.ShapeContainer1.Size = New System.Drawing.Size(436, 187)
        Me.ShapeContainer1.TabIndex = 20
        Me.ShapeContainer1.TabStop = False
        '
        'rctBorder
        '
        Me.rctBorder.BorderColor = System.Drawing.Color.Black
        Me.rctBorder.BorderWidth = 4
        Me.rctBorder.Location = New System.Drawing.Point(3, 2)
        Me.rctBorder.Name = "rctBorder"
        Me.rctBorder.Size = New System.Drawing.Size(429, 180)
        '
        'HUD_UC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbGPSpos)
        Me.Controls.Add(Me.lbcomm)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
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
        Me.Controls.Add(Me.ShapeContainer1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "HUD_UC"
        Me.Size = New System.Drawing.Size(436, 187)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
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
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents dgName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbcomm As System.Windows.Forms.Label
    Friend WithEvents lbGPSpos As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents rctBorder As Microsoft.VisualBasic.PowerPacks.RectangleShape

End Class
