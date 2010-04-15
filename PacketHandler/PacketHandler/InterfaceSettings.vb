


Public Class InterfaceSettings

    'class to hold settings about an interface, such as its type, protocol etc. Settings specific to an interface type are stored in the InterfaceTypeSpecificSettings_ object
    'filters are also (but not yet) stored in this class

    Private InterfaceName_ As String = ""    'unique string to identify interface to end user
    Private InterfaceDirection_ As InterfaceDirections = InterfaceDirections.BLANK   'specifies what data travels through this interface
    Private InterfaceType_ As InterfaceTypes = InterfaceTypes.BLANK            'specifies interface's type
    Private DataFormat_ As PacketFormats = PacketFormats.BLANK                    'specifies whether UKHAS DL, APRS, etc is used
    
    Private InterfaceTypeSpecificSettings_ As New Object ' object to hold settings relevelent to the specified type
    Private Enabled_ As Boolean = True
    Private filter_ As New List(Of String)              'list of filters

    


#Region "properties"

    'ReadOnly Property AllValuesAsString() As Dictionary(Of String, String)
    '    'the InterfaceTypeSpecificSettings are not returned by this function
    '    Get
    '        Dim tempcol As New Dictionary(Of String, String)
    '        Dim tempstr As String = ""

    '        tempcol.Add(InterfaceName_, "InterfaceName")
    '       ' tempcol.Add(EnumToStr(InterfaceDirection_), "InterfaceDirection")
    '       tempcol.Add("InterfaceDirection", (InterfaceDirection_).ToString)
    '        'tempcol.Add(EnumToStr(InterfaceType_), "InterfaceType")
    '        'tempcol.Add(EnumToStr(DataFormat_), "DataFormat")
    '        tempcol.Add("InterfaceType", (InterfaceType_).ToString)
    '        tempcol.Add("DataFormat", (DataFormat_).ToString)
    '        tempcol.Add("Enabled", Enabled_.ToString)
    '        For Each s As String In filter_
    '            If Not tempstr = "" Then tempstr = tempstr & "\n"
    '            tempstr = tempstr & s
    '        Next
    '        tempcol.Add("Filter", tempstr)


    '        Return tempcol
    '    End Get
    'End Property

    Public Property Enabled() As Boolean
        Get
            Return Enabled_
        End Get
        Set(ByVal value As Boolean)
            Enabled_ = value
        End Set
    End Property

    Public Property InterfaceName() As String
        Get
            Return InterfaceName_
        End Get
        Set(ByVal value As String)
            InterfaceName_ = value
        End Set
    End Property

    Public Property InterfaceDirection() As InterfaceDirections
        Get
            Return InterfaceDirection_
        End Get
        Set(ByVal value As InterfaceDirections)
            InterfaceDirection_ = value
        End Set
    End Property

    Public Property InterfaceType() As InterfaceTypes
        Get
            Return InterfaceType_
        End Get
        Set(ByVal value As InterfaceTypes)
            InterfaceType_ = value
        End Set
    End Property

    Public Property DataFormat() As PacketFormats
        Get
            Return DataFormat_
        End Get
        Set(ByVal value As PacketFormats)
            DataFormat_ = value
        End Set
    End Property

    'Public Property InterfaceTypeSpecificSettings() As FLDigiSettings
    '    Get
    '        Return InterfaceTypeSpecificSettings_
    '    End Get
    '    Set(ByVal value As FLDigiSettings)
    '        InterfaceTypeSpecificSettings_ = value
    '    End Set
    'End Property
    <System.Xml.Serialization.XmlIgnore()> Public Property InterfaceTypeSpecificSettings() As Object
        Get
            Return InterfaceTypeSpecificSettings_

        End Get
        Set(ByVal value As Object)
            InterfaceTypeSpecificSettings_ = value

        End Set
    End Property

    Public Property Filters() As List(Of String)
        Get
            Return filter_
        End Get
        Set(ByVal value As List(Of String))
            filter_ = value
        End Set
    End Property

#End Region

    Public Shared Function AllowableFormats(ByVal Direction As InterfaceDirections) As List(Of PacketFormats)
        Dim output As New List(Of PacketFormats)
        Select Case Direction
            Case InterfaceDirections.DataBalloonOut
                output.Add(PacketFormats.UPLINK)
            Case InterfaceDirections.DataBiBalloonBoth
                output.Add(PacketFormats.APRS)
                output.Add(PacketFormats.UKHAS)
            Case InterfaceDirections.DataBiSharing
                output.Add(PacketFormats.APRS)
                output.Add(PacketFormats.UKHAS)
            Case InterfaceDirections.DataSharingOut
                output.Add(PacketFormats.APRS)
                output.Add(PacketFormats.UKHAS)
                output.Add(PacketFormats.GOOGLEEARTH)
            Case InterfaceDirections.DataIn
                output.Add(PacketFormats.APRS)
                output.Add(PacketFormats.UKHAS)

        End Select

        Return output
    End Function

    Public Shared Function CanUpload(ByVal input As InterfaceSettings) As Boolean

        Select Case input.InterfaceDirection
            Case InterfaceDirections.DataBalloonOut
                Return True
            Case InterfaceDirections.DataBiBalloonBoth
                Return True
            Case Else
                Return False
        End Select

    End Function

  


End Class
