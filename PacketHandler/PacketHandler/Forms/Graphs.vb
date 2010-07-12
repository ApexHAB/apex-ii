Imports System.Windows.Forms.DataVisualization.Charting
Public Class Graphs

    Private Sub Graphs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      

    End Sub

    Public Sub DisplayData(ByVal data As DataHandler)


        For Each kv As KeyValuePair(Of String, List(Of KeyValuePair(Of DateTime, Double))) In data.Values
            If Not chpnl.Controls.ContainsKey(kv.Key) Then
                Dim chtuc As New GraphUC(kv.Key)
                chtuc.Name = kv.Key
                chtuc.Location = New System.Drawing.Point(3, 260 * chpnl.Controls.Count)
                chpnl.Controls.Add(chtuc)
            End If

            Dim graphuc As GraphUC = chpnl.Controls(kv.Key)
            graphuc.DisplayData(kv.Value)
           
        Next



        'Dim comp As New seriescomparer

        'For Each kv As KeyValuePair(Of String, List(Of KeyValuePair(Of DateTime, Double))) In data.Values
        '    If kv.Key = "altitude" Then
        '        If Not Chart1.Series.Contains(New Series(kv.Key), comp) Then
        '            Dim ser As New Series
        '            Dim cha As New ChartArea
        '            Dim leg As New Legend
        '            cha.Name = "CA_" & kv.Key
        '            Chart1.ChartAreas.Add(cha)
        '            leg.Name = "LEG_" & kv.Key
        '            Chart1.Legends.Add(leg)

        '            ser.ChartArea = "CA_" & kv.Key
        '            ser.ChartType = SeriesChartType.Line
        '            ser.Legend = "LEG_" & kv.Key

        '            ser.Name = kv.Key
        '            ser.XValueType = ChartValueType.Time
        '            Chart1.Series.Add(ser)
        '        End If

        '        Chart1.Series(kv.Key).Points.Clear()

        '        For Each kv1 As KeyValuePair(Of DateTime, Double) In kv.Value
        '            Chart1.Series(kv.Key).Points.AddXY(kv1.Key, kv1.Value)
        '        Next
        '    End If
        'Next




    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim series1 As New Series
        'Series1.ChartArea = "ChartArea1"
        'Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        'series1.Legend = "moo"
        'series1.Name = "moo"
        'Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        'Chart1.Series.Add(series1)
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