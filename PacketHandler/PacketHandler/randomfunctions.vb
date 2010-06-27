Public Enum InterfaceTypes
    AGWPE
    FLDIGI
    MAPPOINT
    GOOGLEEARTH
    SERIALMODEM
    DLINTERNET
    Length
    BLANK
End Enum
Public Enum InterfaceDirections
    DataIn
    DataSharingOut
    DataBalloonOut
    DataBiSharing
    DataBiBalloonBoth
    Length
    BLANK
End Enum

Public Enum PacketFormats
    APRS
    UKHAS
    UPLINK
    GOOGLEEARTH
    Length
    BLANK
End Enum

Public Enum SensorDataTypes
    BLANK
    Temperature
    Pressure
    Length
End Enum

Public Enum GPSFormats
    DDDdddd         'defualt UKHAS
    DDDMMmm         'NMEA $GPGGA / APRS
    DDDMMSS
End Enum

Module randomfunctions
    Public Function StrtoEnumSensorDataTypes(ByVal input As String) As SensorDataTypes
        Select Case input
            Case "Temperature"
                Return SensorDataTypes.Temperature
            Case "Pressure"
                Return SensorDataTypes.Pressure
            Case ""
                Return SensorDataTypes.BLANK

            Case Else
                Return SensorDataTypes.BLANK
        End Select
    End Function

    Public Function StrToEnumInterfaceTypes(ByVal input As String) As InterfaceTypes
        Select Case input
            Case "agwpe"
                Return InterfaceTypes.AGWPE
            Case "DL internet server"
                Return InterfaceTypes.DLINTERNET
            Case "FLDigi"
                Return InterfaceTypes.FLDIGI
            Case "Google Earth"
                Return InterfaceTypes.GOOGLEEARTH
            Case "Mappoint"
                Return InterfaceTypes.MAPPOINT
            Case "Serial Modem"
                Return InterfaceTypes.SERIALMODEM
            Case Else
                Return InterfaceTypes.BLANK
        End Select

    End Function

    Public Function StrToEnumInterfaceDirection(ByVal input As String) As InterfaceDirections
        Select Case input
            Case "Out (Data to balloon)"
                Return InterfaceDirections.DataBalloonOut
            Case "Both (Data to balloon)"
                Return InterfaceDirections.DataBiBalloonBoth
            Case "Both (Data sharing)"
                Return InterfaceDirections.DataBiSharing
            Case "In"
                Return InterfaceDirections.DataIn
            Case "Out (Data sharing)"
                Return InterfaceDirections.DataSharingOut
            Case Else
                Return InterfaceDirections.BLANK
        End Select


    End Function

    Public Function StrToEnumPacketFormat(ByVal input As String) As PacketFormats
        Select Case input
            Case "APRS"
                Return PacketFormats.APRS
            Case "UKHAS"
                Return PacketFormats.UKHAS
            Case "UPLINK"
                Return PacketFormats.UPLINK
            Case "GOOGLEEARTH"
                Return PacketFormats.GOOGLEEARTH
            Case Else
                Return PacketFormats.BLANK
        End Select


    End Function

    Public Function EnumToStr(ByVal input As InterfaceTypes) As String
        Select Case input
            Case InterfaceTypes.AGWPE
                Return "agwpe"
            Case InterfaceTypes.DLINTERNET
                Return "DL internet server"
            Case InterfaceTypes.FLDIGI
                Return "FLDigi"
            Case InterfaceTypes.GOOGLEEARTH
                Return "Google Earth"
            Case InterfaceTypes.MAPPOINT
                Return "Mappoint"
            Case InterfaceTypes.SERIALMODEM
                Return "Serial Modem"

        End Select
        Return ""
    End Function

    Public Function EnumToStr(ByVal input As SensorDataTypes) As String
        Select Case input
            Case SensorDataTypes.Temperature
                Return "Temperature"
            Case SensorDataTypes.Pressure
                Return "Pressure"
            Case SensorDataTypes.BLANK
                Return ""
        End Select
        Return ""
    End Function

    Public Function EnumToStr(ByVal input As InterfaceDirections) As String
        Select Case input
            Case InterfaceDirections.DataBalloonOut
                Return "Out (Data to balloon)"
            Case InterfaceDirections.DataBiBalloonBoth
                Return "Both (Data to balloon)"
            Case InterfaceDirections.DataBiSharing
                Return "Both (Data sharing)"
            Case InterfaceDirections.DataIn
                Return "In"
            Case InterfaceDirections.DataSharingOut
                Return "Out (Data sharing)"
        End Select
        Return ""
    End Function

    Public Function EnumToStr(ByVal input As PacketFormats) As String
        Select Case input
            Case PacketFormats.APRS
                Return "APRS"
            Case PacketFormats.UKHAS
                Return "UKHAS"
            Case PacketFormats.UPLINK
                Return "UPLINK"
            Case PacketFormats.GOOGLEEARTH
                Return "GOOGLEEARTH"
        End Select
        Return ""
    End Function
End Module
