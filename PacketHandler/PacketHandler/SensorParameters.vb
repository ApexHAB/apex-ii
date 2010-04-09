Public Class SensorParameters
    Private flag_ As String = ""
    Private type_ As SensorDataTypes = SensorDataTypes.BLANK
    Private toDisplay_ As String = ""
    Private x0_ As Double = 0       'x^0 adjustment factor
    Private x1_ As Double = 1       'x^1 adjustment factor
    Private round_ As Integer = 1   'round to

    Public Property Round() As Integer
        Get
            Return round_
        End Get
        Set(ByVal value As Integer)
            round_ = value
        End Set
    End Property

    Public Property LinearAdjustment() As Double
        Get
            Return x1_
        End Get
        Set(ByVal value As Double)
            x1_ = value
        End Set
    End Property

    Public Property ConstAdjustment() As Double
        Get
            Return x0_
        End Get
        Set(ByVal value As Double)
            x0_ = value
        End Set
    End Property

    Public Property Flag() As String
        Get
            Return flag_
        End Get
        Set(ByVal value As String)
            flag_ = value
        End Set
    End Property
    Public Property Type() As SensorDataTypes
        Get
            Return type_
        End Get
        Set(ByVal value As SensorDataTypes)
            type_ = value
        End Set
    End Property
    Public Property ToDisplay() As String
        Get
            Return toDisplay_
        End Get
        Set(ByVal value As String)
            toDisplay_ = value
        End Set
    End Property


    Public Shared Function AdjustData(ByVal data As Double, ByVal SensorInfo As SensorParameters) As Double

        Select Case SensorInfo.Type
            Case SensorDataTypes.Temperature

                If data < 3000 Then
                    data = data / 16
                Else
                    data = -(65536 - data) / 16
                End If
            Case SensorDataTypes.Pressure
                data = 10 * (((data / 4096) * 5) + 5 * 0.095) / (5 * 0.009)
        End Select
        Return Math.Round(data * SensorInfo.LinearAdjustment + SensorInfo.ConstAdjustment, SensorInfo.Round)
    End Function

End Class
