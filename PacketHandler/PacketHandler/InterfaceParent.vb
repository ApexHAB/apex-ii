Public Class InterfaceParent

    Private interfacesettings_ As New InterfaceSettings

    Private WithEvents AGWPEHandler As AGWPE_APRSPacketHandler      'all different objects for whatever hte class may need to interface too
    Private WithEvents FLDigiHandler As TCPInterface
    Private SerialHandler As SerialPortInterface
    Private MappointHandler As MapPointInterface
    Private GoogleEarthHandler As TCPInterface
    Private DLHandler As TCPInterface

    Private CanWrite_ As Boolean
    Private CanRead_ As Boolean

    Const inputBufferSize = 2048

    Private InputBuffer(inputBufferSize) As Byte
    Private InputBufferPtr As Integer

    Private Frames As New Collection() '(Of String, Frame)     'stores all frames through this interface - contains only one packet of valid chksum, unlimited of nonvalid chksum
    Private FrameIDList As New List(Of Integer)             'does not store nonvalid checksums


    Public Event LineRecievedStr(ByVal output As String, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
    Public Event LineRecievedbyte(ByVal output() As Byte, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String) '## add from/to fields




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
            Return interfacesettings_.DataFormat
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


    Public Sub New(ByVal _interfaceSettings As InterfaceSettings)
        interfacesettings_ = _interfaceSettings

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

        Select Case interfacesettings_.InterfaceType
            Case InterfaceTypes.SERIALMODEM
            Case InterfaceTypes.AGWPE
            Case InterfaceTypes.FLDIGI
                FLDigiHandler = New TCPInterface(interfacesettings_.InterfaceTypeSpecificSettings.Host, interfacesettings_.InterfaceTypeSpecificSettings.Port, True)
            Case InterfaceTypes.MAPPOINT
                MappointHandler = New MapPointInterface()

        End Select



    End Sub

    Public Sub StoreFrame(ByVal Frame As Frame)
        'can only store one packet of the same id if the chksum is correct

        If Frame.CheckSum = True Then
            If FrameIDList.Contains(Frame.PcktCounter) Then Exit Sub

            FrameIDList.Add(Frame.PcktCounter)
            Frames.Add(Frame, Frame.PcktCounter.ToString)

        Else
            Dim i As Integer = 0
            While Frames.Contains("N" + Frame.PcktCounter + "-" + i)
                i = i + 1
            End While
            Frames.Add(Frame, Frame.PcktCounter.ToString)
        End If

    End Sub

    Private Sub fldigiRecievied() Handles FLDigiHandler.DataRecieved

        Dim input() As Byte = FLDigiHandler.ReadBufferChars()
        Dim str As String = ""
        '#######need to sort stuff here - (the converting stream of packets to one string bit) #########


        For Each b As Byte In input
            If (b = 10 Or b = 13) And (InputBufferPtr > 0) Then
                For i As Integer = 0 To InputBufferPtr - 1
                    str = str & ChrW(InputBuffer(i))
                Next
                RaiseEvent LineRecievedStr(str, interfacesettings_, "", "")
                InputBufferPtr = 0
            Else
                If InputBufferPtr >= inputBufferSize Then
                    For Each c As Byte In InputBuffer
                        str = str & ChrW(c)
                    Next
                    RaiseEvent LineRecievedStr(str, interfacesettings_, "", "")
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

    End Sub

    Public Sub Write(ByVal frame As Frame, Optional ByVal frameOrigin As InterfaceSettings = Nothing)  'this function formats the frame as it feels best

        Select Case interfacesettings_.InterfaceType
            Case InterfaceTypes.MAPPOINT
                MappointHandler.PlotPoint(frame.GPSCoordinates, frame.PcktCounter, 1, 5, 0.5)

        End Select

    End Sub

    Public Sub WriteMappoint(ByVal coords As GPScoord, ByVal sequence As Integer, Optional ByVal PinType As Integer = 1, Optional ByVal weight As Single = 0.5, Optional ByVal name As String = "")
        'aim to remove this function and let the one above do all its stuff
        If interfacesettings_.InterfaceType = InterfaceTypes.MAPPOINT Then
            MappointHandler.PlotPoint(coords, name, sequence, PinType, weight)
        End If
    End Sub

End Class
