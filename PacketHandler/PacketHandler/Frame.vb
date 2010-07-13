Imports System.Text


Public Class Frame

    Private Empty_ As Boolean = True     'marker for blank frame
    ' Private packetEncodingType_ As PacketFormats       'APRS/UKHAS?
    Private packetStructure_ As PacketStructure     'holds details on how the packet will be decoded
    Private type_ As Char = ""      'only relevent for aprs packets
    Private time_ As String = ""    'time
    ' Private gpsla_ As String = ""   'gps latitude
    ' Private gpslo_ As String = ""   'gps longitude
    Private GPScoord_ As GPScoord
    Private gpsal_ As Integer = 0   'gps altitude   (m)
    Private gpssp_ As Single = 0   'gps speed
    Private gpsh_ As Single = 0    'gps heading    (degrees)
    Private rcomment_ As String = ""        'custom data on the string
    Private comm_ As String = ""            'comment on the end of the custom string
    Private valid_ As Boolean = False       'a valid packet?
    Private Pdata_ As New Dictionary(Of String, Double)    'holds 'extra' vairable data
    Private gpsNoLOCKf_ As Boolean = False
    Private gpsERRORf_ As Boolean = False
    Private timeoutf_ As Boolean = False        'a timeout has occured (relevent to APEXI)
    Private statusPacketf_ As Boolean = False
    Private statuspackett_ As String = "sgsballoon:"
    Public xTimeZone_ As Integer

    Private RawString_ As String
    Private ProcessedString_ As String

    Private pcktcount_ As Integer       'as sent
    Private gpsSats_ As Integer         'no sats using
    Private Callsign_ As String         'as sent
    Private chksum_ As Boolean = False         'checksum ok? - always true for aprs


#Region "Properties"

    Public ReadOnly Property ProcessedString As String
        Get
            If ProcessedString_ = "" Then Return RawString_
            Return ProcessedString_
        End Get
    End Property

    Public ReadOnly Property RawString As String
        Get
            Return RawString_
        End Get
    End Property
    Public ReadOnly Property CheckSum As Boolean
        Get
            If packetStructure_ Is Nothing Then Return chksum_
            If packetStructure_.PacketType = PacketFormats.APRS Then Return True
            Return chksum_
        End Get
    End Property

    Public ReadOnly Property PcktCounter As Integer
        Get
            If packetStructure_.PacketType = PacketFormats.UKHAS Then Return pcktcount_
            If packetStructure_.PacketType = PacketFormats.APRS Then Return OnlyNumbers(time_).ToString
            Return 0
        End Get

    End Property

    Private Function OnlyNumbers(ByVal input As String) As String
        Dim str As String = ""
        For Each c As Char In input
            If (AscW(c) >= AscW(0)) And (AscW(c) <= AscW(9)) Then
                str = str + c
            End If
        Next
        Return str
    End Function

    Public Property Sats As Integer
        Get
            Return gpsSats_
        End Get
        Set(ByVal value As Integer)
            gpsSats_ = value
        End Set
    End Property

    Public Property Callsign As String
        Get
            Return Callsign_
        End Get
        Set(ByVal value As String)
            Callsign_ = value
        End Set
    End Property

    Public ReadOnly Property Empty() As Boolean
        Get
            Return Empty_
        End Get
    End Property



    Public Property TimeZone() As Integer
        Get
            Return xTimeZone_
        End Get
        Set(ByVal value As Integer)
            xTimeZone_ = value
        End Set
    End Property
    Public ReadOnly Property PacketType() As String
        Get
            Return type_
        End Get
    End Property

    Public ReadOnly Property PacketTime() As String
        Get
            Return time_
        End Get
    End Property

    'Public ReadOnly Property Latitude() As String
    '    Get
    '        Return gpsla_
    '    End Get
    'End Property

    'Public ReadOnly Property Longitude() As String
    '    Get
    '        Return gpslo_
    '    End Get
    'End Property

    Public ReadOnly Property GPSCoordinates() As GPScoord
        Get
            Return GPScoord_
        End Get
    End Property


    Public ReadOnly Property Altitude() As String
        Get
            Return gpsal_
        End Get
    End Property

    Public ReadOnly Property Speed() As String
        Get
            Return gpssp_
        End Get
    End Property

    Public ReadOnly Property Heading() As String
        Get
            Return gpsh_
        End Get
    End Property

    Public ReadOnly Property RawComment() As String
        Get
            Return rcomment_
        End Get
    End Property

    Public ReadOnly Property ValidPacket() As String
        Get
            Return valid_
        End Get
    End Property

    Public ReadOnly Property Comment() As String
        Get
            Return comm_
        End Get
    End Property

    Public ReadOnly Property PICdata(ByVal name As String) As Double
        Get
            If Pdata_.ContainsKey(name) Then
                Return Pdata_(name)
            Else
                Return vbNull
            End If
        End Get
    End Property
    Public ReadOnly Property PICdata() As Dictionary(Of String, Double)
        Get
            Return Pdata_
        End Get
    End Property
    Public ReadOnly Property GPSERROR() As Boolean
        Get
            Return gpsERRORf_
        End Get
    End Property
    Public ReadOnly Property GPSNOLOCK() As Boolean
        Get
            Return gpsNoLOCKf_
        End Get
    End Property
    Public ReadOnly Property TIMEOUT() As Boolean
        Get
            Return timeoutf_
        End Get
    End Property

    Public ReadOnly Property StatusPacket() As Boolean
        Get
            Return statusPacketf_
        End Get
    End Property

    Public Property StatusPacketStartText() As String
        Get
            Return statuspackett_
        End Get
        Set(ByVal value As String)
            statuspackett_ = value
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New()
        Empty_ = True
    End Sub

    Public Sub New(ByVal FrameString As String, ByVal pkStructure As PacketStructure)
        RawString_ = FrameString
        Select Case pkStructure.PacketType
            Case PacketFormats.APRS
                DecodeAPRS(FrameString)
                packetStructure_ = pkStructure
            Case PacketFormats.UKHAS
                'DecodeUKHAS(Encoding.ASCII.GetBytes(FrameString))

                packetStructure_ = pkStructure
                DecodeUKHAS1(FrameString)
        End Select
        Empty_ = False
    End Sub

#End Region

    Private Sub DecodeAPRS(ByVal raw As String)
        'Dim RegexObj As Regex = New Regex("regularexpression")
        valid_ = False
        If raw.Length = 0 Then Exit Sub
        Dim a As Integer
        Dim b As Integer


        gpsNoLOCKf_ = False
        gpsERRORf_ = False

        If raw.Length > 8 Then
            For a = 0 To raw.Length - 6
                If raw(a) & raw(a + 1) & raw(a + 2) & raw(a + 3) & raw(a + 4) & raw(a + 5) = "NOLOCK" Then
                    gpsNoLOCKf_ = True
                    Exit For
                End If
            Next
            For a = 0 To raw.Length - 8
                If raw(a) & raw(a + 1) & raw(a + 2) & raw(a + 3) & raw(a + 4) & raw(a + 5) & raw(a + 6) & raw(a + 7) = "GPSERROR" Then
                    gpsERRORf_ = True
                    Exit For
                End If
            Next
        End If

        Select Case raw(0)
            Case "@"
                type_ = "@"
                If raw.Length >= 42 Then

                    If raw(7) <> "h" Then Exit Sub
                    If raw(16) <> "/" Then Exit Sub
                    If raw(29) <> "/" Then Exit Sub
                    If raw(33) <> "/" Then Exit Sub

                    b = Val(raw(1) & raw(2))
                    b = b + xTimeZone_
                    If b >= 24 Then b = b - 24
                    If b <= -1 Then b = b + 24
                    time_ = b.ToString & ":" & raw(3) & raw(4) & ":" & raw(5) & raw(6)
                    If time_.Length = 7 Then time_ = "0" & time_

                    If (GPSERROR = False) And (GPSNOLOCK = False) Then
                        ' gpsla_ = raw.Substring(8, 8)
                        ' gpslo_ = raw.Substring(17, 9)

                        GPScoord_ = New GPScoord(raw.Substring(8, 8), raw.Substring(17, 9)) 'DDDMMmm

                        gpsh_ = Integer.Parse(raw.Substring(26, 3))
                        gpssp_ = Single.Parse(raw.Substring(30, 3))
                        gpsal_ = Integer.Parse(raw.Substring(36, 6)) * 0.3048   'convert to meters
                    End If
                End If
                If raw.Length >= 43 Then
                    rcomment_ = raw.Substring(42, raw.Length - 42)
                End If
            Case "!"
                type_ = "!"
            Case "/"
                type_ = "/"
            Case "="
                type_ = "="
            Case Else
                rcomment_ = raw
                ' Exit Sub
        End Select
        valid_ = True


        DecodeCustom()


    End Sub

    Private Sub DecodeCustomApexI()
        'acts on the rcomment_ string and splits it up


        ' @124840h5121.89N/00011.43W085/000/A=000000AVDATA-ITxxxxOTxxxxPPxxxx SGSBALLOON
        Dim a As Integer
        Dim name As String
        Dim value As String = ""

        If rcomment_.Length < 12 Then Exit Sub
        Try
            If rcomment_.Substring(0, 7) = "TIMEOUT" Then
                timeoutf_ = True
            Else
                timeoutf_ = False
            End If

            If LCase(rcomment_.Substring(0, statuspackett_.Length)) = statuspackett_ Then
                statusPacketf_ = True
            Else
                statusPacketf_ = False
            End If


            If rcomment_.Substring(0, 7) = "AVDATA-" Then
                a = 7
                Do
                    name = rcomment_.Substring(a, 2)
                    a = a + 2
                    value = ""
                    Do
                        value = value & rcomment_(a)
                        a = a + 1
                        If rcomment_.Length <= a Then Exit Do
                    Loop While IsDigit(rcomment_(a)) = True


                    Select Case name
                        Case "IT"
                            If Pdata_.ContainsKey("IT") Then Pdata_.Remove("IT")
                            Pdata_.Add("IT", Val(value))
                        Case "OT"
                            If Pdata_.ContainsKey("OT") Then Pdata_.Remove("OT")
                            Pdata_.Add("OT", Val(value))
                        Case "PP"
                            If Pdata_.ContainsKey("PP") Then Pdata_.Remove("PP")
                            Pdata_.Add("PP", Val(value))
                        Case "BV"
                            If Pdata_.ContainsKey("BV") Then Pdata_.Remove("BV")
                            Pdata_.Add("BV", Val(value))
                        Case "A1"
                            If Pdata_.ContainsKey("A1") Then Pdata_.Remove("A1")
                            Pdata_.Add("A1", Val(value))
                        Case "A2"
                            If Pdata_.ContainsKey("A2") Then Pdata_.Remove("A2")
                            Pdata_.Add("A2", Val(value))
                        Case "A3"
                            If Pdata_.ContainsKey("A3") Then Pdata_.Remove("A3")
                            Pdata_.Add("A3", Val(value))
                        Case "A4"
                            If Pdata_.ContainsKey("A4") Then Pdata_.Remove("A4")
                            Pdata_.Add("A4", Val(value))
                        Case "A5"
                            If Pdata_.ContainsKey("A5") Then Pdata_.Remove("A5")
                            Pdata_.Add("A5", Val(value))
                    End Select
                    If rcomment_.Length < a + 3 Then Exit Do
                Loop While rcomment_(a) <> " "
                a = a + 1
                comm_ = rcomment_.Substring(a, rcomment_.Length - a)
            End If

        Catch
        End Try
    End Sub

    Private Sub DecodeCustom()

    End Sub

    Public Sub DecodeUKHAS1(ByVal input As String)

        Dim i As Integer
        Dim packet As String = ""

        'find start of string

        If packetStructure_.SentenceDelimiter <> "" Then
            For i = 0 To input.Count - 2
                If input(i) = packetStructure_.SentenceDelimiter.First And input(i + 1) <> packetStructure_.SentenceDelimiter.First Then   'invalid operatin no elements 
                    packet = input.Substring(i + 1)
                End If
            Next
        Else
            packet = input
        End If
        ProcessedString_ = packet

        packet = packet + ","   'add a comma to the end to mark the end of hte last field

        Dim chksumchar As Integer = -1  'location of checksum character

        'input now contains the string after $$
        Dim fields As List(Of String) = New List(Of String)()
        fields.Add("")  'blanking to make the list '1' starting
        Dim start As Integer = 0
        For i = 0 To packet.Count - 1
            If (packet(i) = "*") And (chksumchar = -1) Then
                chksumchar = i
            End If
            If (packet(i) = ",") Or (AscW(packet(i)) = 10) Or (AscW(packet(i)) = 13) Then
                fields.Add(packet.Substring(start, i - start))
                start = i + 1
            End If
            If packet(i) = "*" Then
                fields.Add(packet.Substring(start, i - start))
                start = i
            End If
        Next

        'calcuate checksum
        Dim checksum As UInteger = 0
        If chksumchar > 0 Then
            checksum = CRC16_CITT(packet.Substring(0, chksumchar))
        End If


        Dim GPSla As String = ""
        Dim GPSlo As String = ""
        Dim GPSfrmat As PacketStructure.Encoding

        'Dim tempint As Integer
        Dim tempUint As UInteger
        Dim tempsing As Single
        Dim tempdoub As Double

        For i = 1 To fields.Count - 1

            If (fields(i) <> "") Then
                Try
                    If fields(i)(0) = "*" Then
                        UInteger.TryParse(HexToInt_str(fields(i).Substring(1)), tempUint)
                        If tempUint = checksum Then chksum_ = True
                    Else
                        If (packetStructure_.FieldExists(i)) Then

                            If (packetStructure_.GetField(i).Encoding = PacketStructure.Encoding.hexinteger) Or (packetStructure_.GetField(i).Encoding2 = PacketStructure.Encoding.hexinteger) Then
                                fields(i) = HexToInt_str(fields(i))
                            End If
                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.callsign) Then
                                Callsign_ = fields(i)
                            End If
                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.latitude) Then
                                GPSla = fields(i)
                                GPSfrmat = packetStructure_.GetField(i).Encoding
                            End If
                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.longitude) Then
                                GPSlo = fields(i)
                                GPSfrmat = packetStructure_.GetField(i).Encoding
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.cycle_count) Then
                                Integer.TryParse(fields(i), pcktcount_)
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.time) Then
                                time_ = fields(i)
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.altitude) Then
                                If packetStructure_.GetField(i).Unit = PacketStructure.Units.imperial Then
                                    Single.TryParse(fields(i), tempsing)
                                    gpsal_ = Math.Round(tempsing * 0.3048)
                                Else
                                    Integer.TryParse(fields(i), gpsal_)
                                End If
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.bearing) Then
                                Single.TryParse(fields(i), gpsh_)
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.speed) Then
                                If packetStructure_.GetField(i).Unit = PacketStructure.Units.imperial Then
                                    Single.TryParse(fields(i), tempsing)
                                    gpssp_ = tempsing * 0.3048
                                Else
                                    Single.TryParse(fields(i), gpssp_)
                                End If
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.sats) Then
                                Integer.TryParse(fields(i), gpsSats_)
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.comment) Then
                                comm_ = fields(i)
                            End If

                            If (packetStructure_.GetField(i).FieldType = PacketStructure.FieldType.sensor) Then
                                Select Case packetStructure_.GetField(i).Encoding
                                    Case PacketStructure.Encoding.light_value
                                        Pdata_.Add("Light - Clear", ProcessLight(fields(i))(0))
                                        Pdata_.Add("Light - Red", ProcessLight(fields(i))(1))
                                        Pdata_.Add("Light - Green", ProcessLight(fields(i))(2))
                                        Pdata_.Add("Light - Blue", ProcessLight(fields(i))(3))
                                    Case Else
                                        Double.TryParse(fields(i), tempdoub)
                                        tempdoub = tempdoub * packetStructure_.GetField(i).ScaleFactor
                                        tempdoub = tempdoub + packetStructure_.GetField(i).Offset
                                        Pdata_.Add(packetStructure_.GetField(i).FieldName, tempdoub)
                                End Select

                            End If
                        End If
                    End If
                Catch
                    Debug.WriteLine("Decoding error")
                End Try
            End If

        Next

        'do GPS stuff
        If (GPSla.Length > 0) And (GPSlo.Length > 0) Then
            Select Case GPSfrmat
                Case PacketStructure.Encoding.ddddddd
                    Dim tempdoub2 As Double
                    Double.TryParse(GPSla, tempdoub)
                    Double.TryParse(GPSlo, tempdoub2)
                    GPScoord_ = New GPScoord(tempdoub, tempdoub2)
                Case PacketStructure.Encoding.dddmmmm
                    If (GPSla.Length > 4) And (GPSlo.Length > 4) Then
                        Dim a As String
                        Dim b As String
                        Dim c As Char = "N"
                        Dim d As Char = "E"
                        If GPSla(0) = "-" Then
                            a = GPSla.Substring(1)
                            c = "S"
                        Else
                            a = GPSla.Substring(0)
                        End If
                        If GPSlo(0) = "-" Then
                            b = GPSlo.Substring(1)
                            d = "W"
                        Else
                            b = GPSlo.Substring(0)
                        End If
                        Dim tempint1 As Integer
                        Dim tempint2 As Integer
                        Dim tempsin1 As Single
                        Dim tempsin2 As Single
                        Integer.TryParse(a.Substring(0, 2), tempint1)
                        Single.TryParse(a.Substring(2), tempsin1)
                        Integer.TryParse(b.Substring(0, 3), tempint2)
                        Single.TryParse(b.Substring(3), tempsin2)
                        GPScoord_ = New GPScoord(tempint1, tempsin1, tempint2, tempsin2, c, d)
                    End If
                    'Case PacketStructure.Encoding.DDDMMSS
                    '   GPScoord_ = New GPScoord(Double.Parse(GPSla), Double.Parse(GPSlo))

            End Select
        End If


    End Sub

    Private Function ProcessLight(ByVal valuestr As String) As Double()
        Dim output() As Double = {0, 0, 0, 0}
        Dim value As ULong
        If ULong.TryParse(valuestr, value) = False Then Return output

        Dim clear As ULong = value And &HFF0000000
        Dim red As ULong = value And &HFF00000
        Dim green As ULong = value And &HFF000
        Dim blue As ULong = value And &HFF0
        Dim scaling As ULong = value And &HF

        clear = clear / (2 ^ (7 * 4))
        red = red / (2 ^ (5 * 4))
        green = green / (2 ^ (3 * 4))
        blue = blue / (2 ^ (1 * 4))

        If scaling = 1 Then
            For i As Integer = 0 To 3
                output(i) = output(1) * 50
            Next
        ElseIf scaling = 2 Then
            For i As Integer = 0 To 3
                output(i) = output(1) * 5
            Next
        End If

        output(0) = clear
        output(1) = red
        output(2) = green
        output(3) = blue

        Return output

    End Function

    Private Function CRC16_CITT(ByVal input As String) As UInteger

        Dim crc As UInteger = &HFFFF
        Dim poly As UInteger = &H1021
        Dim LastXor As UInteger = 0
        Dim temp As UInteger

        Dim mask As UInteger = &HFFFF  '16bit

        For Each c As Char In input
            temp = (AscW(c) And &HFF) << 8
            crc = (crc Xor temp) And mask

            For i = 0 To 7
                If (crc And &H8000) > 0 Then
                    crc = crc << 1
                    crc = (crc Xor &H1021) And mask
                Else
                    crc = crc << 1
                End If

            Next

        Next

        Return crc
    End Function


    Private Function HexToInt_str(ByVal input As String) As String
        If input.Count > 16 Then Return 0
        Dim j = 0
        Dim outputint As ULong = 0
        For i As Integer = 0 To input.Count - 1
            j = (input.Count - 1) - i
            If AscW(Char.ToUpper(input(j))) >= AscW("A") Then
                If AscW(Char.ToUpper(input(j))) <= AscW("F") Then
                    outputint = outputint + (AscW(Char.ToUpper(input(j))) - AscW("A") + 10) * Math.Pow(16, i)
                End If
            Else
                If (AscW(Char.ToUpper(input(j))) >= AscW("0")) And (AscW(Char.ToUpper(input(j))) <= AscW("9")) Then
                    outputint = outputint + (AscW(Char.ToUpper(input(j))) - AscW("0")) * Math.Pow(16, i)
                End If
            End If
        Next
        Return outputint.ToString
    End Function

    Private Sub DecodeUKHAS(ByVal received() As Byte)
        'Try
        Dim data(7) As String
        'seven UKHAS frame fields
        Dim rcount As Integer
        Dim temp As Char

        rcount = 1
        If Microsoft.VisualBasic.Chr(received(0)) = "$" And Microsoft.VisualBasic.Chr(received(1)) = "$" Then
            For rcounter = 2 To (received.Length - 1)
                'first two characters are $$ so skip
                temp = Microsoft.VisualBasic.Chr(received(rcounter))      'Gets next character in string

                If temp <> "," Then     'if not new field
                    If temp = "" Then Exit For 'if reached end of frame
                    If rcount <> 3 Then
                        data(rcount) = data(rcount) & temp
                    Else    'remove colons from time field
                        If temp <> ":" Then
                            data(rcount) = data(rcount) & temp
                        End If
                    End If

                Else : rcount = rcount + 1
                End If
            Next
        Else
            MsgBox("Frame corrupted")
        End If

        'creates individual fields from UKHAS frame data
        Dim time As String
        Dim latd As String
        Dim latm As String
        Dim lats As String
        Dim longd As String
        Dim longm As String
        Dim longs As String
        Dim heading As String
        Dim speed As String
        Dim altitude As String
        ' Dim custom As String

        'ensures correct length by adding leading zeroes
        If data(3).Length = 6 Then
            time = data(3)
        Else
            time = data(3)
            For rcount = 1 To (6 - data(3).Length)
                time = "0" & time
            Next
        End If

        'converts from degrees to degrees and minutes
        latd = Int(data(4))
        If latd.Length < 2 Then
            For rcount = 1 To (2 - latd.Length)
                latd = "0" & latd
            Next
        End If

        latm = Int((data(4) * 60) - (latd * 60))
        If latm.Length < 2 Then
            For rcount = 1 To (2 - latm.Length)
                latm = "0" & latm
            Next
        End If

        lats = Int((data(4) * 6000) - (latd * 6000) - (latm * 100))
        If lats.Length < 2 Then
            For rcount = 1 To (2 - lats.Length)
                lats = "0" & lats
            Next
        End If


        longd = Int(data(5))
        If longd.Length < 3 Then
            For rcount = 1 To (3 - longd.Length)
                longd = "0" & longd
            Next
        End If

        longm = Int((data(5) * 60) - (longd * 60))
        If longm.Length < 2 Then
            For rcount = 1 To (2 - longm.Length)
                longm = "0" & longm
            Next
        End If

        longs = Int((data(5) * 6000) - (longd * 6000) - (longm * 100))
        If longs.Length < 2 Then
            For rcount = 1 To (2 - longs.Length)
                longs = "0" & longs
            Next
        End If

        'these are not reported in UKHAS, so are set to nothing in balloon frame
        heading = "000"

        speed = "000"

        If data(6).Length = 5 Then
            altitude = data(6)
        Else
            altitude = data(6)
            For rcount = 1 To (5 - data(6).Length)
                altitude = "0" & altitude
            Next
        End If

        'balloon sensor data
        rcomment_ = data(7)

        'builds balloon format frame from individual fields
        '  Return AssembleExtras(time, latd, latm, lats, longd, longm, longs, heading, speed, altitude, custom)
        time_ = time
        ' gpsla_ = latd & "." & latm & "." & lats
        'gpslo_ = longd & "." & longm & "." & longs

        GPScoord_ = New GPScoord(Integer.Parse(latd), Integer.Parse(latm), Integer.Parse(lats), Integer.Parse(longd), Integer.Parse(longm), Integer.Parse(longs))
        gpsal_ = Integer.Parse(altitude)
        gpsh_ = Integer.Parse(heading)
        gpssp_ = Integer.Parse(speed)

        DecodeCustom()

        ' Catch ex As Exception
        'MsgBox("Error while decoding UKHAS frame. Error = " & ex.Message)

        ' End Try
    End Sub

    Public Function AssembleExtras(ByVal time As String, ByVal latd As String, ByVal latm As String, ByVal lats As String, ByVal longd As String, ByVal longm As String, ByVal longs As String, ByVal heading As String, ByVal speed As String, ByVal altitude As String, ByVal custom As String)
        Dim Position As String

        'builds balloon format frame from individual fields
        Position = "@"
        Position = Position & time & "h"
        Position = Position & latd
        Position = Position & latm & "."
        Position = Position & lats & "N/"
        Position = Position & longd
        Position = Position & longm & "."
        Position = Position & longs & "W"
        Position = Position & heading & "/"
        Position = Position & speed & "/A="
        Position = Position & altitude
        Position = Position & custom

        Return Position
    End Function

    Private Function IsDigit(ByVal character As Char) As Boolean
        If ((AscW(character) >= 48) And (AscW(character) <= 57)) Or (AscW(character) = 45) Or (AscW(character) = 46) Then
            Return True
        Else
            Return False
        End If
    End Function


End Class
