Public Class GPScoord
    'a class to hold a GPS coordinate, and be able to output in various ways
    'stored as signed decimal degrees, NE is the +ve quadrant

    Private lat_ As Double = 0      'varies from 90 to -90
    Private long_ As Double = 0     'varies from 180 to -180
    Private latdecDP_ As Integer    'decimal places for lat decimal representation
    Private longdecDP_ As Integer  'for long

#Region "properties"
    Public ReadOnly Property sLatitudeDecimal As Double
        Get
            Return lat_
        End Get
    End Property

    Public ReadOnly Property sLongitudeDecimal As Double
        Get
            Return long_
        End Get
    End Property

    Public ReadOnly Property uLatitudeDecimal As Double
        Get
            Return Math.Abs(lat_)
        End Get
    End Property

    Public ReadOnly Property uLongitudeDecimal As Double
        Get
            Return Math.Abs(long_)
        End Get
    End Property

    Public ReadOnly Property NS As Char
        Get
            If lat_ >= 0 Then
                Return "N"
            Else
                Return "S"
            End If
        End Get
    End Property

    Public ReadOnly Property EW As Char
        Get
            If long_ >= 0 Then
                Return "E"
            Else
                Return "W"
            End If
        End Get
    End Property

    Public ReadOnly Property sLatitudeDegrees As Integer
        Get
            Return Math.Truncate(lat_)
        End Get
    End Property
    Public ReadOnly Property uLatitudeDegrees As Integer
        Get
            Return Math.Abs(Math.Truncate(lat_))
        End Get
    End Property

    Public ReadOnly Property LatitudeMinutes As Integer
        Get
            Return Math.Truncate(Math.Abs(lat_ - Math.Truncate(lat_)) * 60)
        End Get
    End Property

    Public ReadOnly Property LatitudeSeconds As Integer
        Get
            Dim mins As Double = Math.Abs(lat_ - Math.Truncate(lat_)) * 60
            Return Math.Round((mins - Math.Truncate(mins)) * 60)
        End Get
    End Property
    Public ReadOnly Property uLongitudeDegrees As Integer
        Get
            Return Math.Abs(Math.Truncate(long_))
        End Get
    End Property
    Public ReadOnly Property sLongitudeDegrees As Integer
        Get
            Return Math.Truncate(long_)
        End Get
    End Property

    Public ReadOnly Property LongitudeMinutes As Integer
        Get
            Return Math.Truncate(Math.Abs(long_ - Math.Truncate(long_)) * 60)
        End Get
    End Property

    Public ReadOnly Property LongitudeSeconds As Integer
        Get
            Dim mins As Double = Math.Abs(long_ - Math.Truncate(long_)) * 60
            Return Math.Round((mins - Math.Truncate(mins)) * 60)
        End Get
    End Property
    Public ReadOnly Property LongitudeMinutesFP As Single
        Get
            Return Math.Abs(long_ - Math.Truncate(long_)) * 60
        End Get
    End Property
    Public ReadOnly Property LatitudeMinutesFP As Single
        Get
            Return Math.Abs(lat_ - Math.Truncate(lat_)) * 60
        End Get
    End Property

#End Region

#Region "constructors"

    Public Sub New(ByVal Latitude As Double, ByVal Longitude As Double, Optional ByVal NS As Char = "N", Optional ByVal EW As Char = "E")
        If NS = "S" Then
            Latitude = -Latitude
        End If
        If EW = "W" Then
            Longitude = -Longitude
        End If

        lat_ = Latitude
        long_ = Longitude

        ValidateValues()
    End Sub

    Public Sub New(ByVal LatitudeDegrees As Integer, ByVal LatitudeMinutes As Integer, ByVal LatitudeSecs As Integer, ByVal LongitudeDegrees As Integer, ByVal LongitudeMinutes As Integer, ByVal LongitudeSecs As Integer, Optional ByVal NS As Char = "N", Optional ByVal EW As Char = "E")

        lat_ = LatitudeDegrees + (((LatitudeMinutes * 60) + LatitudeSecs) / 3600)
        long_ = LongitudeDegrees + (((LongitudeMinutes * 60) + LongitudeSecs) / 3600)

        If NS = "S" Then
            lat_ = -lat_
        End If
        If EW = "W" Then
            long_ = -long_
        End If
        ValidateValues()
    End Sub

    Public Sub New(ByVal LatitudeDegrees As Integer, ByVal LatitudeMinutes As Single, ByVal LongitudeDegrees As Integer, ByVal LongitudeMinutes As Single, Optional ByVal NS As Char = "N", Optional ByVal EW As Char = "E")
        lat_ = LatitudeDegrees + (LatitudeMinutes / 60)
        long_ = LongitudeDegrees + (LongitudeMinutes / 60)

        If NS = "S" Then
            lat_ = -lat_
        End If
        If EW = "W" Then
            long_ = -long_
        End If
        ValidateValues()
        ValidateValues()
    End Sub

    Public Sub New(ByVal LatitudeAPRS As String, ByVal LongitudeAPRS As String)

        '    If LatitudeAPRS.Length < 8 Then Exit Sub
        '  If LongitudeAPRS.Length < 9 Then Exit Sub

        Dim latdeg As Integer = Integer.Parse(LatitudeAPRS.Substring(0, 2))
        Dim latmin As Single = Integer.Parse(LatitudeAPRS.Substring(2, 2)) + (Integer.Parse(LatitudeAPRS.Substring(5, 2)) / 100)
        Dim longdeg As Integer = Integer.Parse(LongitudeAPRS.Substring(0, 3))
        Dim longmin As Single = Integer.Parse(LongitudeAPRS.Substring(3, 2)) + (Integer.Parse(LongitudeAPRS.Substring(6, 2)) / 100)


        lat_ = latdeg + (latmin / 60)
        long_ = longdeg + (longmin / 60)

        If LatitudeAPRS(7) = "S" Then
            lat_ = -lat_
        End If
        If LongitudeAPRS(8) = "W" Then
            long_ = -long_
        End If
        ValidateValues()
        ValidateValues()
    End Sub

#End Region


    Private Sub ValidateValues()
        'checks the values of lat_ and long_ are in range, otherwise sets them to 0

        If (lat_ < -90) Or (lat_ > 90) Then
            lat_ = 0
        End If

        If (long_ < -180) Or (long_ > 180) Then
            long_ = 0
        End If

    End Sub

End Class
