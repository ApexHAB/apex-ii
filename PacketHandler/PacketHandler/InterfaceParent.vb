Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Security.Cryptography

Public Class InterfaceParent

    Public Enum InterfaceStatus
        Inactive
        Active
        Inactive_ConRefused
        Inactive_NotFound
        Inactive_NotImplemented
        Ready
    End Enum

    Private interfacesettings_ As New InterfaceSettings

    Private WithEvents AGWPEHandler As AGWPE_APRSPacketHandler      'all different objects for whatever hte class may need to interface too
    Private WithEvents FLDigiHandler As TCPInterface
    Private SerialHandler As SerialPortInterface
    Private MappointHandler As MapPointInterface
    Private GoogleEarthHandler As TCPInterface
    Private WithEvents DLHandler As TCPInterface

    Private CanWrite_ As Boolean
    Private CanRead_ As Boolean

    Private Status_ As InterfaceStatus = InterfaceStatus.Inactive
    Private error_ As Exception

    Private WithEvents timer As System.Timers.Timer

    Const inputBufferSize = 65536

    Private InputBuffer(inputBufferSize) As Byte
    Private InputBufferPtr As Integer

    Private Frames As New Collection() '(Of String, Frame)     'stores all frames through this interface - contains only one packet of valid chksum, unlimited of nonvalid chksum
    Private FrameIDList As New List(Of Integer)             'does not store nonvalid checksums
    Private PacketHashes As New List(Of String) 'used so not to duplicate incorrect checksum packets


    Public Event LineRecievedStr(ByVal output As String, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
    Public Event LineRecievedbyte(ByVal output() As Byte, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String) '## add from/to fields
    Public Event InterfaceStatusChange(ByVal NewStatus As InterfaceStatus, ByVal Message As String, ByVal InterfaceDetails As InterfaceSettings)

#Region "Properties"

    Public ReadOnly Property Status As InterfaceStatus
        Get
            Return Status_
        End Get
    End Property
    Public ReadOnly Property CurrentError As Exception
        Get
            Return error_
        End Get
    End Property


    Public ReadOnly Property CanWrite() As Boolean
        Get
            Return CanWrite_
        End Get
    End Property
    Public ReadOnly Property CanRead() As Boolean
        Get
            Return CanRead_
        End Get
    End Property
    Public ReadOnly Property DataFormat() As PacketFormats
        Get
            Return interfacesettings_.PacketStructure.PacketType
        End Get
    End Property
    Public ReadOnly Property InterfaceName()
        Get
            Return interfacesettings_.InterfaceName
        End Get
    End Property
    Public ReadOnly Property GetInterfaceSettings As InterfaceSettings
        Get
            Return interfacesettings_
        End Get
    End Property

#End Region

    Public Sub New(ByVal _interfaceSettings As InterfaceSettings)
        interfacesettings_ = _interfaceSettings
        ' If interfacesettings_.PacketStructure Is Nothing Then
        interfacesettings_.PacketStructure.LoadXML(interfacesettings_.XMLStructurePath)
        ' End If

        Select Case interfacesettings_.InterfaceDirection
            Case InterfaceDirections.DataBalloonOut
                CanWrite_ = True
                CanRead_ = False
            Case InterfaceDirections.DataSharingOut
                CanWrite_ = True
                CanRead_ = False
            Case InterfaceDirections.DataBiBalloonBoth Or InterfaceDirections.DataBiSharing
                CanWrite_ = True
                CanRead_ = True
            Case InterfaceDirections.DataIn
                CanWrite_ = False
                CanRead_ = True
            Case Else
                CanWrite_ = False
                CanRead_ = False
        End Select
        Try
            Select Case interfacesettings_.InterfaceType
                Case InterfaceTypes.SERIALMODEM
                    SerialHandler = New SerialPortInterface(interfacesettings_, True)
                    Status_ = InterfaceStatus.Active
                    '  Case InterfaceTypes.AGWPE
                Case InterfaceTypes.FLDIGI
                    FLDigiHandler = New TCPInterface(interfacesettings_.TCPHost, interfacesettings_.TCPPort, True)
                    Status_ = InterfaceStatus.Active
                Case InterfaceTypes.MAPPOINT
                    MappointHandler = New MapPointInterface()
                    Status_ = InterfaceStatus.Active
                Case InterfaceTypes.DLINTERNET
                    If interfacesettings_.Timer < 10 Then interfacesettings_.Timer = 4
                    timer = New System.Timers.Timer(interfacesettings_.Timer * 1000)
                    timer.Enabled = True
                    Status_ = InterfaceStatus.Ready
                Case Else
                    Status_ = InterfaceStatus.Inactive_NotImplemented

            End Select


            RaiseEvent InterfaceStatusChange(Status_, "", interfacesettings_)

        Catch ex1 As System.Net.Sockets.SocketException
            Debug.WriteLine("ERROR - IN INTERFACEPARENT:NEW")
            Dim i As Integer = 0
            If ex1.SocketErrorCode = System.Net.Sockets.SocketError.ConnectionRefused Then
                Status_ = InterfaceStatus.Inactive_ConRefused
            End If
            If ex1.SocketErrorCode = System.Net.Sockets.SocketError.HostNotFound Then
                Status_ = InterfaceStatus.Inactive_NotFound
            End If
            error_ = ex1

            RaiseEvent InterfaceStatusChange(Status_, ex1.Message, interfacesettings_)

        Catch ex As Exception
            Debug.WriteLine("ERROR - IN INTERFACEPARENT:NEW")
            error_ = ex
            Status_ = InterfaceStatus.Inactive
            RaiseEvent InterfaceStatusChange(Status_, ex.Message, interfacesettings_)
        End Try


    End Sub



    Public Function StoreFrame(ByVal Frame As Frame) As Boolean
        'can only store one packet of the same id if the chksum is correct
        'returns true if a new packet has been added.

        If Frame.CheckSum = True Then
            If FrameIDList.Contains(Frame.PcktCounter) Then Return False

            FrameIDList.Add(Frame.PcktCounter)
            Frames.Add(Frame, Frame.PcktCounter.ToString)

            Return True

        Else
            If PacketHashes.Contains(GenerateHash(Frame.ProcessedString)) Then Return False
            Dim i As Integer = 0
            While Frames.Contains("N" & Frame.PcktCounter.ToString() & "-" & i.ToString())
                i = i + 1
            End While
            Frames.Add(Frame, "N" & Frame.PcktCounter.ToString() & "-" & i.ToString())
            PacketHashes.Add(GenerateHash(Frame.ProcessedString))
            Return True
        End If



    End Function

    Private Function GenerateHash(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

    Private Sub fldigiRecievied() Handles FLDigiHandler.DataRecieved

        Dim input() As Byte = FLDigiHandler.ReadBufferChars()
        Dim str As String = ""
        '#######need to sort stuff here - (the converting stream of packets to one string bit) #########


        For Each b As Byte In input
            If b = 10 Or b = 13 Then
                If InputBufferPtr > 0 Then
                    str = ""
                    For i As Integer = 0 To InputBufferPtr - 1
                        str = str & ChrW(InputBuffer(i))
                    Next
                    RaiseEvent LineRecievedStr(str, interfacesettings_, "", "")
                    Debug.WriteLine(str)
                    InputBufferPtr = 0
                End If
            Else
                If InputBufferPtr >= inputBufferSize Then
                    For Each c As Byte In InputBuffer
                        str = str & ChrW(c)
                    Next
                    RaiseEvent LineRecievedStr(str, interfacesettings_, "", "")
                    Debug.WriteLine(str)
                    InputBufferPtr = 0
                Else

                    InputBuffer(InputBufferPtr) = b
                    InputBufferPtr = InputBufferPtr + 1
                End If
            End If
        Next





    End Sub

    Private Sub DLDataRecieved() Handles DLHandler.DataRecieved
        Dim reg As New Regex(interfacesettings_.PacketStructure.CallSign, RegexOptions.IgnoreCase)
        Dim reg2 As New Regex("</BODY>|</HTML>", RegexOptions.IgnoreCase)
        Dim input() As Byte = DLHandler.ReadBufferChars()
        Dim str As String = ""
        '#######need to sort stuff here - (the converting stream of packets to one string bit) #########


        For Each b As Byte In input
            ' Debug.Write(ChrW(b))
            If (b = 10 Or b = 13) Then
                If (InputBufferPtr > 0) Then
                    str = ""
                    For i As Integer = 0 To InputBufferPtr - 1
                        str = str & ChrW(InputBuffer(i))
                    Next
                    '
                    ' Debug.WriteLine(str)
                    If reg.IsMatch(str) Then
                        '  Debug.WriteLine("match")
                        ' Debug.WriteLine()

                        RaiseEvent LineRecievedStr(interfacesettings_.PacketStructure.SentenceDelimiter & str.Substring(reg.Match(str).Index), interfacesettings_, "", "")
                    End If

                    If reg2.IsMatch(str) Then
                        DLHandler.Close()
                    End If

                    InputBufferPtr = 0
                Else

                End If
            Else
                If InputBufferPtr >= inputBufferSize Then
                    For Each c As Byte In InputBuffer
                        str = str & ChrW(c)
                    Next
                    'RaiseEvent LineRecievedStr(str, interfacesettings_, "", "")
                    Debug.WriteLine(str)
                    InputBufferPtr = 0
                Else

                    InputBuffer(InputBufferPtr) = b
                    InputBufferPtr = InputBufferPtr + 1
                End If
            End If
        Next
    End Sub

    Private Sub AGWPERecieved(ByVal FromCall As String, ByVal ToCall As String, ByVal Header As String, ByVal Payload As String, ByVal All As String) Handles AGWPEHandler.ReceivedPacket
        '#### need to do filtering based on filters in the settings
    End Sub

    Public Sub Write(ByVal input As String)
        Select Case interfacesettings_.InterfaceType
            Case InterfaceTypes.SERIALMODEM
                SerialHandler.SendData(input)
        End Select
        Debug.WriteLine("DATA WRITTEN - " & input)
    End Sub

    Public Function Write(ByVal frame As Frame, Optional ByVal frameOrigin As InterfaceSettings = Nothing) As Boolean  'this function formats the frame as it feels best

        Select Case interfacesettings_.InterfaceType
            Case InterfaceTypes.MAPPOINT
                Select Case frameOrigin.InterfaceName
                    Case "Manual"
                        MappointHandler.PlotPoint(frame.GPSCoordinates, frame.PcktCounter, 2, 3, 0.5)
                    Case Else
                        MappointHandler.PlotPoint(frame.GPSCoordinates, frame.PcktCounter, 1, 5, 0.5)
                End Select
                Return True

            Case Else

        End Select

        Return False
    End Function

    Public Sub WriteMappoint(ByVal coords As GPScoord, ByVal sequence As Integer, Optional ByVal PinType As Integer = 1, Optional ByVal weight As Single = 0.5, Optional ByVal name As String = "")
        'aim to remove this function and let the one above do all its stuff
        If interfacesettings_.InterfaceType = InterfaceTypes.MAPPOINT Then
            MappointHandler.PlotPoint(coords, name, sequence, PinType, weight)
        End If
    End Sub

    Private Sub timer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timer.Elapsed
        '  Try

        If Not DLHandler Is Nothing Then DLHandler.Close()

        Dim uri As New System.Uri(interfacesettings_.TCPHost, System.UriKind.RelativeOrAbsolute)

        If uri.IsAbsoluteUri = False Then
            uri = New System.Uri("http://" & interfacesettings_.TCPHost)
        End If

        DLHandler = New TCPInterface(uri.Authority, interfacesettings_.TCPPort, True)
        Status_ = InterfaceStatus.Active

       


        DLHandler.SendMessage(ToByteArr("GET " & uri.AbsolutePath & " HTTP/1.1" & vbCrLf & "HOST: " & uri.Authority & vbCrLf & vbCrLf))





        'Catch ex1 As System.Net.Sockets.SocketException
        '    Dim i As Integer = 0
        '    If ex1.SocketErrorCode = System.Net.Sockets.SocketError.ConnectionRefused Then
        '        Status_ = InterfaceStatus.Inactive_ConRefused
        '    End If
        '    If ex1.SocketErrorCode = System.Net.Sockets.SocketError.HostNotFound Then
        '        Status_ = InterfaceStatus.Inactive_NotFound
        '    End If
        '    error_ = ex1

        '    RaiseEvent InterfaceStatusChange(Status_, ex1.Message, interfacesettings_)

        'Catch ex As Exception
        '    error_ = ex
        '    Status_ = InterfaceStatus.Inactive
        '    RaiseEvent InterfaceStatusChange(Status_, ex.Message, interfacesettings_)
        'End Try
    End Sub

    Private Function ToByteArr(ByVal str As String) As Byte()
        Dim buff(str.Count - 1) As Byte

        For i = 0 To str.Count - 1
            buff(i) = Byte.Parse(AscW(str(i)))
        Next

        Return (buff)

    End Function

End Class
