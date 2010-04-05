Imports System.Text
Public Class AGWPE_APRSPacketHandler
    'class uses the tcpinterface class to talk to agwpe, decoding agwpe packets, and decoding the APRS, extracting the to/from call and body of the message
    Private WithEvents client As TCPInterface
    Public Event ReceivedPacket(ByVal FromCall As String, ByVal ToCall As String, ByVal Header As String, ByVal Payload As String, ByVal All As String)


    ' Private recievedPackets As Queue 'fm call,to call,header,payload,all



    Public Sub New(ByVal host As String, ByVal port As Integer, ByVal connect As Boolean)
        client = New TCPInterface(host, port, connect)
    End Sub

    Public Function connect()
        '   client.Reconnect()
        client.ConnectTCP()
    End Function

    Private Sub DataRec() Handles client.DataRecieved

        Dim port As Integer = -1
        Dim dataKind As Char
        Dim errors As Integer = 0
        Dim CallFrom As String
        Dim CallTo As String
        Dim datalen As Integer

        Dim raw() As Byte = client.ReadBufferChars


        Dim a As Integer
        Try
            port = raw(0)

            If (raw(1) <> 0) Or (raw(2) <> 0) Or (raw(3) <> 0) Then
                errors = errors + 1
            End If

            dataKind = ChrW(raw(4))
            'raw(5,6,7) normally 0
            CallFrom = ChrW(raw(8)) & ChrW(raw(9)) & ChrW(raw(10)) & ChrW(raw(11)) & ChrW(raw(12)) & ChrW(raw(13)) & ChrW(raw(14)) & ChrW(raw(15)) & ChrW(raw(16)) & ChrW(raw(17))
            CallTo = ChrW(raw(18)) & ChrW(raw(19)) & ChrW(raw(20)) & ChrW(raw(21)) & ChrW(raw(22)) & ChrW(raw(23)) & ChrW(raw(24)) & ChrW(raw(25)) & ChrW(raw(26)) & ChrW(raw(27))
            datalen = raw(28) + (raw(29) * 256) + (raw(30) * 65536) ' + (raw(31) * (2 ^ 24))
            'raw(32,33,34,35) normally 0

            CallFrom = CallFrom.TrimEnd(ChrW(0))
            CallTo = CallTo.TrimEnd(ChrW(0))

            If datalen > 0 Then
                Dim payload(datalen) As Byte
                For a = 36 To datalen + 35
                    If a >= raw.Length Then
                        errors = errors + 1
                        Exit For
                    End If
                    payload(a - 36) = raw(a)
                Next

                Select Case dataKind
                    Case "U"
                        Dim header As String = ""

                        For a = 0 To payload.Length - 1
                            If ((payload(a)) = 13) Or ((payload(a)) = 10) Then Exit For
                            header = header & ChrW(payload(a))
                        Next

                        Dim packetpayload As String = ""

                        For a = a To payload.Length - 1
                            If ((payload(a)) = 13) Or ((payload(a)) = 10) Or ((payload(a)) = 0) Then
                            Else
                                packetpayload = packetpayload & ChrW(payload(a))
                            End If
                        Next

                        Debug.WriteLine(packetpayload)
                        Debug.WriteLine(header)


                        For a = 0 To header.Length - 3
                            If header(a) & header(a + 1) & header(a + 2) = "To " Then Exit For
                        Next
                        Dim Tocall As String = ""
                        For a = (a + 3) To (a + 12)
                            If header(a) = " " Then Exit For
                            Tocall = Tocall & header(a)
                        Next

                        For a = 0 To header.Length - 3
                            If header(a) & header(a + 1) & header(a + 2) = "Fm " Then Exit For
                        Next
                        Dim Fmcall As String = ""
                        For a = (a + 3) To (a + 12)
                            If header(a) = " " Then Exit For
                            Fmcall = Fmcall & header(a)
                        Next

                        'If Fmcall <> CallFrom Then
                        '    errors = errors + 1
                        'End If

                        'If Tocall <> CallTo Then
                        '    errors = errors + 1
                        'End If


                        Dim allpacket As String = ""
                        For a = 0 To payload.Length - 1
                            allpacket = allpacket & ChrW(payload(a))
                        Next
                        RaiseEvent ReceivedPacket(Fmcall, Tocall, header, packetpayload, allpacket)
                End Select

                If errors > 0 Then Debug.WriteLine("######### ERRORS: " & errors & "     #################")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub


#Region "Sendable Commands"

    Public Function sendAUT_P(ByVal port As Byte, ByVal user As String, ByVal password As String)

        Dim a() As Byte = {port, 0, 0, 0, AscW("P"), 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 254, 1, 0, 0, 0, 0, 0, 0}
        Dim u() As Byte = Encoding.ASCII.GetBytes(user)
        Dim p() As Byte = Encoding.ASCII.GetBytes(password)

        Dim uu(255) As Byte
        Dim pp(255) As Byte

        Dim b As Integer

        For b = 0 To u.Count - 1
            uu(b) = u(b)
        Next
        For b = 0 To u.Count - 1
            pp(b) = p(b)
        Next


        Dim d(546) As Byte

        For b = 0 To 35
            d(b) = a(b)
        Next
        For b = 0 To 254
            d(b + 36) = uu(b)
        Next
        For b = 0 To 254
            d(b + 291) = pp(b)
        Next

        client.SendMessage(d)

        Return True
    End Function

    Public Function RegCall_X(ByVal port As Byte, ByVal callsign As String)

        Dim a() As Byte = {port, 0, 0, 0, 88, 0, 0, 0, _
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
           0, 0, 0, 0, 0, 0, 0, 0}

        Dim b As Integer

        For b = 1 To 10
            If callsign.Length >= b Then
                a(b + 7) = AscW(callsign(b - 1))
            Else
                a(b + 7) = 0
            End If
        Next
        For b = 1 To 10
            If callsign.Length >= b Then
                a(b + 17) = AscW(callsign(b - 1))
            Else
                a(b + 17) = 0
            End If
        Next
        a(17) = AscW("*")

        client.SendMessage(a)

        Return True
    End Function

    Public Function UnRegCall_x(ByVal port As Byte, ByVal callsign As String)

        Dim a() As Byte = {port, 0, 0, 0, 120, 0, 0, 0, _
                   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                   0, 0, 0, 0, 0, 0, 0, 0}

        Dim b As Integer

        For b = 1 To 10
            If callsign.Length >= b Then
                a(b + 7) = AscW(callsign(b - 1))
            Else
                a(b + 7) = 0
            End If
        Next


        client.SendMessage(a)
        Return True
    End Function

    Public Function AskInfo_G()

        Dim a() As Byte = {0, 0, 0, 0, 71, 0, 0, 0, _
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                            0, 0, 0, 0, 0, 0, 0, 0}


        client.SendMessage(a)

        Return True
    End Function

    Public Function AllowAll_m()
        Dim a() As Byte = {0, 0, 0, 0, 109, 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0}

        client.SendMessage(a)

        Return True
    End Function

    Public Function SendUnproto_M(ByVal port As Integer, ByVal ToCall As String, ByVal FromCall As String, ByVal Message As String)

        Dim a() As Byte = {port, 0, 0, 0, 77, 0, 0, 0, _
                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                                 0, 0, 0, 0, 0, 0, 0, 0}
        Dim b As Integer
        For b = 1 To 10
            If FromCall.Length >= b Then
                a(b + 7) = AscW(FromCall(b - 1))
            Else
                a(b + 7) = 0
            End If
        Next

        For b = 1 To 10
            If ToCall.Length >= b Then
                a(b + 17) = AscW(ToCall(b - 1))
            Else
                a(b + 17) = 0
            End If
        Next


        If Message.Length >= 2 Then
            If (AscW(Message(Message.Length - 1)) <> 13) Then Message = Message & ChrW(13)
            '    If (AscW(Message(Message.Length - 2)) <> 13) Then Message = Message & ChrW(13)
        End If


        b = Message.Length
        a(28) = b Mod 2 ^ 8
        b = b - a(28)
        a(29) = b Mod 2 ^ 16
        b = b - a(29)
        a(30) = b Mod 2 ^ 24
        b = b - a(30)
        'a(31) = b Mod 2 ^ 32
        b = b - a(31)



        Dim d(35 + Message.Length) As Byte


        For b = 0 To 35
            d(b) = a(b)
        Next
        For b = 0 To Message.Length - 1
            d(b + 36) = AscW(Message(b))
        Next

        client.SendMessage(d)
        'client.SendMessage(d)

        Return True
    End Function
#End Region

End Class
