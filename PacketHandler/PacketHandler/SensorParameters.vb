Public Class SensorParameters
    Private flag_ As String = ""
    Private type_ As SensorDataTypes = SensorDataTypes.BLANK
    Private toDisplay_ As String = ""

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


    Public Shared Function AdjustData(ByVal data As Double, ByVal type As SensorDataTypes) As Double
        Select Case type
            Case SensorDataTypes.Temperature

                If data < 3000 Then
                    Return data / 16
                Else
                    Return -(65536 - data) / 16
                End If
            Case SensorDataTypes.Pressure
                Return 10 * (((data / 4096) * 5) + 5 * 0.095) / (5 * 0.009)
            Case Else
                Return data
        End Select
    End Function

End Class
