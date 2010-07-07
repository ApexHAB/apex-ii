Public Class InterfaceStatusUC
    Private ToDisplay_ As InterfaceParent

    Public Property ToDisplay As InterfaceParent
        Get
            Return ToDisplay_
        End Get
        Set(ByVal value As InterfaceParent)
            ToDisplay_ = value
            UpdateUC()
        End Set
    End Property

    Public Sub UpdateUC()
        lbName.Text = ToDisplay_.InterfaceName
        lbstatus.Text = "Status: " & ToDisplay_.Status.ToString
        txtMessages.Text = ToDisplay.Messages
        If ToDisplay_.CanConnect = False Then btnConnect.Enabled = False

        If btnConnect.Enabled = True Then
            If ToDisplay_.Status <> InterfaceParent.InterfaceStatus.Active Then
                btnConnect.Text = "Connect"
            Else
                btnConnect.Text = "Disconnect"
            End If
        End If
    End Sub


    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If btnConnect.Text = "Disconnect" Then
            ToDisplay_.Disconnect()
        Else
            ToDisplay_.ReConnect()
        End If
    End Sub

End Class
