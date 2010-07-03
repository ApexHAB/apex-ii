Imports System.Windows.Forms

Public Class UplinkFrm

    Private settings_ As GlobalSettings
    Private msgsent_ As String = ""
    Private msgInterface_ As String = ""

    Public ReadOnly Property MessageSent() As String
        Get
            Return msgsent_
        End Get
    End Property

    Public ReadOnly Property MsgInterface() As String
        Get
            Return msgInterface_
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        msgsent_ = txtmsg.Text
        msgInterface_ = cmbInterfaces.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal Settings As GlobalSettings)
        InitializeComponent()
        settings_ = Settings
    End Sub

    Private Sub Uplink_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each i As InterfaceSettings In settings_.Interfaces
            If InterfaceSettings.CanUpload(i) Then ' And i.Enabled Then
                cmbInterfaces.Items.Add(i.InterfaceName)
            End If
        Next
    End Sub
End Class
