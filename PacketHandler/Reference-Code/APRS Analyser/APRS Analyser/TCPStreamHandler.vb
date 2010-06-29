Public Class TCPStreamHandler

    Dim tempbuffer() As Byte = {}

    Private WithEvents client As TCPInterface
    Dim WithEvents timeout As System.Timers.Timer
    Public Event ReceivedLine(ByVal data As String)


    Public Sub New(ByVal host As String, ByVal port As Integer, ByVal connect As Boolean, ByVal timeoutMS As Integer)
        client = New TCPInterface(host, port, connect)
        timeout = New System.Timers.Timer(timeoutMS)
        timeout.Enabled = False
        ' timeout.Stop()
        timeout.Interval = timeoutMS
    End Sub


    Private Sub clientRcv() Handles client.DataRecieved
        'timeout.Stop()
        timeout.Enabled = False
        Dim a() As Byte = client.ReadBufferChars
        If a.Count = 0 Then Exit Sub


        Dim b As Byte
        Dim pointerS As Integer = 0
        Dim pointerE As Integer = -1
        Dim str As String = ""

        Dim recievedArray((a.Length + tempbuffer.Length) - 1) As Byte
        Array.Copy(tempbuffer, recievedArray, tempbuffer.Length)

        For z = 0 To a.Length - 1
            recievedArray(z + tempbuffer.Length) = a(z)
        Next



        For z = 0 To recievedArray.Length - 1
            b = recievedArray(z)

            If b = AscW("$") Or b = 10 Or b = 13 Then
                If z = 0 Then
                    pointerS = z
                Else
                    If z - pointerS <> 1 Then
                        pointerE = z
                    End If
                End If
                If pointerE <> -1 Then
                    str = ""
                    For y = pointerS To pointerE - 1
                        str = str & ChrW(recievedArray(y))
                    Next
                    RaiseEvent ReceivedLine(StripCRLF(str))
                    pointerS = pointerE
                    pointerE = -1

                End If

            End If
        Next
        ReDim tempbuffer(-1)
        If (recievedArray(recievedArray.Length - 1) = 10 Or recievedArray(recievedArray.Length - 1) = 13) Or recievedArray.Length > 1024 Then
            str = ""
            For y = pointerS To recievedArray.Length - 1
                str = str & ChrW(recievedArray(y))
            Next
            RaiseEvent ReceivedLine(StripCRLF(str))
        Else
            ReDim tempbuffer(recievedArray.Length - 1 - pointerS)
            Array.Copy(recievedArray, pointerS, tempbuffer, 0, (recievedArray.Length) - pointerS)
            timeout.Enabled = True
            '  timeout.Start()

        End If

    End Sub

    Private Sub timeouts() Handles timeout.Elapsed
        'timeout.Stop()
        timeout.Enabled = False
        Dim a() As Byte = {10, 13}


        Dim pointerS As Integer = 0
        Dim pointerE As Integer = -1
        Dim str As String = ""

        Dim recievedArray((a.Length + tempbuffer.Length) - 1) As Byte
        Array.Copy(tempbuffer, recievedArray, tempbuffer.Length)

        For z = 0 To a.Length - 1
            recievedArray(z + tempbuffer.Length) = a(z)
        Next


        ReDim tempbuffer(-1)

        str = ""
        For y = 0 To recievedArray.Length - 1
            str = str & ChrW(recievedArray(y))
        Next
        RaiseEvent ReceivedLine(StripCRLF(str))


    End Sub

    Private Function StripCRLF(ByVal str As String) As String
        Dim nstr As String = ""
        If str <> "" Then
            For a = 0 To str.Length - 1
                If Not (AscW(str(a)) = 10 Or AscW(str(a)) = 13) Then
                    nstr = nstr & str(a)
                End If
            Next
        End If
        Return nstr
    End Function
End Class
