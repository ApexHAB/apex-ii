Public Class HUD_UC

    Private FrameToDisplay_ As Frame = New Frame()
    Private WithEvents timeSinceLastTmr As Timer = New Timer()
    Private secondsSinceLast As Integer = 0

    Public Property FrameToDisplay() As Frame
        Get
            Return FrameToDisplay_
        End Get
        Set(ByVal value As Frame)
            FrameToDisplay_ = value
            UpdateDisplay()
        End Set
    End Property


    Public Sub ClearDispay()

    End Sub

    Public Sub UpdateDisplay()
        If Not FrameToDisplay_.Empty Then
            lbAlt.Text = FrameToDisplay_.Altitude
            lbHeading.Text = FrameToDisplay_.Heading
            lbSpeed.Text = FrameToDisplay_.Speed
            lbTime.Text = FrameToDisplay_.PacketTime
        End If

        timeSinceLastTmr.Enabled = True



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
End Class
