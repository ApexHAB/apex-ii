Imports System.Text.RegularExpressions

Public Class extractor
    Private type As Char = ""
    Private time As String = ""
    Private gpsla As String = ""
    Private gpslo As String = ""
    Private gpsal As String = ""
    Private gpssp As String = ""
    Private gpsh As String = ""
    Private rcomment As String = ""
    Private comm As String = ""
    Private valid As Boolean = False
    Private Pdata As New Collection
    Private gpsNoLOCKf As Boolean = False
    Private gpsERRORf As Boolean = False
    Private timeoutf As Boolean = False
    Private statusPacketf As Boolean = False
    Private statuspackett As String = "sgsballoon:"
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
    Public ReadOnly Property PacketType() As String
        Get
            Return type
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

    Public ReadOnly Property ValidPacket() As String
        Get
            Return valid
        End Get
    End Property

    Public ReadOnly Property Comment() As String
        Get
            Return comm
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
        'Dim RegexObj As Regex = New Regex("regularexpression")
        valid = False
        If raw.Length = 0 Then Exit Sub
        Dim a As Integer
        Dim b As Integer


        gpsNoLOCKf = False
        gpsERRORf = False

        If raw.Length > 8 Then
            For a = 0 To raw.Length - 6
                If raw(a) & raw(a + 1) & raw(a + 2) & raw(a + 3) & raw(a + 4) & raw(a + 5) = "NOLOCK" Then
                    gpsNoLOCKf = True
                    Exit For
                End If
            Next
            For a = 0 To raw.Length - 8
                If raw(a) & raw(a + 1) & raw(a + 2) & raw(a + 3) & raw(a + 4) & raw(a + 5) & raw(a + 6) & raw(a + 7) = "GPSERROR" Then
                    gpsERRORf = True
                    Exit For
                End If
            Next
        End If

        Select Case raw(0)
            Case "@"
                type = "@"
                If raw.Length >= 42 Then

                    If raw(7) <> "h" Then Exit Sub
                    If raw(16) <> "/" Then Exit Sub
                    If raw(29) <> "/" Then Exit Sub
                    If raw(33) <> "/" Then Exit Sub

                    b = Val(raw(1) & raw(2))
                    b = b + xTimeZone
                    If b >= 24 Then b = b - 24
                    If b <= -1 Then b = b + 24
                    time = b.ToString & ":" & raw(3) & raw(4) & ":" & raw(5) & raw(6)
                    If time.Length = 7 Then time = "0" & time

                    If (GPSERROR = False) And (GPSNOLOCK = False) Then
                        gpsla = raw.Substring(8, 8)
                        gpslo = raw.Substring(17, 9)
                        gpsh = raw.Substring(26, 3)
                        gpssp = raw.Substring(30, 3)
                        gpsal = raw.Substring(36, 6)
                    End If
                End If
                If raw.Length >= 43 Then
                    rcomment = raw.Substring(42, raw.Length - 42)
                End If
            Case "!"
                    type = "!"
            Case "/"
                    type = "/"
            Case "="
                    type = "="
            Case Else
                rcomment = raw
                ' Exit Sub
        End Select
        valid = True

        ' @124840h5121.89N/00011.43W085/000/A=000000AVDATA-ITxxxxOTxxxxPPxxxx SGSBALLOON

        Dim name As String
        Dim value As String = ""

        If rcomment.Length < 12 Then Exit Sub
        Try
            If rcomment.Substring(0, 7) = "TIMEOUT" Then
                timeoutf = True
            Else
                timeoutf = False
            End If

            If LCase(rcomment.Substring(0, statuspackett.Length)) = statuspackett Then
                statusPacketf = True
            Else
                statusPacketf = False
            End If


            If rcomment.Substring(0, 7) = "AVDATA-" Then
                a = 7
                Do
                    name = rcomment.Substring(a, 2)
                    a = a + 2
                    value = ""
                    Do
                        value = value & rcomment(a)
                        a = a + 1
                        If rcomment.Length <= a Then Exit Do
                    Loop While IsDigit(rcomment(a)) = True


                    Select Case name
                        Case "IT"
                            If Pdata.Contains("IT") Then Pdata.Remove("IT")
                            Pdata.Add(Val(value), "IT")
                        Case "OT"
                            If Pdata.Contains("OT") Then Pdata.Remove("OT")
                            Pdata.Add(Val(value), "OT")
                        Case "PP"
                            If Pdata.Contains("PP") Then Pdata.Remove("PP")
                            Pdata.Add(Val(value), "PP")
                        Case "BV"
                            If Pdata.Contains("BV") Then Pdata.Remove("BV")
                            Pdata.Add(Val(value), "BV")
                        Case "A1"
                            If Pdata.Contains("A1") Then Pdata.Remove("A1")
                            Pdata.Add(Val(value), "A1")
                        Case "A2"
                            If Pdata.Contains("A2") Then Pdata.Remove("A2")
                            Pdata.Add(Val(value), "A2")
                        Case "A3"
                            If Pdata.Contains("A3") Then Pdata.Remove("A3")
                            Pdata.Add(Val(value), "A3")
                        Case "A4"
                            If Pdata.Contains("A4") Then Pdata.Remove("A4")
                            Pdata.Add(Val(value), "A4")
                        Case "A5"
                            If Pdata.Contains("A5") Then Pdata.Remove("A5")
                            Pdata.Add(Val(value), "A5")
                    End Select
                    If rcomment.Length < a + 3 Then Exit Do
                Loop While rcomment(a) <> " "
                a = a + 1
                comm = rcomment.Substring(a, rcomment.Length - a)
            End If

        Catch
        End Try

    End Sub

    Private Function IsDigit(ByVal character As Char) As Boolean
        If ((AscW(character) >= 48) And (AscW(character) <= 57)) Or (AscW(character) = 45) Or (AscW(character) = 46) Then
            Return True
        Else
            Return False
        End If
    End Function

 
End Class
