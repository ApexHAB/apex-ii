Public Class GlobalSettings
    Private interfaces_ As New List(Of InterfaceSettings)
    Private sensorDataParameters_ As New List(Of SensorParameters)
    Private timezone_ As Integer = 0
    Private UseUTC_ As Boolean = False

    Public Property SensorDataParameters() As List(Of SensorParameters)
        Get
            Return sensorDataParameters_
        End Get
        Set(ByVal value As List(Of SensorParameters))
            sensorDataParameters_ = value
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

    Public Function ContainsInterface(ByVal input As String) As Boolean
        For Each i As InterfaceSettings In interfaces_
            If i.InterfaceName = input Then Return True
        Next
        Return False
    End Function

End Class
