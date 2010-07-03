Imports System.IO

Public Class GlobalSettings
    Private interfaces_ As New List(Of InterfaceSettings)

    Private timezone_ As Integer = 0
    Private UseUTC_ As Boolean = False
    Private LogFolder_ As String = Directory.GetCurrentDirectory()
    ' Public test As New Dictionary(Of String, String)

#Region "Properties"

    Public Property logFolder As String
        Get
            Return LogFolder_
        End Get
        Set(ByVal value As String)
            LogFolder_ = value
        End Set
    End Property

    Public Property Interfaces() As List(Of InterfaceSettings)
        Get
            Return interfaces_
        End Get
        Set(ByVal value As List(Of InterfaceSettings))
            interfaces_ = value
        End Set
    End Property

    Public Property TimeZone() As Integer
        Get
            Return timezone_
        End Get
        Set(ByVal value As Integer)
            timezone_ = value
        End Set
    End Property

    Public Property UseUTC() As Boolean
        Get
            Return UseUTC_
        End Get
        Set(ByVal value As Boolean)
            UseUTC_ = value
        End Set
    End Property

#End Region



    Public Function SaveToDisk(ByVal Path As String) As Boolean


        Dim ser As New System.Xml.Serialization.XmlSerializer(GetType(GlobalSettings))
        Dim writestream As New System.IO.StreamWriter(Path)
        ser.Serialize(writestream, Me)
        writestream.Close()

    End Function



    Public Function ContainsInterface(ByVal input As String) As Boolean
        For Each i As InterfaceSettings In interfaces_
            If i.InterfaceName = input Then Return True
        Next
        Return False
    End Function

End Class
