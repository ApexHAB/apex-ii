﻿Public Class PacketStructure
    'class which stores data about the structure of the incoming packets

    Private CustomDataType_ As Project
    Private PacketType_ As PacketFormats    'UKHAS or APRS - applies to first part of packet


    Private Fields_ As Dictionary(Of String, PacketField) = New Dictionary(Of String, PacketField) 'integer value is offset in packet

    Public Property PacketType() As PacketFormats
        Get
            Return PacketType_
        End Get
        Set(ByVal value As PacketFormats)
            PacketType_ = value
        End Set
    End Property

    Public Property GetField(ByVal offset As Integer) As PacketField
        Get
            If Fields_.ContainsKey("A" + offset.ToString) Then
                Return Fields_("A" + offset.ToString)
            Else
                Return Nothing ' New PacketField
            End If
        End Get
        Set(ByVal value As PacketField)

        End Set
    End Property




    Public Enum FieldType
        callsign
        cycle_count
        time
        latitude
        longitude
        altitude
        bearing
        speed
        sats
        sensor
        comment
        checksum
    End Enum

    Public Enum Encoding
        hexinteger
        decimalinteger
        decimalfloating
        tempraw
        humraw
        pressureraw
        light_mode
        light_value
        ddddddd         'defualt UKHAS
        dddmmmm         'NMEA $GPGGA / APRS
        dddmmss
        null
    End Enum

    Public Enum Units
        metric
        imperial
        null
    End Enum


    Public Sub LoadXML(ByVal FilePath As String)
        If FilePath = "" Then Exit Sub
        ' Try




        Dim xmlrd As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(FilePath)

        'clear current fields dictionary
        Fields_.Clear()

        While Not xmlrd.EOF
            xmlrd.Read()
            If xmlrd.IsStartElement Then
                Select Case xmlrd.Name
                    Case "sentence_delimiter"

                        Debug.WriteLine("SD " + xmlrd.ReadElementContentAsString)

                    Case "field_delimiter"
                        Debug.WriteLine("FD " + xmlrd.ReadElementContentAsString)

                    Case "fields"
                        Debug.WriteLine("Fs " + xmlrd.ReadElementContentAsString)

                    Case "callsign"
                        Debug.WriteLine("cs " + xmlrd.ReadElementContentAsString)

                    Case "field"
                        Dim fld As New PacketField
                        fld = DefualtPacketField()
                        Dim seq As Integer = 0
                        Dim str As String

                        xmlrd.Read()
                        While Not ((xmlrd.IsStartElement = False) And (xmlrd.Name = "field"))   'go through every element in field


                            If xmlrd.IsStartElement Then
                                Select Case xmlrd.Name.ToLower
                                    Case "seq"
                                        str = xmlrd.ReadElementString()
                                        If str <> "" Then
                                            seq = Integer.Parse(str)
                                        End If
                                    Case "name"
                                        str = xmlrd.ReadElementString()
                                        If str <> "" Then
                                            fld.FieldName = str
                                        End If
                                    Case "type"
                                        str = xmlrd.ReadElementString().ToLower
                                        If [Enum].IsDefined(GetType(FieldType), str) = True Then
                                            fld.FieldType = [Enum].Parse(GetType(FieldType), str, True)
                                        End If
                                    Case "encoding"
                                        str = xmlrd.ReadElementString().ToLower
                                        If [Enum].IsDefined(GetType(Encoding), str) = True Then
                                            fld.Encoding = [Enum].Parse(GetType(Encoding), str, True)
                                        End If
                                    Case "encoding2"
                                        str = xmlrd.ReadElementString().ToLower
                                        If [Enum].IsDefined(GetType(Encoding), str) = True Then
                                            fld.Encoding2 = [Enum].Parse(GetType(Encoding), str, True)
                                        End If
                                    Case "scaling"
                                        str = xmlrd.ReadElementString()
                                        If str <> "" Then
                                            fld.ScaleFactor = Double.Parse(str)
                                        End If
                                    Case "offset"
                                        str = xmlrd.ReadElementString()
                                        If str <> "" Then
                                            fld.Offset = Double.Parse(str)
                                        End If
                                    Case "unit"
                                        str = xmlrd.ReadElementString().ToLower
                                        If [Enum].IsDefined(GetType(Units), str) = True Then
                                            fld.Unit = [Enum].Parse(GetType(Units), str, True)
                                        End If
                                    Case "dp"
                                        str = xmlrd.ReadElementString()
                                        If str <> "" Then
                                            fld.DP = Integer.Parse(str)
                                        End If
                                    Case Else
                                        xmlrd.Read()
                                End Select
                            End If

                        End While

                        Fields_.Add("A" + seq.ToString, fld)

                End Select
            End If
        End While
        ' Catch
        'MsgBox("XML load failed")
        ' End Try

    End Sub

    Private Function DefualtPacketField()
        Dim out As New PacketField
        out.FieldName = ""
        out.FieldType = FieldType.Sensor
        out.Encoding = Encoding.null
        out.Encoding2 = Encoding.null
        out.ScaleFactor = 1
        out.Offset = 0
        out.FieldFlag = ""
        out.Unit = Units.null
        out.DP = -1
        Return out
    End Function

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
    Public DP As Integer           'decimal point; -1 for null
End Structure
