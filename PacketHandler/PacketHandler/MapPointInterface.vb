Imports Mappoint
Public Class MapPointInterface


    Public Sub PlotPoint(ByVal coords As GPScoord, ByVal name As String)
        Try

            Dim app As Application = New Application()

            'Dim location As Location

            'app.Visible = True

            'location = app.ActiveMap.GetLocation(coords.sLatitudeDecimal, coords.sLongitudeDecimal)

            'app.ActiveMap.AddPushpin(location, name)



        Catch ex As Exception

        End Try
    End Sub
End Class
