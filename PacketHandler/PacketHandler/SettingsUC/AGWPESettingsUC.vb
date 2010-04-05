Public Class AGWPESettingsUC



    Private settings_ As New AGWPESettings

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

    Private Sub AGWPESettingsUC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateUC()
    End Sub

    Private Sub UpdateUC()

        txtHost.Text = settings_.Host
        txtPort.Text = settings_.Port


    End Sub

    Private Sub PopulateSettings()
        settings_.Port = txtPort.Text
        settings_.Host = txtHost.Text
    End Sub
End Class
