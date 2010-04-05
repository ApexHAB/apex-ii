Imports System.Text
Public Enum PacketType
    APRS
    UKHAS
End Enum



Public Class Frame

    Private packetEncodingType_ As PacketType        'APRS/UKHAS?
    Private type_ As Char = ""      'only relevent for aprs packets
    Private time_ As String = ""    'time
    Private gpsla_ As String = ""   'gps latitude
    Private gpslo_ As String = ""   'gps longitude
    Private gpsal_ As String = ""   'gps altitude
    Private gpssp_ As String = ""   'gps speed
    Private gpsh_ As String = ""    'gps heading
    Private rcomment_ As String = ""        'custom data on the string
    Private comm_ As String = ""            'comment on the end of the custom string
    Private valid_ As Boolean = False       'a valid packet?
    Private Pdata_ As New Collection    'holds 'extra' vairable data
    Private gpsNoLOCKf_ As Boolean = False
    Private gpsERRORf_ As Boolean = False
    Private timeoutf_ As Boolean = False        'a timeout has occured (relevent to APEXI)
    Private statusPacketf_ As Boolean = False
    Private statuspackett_ As String = "sgsballoon:"
    Public xTimeZone_ As Integer

#Region "Properties"
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

    Public ReadOnly Property Latitude() As String
        Get
            Return gpsla_
        End Get
    End Property

    Public ReadOnly Property Longitude() As String
        Get
            Return gpslo_
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

    Public ReadOnly Property PICdata(ByVal name As String) As Integer
        Get
            If Pdata_.Contains(name) Then
                Return Pdata_(name)
            Else
                Return vbNull
            End If
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

    Public Sub New(ByVal FrameString As String, ByVal pkType As PacketType)
        Select Case pkType
            Case APRS_Analyser.PacketType.APRS
                DecodeAPRS(FrameString)
                packetEncodingType_ = APRS_Analyser.PacketType.APRS
            Case APRS_Analyser.PacketType.UKHAS
                DecodeUKHAS(Encoding.ASCII.GetBytes(FrameString))
                packetEncodingType_ = APRS_Analyser.PacketType.UKHAS

        End Select
    End Sub



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
                        gpsla_ = raw.Substring(8, 8)
                        gpslo_ = raw.Substring(17, 9)
                        gpsh_ = raw.Substring(26, 3)
                        gpssp_ = raw.Substring(30, 3)
                        gpsal_ = raw.Substring(36, 6)
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

    Private Sub DecodeCustom()
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
                            If Pdata_.Contains("IT") Then Pdata_.Remove("IT")
                            Pdata_.Add(Val(value), "IT")
                        Case "OT"
                            If Pdata_.Contains("OT") Then Pdata_.Remove("OT")
                            Pdata_.Add(Val(value), "OT")
                        Case "PP"
                            If Pdata_.Contains("PP") Then Pdata_.Remove("PP")
                            Pdata_.Add(Val(value), "PP")
                        Case "BV"
                            If Pdata_.Contains("BV") Then Pdata_.Remove("BV")
                            Pdata_.Add(Val(value), "BV")
                        Case "A1"
                            If Pdata_.Contains("A1") Then Pdata_.Remove("A1")
                            Pdata_.Add(Val(value), "A1")
                        Case "A2"
                            If Pdata_.Contains("A2") Then Pdata_.Remove("A2")
                            Pdata_.Add(Val(value), "A2")
                        Case "A3"
                            If Pdata_.Contains("A3") Then Pdata_.Remove("A3")
                            Pdata_.Add(Val(value), "A3")
                        Case "A4"
                            If Pdata_.Contains("A4") Then Pdata_.Remove("A4")
                            Pdata_.Add(Val(value), "A4")
                        Case "A5"
                            If Pdata_.Contains("A5") Then Pdata_.Remove("A5")
                            Pdata_.Add(Val(value), "A5")
                    End Select
                    If rcomment_.Length < a + 3 Then Exit Do
                Loop While rcomment_(a) <> " "
                a = a + 1
                comm_ = rcomment_.Substring(a, rcomment_.Length - a)
            End If

        Catch
        End Try
    End Sub

    Private Sub DecodeUKHAS(ByVal received() As Byte)
        Try
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
            Dim custom As String

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
            custom = data(7)

            'builds balloon format frame from individual fields
            '  Return AssembleExtras(time, latd, latm, lats, longd, longm, longs, heading, speed, altitude, custom)
            time_ = time
            gpsla_ = latd & "." & latm & "." & lats
            gpslo_ = longd & "." & longm & "." & longs
            gpsal_ = altitude
            gpsh_ = heading
            gpssp_ = speed

            DecodeCustom()

        Catch ex As Exception
            MsgBox("Error while decoding UKHAS frame. Error = " & ex.Message)

        End Try
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
