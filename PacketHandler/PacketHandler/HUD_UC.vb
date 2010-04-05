Public Class HUD_UC

    Private FrameToDisplay_ As Frame

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
        lbAlt.Text = FrameToDisplay_.Altitude
        lbHeading.Text = FrameToDisplay_.Heading
        lbSpeed.Text = FrameToDisplay_.Speed
        lbTime.Text = FrameToDisplay_.PacketTime


    End Sub
End Class
