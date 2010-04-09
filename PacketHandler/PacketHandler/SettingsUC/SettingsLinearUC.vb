Public Class SettingsLinearUC

    Public Property M() As Double
        Get
            Return Val(txtM.Text)
        End Get
        Set(ByVal value As Double)
            txtM.Text = value.ToString
        End Set
    End Property
    Public Property C() As Double
        Get
            Return Val(txtC.Text)
        End Get
        Set(ByVal value As Double)
            txtC.Text = value.ToString
        End Set
    End Property

    Private Sub SettingsLinearUC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
