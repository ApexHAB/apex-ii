Public Class GraphUC

    Private Sub GraphUC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(Optional ByVal Title As String = "", Optional ByVal YAxis As String = "")
        InitializeComponent()

        chtData.Titles("Title1").Text = Title
    End Sub

    Public Sub DisplayData(ByVal data As List(Of KeyValuePair(Of DateTime, Double)))

        chtData.Series("Series1").Points.Clear()
        For Each kv As KeyValuePair(Of DateTime, Double) In data
            chtData.Series("Series1").Points.AddXY(kv.Key, kv.Value)
        Next

    End Sub

End Class
