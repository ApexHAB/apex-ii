Imports System.Text

Public Class tcpiptest
    Private client As New TCPInterface("86.137.48.140", 8000, True)

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


        Dim d(542) As Byte

        For b = 0 To 31
            d(b) = a(b)
        Next
        For b = 0 To 254
            d(b + 32) = uu(b)
        Next
        For b = 0 To 254
            d(b + 287) = pp(b)
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

    Public Function AllowAll_M()
        Dim a() As Byte = {0, 0, 0, 0, 109, 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                           0, 0, 0, 0, 0, 0, 0, 0}

        client.SendMessage(a)
        Return True
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'sendAUT_P(2, "abc", "123")
        AllowAll_M()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AskInfo_G()
    End Sub


End Class

