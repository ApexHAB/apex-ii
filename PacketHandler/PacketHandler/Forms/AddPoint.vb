Imports System.Windows.Forms


Public Class AddPoint

    Public ReadOnly Property Latitude As String
        Get
            Return txtlat.Text
        End Get
    End Property

    Public ReadOnly Property Longitude As String
        Get
            Return txtlong.Text
        End Get
    End Property

    Public ReadOnly Property NMEA As Boolean
        Get
            Return radNMEA.Checked
        End Get
    End Property

    Public ReadOnly Property Decimal_ As Boolean
        Get
            Return radDec.Checked
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
