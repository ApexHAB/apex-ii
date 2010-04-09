Imports System.Windows.Forms

Public Class EditSensorInfo

    Private settings_ As New SensorParameters

    Public Property Settings() As SensorParameters
        Get
            Return settings_
        End Get
        Set(ByVal value As SensorParameters)
            settings_ = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        settings_.LinearAdjustment = SettingsLinearUC1.M
        settings_.ConstAdjustment = SettingsLinearUC1.C
        settings_.Flag = txtFlag.Text
        settings_.ToDisplay = txtDisplay.Text
        settings_.Type = StrtoEnumSensorDataTypes(cmbType.SelectedItem)
        settings_.Round = nudRound.Value

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SettingsLinearUC1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsLinearUC1.Load
        UpdateFields()
    End Sub

    Private Sub EditSensorInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UpdateFields()
        SettingsLinearUC1.M = settings_.LinearAdjustment
        SettingsLinearUC1.C = settings_.ConstAdjustment

        txtDisplay.Text = settings_.ToDisplay
        txtFlag.Text = settings_.Flag
        nudRound.Value = settings_.Round

        cmbType.Items.Clear()
        For i As Integer = 0 To SensorDataTypes.Length - 1
            cmbType.Items.Add(EnumToStr(CType(i, SensorDataTypes)))
        Next

        cmbType.SelectedItem = EnumToStr(settings_.Type)
    End Sub
End Class
