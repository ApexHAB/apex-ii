Public Class GlobalSettings
    Private interfaces_ As New List(Of InterfaceSettings)
    Private sensorDataParameters_ As New List(Of SensorParameters)
    Private timezone_ As Integer = 0
    Private UseUTC_ As Boolean = False

#Region "Properties"

    Public Property SensorDataParameters() As List(Of SensorParameters)
        Get
            Return sensorDataParameters_
        End Get
        Set(ByVal value As List(Of SensorParameters))
            sensorDataParameters_ = value
        End Set
    End Property

    Public Property Interfaces() As List(Of InterfaceSettings)
        Get
            Return interfaces_
        End Get
        Set(ByVal value As List(Of InterfaceSettings))
            interfaces_ = value
        End Set
    End Property

    Public Property TimeZone() As Integer
        Get
            Return timezone_
        End Get
        Set(ByVal value As Integer)
            timezone_ = value
        End Set
    End Property

    Public Property UseUTC() As Boolean
        Get
            Return UseUTC_
        End Get
        Set(ByVal value As Boolean)
            UseUTC_ = value
        End Set
    End Property

#End Region

    Public Function SaveToDisk(ByVal Path As String) As Boolean

        Dim settings As New System.Xml.XmlWriterSettings()
        settings.Indent = True
        settings.NewLineOnAttributes = True

        Using writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(Path, settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("countries")
            writer.WriteStartElement("UnitedStates")
            writer.WriteStartAttribute("capital")
            writer.WriteValue("london")
            writer.WriteEndAttribute()
            writer.WriteStartAttribute("Cities")
            writer.WriteValue("soton")
            writer.WriteEndAttribute()
            writer.WriteStartAttribute("rank")
            writer.WriteValue("1st")
            writer.WriteEndAttribute()
            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Flush()
        End Using









        'Dim writer As New System.Xml.XmlWriter(Path, Nothing)

        'writer.WriteStartDocument()


        'writer.WriteStartElement("GLOBALSETTINGS")
        'writer.WriteStartElement("TIMEZONE"

        '// Write first element

        'textWriter.WriteStartElement("Student");

        'textWriter.WriteStartElement("r", "RECORD", "urn:record");

        '// Write next element

        'textWriter.WriteStartElement("Name", "");

        'textWriter.WriteString("Student");

        'textWriter.WriteEndElement();

        '// Write one more element

        'textWriter.WriteStartElement("Address", ""); textWriter.WriteString("Colony");

        'textWriter.WriteEndElement();

        '// WriteChars

        'char[] ch = new char[3];

        'ch[0] = 'a';

        'ch[1] = 'r';

        'ch[2] = 'c';

        'textWriter.WriteStartElement("Char");

        'textWriter.WriteChars(ch, 0, ch.Length);

        'textWriter.WriteEndElement();

        '// Ends the document.

        'textWriter.WriteEndDocument();

        '// close writer

        'textWriter.Close();


    End Function

    Public Function ContainsInterface(ByVal input As String) As Boolean
        For Each i As InterfaceSettings In interfaces_
            If i.InterfaceName = input Then Return True
        Next
        Return False
    End Function

End Class
