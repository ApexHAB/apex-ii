Public Class altitude

    Private Sub altitude_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub draw()
        Dim image As New Bitmap(Me.BackgroundImage)
        Dim objgraphics As System.Drawing.Graphics
        objgraphics = System.Drawing.Graphics.FromImage(image)

        ' objgraphics.DrawLine(Pens.Black, CType(image.Width / 2, Integer), CType(image.Height / 2, Integer), 0, 0)
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()

        path.AddLine(0, 0, 50, 0)
        path.AddLine(50, 0, 50, 50)
        path.AddLine(50, 50, 0, 50)
        path.AddLine(0, 50, 0, 0)

        objgraphics.FillPath(Brushes.Pink, path)

        Me.BackgroundImage = image
    End Sub

End Class
