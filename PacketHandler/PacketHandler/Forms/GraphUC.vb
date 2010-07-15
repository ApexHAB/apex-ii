Imports System.Windows.Forms.DataVisualization.Charting

Public Class GraphUC

    Private Sub GraphUC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(Optional ByVal Title As String = "", Optional ByVal YAxis As String = "")
        InitializeComponent()

        chtData.Titles("Title1").Text = Title
        chtData.ChartAreas(0).AxisY.Title = YAxis
    End Sub

    Public Sub DisplayData(ByVal data As List(Of KeyValuePair(Of DateTime, Double)))



        chtData.Series("Series1").Points.Clear()
        For Each kv As KeyValuePair(Of DateTime, Double) In data            '#something is wrong with this 
            chtData.Series("Series1").Points.AddXY(kv.Key, kv.Value)
        Next

    End Sub

    Public Sub DisplayDataMulti(ByVal data As List(Of KeyValuePair(Of DateTime, Double)), ByVal seriesname As String)

        AddSeries(seriesname)

        chtData.Series(seriesname).Points.Clear()

        For Each kv As KeyValuePair(Of DateTime, Double) In data
            chtData.Series(seriesname).Points.AddXY(kv.Key, kv.Value)
        Next

    End Sub

    Public Sub DisplayDataMultiAdd(ByVal data As List(Of KeyValuePair(Of DateTime, Double)), ByVal seriesname As String)
        AddSeries(seriesname)
        For Each kv As KeyValuePair(Of DateTime, Double) In data
            chtData.Series(seriesname).Points.AddXY(kv.Key, kv.Value)
        Next
    End Sub

    Private Sub AddSeries(ByVal seriesname As String)
        Dim comp As New seriescomparer
        If Not chtData.Series.Contains(New Series(seriesname), comp) Then
            Dim series1 As New Series
            series1.ChartArea = "ChartArea1"
            If seriesname.ToLower.Contains("red") Then series1.Color = Color.Red
            If seriesname.ToLower.Contains("green") Then series1.Color = Color.Green
            If seriesname.ToLower.Contains("blue") Then series1.Color = Color.Blue
            If seriesname.ToLower.Contains("clear") Then series1.Color = Color.Gray

            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            series1.Legend = "Legend1"
            series1.Name = seriesname
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
            series1.YValuesPerPoint = 6
            chtData.Series.Add(series1)
        End If
    End Sub

    Public Sub EnableMultiLines()
        chtData.Legends(0).Enabled = True
        If chtData.Series.Count > 0 Then
            chtData.Series.RemoveAt(0)
        End If
    End Sub

    Public Sub DisplayAdd(ByVal data As List(Of KeyValuePair(Of DateTime, Double)))


        For Each kv As KeyValuePair(Of DateTime, Double) In data
            chtData.Series("Series1").Points.AddXY(kv.Key, kv.Value)
        Next
    End Sub


End Class


Class seriescomparer
    Implements IEqualityComparer(Of Series)

    Public Function Equals1(ByVal x As System.Windows.Forms.DataVisualization.Charting.Series, ByVal y As System.Windows.Forms.DataVisualization.Charting.Series) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of System.Windows.Forms.DataVisualization.Charting.Series).Equals
        If x.Name = y.Name Then Return True
        Return False
    End Function

    Public Function GetHashCode1(ByVal obj As System.Windows.Forms.DataVisualization.Charting.Series) As Integer Implements System.Collections.Generic.IEqualityComparer(Of System.Windows.Forms.DataVisualization.Charting.Series).GetHashCode
        Return obj.ToString.GetHashCode
    End Function
End Class
