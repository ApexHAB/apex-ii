Imports Mappoint
Public Class MapPointInterface
    Dim app As Application = New Application()
    Dim lastpnt As New Dictionary(Of Integer, GPScoord)


    Public Sub PlotPoint(ByVal coords As GPScoord, ByVal name As String, ByVal seqence As Integer, Optional ByVal PushPinType As Single = 1, Optional ByVal Weight As Single = 0.2)
        If coords Is Nothing Then Exit Sub
        Try



            Dim location As Location
            Dim location2 As Location

            app.Visible = True

            location = app.ActiveMap.GetLocation(coords.sLatitudeDecimal, coords.sLongitudeDecimal)

            If lastpnt.ContainsKey(seqence) Then
                location2 = app.ActiveMap.GetLocation(lastpnt(seqence).sLatitudeDecimal, lastpnt(seqence).sLongitudeDecimal)

                Dim shape_ As Shape
                'Dim map_ As Map = app.ActiveMap
                shape_ = app.ActiveMap.Shapes.AddLine(location, location2)
                shape_.Line.Weight = Weight
                lastpnt(seqence) = coords

                'app.ActiveMap.Shapes.AddLine(location, location2)
            Else
                lastpnt.Add(seqence, coords)

            End If



            app.ActiveMap.AddPushpin(location, name).Symbol = PushPinType




        Catch ex As Exception
            MsgBox("U sure u have mappoint installed")
        End Try
    End Sub
End Class
