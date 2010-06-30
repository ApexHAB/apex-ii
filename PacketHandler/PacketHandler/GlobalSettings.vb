Public Class GlobalSettings
    Private interfaces_ As New List(Of InterfaceSettings)

    Private timezone_ As Integer = 0
    Private UseUTC_ As Boolean = False
    ' Public test As New Dictionary(Of String, String)

#Region "Properties"

   

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

        'Dim settings As New System.Xml.XmlWriterSettings()
        'settings.Indent = True
        'settings.NewLineOnAttributes = True


        'Using writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(Path, settings)

        '    writer.WriteStartDocument()
        '    writer.WriteStartElement("GlobalSettings")

        '        writer.WriteStartElement("TimeSettings")
        '             writer.WriteStartElement("TimeZone")
        '                 writer.WriteValue(timezone_.ToString())
        '             writer.WriteEndElement()
        '            writer.WriteStartElement("UseUTC")
        '                writer.WriteValue(UseUTC_.ToString())
        '            writer.WriteEndElement()
        '        writer.WriteEndElement()

        '        writer.WriteStartElement("Interfaces")
        '        Dim i As Integer = 0
        '        For Each inter As InterfaceSettings In interfaces_
        '            writer.WriteStartElement("Interface" & i)


        '                For Each kv As KeyValuePair(Of String, String) In inter.AllValuesAsString
        '                    writer.WriteStartElement(kv.Key)
        '                        writer.WriteValue(kv.Value)

        '                    writer.WriteEndElement()
        '                Next
        '            writer.WriteEndElement()
        '            i = i + 1
        '        Next

        '        writer.WriteEndElement()

        '        writer.WriteStartElement("Sensors")
        '            writer.WriteStartElement("Sensor" & "0")
        '                writer.WriteValue("SENSOR STUFF ERE")
        '            writer.WriteEndElement()
        '        writer.WriteEndElement()

        '    writer.WriteEndElement()
        '    writer.WriteEndDocument()
        '    writer.Flush()


        'End Using







        Dim ser As New System.Xml.Serialization.XmlSerializer(GetType(GlobalSettings))
        Dim writestream As New System.IO.StreamWriter("sampledb.xml")
        ser.Serialize(writestream, Me)


        'Using writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(Path, settings)
        '    writer.WriteStartDocument()
        '    writer.WriteStartElement("countries")
        '    writer.WriteStartElement("UnitedStates")
        '    writer.WriteStartAttribute("capital")
        '    writer.WriteValue("london")
        '    writer.WriteEndAttribute()
        '    writer.WriteStartAttribute("Cities")
        '    writer.WriteValue("soton")
        '    writer.WriteEndAttribute()
        '    writer.WriteStartAttribute("rank")
        '    writer.WriteValue("1st")
        '    writer.WriteEndAttribute()
        '    writer.WriteEndElement()
        '    writer.WriteEndDocument()
        '    writer.Flush()
        'End Using









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
