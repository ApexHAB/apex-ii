Public Class SerialPortSettings
    'class contains variables relating to the specific interface, and carries out any validation on its data
    Private baud_ As Integer = 2400
    Private port_ As String = ""
    Private parity_ As System.IO.Ports.Parity = IO.Ports.Parity.None
    Private databits_ As Integer = 8
    Private stopbits_ As System.IO.Ports.StopBits = IO.Ports.StopBits.One

    Public Property Baud() As Integer
        Get
            Return baud_
        End Get
        Set(ByVal value As Integer)
            baud_ = value
        End Set
    End Property

    Public Property Port() As String
        Get
            Return port_
        End Get
        Set(ByVal value As String)
            port_ = value
        End Set
    End Property

    Public Property Parity() As System.IO.Ports.Parity
        Get
            Return parity_
        End Get
        Set(ByVal value As System.IO.Ports.Parity)
            parity_ = value
        End Set
    End Property

    Public Property DataBits() As Integer
        Get
            Return databits_
        End Get
        Set(ByVal value As Integer)
            databits_ = value
        End Set
    End Property

    Public Property StopBits() As System.IO.Ports.StopBits
        Get
            Return stopbits_
        End Get
        Set(ByVal value As System.IO.Ports.StopBits)
            stopbits_ = value
        End Set
    End Property

End Class
