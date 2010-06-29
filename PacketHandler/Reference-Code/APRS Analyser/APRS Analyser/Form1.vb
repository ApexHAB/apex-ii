Public Class MainForm
    Public ex As New extractor()
    Public exDL As New extractorDL()
    Public ex2 As New extractor()
    Public FileSavePath As String = ""
    Public FileSavePathfilt As String = ""
    Public FileSavePathCSV As String = ""
    Private savedf As Boolean = True
    Dim WithEvents packetH As PacketHandler
    Dim WithEvents client As TCPStreamHandler
    Public Filter As New List(Of String)
    Public Host As String
    Public Port As Int16
    Public HostFL As String
    Public PortFL As Int16
    Public timezone As Integer = 0
    Public RunningDir As String = System.AppDomain.CurrentDomain.BaseDirectory
    Dim WithEvents lastTimer As New System.Timers.Timer(1000)
    Private WithEvents serialport As New System.IO.Ports.SerialPort()
    Dim lastupdate As Integer = 0
    Dim GPScoordinates As New List(Of String)
    Public ignoreZ As Boolean = True
    Dim tempbuffer() As Byte = {}

    Dim correctPacketID As New List(Of Integer)
    Dim correctOnlyGPSPacketID As New List(Of Integer)
    Dim correctOnlyDataPacketID As New List(Of Integer)

    Dim GPSdata As New Collection
    Dim Sensordata As New Collection


#Region "threading"
    Delegate Sub readsetd()
    Delegate Sub readsetdDL(ByVal doGPS As Boolean, ByVal doData As Boolean)
    Delegate Sub SetRTBd(ByVal text As String, ByVal BoxToChange As RichTextBox)
    Delegate Sub SetLBd(ByVal text As String, ByVal LabelToChange As Label)
    Delegate Sub SetListd(ByVal text As String, ByVal ListToChange As ListBox)
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

    Private Sub ReadS()
        Dim a(1) As Object
        If lbBV.InvokeRequired Then
            Dim del As New readsetd(AddressOf ReadS)
            Me.Invoke(del)
        Else
            ReadAndSet()
        End If
    End Sub

    Private Sub ReadSDL(Optional ByVal doGPS As Boolean = True, Optional ByVal doData As Boolean = True)
        Dim a(1) As Object
        If lbBV.InvokeRequired Then
            Dim del As New readsetdDL(AddressOf ReadSDL)
            a(0) = doGPS
            a(1) = doData
            Me.Invoke(del, a)
        Else
            ReadAndSetDL(doGPS, doData)
        End If
    End Sub
#End Region

    Private Function AddToFile(ByVal path As String, ByVal data As String)

        If path.Length < 5 Then
            Return False
            Exit Function
        End If

        Try

            Dim writer As New System.IO.StreamWriter(path, True)
            writer.WriteLine(data)
            writer.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Private Function CreateKML(ByVal coordinates As List(Of String), ByVal path As String)
        Dim a As Integer
        Dim IsAbs As Boolean = True
        Dim FileSavePathKML As String = path
        If FileSavePathKML.Length < 5 Then
            Return False
            Exit Function
        End If
        'Try
        Dim writer As New System.IO.StreamWriter(FileSavePathKML, False)


        writer.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        writer.WriteLine("<kml xmlns=""http://www.opengis.net/kml/2.2"">")
        writer.WriteLine("<Document>")

        writer.WriteLine("<name>Paths</name>")
        writer.WriteLine("<visibility>1</visibility>")

        writer.WriteLine("<Placemark>")
        writer.WriteLine("<name>Rel" & a & "</name>")
        writer.WriteLine("<visibility>1</visibility>")
        writer.WriteLine("<LineString>")
        writer.WriteLine("<extrude>1</extrude>")
        writer.WriteLine("<tessellate>1</tessellate>")
        If coordinates(0).Substring(coordinates(0).Length - 1, 1) = "0" Then
            writer.WriteLine("<altitudeMode>relative</altitudeMode>")
            IsAbs = False
        Else
            writer.WriteLine("<altitudeMode>absolute</altitudeMode>")
        End If
        writer.WriteLine("<coordinates>")



        For a = 0 To coordinates.Count - 1

            If coordinates(a).Substring(coordinates(a).Length - 1, 1) = "0" Then

                If IsAbs = False Then
                    writer.WriteLine(coordinates(a))
                Else
                    writer.WriteLine("</coordinates>")
                    writer.WriteLine("</LineString>")
                    writer.WriteLine("</Placemark>")

                    writer.WriteLine("<Placemark>")
                    writer.WriteLine("<name>Rel" & a & "</name>")
                    writer.WriteLine("<visibility>1</visibility>")
                    writer.WriteLine("<LineString>")
                    writer.WriteLine("<extrude>1</extrude>")
                    writer.WriteLine("<tessellate>1</tessellate>")
                    writer.WriteLine("<altitudeMode>relative</altitudeMode>")
                    writer.WriteLine("<coordinates>")
                    writer.WriteLine(coordinates(a - 1))
                    writer.WriteLine(coordinates(a))
                End If
                IsAbs = False


            Else

                If IsAbs = True Then
                    writer.WriteLine(coordinates(a))
                Else
                    writer.WriteLine("</coordinates>")
                    writer.WriteLine("</LineString>")
                    writer.WriteLine("</Placemark>")

                    writer.WriteLine("<Placemark>")
                    writer.WriteLine("<name>Abs" & a & "</name>")
                    writer.WriteLine("<visibility>1</visibility>")
                    writer.WriteLine("<LineString>")
                    writer.WriteLine("<extrude>1</extrude>")
                    writer.WriteLine("<tessellate>1</tessellate>")
                    writer.WriteLine("<altitudeMode>absolute</altitudeMode>")
                    writer.WriteLine("<coordinates>")
                    writer.WriteLine(coordinates(a - 1))
                    writer.WriteLine(coordinates(a))
                End If
                IsAbs = True

            End If

        Next

        writer.WriteLine("</coordinates>")
        writer.WriteLine("</LineString>")
        writer.WriteLine("</Placemark>")

        writer.WriteLine("</Document>")
        writer.WriteLine("</kml>")


        writer.Close()
        savedf = True
        ' Catch ex As Exception
        '     MsgBox(ex.Message)
        '     Return False
        '    Exit Function
        ' End Try


        Return True
    End Function

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim str As String

        str = InputBox("Enter test string", , "@124840h5121.89N/00011.43W085/000/A=000000AVDATA-IT28OT25PP3536 SGSBALLOON")

        If str = "" Then Exit Sub

        SetRTB(str & vbCrLf, RTBAll)


        lastTimer.Enabled = True
        AddToFile(FileSavePath, str)
        ex.ExtractString(str)
        If lbTime.Text <> ex.PacketTime Then
            lbTimer.Text = "0:00"
            lastupdate = 0
        End If
        If ex.StatusPacket = True Then
            SetList(str & vbCrLf, LstStatus)
        Else
            SetList(str & vbCrLf, lstFiltered)
        End If
        ReadS()


    End Sub

    Private Sub PacketReceived(ByVal FromCall As String, ByVal ToCall As String, ByVal Header As String, ByVal Payload As String, ByVal All As String) Handles packetH.ReceivedPacket
        SetRTB(Payload & vbCrLf, RTBAll)

        Dim a As Integer

        For a = 0 To Filter.Count - 1
            If UCase(FromCall).Contains(UCase(Filter(a))) Then
                lastTimer.Enabled = True

                ex.ExtractString(Payload)
                If lbTime.Text <> ex.PacketTime Then
                    SetLB("0:00", lbTimer)
                    lastupdate = 0
                End If
                If ex.StatusPacket = True Then
                    SetList(Payload & vbCrLf, LstStatus)
                    AddToFile(FileSavePathfilt, All)
                Else
                    SetList(Payload & vbCrLf, lstFiltered)
                    AddToFile(FileSavePath, All)
                End If
                ReadS()
                Exit For
            End If
        Next

    End Sub

    Private Sub ReadAndSet()
        Dim lat As String
        Dim lng As String
        If ex.ValidPacket = True Then
            lbAlt.Text = ex.Altitude
            lbCoordinates.Text = ex.Latitude & "  " & ex.Longitude
            lbHeading.Text = ex.Heading
            lbSpeed.Text = ex.Speed
            lbTime.Text = ex.PacketTime
            lbcomment.Text = ex.Comment
            If ex.Longitude.Length >= 9 Then

                lat = Val(ex.Latitude(0) & ex.Latitude(1)) + ((Val(ex.Latitude(2) & ex.Latitude(3) & ex.Latitude(4) & ex.Latitude(5) & ex.Latitude(6))) / 60)
                lng = Val(ex.Longitude(0) & ex.Longitude(1) & ex.Longitude(2)) + (Val(ex.Longitude(3) & ex.Longitude(4) & ex.Longitude(5) & ex.Longitude(6) & ex.Longitude(7)) / 60)

                If ex.Longitude(8) = "W" Then lng = "-" & lng
                If ex.Latitude(7) = "S" Then lat = "-" & lat

                If ignoreZ = False Then
                    If lat <> "00.00000" Then GPScoordinates.Add(lng & "," & lat & "," & ex.Altitude * 0.3048)
                Else
                    If lat <> "00.00000" Then GPScoordinates.Add(lng & "," & lat & ",0")
                End If

                savedf = False
            End If


        Else
            lbcomment.Text = "DEFORMED PACKET"
        End If

        If ex.GPSERROR = True Then lbError.Text = "GPS ERROR!!!"
        If ex.GPSNOLOCK = True Then lbError.Text = "NOLOCK!!!"

        If (ex.GPSERROR = True) Or (ex.GPSNOLOCK = True) Then
            lbError.Visible = True
            Label7.Text = "Time (PIC)"
        Else
            lbError.Visible = False
            Label7.Text = "Time"
        End If

        If lbTime.Text = "00:00:00" Then
            lbTime.Text = Date.Now.ToLongTimeString
            Label7.Text = "Time (sys)"
        End If


        If ex.TIMEOUT = True Then
            Panel1.ForeColor = Color.Red
        Else
            Panel1.ForeColor = Color.Black
        End If

        lbBV.Text = Math.Round((ex.PICdata("BV") / 4096 * 10), 1)
        lbIT.Text = Math.Round(ProcessTemp(ex.PICdata("IT")), 1)
        lbOT.Text = Math.Round(ProcessTemp(ex.PICdata("OT")), 1)
        lbPP.Text = Math.Round(ProcessPressure(ex.PICdata("PP")), 1)
        AddToFile(FileSavePathCSV, lbTime.Text & "," & lbBV.Text & "," & lbIT.Text & "," & lbOT.Text & "," & lbPP.Text)
    End Sub

    Private Sub ReadAndSetDL(Optional ByVal doGPS As Boolean = True, Optional ByVal doData As Boolean = True)
        Dim lat As String
        Dim lng As String
        If exDL.ValidPacketGPS = True Then
            lbAlt.Text = exDL.Altitude
            lbCoordinates.Text = exDL.Latitude & "  " & exDL.Longitude
            lbHeading.Text = exDL.Heading
            lbSpeed.Text = exDL.Speed
            lbTime.Text = exDL.PacketTime
            lbcomment.Text = exDL.Comment
            If exDL.Longitude.Length >= 9 Then

                lat = Val(exDL.Latitude(0) & exDL.Latitude(1)) + ((Val(exDL.Latitude(2) & exDL.Latitude(3) & exDL.Latitude(4) & exDL.Latitude(5) & exDL.Latitude(6))) / 60)
                lng = Val(exDL.Longitude(0) & exDL.Longitude(1) & exDL.Longitude(2)) + (Val(exDL.Longitude(3) & exDL.Longitude(4) & exDL.Longitude(5) & exDL.Longitude(6) & exDL.Longitude(7)) / 60)

                If exDL.Longitude(8) = "W" Then lng = "-" & lng
                If exDL.Latitude(7) = "S" Then lat = "-" & lat

                If ignoreZ = False Then
                    If lat <> "00.00000" Then GPScoordinates.Add(lng & "," & lat & "," & exDL.Altitude * 0.3048)
                Else
                    If lat <> "00.00000" Then GPScoordinates.Add(lng & "," & lat & ",0")
                End If

                savedf = False
            End If


        Else
            lbcomment.Text = "DEFORMED PACKET"
        End If

        If exDL.GPSERROR = True Then lbError.Text = "GPS ERROR!!!"
        If exDL.GPSNOLOCK = True Then lbError.Text = "NOLOCK!!!"

        If (exDL.GPSERROR = True) Or (exDL.GPSNOLOCK = True) Then
            lbError.Visible = True
            Label7.Text = "Time (PIC)"
        Else
            lbError.Visible = False
            Label7.Text = "Time"
        End If

        If lbTime.Text = "00:00:00" Then
            lbTime.Text = Date.Now.ToLongTimeString
            Label7.Text = "Time (sys)"
        End If


        If exDL.TIMEOUT = True Then
            Panel1.ForeColor = Color.Red
        Else
            Panel1.ForeColor = Color.Black
        End If

        lbBV.Text = Math.Round((exDL.PICdata("A1") / 4096 * 10), 1)
        lbIT.Text = Math.Round(ProcessTemp(exDL.PICdata("T0")), 1)
        lbOT.Text = Math.Round(ProcessTemp(exDL.PICdata("T1")), 1)
        lbPP.Text = Math.Round(ProcessPressure(exDL.PICdata("A0")), 1)

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        ' Settings.t()
        Settings.Show()
    End Sub

    Private Sub MainForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Dim path As String = RunningDir & "\filter.txt"
        Dim writer As New System.IO.StreamWriter(path, False)

        Dim a As Integer

        For a = 0 To Filter.Count - 1
            writer.WriteLine(Filter(a))
        Next
        writer.Close()

        path = RunningDir & "\save.txt"
        Dim writer1 As New System.IO.StreamWriter(path, False)
        writer1.WriteLine(FileSavePath)
        writer1.WriteLine(FileSavePathfilt)
        writer1.WriteLine(FileSavePathCSV)
        writer1.WriteLine(ex.StatusPacketStartText)
        writer1.WriteLine(ignoreZ.ToString)
        writer1.WriteLine(timezone)


        writer1.Close()


        Do While System.IO.File.Exists(RunningDir & "\autosave" & Date.Now.Day & Date.Now.Month & Date.Now.Year & "_" & a.ToString() & ".kml") = True
            a = a + 1
        Loop

        If savedf = False Then CreateKML(GPScoordinates, RunningDir & "\autosave" & Date.Now.Day & Date.Now.Month & Date.Now.Year & "_" & a.ToString() & ".kml")


    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lastTimer.Enabled = False
        Dim path As String = RunningDir & "\host.txt"
        If System.IO.File.Exists(path) = True Then
            Dim reader As New System.IO.StreamReader(path)
            Host = reader.ReadLine
            Port = Val(reader.ReadLine)
            HostFL = reader.ReadLine
            PortFL = Val(reader.ReadLine)
            reader.Close()
        Else
            Host = "127.0.0.1"
            Port = 8000
            HostFL = "127.0.0.1"
            PortFL = 7233
        End If

        Dim str As String
        Dim int As String

        path = RunningDir & "filter.txt"
        If System.IO.File.Exists(path) = True Then
            Dim reader1 As New System.IO.StreamReader(path)

            Do While reader1.EndOfStream = False
                str = reader1.ReadLine()
                If str.Length <= 10 Then Filter.Add(str)
            Loop

            reader1.Close()
        End If

        path = RunningDir & "save.txt"
        If System.IO.File.Exists(path) = True Then
            Dim reader2 As New System.IO.StreamReader(path)

            If reader2.EndOfStream = False Then
                str = reader2.ReadLine()
                'If System.IO.File.Exists(str) = True Then
                FileSavePath = str
                'End If
            End If
            If reader2.EndOfStream = False Then
                str = reader2.ReadLine()
                ' If System.IO.File.Exists(str) = True Then
                FileSavePathfilt = str
                'End If
            End If
            If reader2.EndOfStream = False Then
                str = reader2.ReadLine()
                ' If System.IO.File.Exists(str) = True Then
                FileSavePathCSV = str
                'End If
            End If
            If reader2.EndOfStream = False Then
                str = reader2.ReadLine()
                If str.Length <= 11 Then
                    ex.StatusPacketStartText = str
                End If
            End If
            If reader2.EndOfStream = False Then
                str = reader2.ReadLine()
                If str = "True" Then
                    ignoreZ = True
                Else
                    ignoreZ = False
                End If
            End If
            If reader2.EndOfStream = False Then
                int = Val(reader2.ReadLine())
                If int >= -12 Or int <= 12 Then
                    timezone = int
                End If
            End If

            reader2.Close()
        End If



        packetH = New PacketHandler(Host, Port, True)
        packetH.AllowAll_m()

        client = New TCPStreamHandler(HostFL, PortFL, True, 1000)


        ex.TimeZone = timezone
        ex2.TimeZone = timezone

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        packetH.UnRegCall_x(0, "M6VX0-2  *")
        'packetH.RegCall_X(0, "M6VX0")
        'packetH.SendUnproto_M(0, "APR", "M6VXO", "TEST")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        packetH.RegCall_X(0, "M6VX0-2  *")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        packetH.SendUnproto_M(0, "APR", "M6VX0-2", "TES")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        packetH.AllowAll_m()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'packetH.connect()
        'packetH = New PacketHandler(Host, Port, True)

    End Sub
    Private Sub timer_tick() Handles lastTimer.Elapsed
        lastupdate = lastupdate + 1
        ' lbTimer.Text = lastupdate - (lastupdate Mod 60) & ":" & lastupdate Mod 60

        If lastupdate Mod 60 < 10 Then
            SetLB((lastupdate - (lastupdate Mod 60)) / 60 & ":0" & lastupdate Mod 60, lbTimer)
        Else
            SetLB((lastupdate - (lastupdate Mod 60)) / 60 & ":" & lastupdate Mod 60, lbTimer)
        End If
    End Sub

    Private Function ProcessTemp(ByVal value As Integer) As Single
        Dim output As Single

        If value < 3000 Then
            output = value / 16
        Else
            output = -(65536 - value) / 16
        End If


        Return output
    End Function

    Private Function ProcessPressure(ByVal value As Integer) As Single
        Return 10 * (((value / 4096) * 5) + 5 * 0.095) / (5 * 0.009)
    End Function

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResize.Click

        If TC1.Visible = True Then
            Dim a As New System.Drawing.Size(1024, 282)
            Dim b As New System.Drawing.Size(462, 282)
            TC1.Visible = False
            btnResize.BackgroundImage = APRS_Analyser.My.Resources.Resources.full
            Me.Height = 282
            Me.MaximumSize = a
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.MinimumSize = b
        Else
            Dim a As New System.Drawing.Size(1024, 522)
            Dim b As New System.Drawing.Size(462, 522)
            TC1.Visible = True
            btnResize.BackgroundImage = APRS_Analyser.My.Resources.Resources.small
            Me.MaximumSize = a
            Me.Height = 522
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.MinimumSize = b
        End If
    End Sub

    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TC1.Width = Me.Width - 28
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveKML.Click

        Dim saveD As New SaveFileDialog
        saveD.Filter = "KML Files|*.kml"
        saveD.ValidateNames = True
        saveD.AddExtension = True
        saveD.CheckFileExists = False
        saveD.CheckPathExists = False
        saveD.CreatePrompt = False
        saveD.OverwritePrompt = False
        saveD.ShowDialog()

        If saveD.FileName.Length < 5 Then

            Exit Sub
        End If
        If LCase(saveD.FileName.Substring(saveD.FileName.Length - 4, 4)) <> ".kml" Then
            MsgBox("Invalid File")

            Exit Sub
        End If

        CreateKML(GPScoordinates, saveD.FileName)
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim openD As New OpenFileDialog

        openD.Filter = "Text Files|*.txt"
        openD.ShowDialog()

        If openD.FileName.Length < 5 Then Exit Sub
        Dim reader As New System.IO.StreamReader(openD.FileName)
        Dim str As String

        While reader.EndOfStream = False
            str = reader.ReadLine
            ex.ExtractString(str)

            SetRTB(str & vbCrLf, RTBAll)

            ' ex.ExtractString(str)


            If ex.StatusPacket = True Then
                SetList(str & vbCrLf, LstStatus)
                If FileSavePathfilt <> openD.FileName Then AddToFile(FileSavePathfilt, str)
            Else
                SetList(str & vbCrLf, lstFiltered)
                If FileSavePath <> openD.FileName Then AddToFile(FileSavePath, str)
            End If
            ReadS()


        End While
        reader.Close()
        lbTimer.Text = "0:00"
        lastupdate = 0

    End Sub


    Private Sub lstFiltered_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFiltered.SelectedIndexChanged

        Dim flags As String = ""
        If lstFiltered.SelectedIndex = -1 Then Exit Sub
        ex2.ExtractString(lstFiltered.Items(lstFiltered.SelectedIndex))

        If ex2.TIMEOUT = True Then flags = " TIMEOUT"
        If ex2.GPSERROR = True Then flags = flags & " GPSERROR"
        If ex2.GPSNOLOCK = True Then flags = flags & " GPSNOLOCK"

        If ex2.ValidPacket = True Then Me.ToolTip1.SetToolTip(Me.lstFiltered, ex2.PacketTime & ": " & flags & "   " & ex2.Latitude & "  " & ex2.Longitude & "  Speed: " & ex2.Speed & "kts  Heading: " & ex2.Heading & "º  Alt: " & ex2.Altitude & "ft     " & _
        Math.Round(ProcessPressure(ex2.PICdata("PP")), 1) & "mb  OT:" & _
        Math.Round(ProcessTemp(ex2.PICdata("OT")), 1) & "ºC  IT:" & _
        Math.Round(ProcessTemp(ex2.PICdata("IT")), 1) & "ºC  BV:" & _
        Math.Round((ex2.PICdata("BV") / 4096 * 10), 1) & "V")
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        panel.Show()
    End Sub

    Private Sub ProcessDLInData(ByVal str As String)

        '  str = InputBox("Enter test string", , "$$APEX,12342,12:34:17,52.345645,-1.02342,10232,?T00243,00235,00126A0043,0352L124,065,187I0943,2964,1032C7321,5453 fdgdgsgdfndfndfhsdgdsf")

        If str = "" Then Exit Sub



        lastTimer.Enabled = True
        AddToFile(FileSavePath, str)    'everything
        exDL.ExtractString(str)
        If lbTime.Text <> ex.PacketTime Then
            SetLB("0:00", lbTimer)
            lastupdate = 0
        End If

        Dim c As Boolean = False
        Dim d As Boolean = False

        If exDL.ValidPacketGPS = True Then
            If insertOrderCollection(GPSdata, exDL.PacketCounterID, exDL.RawGPS) = True Then
                c = True
                '###########################################
                '###### update mappoint!!!!!!!!!11 #########
                '###########################################
            End If
        End If

        If exDL.ValidPacketdata = True Then
            If insertOrderCollection(Sensordata, exDL.PacketCounterID, exDL.RawComment) = True Then
                '###########################################
                '###### update sensor data!!!!!!!! #########
                '###########################################
                AddToFile(FileSavePathCSV, exDL.PacketCounterID & "," & lbTime.Text & "," & lbBV.Text & "," & lbIT.Text & "," & lbOT.Text & "," & lbPP.Text)
                d = True

            End If
        End If

      
        Dim lststr As String = ""
   

        If exDL.ValidPacketGPS Then
            If c Then
                lststr = exDL.RawGPS
                SetRTB(exDL.RawGPS, RTBAll)
            Else
                SetRTB(exDL.RawGPS, RTBAll) 'BLUE
                ' If j = True Then SetList(exDL.RawGPS, lstFiltered) 'blue
            End If
        Else
            SetRTB(exDL.RawGPS, RTBAll) 'RED
           ' If j = True Then SetList(exDL.RawGPS, lstFiltered) 'red
        End If


        If exDL.ValidPacketdata Then
            If c Then
                lststr = lststr & exDL.RawComment
                SetRTB(exDL.RawComment, RTBAll)
            Else
                SetRTB(exDL.RawComment, RTBAll) 'BLUE
                '  If i = True Then SetList(exDL.RawComment, lstFiltered) 'BLUE
            End If
        Else
            SetRTB(exDL.RawComment, RTBAll) 'RED
            ' If i = True Then SetList(exDL.RawComment, lstFiltered) 'RED
        End If

        If lststr <> "" Then
            SetList(lststr, lstFiltered)
            AddToFile(FileSavePathfilt, lststr) 'write file lststr ###################
        End If

        SetRTB(vbCrLf, RTBAll)


        If correctPacketID.Count = 0 Then
            ReadSDL()
        Else
            If exDL.PacketCounterID = correctPacketID.Item(correctPacketID.Count - 1) Then
                ReadSDL()
            End If
        End If



        'last statements in sub..
        If exDL.ValidPacketdata = True And exDL.ValidPacketGPS Then
            If correctPacketID.Contains(exDL.PacketCounterID) = False Then
                correctPacketID.Add(exDL.PacketCounterID)
                correctPacketID.Sort()
            End If
            Exit Sub
        End If
        If exDL.ValidPacketdata = True Then
            If correctOnlyDataPacketID.Contains(exDL.PacketCounterID) = False Then
                correctOnlyDataPacketID.Add(exDL.PacketCounterID)
                correctOnlyDataPacketID.Sort()
            End If
        End If
        If exDL.ValidPacketGPS = True Then
            If correctOnlyGPSPacketID.Contains(exDL.PacketCounterID) = False Then
                correctOnlyGPSPacketID.Add(exDL.PacketCounterID)
                correctOnlyGPSPacketID.Sort()
            End If
        End If
    End Sub

    Private Sub Button2_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str As String

        str = InputBox("Enter test string", , "$$APEX,2,12:34:17,52.345645,-1.02342,10232,?T00243,00235,00126A0043,0352L124,065,187I0943,2964,1032C7321,5453 fdgdgsgdfndfndfhsdgdsf")

        If str = "" Then Exit Sub

        ProcessDLInData(str)

    End Sub

    '  Public Sub SortCollection(ByVal col As Collection, _
    'ByVal psSortPropertyName As String, ByVal pbAscending As Boolean, _
    ' Optional ByVal psKeyPropertyName As String = "")

    '      Dim obj As Object
    '      Dim i As Integer
    '      Dim j As Integer
    '      Dim iMinMaxIndex As Integer
    '      Dim vMinMax As Object
    '      Dim vValue As Object
    '      Dim bSortCondition As Boolean
    '      Dim bUseKey As Boolean
    '      Dim sKey As String

    '      bUseKey = (psKeyPropertyName <> "")

    '      For i = 1 To col.Count - 1
    '          obj = col(i)
    '          ' the vbGet can be replaced with a 
    '          'CallType.Get if you
    '          ' want. See VB Language reference for CallByName

    '          vMinMax = CallByName(obj, psSortPropertyName, vbGet)
    '          iMinMaxIndex = i

    '          For j = i + 1 To col.Count
    '              obj = col(j)
    '              vValue = CallByName(obj, _
    '               psSortPropertyName, vbGet)

    '              If (pbAscending) Then
    '                  bSortCondition = (vValue < vMinMax)
    '              Else
    '                  bSortCondition = (vValue > vMinMax)
    '              End If

    '              If (bSortCondition) Then
    '                  vMinMax = vValue
    '                  iMinMaxIndex = j
    '              End If

    '              obj = Nothing
    '          Next j

    '          If (iMinMaxIndex <> i) Then
    '              obj = col(iMinMaxIndex)

    '              col.Remove(iMinMaxIndex)
    '              If (bUseKey) Then
    '                  sKey = CStr(CallByName(obj, _
    '                     psKeyPropertyName, vbGet))
    '                  col.Add(obj, sKey, i)
    '              Else
    '                  col.Add(obj, , i)
    '              End If

    '              obj = Nothing
    '          End If

    '          obj = Nothing
    '      Next i

    '  End Sub


    Private Function insertOrderCollection(ByVal col As Collection, ByVal index As Integer, ByVal item As String)
        'returns TRUE if UNIQUE data has been entered
        Dim a As Integer
        Dim b As Integer = -1
        Dim str As String = ""

        If index < 0 Then index = (-index)

        If index > 500000 Then
            col.Add(item, index.ToString)
            Return True
            Exit Function
        End If

        For a = 1 To index
            If col.Contains(a.ToString) = True Then
                'col.
                b = a

                'For Each item1 As KeyValuePair(Of String, Object) In col
                '    Debug.WriteLine(item1.Key & ": " & item1.Value)
                'Next


            End If
        Next

        If b = -1 Then
            If col.Count = 0 Then
                col.Add(item, index.ToString)
                Return True
                Exit Function
            Else
                col.Add(item, index.ToString, 1)
                Return True
                Exit Function
            End If
        End If


        If col.Contains(b.ToString & ".1") = True Then
            For a = 1 To 50
                If col.Contains(b.ToString & "." & a.ToString) = False Then
                    str = b.ToString & "." & (a - 1).ToString
                    ' col.Add(item, index, , b.ToString & "." & (a - 1).ToString)
                    Exit For
                End If
            Next
        Else
            str = b.ToString
            ' col.Add(item, index, , b.ToString)
        End If
        If col.Contains(exDL.PacketCounterID.ToString) Then
            If item <> col.Item(index.ToString) Then
                For a = 1 To 50
                    If col.Contains(index.ToString & "." & a.ToString) = False Then
                        col.Add(item, index & "." & a.ToString, , str)
                        Return True
                        Exit Function
                    End If
                Next
                Return True
            Else
                Return False
            End If
        Else
            col.Add(item, index, , str)
            Return True
        End If

    End Function

    Private Sub TCPLine(ByVal str As String) Handles client.ReceivedLine
        ProcessDLInData(str)
    End Sub

    Public Function serialconnect(ByVal port As String, ByVal baud As Integer) As Boolean

        'function to open the serial port
        Try
            If serialport.IsOpen = False Then   'if already not open then open...
                With serialport                 'set up the options
                    .BaudRate = baud
                    .PortName = port
                    .Parity = IO.Ports.Parity.None
                    .DataBits = 8
                    .StopBits = IO.Ports.StopBits.One
                    .ReadTimeout = 0
                    .Open()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)  'display error
            Return False
        End Try
        Return True

    End Function

    Public Function SerialClose() As Boolean
        'function to close the serial connection
        Try
            If serialport.IsOpen = True Then    'if port is open then close...
                serialport.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)                  'display error
            Return False
        End Try
        Return True
    End Function

    Private Sub serialport_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles serialport.DataReceived
        '###############SORT OUT DATA#########
        ProcessDLInData(serialport.ReadLine)
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        packetH.SendUnproto_M(1, "m3rfd", "m6vxo", "tyu")
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        packetH.connect()
    End Sub


End Class
