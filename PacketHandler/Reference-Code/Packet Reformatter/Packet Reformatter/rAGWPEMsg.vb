Imports System.Net.Sockets
Imports System.Text
Imports System.IO.Ports

Public Class rAGWPEMsg
    Public Port As Byte            'All have defaults, since most are not used in every type of packet
    Public DataKind As Char             'DataKind has no default, since it is used in every packet
    Public PID As Byte
    Public CallFrom As String
    Public CallTo As String
    Public DataLen As Int32

    'Received data
    Public majVers As Int16
    Public minVers As Int16
    Public nPorts As Integer
    Public PortInfo(,) As Object
    Private msg(35) As Byte         'byte array of AGWPE frame to be sent

    Public Sub New()
        'initialise
        Port = 0
        PID = 0
        CallFrom = Nothing
        CallTo = Nothing
        DataLen = 0
    End Sub

    Public Function ToBytes(ByVal DataKind As Char, Optional ByVal Port As Byte = 0, Optional ByVal PID As Byte = 0, Optional ByVal CallFrom As String = Nothing, Optional ByVal CallTo As String = Nothing, Optional ByVal DataLen As Int32 = 0, Optional ByVal User As Int32 = 0)
        'All have defaults, since most are not used in every type of packet
        'DataKind has no default, since it is used in every packet

        Dim msg(35) As Byte

        Dim temp() As Byte      'used as inbetween for callsign byte conversions
        Dim rmod As Integer = 0

        For rCount = 0 To 35
            msg(rCount) = 0
        Next

        'built up according to AGWPE format
        msg(0) = Port
        msg(4) = Microsoft.VisualBasic.AscW(DataKind)
        msg(6) = PID

        If CallFrom <> "" Then
            temp = Encoding.ASCII.GetBytes(CallFrom)
            For rCount = 0 To (temp.Length - 1)
                msg(rCount + 8) = temp(rCount)
            Next
        End If

        If CallTo <> "" Then
            temp = Encoding.ASCII.GetBytes(CallTo)
            For rCount = 0 To (temp.Length - 1)
                msg(rCount + 18) = temp(rCount)
            Next
        End If

        msg(28) = (DataLen And &HFF)
        msg(29) = ((DataLen And &HFF00) / &H100)
        msg(30) = ((DataLen And &HFF0000) / &H10000)
        msg(31) = ((DataLen And &HFF000000) / &H1000000)

        'return byte array
        ToBytes = msg
    End Function

    Public Function APRSFrame(ByVal Info As String, Optional ByVal Destination As String = "", Optional ByVal Source As String = "")
        Try
            Dim output() As Byte        'array to return
            Dim temp1() As Byte         'callto
            Dim temp2() As Byte         'callsign
            Dim temp3() As Byte         'custom info (i.e. balloon sensor data)
            Dim length As Integer       'length of frame

            If Destination <> "" Then   'M frame - APRS standard
                temp1 = Encoding.ASCII.GetBytes(Destination)
                temp2 = Encoding.ASCII.GetBytes(Source)
                temp3 = Encoding.ASCII.GetBytes(Info)

                length = temp1.Length + temp2.Length + temp3.Length

                ReDim output(length + 5)

                'copy fields into output in order
                Buffer.BlockCopy(temp1, 0, output, 1, 7)
                Buffer.BlockCopy(temp2, 0, output, temp1.Length + 1, 7)
                Buffer.BlockCopy(temp3, 0, output, temp1.Length + temp2.Length + 3, temp3.Length)

                output(0) = 126
                output(15) = 3
                output(16) = 240
                output(19 + Info.Length) = 126
            Else    'M* frame - for APRS Analyser comms
                'contains no callsigns
                temp3 = Encoding.ASCII.GetBytes(Info)
                ReDim output(temp3.Length)
                Buffer.BlockCopy(temp3, 0, output, 0, temp3.Length)
            End If

            APRSFrame = output

        Catch ex As Exception
            MsgBox("Error while building balloon frame. Error = " & ex.Message)
            APRSFrame = ""
        End Try
    End Function

    Public Sub FromBytes(ByVal response() As Byte)
        Try
            Dim temp(9) As Byte      'go-between for conversions

            'frame is according to known structure, so fields can be extracted
            Port = response(0)
            DataKind = Microsoft.VisualBasic.Chr(response(4))
            PID = response(6)

            For rCount = 8 To 17
                temp(rCount - 8) = response(rCount)
            Next
            CallFrom = Encoding.ASCII.GetChars(temp)

            For rCount = 18 To 27
                temp(rCount - 18) = response(rCount)
            Next
            CallTo = Encoding.ASCII.GetChars(temp)

            DataLen = response(28) + (response(29) * &H100) + (response(30) * &H10000) + (response(31) * &H1000000)

            'once frame is decoded, decode any following data
            If DataLen > 0 Then
                ReDim temp(response.Length - 36)
                For rcount = 36 To (response.Length - 1)
                    temp(rcount - 36) = response(rcount)
                Next
                decodeExtras(temp, DataKind)
            End If

        Catch ex As Exception
            MsgBox("Error while decoding AGWPE frame. Error = " & ex.Message)
        End Try
    End Sub

    Private Sub decodeExtras(ByVal info() As Byte, ByVal datakind As Char)
        Try
            'decodes following information
            Select Case datakind
                Case Is = "R"                                           'Version Number
                    majVers = info(0) + (info(1) * &H100)
                    minVers = info(4) + (info(5) * &H100)
                Case Is = "G"                                           'Port Info
                    nPorts = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Chr(info(0)))
                    If nPorts > 0 Then
                        ReDim PortInfo(nPorts - 1, 9)

                        Dim temp As String
                        Dim CurrentPort As Integer = 0

                        For rCount = 2 To (info.Length - 1)
                            temp = Microsoft.VisualBasic.Chr(info(rCount))      'Gets next character in info string
                            If temp <> ";" Then                                 'If still in same section
                                PortInfo(CurrentPort, 0) = PortInfo(CurrentPort, 0) & temp        'Add next char to string
                            Else
                                CurrentPort = CurrentPort + 1                   'If delimiter found, goto next port
                                If CurrentPort > nPorts - 1 Then                'if no more ports
                                    Exit For                                    'stop reading
                                End If
                            End If
                        Next
                    End If
                Case Is = "g"                                           'Port Capabilities
                    Dim temp As Int32
                    Dim PortNum As Integer = (frmMain.lstPorts.SelectedIndex - 1)
                    For rcount = 0 To 7
                        PortInfo(PortNum, rcount + 1) = info(rcount)
                    Next rcount

                    temp = info(8) + (info(9) * &H100) + (info(10) * &H10000) + (info(11) * &H1000000)
                    PortInfo(PortNum, 9) = temp
                Case Is = "U"       'Monitoring frame
                    frmMain.lstMessages.Items.Add(Encoding.ASCII.GetChars(info))
            End Select

        Catch ex As Exception
            MsgBox("Error while decoding additional information following AGWPE frame. Error = " & ex.Message)
        End Try

    End Sub
End Class
