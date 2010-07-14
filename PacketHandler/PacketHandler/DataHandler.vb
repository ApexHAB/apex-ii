Imports System.Text
Imports System.Security.Cryptography

Public Class DataHandler

    ' Private Callsign_ As String = ""
    Dim ValidPackets As New List(Of Integer)
    Dim NonValidPackets As New List(Of String)
    ' Private pStructure As PacketStructure

    '   Dim Altitudes_ As New List(Of KeyValuePair(Of DateTime, Double))

    Dim Values_ As New Dictionary(Of String, List(Of KeyValuePair(Of DateTime, Double)))
    Dim ValuesAdded_ As Dictionary(Of String, List(Of KeyValuePair(Of DateTime, Double)))

#Region "properties"

    Public ReadOnly Property Values As Dictionary(Of String, List(Of KeyValuePair(Of DateTime, Double)))
        Get
            Return Values_
        End Get
    End Property

    Public Property ValuesChanged As Dictionary(Of String, List(Of KeyValuePair(Of DateTime, Double)))
        Get
            Return ValuesAdded_
        End Get
        Set(ByVal value As Dictionary(Of String, List(Of KeyValuePair(Of DateTime, Double))))
            ValuesAdded_ = value
        End Set
    End Property

    'Public ReadOnly Property PacketStructure As PacketStructure
    '    Get
    '        Return pStructure
    '    End Get
    'End Property

    'Public Property Callsign As String
    '    Get
    '        Return Callsign_
    '    End Get
    '    Set(ByVal value As String)
    '        Callsign_ = value
    '    End Set
    'End Property
    Public ReadOnly Property Altitudes As List(Of KeyValuePair(Of DateTime, Double))
        Get
            If Values_.ContainsKey("altitude") Then Return Values_("altitude")
            Return New List(Of KeyValuePair(Of DateTime, Double))
        End Get
    End Property

#End Region

    Public Sub New()
        ' pStructure = PacketS
        'Callsign_ = PacketS.CallSign
    End Sub

    Public Function AddFrame(ByVal frame As Frame) As Boolean

        If Not frame.CheckSum Then Return False



        Dim dt As DateTime

        If Not DateTime.TryParse(frame.PacketTime, dt) Then Return False

        If ValidPackets.Contains(frame.PcktCounter) Then Return False
        ValidPackets.Add(frame.PcktCounter)



        For Each kv As KeyValuePair(Of String, Double) In frame.PICdata

            AddKVPair(kv, dt)

        Next

        Dim kv1 As New KeyValuePair(Of String, Double)("altitude", CDbl(frame.Altitude))
        AddKVPair(kv1, dt)

        kv1 = New KeyValuePair(Of String, Double)("sats", frame.Sats)
        AddKVPair(kv1, dt)

        kv1 = New KeyValuePair(Of String, Double)("speed", frame.Speed)
        AddKVPair(kv1, dt)

        kv1 = New KeyValuePair(Of String, Double)("bearing", frame.Heading)
        AddKVPair(kv1, dt)


        Return True
    End Function

    Private Function AddKVPair(ByVal KV As KeyValuePair(Of String, Double), ByVal dt As DateTime) As Boolean
        'returns whether the action is an addition or insertion
        Dim sortbool As Boolean = False
        If Not Values_.ContainsKey(KV.Key) Then Values_.Add(KV.Key, New List(Of KeyValuePair(Of DateTime, Double)))

        If Values_(KV.Key).Count > 0 Then
            If Values_(KV.Key)(Values_(KV.Key).Count - 1).Key > dt Then sortbool = True
        End If

        Values_(KV.Key).Add(New KeyValuePair(Of DateTime, Double)(dt, KV.Value))

        If sortbool Then
            Dim sorter As New DateKeyComp
            Values_(KV.Key).Sort(sorter)
            ValuesAdded_ = Nothing
        Else
            If ValuesAdded_ Is Nothing Then ValuesAdded_ = New Dictionary(Of String, List(Of KeyValuePair(Of DateTime, Double)))
            If Not ValuesAdded_.ContainsKey(KV.Key) Then ValuesAdded_.Add(KV.Key, New List(Of KeyValuePair(Of DateTime, Double)))
            ValuesAdded_(KV.Key).Add(New KeyValuePair(Of DateTime, Double)(dt, KV.Value))
        End If
        Return sortbool
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

End Class

Class DateKeyComp
    Implements IComparer(Of KeyValuePair(Of DateTime, Double))

    Public Function Compare(ByVal x As System.Collections.Generic.KeyValuePair(Of Date, Double), ByVal y As System.Collections.Generic.KeyValuePair(Of Date, Double)) As Integer Implements System.Collections.Generic.IComparer(Of System.Collections.Generic.KeyValuePair(Of Date, Double)).Compare
        Compare = x.Key < y.Key
    End Function
End Class