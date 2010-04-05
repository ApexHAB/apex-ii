Public Class SerialPortInterface
    Private WithEvents serialPort As New System.IO.Ports.SerialPort

    Event DataRecieved(ByVal data() As Byte)

    Private settings_ As New SerialPortSettings

    Public Property Settings() As SerialPortSettings
        Get
            Return settings_
        End Get
        Set(ByVal value As SerialPortSettings)
            settings_ = value
        End Set
    End Property

    Public Sub New(ByVal Settings As SerialPortSettings, ByVal Connect As Boolean)
        settings_ = Settings
        With serialPort
            .BaudRate = settings_.Baud
            .DataBits = settings_.DataBits
            .Parity = settings_.Parity
            .PortName = settings_.Port
            .StopBits = settings_.StopBits
        End With



        If Connect Then
            OpenPort()
        End If

    End Sub

    Public Sub OpenPort()
        If Not (serialPort.IsOpen) Then
            serialPort.Open()
        End If
    End Sub

    Public Sub SendData(ByVal input As String)
        serialPort.Write(input)
    End Sub

    Public Sub SendData(ByVal input() As Byte)
        If input.Count > 0 Then
            serialPort.Write(input, 0, input.Count - 1)
        End If
    End Sub

    Private Sub SerialDataRecieved() Handles serialPort.DataReceived
        Dim temp(serialPort.BytesToRead) As Byte
        serialPort.Read(temp, 0, serialPort.BytesToRead)
        RaiseEvent DataRecieved(temp)
    End Sub

End Class
