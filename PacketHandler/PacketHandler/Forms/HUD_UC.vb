Public Class HUD_UC
    'will need to be changed to use the new PacketStructure class.


#Region "Fields"

    'Private FrameToDisplay_ As Frame = New Frame()
    Private WithEvents timeSinceLastTmr As New System.Timers.Timer
    Private secondsSinceLast As Integer = 0
    Private DisplayAllPackets_ As Boolean = False
    Private DisplayIfGPS_ As Boolean = True
    Private FrameDisplaying As Frame
    'Private LastValid As Frame
    Private LastGoodGPS As GPScoord

#End Region

#Region "threading"
    Delegate Sub readsetd()
    Delegate Sub readsetdDL(ByVal doGPS As Boolean, ByVal doData As Boolean)
    Delegate Sub SetRTBd(ByVal text As String, ByVal BoxToChange As RichTextBox)
    Delegate Sub SetLBd(ByVal text As String, ByVal LabelToChange As Label)
    Delegate Sub SetListd(ByVal text As String, ByVal ListToChange As ListBox)
    Delegate Sub Updated()
    Private Sub SetRTB(ByVal value As String, ByVal BoxToChange As RichTextBox)
        Dim a(1) As Object
        If BoxToChange.InvokeRequired Then
            Dim del As New SetRTBd(AddressOf SetRTB)
            a(0) = value
            a(1) = BoxToChange
            Me.Invoke(del, a)
        Else
            BoxToChange.Text = BoxToChange.Text & value
            ' BoxToChange.SelectionStart = BoxToChange.Find(value)
            'BoxToChange.SelectionColor = Color.Yellow
        End If
    End Sub

    Private Sub SetList(ByVal value As String, ByVal ListToChange As ListBox)
        Dim a(1) As Object
        If ListToChange.InvokeRequired Then
            Dim del As New SetListd(AddressOf SetList)
            a(0) = value
            a(1) = ListToChange
            Me.Invoke(del, a)
        Else
            ListToChange.Items.Add(value)
        End If
    End Sub

    Private Sub SetLB(ByVal value As String, ByVal LabelToChange As Label)
        Dim a(1) As Object
        If LabelToChange.InvokeRequired Then
            Dim del As New SetLBd(AddressOf SetLB)
            a(0) = value
            a(1) = LabelToChange
            Me.Invoke(del, a)
        Else
            LabelToChange.Text = value
        End If
    End Sub

    Private Sub Updateth()
        Dim a(1) As Object
        If lbAlt.InvokeRequired Then
            Dim del As New readsetd(AddressOf Updateth)
            Me.Invoke(del)
        Else
            UpdateDisplay()
        End If
    End Sub

    'Private Sub ReadSDL(Optional ByVal doGPS As Boolean = True, Optional ByVal doData As Boolean = True)
    '    Dim a(1) As Object
    '    If lbBV.InvokeRequired Then
    '        Dim del As New readsetdDL(AddressOf ReadSDL)
    '        a(0) = doGPS
    '        a(1) = doData
    '        Me.Invoke(del, a)
    '    Else
    '        ReadAndSetDL(doGPS, doData)
    '    End If
    'End Sub
#End Region

#Region "Properties"


    'Public ReadOnly Property FrameToDisplay() As Frame
    '    'Get
    '    '    Return FrameToDisplay_
    '    'End Get
    '    'Set(ByVal value As Frame)
    '    '    FrameToDisplay_ = value
    '    '    secondsSinceLast = 0

    '    '    SetLB("", lbTimer)  ' lbTimer.Text = ""
    '    '    ResetClock()
    '    '    Updateth()
    '    'End Set
    'End Property

    Public Property DisplayAllPackets As Boolean
        Get
            Return DisplayAllPackets_
        End Get
        Set(ByVal value As Boolean)
            DisplayAllPackets_ = value
        End Set
    End Property

    Public Property DisplayIfGPS As Boolean
        Get
            Return DisplayIfGPS_
        End Get
        Set(ByVal value As Boolean)
            DisplayIfGPS_ = value
        End Set
    End Property
#End Region

    Public Function AddFrame(ByVal frame As Frame)

        If Not DisplayAllPackets_ And (Not frame.CheckSum) Then

            If (Not DisplayIfGPS_) Then Return False

            If frame.GPSCoordinates Is Nothing Then Return False
        End If

        If FrameDisplaying Is Nothing Then
            FrameDisplaying = frame
            SetLB("", lbTimer)  ' lbTimer.Text = ""
            secondsSinceLast = 0
            ResetClock()
            Updateth()
            Return True
        Else
            If FrameDisplaying.PcktCounter < frame.PcktCounter Then
                FrameDisplaying = frame
                SetLB("", lbTimer)  ' lbTimer.Text = ""
                secondsSinceLast = 0
                ResetClock()
                Updateth()
                Return True
            Else
                Return False
            End If
        End If

        Return True
    End Function


    Public Sub ClearDisplay()
        FrameDisplaying = Nothing
        ResetClock()
        SetLB("", lbTimer)
        UpdateDisplay()
    End Sub

    Public Sub UpdateDisplay()
        If Not FrameDisplaying.Empty Then
            lbAlt.Text = FrameDisplaying.Altitude
            lbHeading.Text = FrameDisplaying.Heading
            lbSpeed.Text = FrameDisplaying.Speed
            lbTime.Text = FrameDisplaying.PacketTime
        End If

        If FrameDisplaying.CheckSum Then
            rctBorder.BorderColor = Color.Black
        Else
            rctBorder.BorderColor = Color.Red
        End If


        timeSinceLastTmr.Enabled = True
        lbcomm.Text = FrameDisplaying.Comment

        If FrameDisplaying.GPSCoordinates Is Nothing Then
            If LastGoodGPS Is Nothing Then
                lbGPSpos.Text = ""
            Else
                lbGPSpos.Text = Math.Round(LastGoodGPS.sLatitudeDecimal, 4).ToString + "  " + Math.Round(LastGoodGPS.sLongitudeDecimal, 4).ToString
                lbGPSpos.ForeColor = Color.Blue
            End If
        Else
            lbGPSpos.Text = Math.Round(FrameDisplaying.GPSCoordinates.sLatitudeDecimal, 4).ToString + "  " + Math.Round(FrameDisplaying.GPSCoordinates.sLongitudeDecimal, 4).ToString
            lbGPSpos.ForeColor = Color.Black
            LastGoodGPS = FrameDisplaying.GPSCoordinates
        End If

        For i As Integer = 1 To dgvData.Rows.Count
            If dgvData.Rows(0).IsNewRow Then Exit For
            dgvData.Rows.RemoveAt(0)
        Next


        Dim a As String() = {"", ""}
        For Each k As KeyValuePair(Of String, Double) In FrameDisplaying.PICdata

            a(0) = k.Key
            a(1) = k.Value.ToString



            dgvData.Rows.Add(a)
        Next
        a(0) = "Sats"
        a(1) = FrameDisplaying.Sats
        dgvData.Rows.Add(a)



    End Sub

    Private Sub Timer_tick() Handles timeSinceLastTmr.Elapsed
        secondsSinceLast = secondsSinceLast + 1
        UpdateClock()
        ResetClock()
    End Sub

    Private Sub UpdateClock()
        Dim tempint = 0
        Dim str As String
        tempint = Math.Truncate(secondsSinceLast / 60)
        ' lbTimer.Text = tempint.ToString() & ":"
        str = tempint.ToString() & ":"
        'SetLB(tempint.ToString() & ":", lbTimer)

        tempint = (secondsSinceLast Mod 60)
        If tempint < 10 Then str = str & "0" ' SetLB(lbTimer.Text & "0", lbTimer) 'lbTimer.Text = lbTimer.Text & "0"

        ' lbTimer.Text = lbTimer.Text & tempint.ToString
        ' SetLB(lbTimer.Text & tempint.ToString, lbTimer)
        str = str & tempint.ToString
        SetLB(str, lbTimer)


    End Sub

    Public Sub ResetClock()
        timeSinceLastTmr.Stop()
        timeSinceLastTmr.Enabled = False
        timeSinceLastTmr.close()
        timeSinceLastTmr = New System.Timers.Timer()
        timeSinceLastTmr.Interval = 1000
        timeSinceLastTmr.Enabled = True
        'lbTimer.Text = ""
        ' SetLB("", lbTimer)
    End Sub


    Private Sub HUD_UC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timeSinceLastTmr.Enabled = False
        timeSinceLastTmr.Interval = 1000

    End Sub
End Class
