'[XmlInclude(typeof(FLDigiSettings))] _
<System.Xml.Serialization.XmlInclude(GetType(FLDigiSettings))> Public Class FLDigiSettings
    'class contains variables relating to the specific interface, and carries out any validation on its data
    Private Host_ As String = "127.0.0.1"
    Private Port_ As Integer = 7322

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
