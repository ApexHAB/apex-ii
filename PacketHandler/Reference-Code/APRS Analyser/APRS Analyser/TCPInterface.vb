Imports System.Net.Sockets
Imports System.Text

Public Class TCPInterface
    Private client As System.Net.Sockets.TcpClient
    Private Const BYTES_TO_READ As Integer = 255
    Private readBuffer(BYTES_TO_READ) As Byte
    Private CLbuffer As New Queue(Of Array)
    Private tempbuffer() As Byte = {}
    Private host As String
    Private port As Integer

    Public Event DataRecieved()

#Region "Properties"

    Public ReadOnly Property ReadBufferChars()
        Get
            If CLbuffer.Count > 0 Then
                Return CLbuffer.Dequeue()
            Else
                Dim a() = {}
                Return a
            End If

        End Get
    End Property

    Public ReadOnly Property BufferLinesToRead() As Integer
        Get
            Return CLbuffer.Count
        End Get
    End Property

#End Region

    Public Sub New(ByVal host_ As String, ByVal port_ As Integer, ByVal connect As Boolean)
        host = host_
        port = port_
        Try
            client = New System.Net.Sockets.TcpClient(host_, port_)
            If connect = True Then ConnectTCP()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function ConnectTCP()
        Try

            client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
            Exit Function
        End Try
        Return True
    End Function

    'Public Function Reconnect()
    '    client.EndConnect(AddressOf doRead)
    '    client.BeginConnect(host, port, AddressOf doRead, Nothing)
    '    ' Dim client As System.Net.Sockets.TcpClient

    'End Function
    Private Sub doRead(ByVal ar As System.IAsyncResult)
        Dim totalRead As Integer
    
        Try
            totalRead = client.GetStream.EndRead(ar) 'Ends the reading and returns the number of bytes read.
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If totalRead > 0 Then

            Dim z As Integer

            
            Dim recievedArray(totalRead - 1) As Byte
           
            For z = 0 To totalRead - 1
                recievedArray(z) = readBuffer(z)
            Next


            CLbuffer.Enqueue(recievedArray)
            RaiseEvent DataRecieved()



        End If

        Try
            client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing) 'Begin the reading again.
        Catch ex As Exception
            Beep()
            Debug.WriteLine(ex.ToString)
        End Try
    End Sub

    Public Sub SendMessage(ByVal msg() As Byte)

        Dim sw As IO.BinaryWriter

        Try
            sw = New IO.BinaryWriter(client.GetStream)
            sw.Write(msg)
            sw.Flush()
        Catch ex As Exception
            Beep()
            Debug.WriteLine(ex.ToString)
        End Try
    End Sub


End Class
