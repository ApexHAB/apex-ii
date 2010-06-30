Public Class HUD_UC
    'will need to be changed to use the new PacketStructure class.
#Region "Fields"

    Private FrameToDisplay_ As Frame = New Frame()
    Private WithEvents timeSinceLastTmr As Timer = New Timer()
    Private secondsSinceLast As Integer = 0


#End Region

#Region "Properties"

    Public Property FrameToDisplay() As Frame
        Get
            Return FrameToDisplay_
        End Get
        Set(ByVal value As Frame)
            FrameToDisplay_ = value
            secondsSinceLast = 0
            lbTimer.Text = ""
            timeSinceLastTmr.Stop()
            timeSinceLastTmr.Start()
            UpdateDisplay()
        End Set
    End Property


#End Region

    Public Sub ClearDisplay()
        FrameToDisplay_ = New Frame()
        ResetClock()
        UpdateDisplay()
    End Sub

    Public Sub UpdateDisplay()
        If Not FrameToDisplay_.Empty Then
            lbAlt.Text = FrameToDisplay_.Altitude
            lbHeading.Text = FrameToDisplay_.Heading
            lbSpeed.Text = FrameToDisplay_.Speed
            lbTime.Text = FrameToDisplay_.PacketTime
        End If

        timeSinceLastTmr.Enabled = True
        lbcomm.Text = FrameToDisplay_.Comment

        For i As Integer = 1 To dgvData.Rows.Count
            If dgvData.Rows(0).IsNewRow Then Exit For
            dgvData.Rows.RemoveAt(0)
        Next


        Dim a As String() = {"", ""}
        For Each k As KeyValuePair(Of String, Double) In FrameToDisplay_.PICdata

            a(0) = k.Key
            a(1) = k.Value.ToString



            dgvData.Rows.Add(a)
        Next



    End Sub

    Private Sub Timer_tick() Handles timeSinceLastTmr.Tick
        secondsSinceLast = secondsSinceLast + 1
        UpdateClock()
    End Sub

    Private Sub UpdateClock()
        Dim tempint = 0

        tempint = Math.Truncate(secondsSinceLast / 60)
        lbTimer.Text = tempint.ToString() & ":"


        tempint = (secondsSinceLast Mod 60)
        If tempint < 10 Then lbTimer.Text = lbTimer.Text & "0"
        lbTimer.Text = lbTimer.Text & tempint.ToString





    End Sub

    Public Sub ResetClock()
        timeSinceLastTmr.Enabled = False
        lbTimer.Text = ""
    End Sub


    Private Sub HUD_UC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timeSinceLastTmr.Enabled = False
        timeSinceLastTmr.Interval = 1000

    End Sub

    Private Sub dgvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellContentClick

    End Sub
End Class
