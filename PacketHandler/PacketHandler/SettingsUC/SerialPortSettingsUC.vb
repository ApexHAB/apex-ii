Public Class SerialPortSettingsUC

    Private settings_ As New SerialPortSettings

    Public Property Settings()
        Get
            PopulateSettings()
            Return settings_
        End Get
        Set(ByVal value)
            settings_ = value
            UpdateUC()
        End Set
    End Property

    Private Sub SerialPortSettingsUC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateUC()
    End Sub

    Private Sub UpdateUC()
        For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
            cmbPort.Items.Add(My.Computer.Ports.SerialPortNames(i))
        Next
        cmbPort.SelectedText = settings_.Port
        cmbParity.SelectedIndex = settings_.Parity
        cmbStopBits.SelectedIndex = settings_.StopBits
        txtBaud.Text = settings_.Baud.ToString
        txtDataBits.Text = settings_.DataBits.ToString
    End Sub

    Private Sub PopulateSettings()
        settings_.Port = cmbPort.Text
        settings_.Baud = Val(txtBaud.Text)
        settings_.DataBits = Val(txtDataBits.Text)
        settings_.Parity = cmbParity.SelectedIndex
        settings_.StopBits = cmbStopBits.SelectedIndex
    End Sub
End Class
