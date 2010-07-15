Imports System.Windows.Forms.DataVisualization.Charting
Public Class Graphs

    Private Sub Graphs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      

    End Sub

    Public Sub New(Optional ByVal data As DataHandler = Nothing)
        InitializeComponent()

        If Not data Is Nothing Then DisplayData(data)
    End Sub

    Private Sub DisplayDataAddSeries(ByVal contains As String, ByVal yValue As String)
        If Not chpnl.Controls.ContainsKey(contains) Then
            Dim chtuc As New GraphUC("", yValue)
            chtuc.Name = contains
            chtuc.Location = New System.Drawing.Point(3, 214 * chpnl.Controls.Count)
            chtuc.EnableMultiLines()

            chpnl.Controls.Add(chtuc)
        End If
    End Sub

    Private Sub DisplayDataAddData(ByVal seriesname As String, ByVal KV As KeyValuePair(Of String, List(Of KeyValuePair(Of DateTime, Double))), ByVal data As DataHandler)

        Dim graphuc As GraphUC = chpnl.Controls(seriesname)

        If data.ValuesChanged Is Nothing Then

            graphuc.DisplayDataMulti(KV.Value, KV.Key)
        Else
            If data.ValuesChanged.ContainsKey(KV.Key) Then graphuc.DisplayDataMultiAdd(data.ValuesChanged(KV.Key), KV.Key)
        End If

    End Sub

    Public Sub DisplayData(ByVal data As DataHandler)

        Try

            For Each kv As KeyValuePair(Of String, List(Of KeyValuePair(Of DateTime, Double))) In data.Values
                If kv.Key.ToLower.Contains("temp") Then
                    DisplayDataAddSeries("temp", "Temperature /C")
                    DisplayDataAddData("temp", kv, data)

                ElseIf kv.Key.ToLower.Contains("ird") Then
                    DisplayDataAddSeries("ird", "IRD Counts")
                    DisplayDataAddData("ird", kv, data)

                ElseIf kv.Key.ToLower.Contains("light") Then
                    DisplayDataAddSeries("light", "Light Level")
                    DisplayDataAddData("light", kv, data)

                Else

                    If Not chpnl.Controls.ContainsKey(kv.Key) Then
                        Dim chtuc As New GraphUC("", kv.Key)
                        chtuc.Name = kv.Key
                        chtuc.Location = New System.Drawing.Point(3, 214 * chpnl.Controls.Count)
                        chpnl.Controls.Add(chtuc)
                    End If

                    Dim graphuc As GraphUC = chpnl.Controls(kv.Key)

                    If data.ValuesChanged Is Nothing Then
                        graphuc.DisplayData(kv.Value)
                    Else
                        If data.ValuesChanged.ContainsKey(kv.Key) Then graphuc.DisplayAdd(data.ValuesChanged(kv.Key))
                    End If


                End If

            Next
        data.ValuesChanged = Nothing


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
        Catch ex As Exception

        End Try



    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim series1 As New Series
        'Series1.ChartArea = "ChartArea1"
        'Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        'series1.Legend = "moo"
        'series1.Name = "moo"
        'Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        'Chart1.Series.Add(series1)
    End Sub

    Private Sub Graphs_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        chpnl.Size = New System.Drawing.Size(chpnl.Width, Me.Height - 38) ' = Me.Height - 60
    End Sub
End Class
