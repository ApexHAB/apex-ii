Public Class HUD_UC
    'will need to be changed to use the new PacketStructure class.
#Region "Fields"

    Private FrameToDisplay_ As Frame = New Frame()
    Private WithEvents timeSinceLastTmr As Timer = New Timer()
    Private secondsSinceLast As Integer = 0


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

    Public Property FrameToDisplay() As Frame
        Get
            Return FrameToDisplay_
        End Get
        Set(ByVal value As Frame)
            FrameToDisplay_ = value
            secondsSinceLast = 0

            SetLB("", lbTimer)  ' lbTimer.Text = ""
            timeSinceLastTmr.Stop()
            timeSinceLastTmr.Start()
            Updateth()
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

        If FrameToDisplay_.GPSCoordinates Is Nothing Then
            lbGPSpos.Text = ""
        Else
            lbGPSpos.Text = Math.Round(FrameToDisplay_.GPSCoordinates.sLatitudeDecimal, 4).ToString + "  " + Math.Round(FrameToDisplay_.GPSCoordinates.sLongitudeDecimal, 4).ToString

        End If

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
