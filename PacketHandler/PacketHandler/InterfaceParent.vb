Public Class InterfaceParent

    Private interfacesettings_ As New InterfaceSettings

    Private WithEvents AGWPEHandler As AGWPE_APRSPacketHandler      'all different objects for whatever hte class may need to interface too
    Private WithEvents FLDigiHandler As TCPInterface
    Private SerialHandler As SerialPortInterface
    Private MappointHandler As TCPInterface
    Private GoogleEarthHandler As TCPInterface
    Private DLHandler As TCPInterface

    Private CanWrite_ As Boolean
    Private CanRead_ As Boolean

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


    Public Sub New(ByVal _interfaceSettings As InterfaceSettings)
        interfacesettings_ = _interfaceSettings

        Select Case interfacesettings_.InterfaceDirection
            Case InterfaceDirections.DataBalloonOut Or InterfaceDirections.DataSharingOut
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
        End Select



    End Sub

    Private Sub fldigiRecievied() Handles FLDigiHandler.DataRecieved

        Dim input() As Byte = FLDigiHandler.ReadBufferChars()
        Dim str As String = ""
        '#######need to sort stuff here - (the converting stream of packets to one string bit) #########
        For Each b As Byte In input
            str = str & ChrW(b)
        Next




        RaiseEvent LineRecievedStr(str, interfacesettings_, "", "")

    End Sub

    Private Sub AGWPERecieved(ByVal FromCall As String, ByVal ToCall As String, ByVal Header As String, ByVal Payload As String, ByVal All As String) Handles AGWPEHandler.ReceivedPacket
        '#### need to do filtering based on filters in the settings
    End Sub

    Public Sub Write(ByVal input As String)

    End Sub

End Class
