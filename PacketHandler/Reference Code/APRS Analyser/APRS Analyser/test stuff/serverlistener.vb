Public Class serverlistener


    Dim listener As Net.Sockets.TcpListener

    Dim listenThread As Threading.Thread

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        listener = New Net.Sockets.TcpListener(Net.IPAddress.Parse("127.0.0.1"), 8000)

        listener.Start()

        listenThread = New Threading.Thread(AddressOf DoListen)

        listenThread.IsBackground = True

        listenThread.Start()

    End Sub



    Private Sub DoListen()

        Dim sr As IO.BinaryReader

        Do

            ' Try

            Dim client As Net.Sockets.TcpClient = listener.AcceptTcpClient

            sr = New IO.BinaryReader(client.GetStream)
            Dim y As Byte
            Do While 1 = 1
                y = sr.ReadByte
                If y = 0 Then
                    Debug.WriteLine(0)
                Else
                    Debug.WriteLine(y & "  " & ChrW(y))
                End If

            Loop
            '  MessageBox.Show(sr.ReadToEnd)

            sr.Close()

            '  Catch

            ' End Try

        Loop

    End Sub
End Class