Public Class settingsFrm

    Private settings_ As New GlobalSettings

    Public Property Settings()
        Get
            Return settings_
        End Get
        Set(ByVal value)
            settings_ = New GlobalSettings
            settings_ = value
        End Set
    End Property

    Private Sub btninterfaceAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninterfaceAdd.Click
        Dim dia As New EditInterfaceSettings()

        dia.ShowDialog()
        If dia.DialogResult = Windows.Forms.DialogResult.OK Then
            settings_.Interfaces.Add(dia.Settings)
        End If
        UpdateFields()
    End Sub

    Private Sub settingsFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateFields()
    End Sub

    Private Sub UpdateFields()

        chkUTC.Checked = settings_.UseUTC
        nudTimeZone.Value = settings_.TimeZone

        lstInterfaces.Items.Clear()

        For Each i As InterfaceSettings In settings_.Interfaces
            lstInterfaces.Items.Add(i.InterfaceName)
        Next

        txtLogFolder.Text = settings_.logFolder

       

    End Sub

    Private Sub btnInterfaceEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInterfaceEdit.Click
        Dim i As Integer = lstInterfaces.SelectedIndex
        If (lstInterfaces.SelectedIndex < lstInterfaces.Items.Count) And (lstInterfaces.SelectedIndex >= 0) Then
            Dim dia As New EditInterfaceSettings()
            dia.Settings = settings_.Interfaces(i)
            dia.ShowDialog()
            If dia.DialogResult = Windows.Forms.DialogResult.OK Then
                settings_.Interfaces(i) = dia.Settings
            End If
            UpdateFields()
        End If
    End Sub

    Private Sub btnInterfaceDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInterfaceDel.Click
        Dim i As Integer = lstInterfaces.SelectedIndex
        If (lstInterfaces.SelectedIndex < lstInterfaces.Items.Count) And (lstInterfaces.SelectedIndex >= 0) Then
            settings_.Interfaces.RemoveAt(i)
            UpdateFields()
        End If
    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        settings_.UseUTC = chkUTC.Checked
        settings_.TimeZone = nudTimeZone.Value
        settings_.logFolder = txtLogFolder.Text

       

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   
    Private Sub btnLogFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogFolder.Click
        Dim fv As New FolderBrowserDialog()
        fv.ShowDialog()

        txtLogFolder.Text = fv.SelectedPath
    End Sub

 
End Class