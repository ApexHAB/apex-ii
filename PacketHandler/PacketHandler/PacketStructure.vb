Public Class PacketStructure
    'class which stores data about the structure of the incoming packets

    Private CustomDataType_ As Project
    Private PacketType_ As PacketFormats    'UKHAS or APRS - applies to first part of packet


    Private Fields_ As Dictionary(Of Integer, PacketField)  'integer value is offset in packet

    Public Property PacketType() As PacketFormats
        Get
            Return PacketType_
        End Get
        Set(ByVal value As PacketFormats)
            PacketType_ = value
        End Set
    End Property




    Public Enum FieldType
        Counter
        Time
        Latitude
        Longitude
        Altitude
        Bearing
        Speed
        NoSats
        Sensor
    End Enum

    Public Enum Encoding
        HexInteger
        DecimalInteger
        DecimalFloating
        TempRaw
        HumRaw
        Light_Mode
        Light_value
        DDDdddd         'defualt UKHAS
        DDDMMmm         'NMEA $GPGGA / APRS
        DDDMMSS
        null
    End Enum

    Public Enum Units
        Metric
        Imperial
        null
    End Enum
End Class

Public Structure PacketField
    Public FieldName As String
    Public FieldType As PacketStructure.FieldType
    Public Encoding As PacketStructure.Encoding
    Public Encoding2 As PacketStructure.Encoding        'temp could be type hex & temp raw for example
    Public ScaleFactor As Double
    Public Offset As Double
    Public FieldFlag As String      'valid to apexi only
    Public Unit As PacketStructure.Units
    Public DP As Integer            'decimal point; -1 for null
End Structure
