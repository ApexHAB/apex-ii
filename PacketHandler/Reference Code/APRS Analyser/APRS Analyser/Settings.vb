Public Class Settings

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lstfilter.Items.Add(txtAdd.Text)
        txtAdd.Text = ""
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lstfilter.SelectedIndex <> -1 Then lstfilter.Items.RemoveAt(lstfilter.SelectedIndex)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
        Me.Dispose()
    End Sub

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAdd.Text = ""
        txtHost.Text = MainForm.Host
        txtPort.Text = MainForm.Port
        txtFLHost.Text = MainForm.HostFL
        txtFLPort.Text = MainForm.PortFL
        NUDTimeZone.Value = MainForm.timezone
        txtmessStart.Text = MainForm.ex.StatusPacketStartText
        ckhIgnoreZ.Checked = MainForm.ignoreZ

        If MainForm.FileSavePath.Length > 30 Then
            lbpath.Text = MainForm.FileSavePath.Substring(0, 12) & " ... " & MainForm.FileSavePath.Substring(MainForm.FileSavePath.Length - 18, 18)
        Else
            lbpath.Text = MainForm.FileSavePath
        End If
        If MainForm.FileSavePathfilt.Length > 30 Then
            lbfiltpath.Text = MainForm.FileSavePathfilt.Substring(0, 12) & " ... " & MainForm.FileSavePathfilt.Substring(MainForm.FileSavePathfilt.Length - 18, 18)
        Else
            lbfiltpath.Text = MainForm.FileSavePathfilt
        End If
        If MainForm.FileSavePathCSV.Length > 30 Then
            lbCSVPath.Text = MainForm.FileSavePathCSV.Substring(0, 12) & " ... " & MainForm.FileSavePathCSV.Substring(MainForm.FileSavePathCSV.Length - 18, 18)
        Else
            lbCSVPath.Text = MainForm.FileSavePathCSV
        End If
        Dim a As Integer

        If MainForm.Filter.Count <> 0 Then
            For a = 0 To MainForm.Filter.Count - 1
                lstfilter.Items.Add(MainForm.Filter.Item(a))
            Next
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        MainForm.Filter.Clear()

        If lstfilter.Items.Count <> 0 Then
            For a = 0 To lstfilter.Items.Count - 1
                MainForm.Filter.Add(lstfilter.Items.Item(a))
            Next
        End If

        MainForm.ex.StatusPacketStartText = txtmessStart.Text
        MainForm.ignoreZ = ckhIgnoreZ.Checked
        MainForm.timezone = NUDTimeZone.Value
        MainForm.ex.TimeZone = NUDTimeZone.Value
        MainForm.ex2.TimeZone = NUDTimeZone.Value

        If (MainForm.Host <> txtHost.Text) Or (MainForm.Port <> txtPort.Text) Or (MainForm.HostFL <> txtFLHost.Text) Or (MainForm.PortFL <> txtFLPort.Text) Then
            MsgBox("Restart program for host/port changes to occur")
            Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory & "\host.txt"
            Dim writer As New System.IO.StreamWriter(path, False)
            writer.WriteLine(txtHost.Text)
            writer.WriteLine(txtPort.Text)
            writer.WriteLine(txtFLHost.Text)
            writer.WriteLine(txtFLPort.Text)
            writer.Close()
        End If

        Me.Hide()
        Me.Dispose()
    End Sub

    Private Sub btnRAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRAll.Click
        lstfilter.Items.Clear()
    End Sub

    Private Sub btnChangePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePath.Click
        Dim saveD As New SaveFileDialog


        saveD.Filter = "Text Files|*.txt"
        saveD.ValidateNames = True
        saveD.AddExtension = True
        saveD.CheckFileExists = False
        saveD.CheckPathExists = False
        saveD.CreatePrompt = False
        saveD.OverwritePrompt = False
        saveD.ShowDialog()

        If saveD.FileName.Length < 5 Then
            Exit Sub
        End If
        If LCase(saveD.FileName.Substring(saveD.FileName.Length - 4, 4)) <> ".txt" Then
            MsgBox("Invalid File")
            Exit Sub
        End If


        MainForm.FileSavePath = saveD.FileName

        If saveD.FileName.Length > 30 Then
            lbpath.Text = saveD.FileName.Substring(0, 12) & " ... " & saveD.FileName.Substring(saveD.FileName.Length - 18, 18)
        Else
            lbpath.Text = saveD.FileName
        End If
    End Sub

    Private Sub btnClearPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPath.Click
        MainForm.FileSavePath = ""
        lbpath.Text = ""
    End Sub


    Private Sub lbChangeMessPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbChangeFiltPath.Click
        Dim saveD As New SaveFileDialog


        saveD.Filter = "Text Files|*.txt"
        saveD.ValidateNames = True
        saveD.AddExtension = True
        saveD.CheckFileExists = False
        saveD.CheckPathExists = False
        saveD.CreatePrompt = False
        saveD.OverwritePrompt = False
        saveD.ShowDialog()

        If saveD.FileName.Length < 5 Then
            Exit Sub
        End If
        If LCase(saveD.FileName.Substring(saveD.FileName.Length - 4, 4)) <> ".txt" Then
            MsgBox("Invalid File")
            Exit Sub
        End If


        MainForm.FileSavePathfilt = saveD.FileName

        If saveD.FileName.Length > 30 Then
            lbfiltpath.Text = saveD.FileName.Substring(0, 12) & " ... " & saveD.FileName.Substring(saveD.FileName.Length - 18, 18)
        Else
            lbfiltpath.Text = saveD.FileName
        End If
    End Sub

    Private Sub btnMessDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMessDe.Click
        txtmessStart.Text = "SGSBalloon:"
    End Sub

    Private Sub btnChangeCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeCSV.Click
        Dim saveD As New SaveFileDialog


        saveD.Filter = "CSV Files|*.csv"
        saveD.ValidateNames = True
        saveD.AddExtension = True
        saveD.CheckFileExists = False
        saveD.CheckPathExists = False
        saveD.CreatePrompt = False
        saveD.OverwritePrompt = False
        saveD.ShowDialog()

        If saveD.FileName.Length < 5 Then
            Exit Sub
        End If
        If LCase(saveD.FileName.Substring(saveD.FileName.Length - 4, 4)) <> ".csv" Then
            MsgBox("Invalid File")
            Exit Sub
        End If


        MainForm.FileSavePathCSV = saveD.FileName

        If saveD.FileName.Length > 30 Then
            lbCSVPath.Text = saveD.FileName.Substring(0, 12) & " ... " & saveD.FileName.Substring(saveD.FileName.Length - 18, 18)
        Else
            lbCSVPath.Text = saveD.FileName
        End If
    End Sub

    Private Sub btnClearCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearCSV.Click
        MainForm.FileSavePathCSV = ""
        lbCSVPath.Text = ""
    End Sub

    Private Sub lbClearMessPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbClearFiltPath.Click
        MainForm.FileSavePathfilt = ""
        lbfiltpath.Text = ""
    End Sub

    Private Sub NUDTimeZone_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUDTimeZone.ValueChanged

    End Sub
End Class