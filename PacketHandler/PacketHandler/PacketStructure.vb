Public Class PacketStructure
    'class which stores data about the structure of the incoming packets

    Private CustomDataType_ As Project
    Private PacketType_ As PacketFormats    'UKHAS or APRS - applies to first part of packet

    'each field in the string will have:
    'offset
    'fieldname
    'fieldtype
    'encoding

    Private Fields_ As Dictionary(Of Integer, PacketField)

    Public Enum FieldType
        Counter
        Time
        Latitude
        Longitude
        Altitude
        Bearing
        Speed
        NoSats
        Temperature
        Pressure
        Raw
        CapHumidity
        LightValue
        LightMode
    End Enum

    Public Enum Encoding
        HexInteger
        DecimalInteger
        DecimalFloating
        DDDdddd         'defualt UKHAS
        DDDMMmm         'NMEA $GPGGA / APRS
        DDDMMSS
    End Enum
End Class

Public Structure PacketField
    Public FieldName As String
    Public FieldType As PacketStructure.FieldType
    Public Encoding As PacketStructure.Encoding
    Public ScaleFactor As Double
    Public Offset As Double
End Structure
