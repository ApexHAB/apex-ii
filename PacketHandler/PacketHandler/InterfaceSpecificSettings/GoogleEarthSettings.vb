Public Class GoogleEarthSettings
    'class contains variables relating to the specific interface, and carries out any validation on its data
    Private Host_ As String = "127.0.0.1"
    Private Port_ As Integer = 8000

    Public Property Host() As String
        Get
            Return Host_
        End Get
        Set(ByVal value As String)
            Host_ = value
        End Set
    End Property

    Public Property Port() As String
        Get
            Return Port_
        End Get
        Set(ByVal value As String)
            Port_ = value
        End Set
    End Property
End Class
