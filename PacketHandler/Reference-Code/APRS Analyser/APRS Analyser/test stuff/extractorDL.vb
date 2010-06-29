Imports System.Text.RegularExpressions

Public Class extractorDL
    ' Private type As Char = ""
    Private time As String = ""
    Private gpsla As String = ""
    Private gpslo As String = ""
    Private gpsal As String = ""
    Private gpssp As String = ""
    Private gpsh As String = ""
    Private rcomment As String = ""
    Private gdata As String = ""
    Private comm As String = ""
    Private validgps As Boolean = False
    Private validdata As Boolean = False
    Private Pdata As New Collection
    Private gpsNoLOCKf As Boolean = False
    Private gpsERRORf As Boolean = False
    Private timeoutf As Boolean = False
    Private statusPacketf As Boolean = False
    Private statuspackett As String = "sgsballoon:"
    Private pjname As String = ""       'name of project - start of string
    Private packetID As Integer = 0
    Private sigstr As Integer = 0
    Public xTimeZone As Integer

#Region "Properties"
    Public Property TimeZone() As Integer
        Get
            Return xTimeZone
        End Get
        Set(ByVal value As Integer)
            xTimeZone = value
        End Set
    End Property
    ' Public ReadOnly Property PacketType() As String
    '     Get
    '         Return type
    '     End Get
    ' End Property

    Public ReadOnly Property SignalStrength() As Integer
        Get
            Return sigstr
        End Get
    End Property

    Public ReadOnly Property PacketTime() As String
        Get
            Return time
        End Get
    End Property

    Public ReadOnly Property Latitude() As String
        Get
            Return gpsla
        End Get
    End Property

    Public ReadOnly Property Longitude() As String
        Get
            Return gpslo
        End Get
    End Property

    Public ReadOnly Property Altitude() As String
        Get
            Return gpsal
        End Get
    End Property

    Public ReadOnly Property Speed() As String
        Get
            Return gpssp
        End Get
    End Property

    Public ReadOnly Property Heading() As String
        Get
            Return gpsh
        End Get
    End Property

    Public ReadOnly Property RawComment() As String
        Get
            Return rcomment
        End Get
    End Property

    Public ReadOnly Property ValidPacketGPS() As String
        Get
            Return validgps
        End Get
    End Property

    Public ReadOnly Property ValidPacketdata() As String
        Get
            Return validdata
        End Get
    End Property

    Public ReadOnly Property PacketCounterID() As Integer
        Get
            Return packetID
        End Get
    End Property

    Public ReadOnly Property Comment() As String
        Get
            Return comm
        End Get
    End Property

    Public ReadOnly Property RawGPS() As String
        Get
            Return gdata
        End Get
    End Property

    Public ReadOnly Property PICdata(ByVal name As String) As Integer
        Get
            If Pdata.Contains(name) Then
                Return Pdata(name)
            Else
                Return vbNull
            End If
        End Get
    End Property
    Public ReadOnly Property GPSERROR() As Boolean
        Get
            Return gpsERRORf
        End Get
    End Property
    Public ReadOnly Property GPSNOLOCK() As Boolean
        Get
            Return gpsNoLOCKf
        End Get
    End Property
    Public ReadOnly Property TIMEOUT() As Boolean
        Get
            Return timeoutf
        End Get
    End Property

    Public ReadOnly Property ProjectCallsign() As String
        Get
            Return pjname
        End Get
    End Property

    Public ReadOnly Property StatusPacket() As Boolean
        Get
            Return statusPacketf
        End Get
    End Property

    Public Property StatusPacketStartText() As String
        Get
            Return statuspackett
        End Get
        Set(ByVal value As String)
            statuspackett = value
        End Set
    End Property

#End Region


    Public Sub ExtractString(ByVal raw As String)
        ' Try
        gdata = raw
        rcomment = ""

        validgps = False
        validdata = False
        If raw.Length = 0 Then Exit Sub
        Dim a As Integer
        Dim b As Integer


        gpsNoLOCKf = False
        gpsERRORf = False

       
        Dim str As String = ""

        '  if raw.Length >1 then...
        For a = 0 To raw.Length - 1
            If raw(a) = "$" Then
                a = a + 1
                If a >= raw.Length - 1 Then Exit Sub
                If raw(a) = "$" Then
                    str = "$"
                    Exit For
                Else
                    a = a - 1
                    Exit For
                End If
            ElseIf raw(a) = "@" Then
                str = "@"
                Exit For
            End If
        Next

        a = a + 1
        b = a
        If a >= raw.Length - 1 Then Exit Sub


        Select Case str
            Case "$"
                str = ""
                For a = b To raw.Length - 1
                    If raw(a) <> "," Then
                        str = str & raw(a)
                    Else
                        Exit For
                    End If
                Next
                pjname = str
                b = a + 1
                If b >= raw.Length - 1 Then Exit Sub

                str = ""
                For a = b To raw.Length - 1
                    If raw(a) <> "," Then
                        str = str & raw(a)
                    Else
                        Exit For
                    End If
                Next
                packetID = Val(str)
                b = a + 1
                If b >= raw.Length - 1 Then Exit Sub


                str = ""
                For a = b To raw.Length - 1
                    If raw(a) <> "," Then
                        str = str & raw(a)
                    Else
                        Exit For
                    End If
                Next
                time = str
                b = a + 1
                If b >= raw.Length - 1 Then Exit Sub

                str = ""
                For a = b To raw.Length - 1
                    If raw(a) <> "," Then
                        str = str & raw(a)
                    Else
                        Exit For
                    End If
                Next
                gpsla = str
                b = a + 1
                If b >= raw.Length - 1 Then Exit Sub

                str = ""
                For a = b To raw.Length - 1
                    If raw(a) <> "," Then
                        str = str & raw(a)
                    Else
                        Exit For
                    End If
                Next
                gpslo = str
                b = a + 1
                If b >= raw.Length - 1 Then Exit Sub

                str = ""
                For a = b To raw.Length - 1
                    If raw(a) <> "," Then
                        str = str & raw(a)
                    Else
                        Exit For
                    End If
                Next
                gpsal = str
                b = a + 1
                If b >= raw.Length - 1 Then Exit Sub

                str = ""

                rcomment = raw.Substring(b, raw.Length - b)
                gdata = raw.Substring(0, b - 1)

                If rcomment = "" Then Exit Sub


                ' $$APEX,12342,12:34:17,52.345645,-1.02342,10232,?T00243,00235,00126A0043,0352L124,065,187I043,264,132C321,543
                Dim c As Integer
                Dim check1 As Integer
                Dim check2 As Integer

                For a = 0 To rcomment.Length - 1
                    If rcomment(a) = "?" Then
                        Exit For
                    End If
                Next


                a = a + 1
                If a >= raw.Length - 1 Then Exit Sub


                'retrives data from FIXED length fields nad puts them in the pdata collection
                Do
                    Select Case rcomment(a)
                        Case "T"
                            c = 0
                            Do
                                If a + 5 >= raw.Length - 1 Then Exit Sub
                                str = rcomment.Substring(a + 1, 5)
                                a = a + 1 + 5
                                If Pdata.Contains("T" & c) Then Pdata.Remove("T" & c)
                                Pdata.Add(Val(str), "T" & c)
                                c = c + 1
                            Loop While rcomment(a) = ","
                        Case "A"
                            c = 0
                            Do
                                If a + 4 >= raw.Length - 1 Then Exit Sub
                                str = rcomment.Substring(a + 1, 4)
                                a = a + 1 + 4
                                If Pdata.Contains("A" & c) Then Pdata.Remove("A" & c)
                                Pdata.Add(Val(str), "A" & c)
                                c = c + 1
                            Loop While rcomment(a) = ","
                        Case "L"
                            c = 0
                            Do
                                If a + 3 >= raw.Length - 1 Then Exit Sub
                                str = rcomment.Substring(a + 1, 3)
                                a = a + 1 + 3
                                If Pdata.Contains("L" & c) Then Pdata.Remove("L" & c)
                                Pdata.Add(Val(str), "L" & c)
                                c = c + 1
                            Loop While rcomment(a) = ","
                        Case "I"
                            c = 0
                            Do
                                If a + 4 >= raw.Length - 1 Then Exit Sub
                                str = rcomment.Substring(a + 1, 4)
                                a = a + 1 + 4
                                If Pdata.Contains("I" & c) Then Pdata.Remove("I" & c)
                                Pdata.Add(Val(str), "I" & c)
                                c = c + 1
                            Loop While rcomment(a) = ","
                        Case "C"
                            If a + 9 >= raw.Length - 1 Then Exit Sub
                            str = rcomment.Substring(a + 1, 4)
                            a = a + 1 + 4
                            check1 = Val(str)
                            str = rcomment.Substring(a + 1, 4)
                            a = a + 1 + 4
                            check2 = Val(str)
                        Case " "
                            If a + 1 >= raw.Length - 1 Then Exit Sub
                            str = rcomment.Substring(a + 1, rcomment.Length - a - 1)
                            comm = str
                            a = rcomment.Length
                    End Select

                Loop Until a >= rcomment.Length - 2 '##########look at this bit

                'checksum!!!!!!!



                validdata = True
                validgps = True


            Case "@"

                str = ""
                For a = b To raw.Length - 1
                    If raw(a) <> "," Then
                        str = str & raw(a)
                    Else
                        Exit For
                    End If
                Next
                sigstr = Val(str)

        End Select

        'Catch
        ' End Try

    End Sub


    Private Function IsDigit(ByVal character As Char) As Boolean
        If ((AscW(character) >= 48) And (AscW(character) <= 57)) Or (AscW(character) = 45) Or (AscW(character) = 46) Then
            Return True
        Else
            Return False
        End If
    End Function


End Class
