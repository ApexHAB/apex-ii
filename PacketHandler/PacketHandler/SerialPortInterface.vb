Public Class SerialPortInterface
    Private WithEvents serialPort As New System.IO.Ports.SerialPort

    Event DataRecieved(ByVal data() As Byte)

    Private settings_ As New InterfaceSettings

    Public Property Settings() As InterfaceSettings
        Get
            Return settings_
        End Get
        Set(ByVal value As InterfaceSettings)
            settings_ = value
            LoadSettings()
            If serialPort.IsOpen Then
                serialPort.Close()
                serialPort.Open()
            End If
        End Set
    End Property



    Private Sub LoadSettings()

        With serialPort
            .BaudRate = settings_.sBaud
            .DataBits = settings_.sDatabits
            .Parity = settings_.sParity
            .PortName = settings_.sPort
            .StopBits = settings_.sStopbits
        End With
    End Sub

    Public Sub New(ByVal Settings As InterfaceSettings, ByVal Connect As Boolean)
        settings_ = Settings
        LoadSettings()


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
        If serialPort.IsOpen = False Then
            OpenPort()
            serialPort.Write(input)
            serialPort.Close()
        Else
            serialPort.Write(input)
        End If

    End Sub

    Public Sub SendData(ByVal input() As Byte)
        If serialPort.IsOpen = False Then
            OpenPort()
            If input.Count > 0 Then
                serialPort.Write(input, 0, input.Count - 1)
            End If
            serialPort.Close()
        Else
            If input.Count > 0 Then
                serialPort.Write(input, 0, input.Count - 1)
            End If
        End If
    End Sub

    Private Sub SerialDataRecieved() Handles serialPort.DataReceived
        Dim temp(serialPort.BytesToRead) As Byte
        serialPort.Read(temp, 0, serialPort.BytesToRead)
        RaiseEvent DataRecieved(temp)
    End Sub

End Class
