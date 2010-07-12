﻿Imports MapPoint
Public Class MainFrm

    Public RunningDir As String = System.IO.Directory.GetCurrentDirectory()

    Private datahandler As New DataHandler()

    Dim app As Application
    Private GlobalSettings_ As New GlobalSettings
    ' Private Interfaces As New Collection()      'used to hold interfaceParents
    Private Interfaces As New List(Of InterfaceParent)
    Private Frames As New Collection()      'stores for the purpose of what order frames arrived in
    Private testingXMLPath = ""
    Dim interStatus As InterfaceStatus
    Dim graphs As Graphs

    Private ErrorMessages As String = ""

#Region "threading"
    'Delegate Sub popgraphdel(ByVal frame As Frame)
    Delegate Sub UpdateStatusDel()
    Delegate Sub AddtoRTBDel(ByVal text As String, ByVal colour As System.Drawing.Color, ByVal tabpagename As String)
    'Delegate Sub RecievedDel(ByVal output As String, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
    'Delegate Sub AddFrameDel(ByVal Frame As Frame)
    Private Sub UpdateStatus()
        If Not interStatus Is Nothing Then
            If interStatus.InvokeRequired Then
                Dim del As New UpdateStatusDel(AddressOf UpdateStatus)
                Me.Invoke(del)
            Else
                If Not interStatus Is Nothing Then
                    interStatus.UpdateForm()
                End If
            End If
        End If
    End Sub

    'Private Sub popgraphth(ByVal frame As Frame)

    '    If Chart2.InvokeRequired Then
    '        Dim del As New popgraphdel(AddressOf popgraphth)
    '        Me.Invoke(del, frame)
    '    Else
    '        popgraph(frame)
    '    End If
    'End Sub


    Private Sub AddToRTBTh(ByVal text As String, ByVal colour As System.Drawing.Color, ByVal tabpagename As String)
        Dim a(2) As Object ' = {text, colour, tabpagename}
        a(0) = text
        a(1) = colour
        a(2) = tabpagename
        If tabData.InvokeRequired Then
            Dim del As New AddtoRTBDel(AddressOf AddToRTBTh)
            Me.Invoke(del, a)
        Else
            AddToRTB(text, colour, tabpagename)
        End If
    End Sub

#End Region

    'Private Sub HUDSetFrame(ByVal fframe As Frame)
    '    If HuD_UC1.InvokeRequired Then
    '        Dim del As New AddFrameDel(AddressOf HUDSetFrame)
    '        Me.Invoke(del, fframe)
    '    Else
    '        HuD_UC1.FrameToDisplay = fframe
    '    End If
    'End Sub

    'Private Sub DoRecieved(ByVal output As String, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
    '    Dim a(3) As Object
    '    If btnLoad.InvokeRequired Then
    '        Dim del As New RecievedDel(AddressOf DoRecieved)
    '        a(0) = output
    '        a(1) = InterfaceDetails
    '        a(2) = ToCall
    '        a(3) = FromCall
    '        Me.Invoke(del, a)
    '    Else
    '        DoRecievedStuff(output, InterfaceDetails, ToCall, FromCall)
    '    End If
    'End Sub


    Private Function ContainsInterface(ByVal input As String) As Boolean
        For i As Integer = 0 To Interfaces.Count - 1
            If Interfaces(i).InterfaceName = input Then Return True
        Next
        Return False
    End Function
    Private Sub AddToFile(ByVal file As String, ByVal data As String)

        Try
            Dim writer As New System.IO.StreamWriter(file, True)

            writer.WriteLine(data)

            writer.Close()
        Catch ex As Exception
            ErrorMessages = ErrorMessages & "File Write Error - " & ex.Message & vbCrLf
            If Not interStatus Is Nothing Then interStatus.Messages = ErrorMessages
        End Try
    End Sub

    '#Region "Button events"

    '    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
    '        Dim dialog As New settingsFrm
    '        dialog.Settings = GlobalSettings_
    '        dialog.ShowDialog()

    '        If dialog.DialogResult = Windows.Forms.DialogResult.OK Then
    '            GlobalSettings_ = dialog.Settings
    '            UpdateInterfaces()
    '        End If
    '        UpdateForm()

    '        GlobalSettings_.SaveToDisk(RunningDir & "\settings.xml")

    '    End Sub


    '    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    '    UpdateForm()
    '    'End Sub

    '    Private Sub btnBalloonUplink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBalloonUplink.Click
    '        Dim uplink As New UplinkFrm(GlobalSettings_)
    '        uplink.ShowDialog()
    '        If uplink.DialogResult = Windows.Forms.DialogResult.OK Then
    '            For Each i As InterfaceParent In Interfaces
    '                If i.InterfaceName = uplink.MsgInterface Then
    '                    i.Write(uplink.MessageSent)
    '                    AddToRTB(Date.UtcNow.ToShortTimeString, Color.Purple, uplink.MsgInterface)
    '                    AddToRTB("  " & uplink.MessageSent & vbCrLf, Color.Black, uplink.MsgInterface)

    '                End If
    '            Next
    '        End If

    '    End Sub

    '    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '        'Dim pf As New PacketStructure
    '        'pf.PacketType = PacketFormats.APRS
    '        'HuD_UC1.FrameToDisplay = New Frame("@124840h5121.89N/00011.43W085/000/A=000000AVDATA-IT768OT679PP168A1453 SGSBALLOON", pf)
    '        Dim pf As New PacketStructure
    '        pf.PacketType = PacketFormats.UKHAS

    '        If testingXMLPath = "" Then
    '            Dim selector As New OpenFileDialog()

    '            With selector
    '                .Multiselect = False
    '                .Title = "Select XML string format file"
    '                .Filter = "XML Files (*.xml)|*.xml"
    '                .CheckFileExists = True
    '                .CheckPathExists = True
    '                .ShowDialog()
    '            End With

    '            Dim xmlpath As String = selector.FileName
    '            testingXMLPath = xmlpath
    '        End If

    '        If System.IO.File.Exists(testingXMLPath) = False Then
    '            testingXMLPath = ""
    '            Exit Sub
    '        End If

    '        pf.LoadXML(testingXMLPath)

    '        'Dim frame As New Frame(InputBox("enter", , "$$APEX,0013,12:34:12,5114.4253,-00014.5264,00167,34,06,27.12,31.20,A34,545,53,58,B4,2,62,15,MOOO_LOL"), pf)
    '        'HuD_UC1.FrameToDisplay = frame
    '        'GoodFrames.Add(frame)
    '        'Dim isd As New InterfaceSettings()
    '        'isd.PacketStructure = pf
    '        'isd.InterfaceName = "Manual"
    '        Interfaces(0).GetInterfaceSettings.PacketStructure = pf
    '        LineReceivedStr(InputBox("enter", , "$$APEX,0013,12:34:12,5114.4253,-00014.5264,00167,34,06,27.12,31.20,A34,545,53,58,B4,2,62,15,MOOO_LOL"), Interfaces(0).GetInterfaceSettings, "", "")


    '    End Sub



    '    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '        ' GlobalSettings_.SaveToDisk("TEST.xml")
    '        ErrorMessages = ErrorMessages & "TEST MESSAGE" & vbCrLf
    '        If Not interStatus Is Nothing Then interStatus.Messages = ErrorMessages

    '    End Sub



    '    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    '        Dim selector As New OpenFileDialog()
    '        With selector
    '            .Multiselect = False
    '            .Title = "Select File to Load"
    '            .Filter = "Text Files (*.txt)|*.txt"
    '            .CheckFileExists = True
    '            .CheckPathExists = True
    '            .ShowDialog()
    '        End With

    '        Dim datapath As String = selector.FileName
    '        selector = New OpenFileDialog()

    '        With selector
    '            .Multiselect = False
    '            .Title = "Select XML string format file"
    '            .Filter = "XML Files (*.xml)|*.xml"
    '            .CheckFileExists = True
    '            .CheckPathExists = True
    '            .ShowDialog()
    '        End With

    '        Dim xmlpath As String = selector.FileName
    '        If System.IO.File.Exists(xmlpath) = False Then Exit Sub

    '        Dim interface_ As InterfaceParent
    '        Dim mappoint As Boolean = False
    '        'find mappoint interface
    '        For Each i As InterfaceParent In Interfaces
    '            If i.GetInterfaceSettings.InterfaceType = InterfaceTypes.MAPPOINT Then
    '                interface_ = i
    '                mappoint = True
    '                Exit For
    '            End If
    '        Next


    '        Dim str As String = ""

    '        Dim pf As New PacketStructure
    '        pf.PacketType = PacketFormats.UKHAS
    '        pf.LoadXML(xmlpath)


    '        Try
    '            If System.IO.File.Exists(datapath) = False Then Exit Sub

    '            Dim reader As New System.IO.StreamReader(datapath)

    '            While Not reader.EndOfStream


    '                str = reader.ReadLine()
    '                If str <> "" Then
    '                    ' Dim frame As New Frame(str, pf)

    '                    Interfaces(0).GetInterfaceSettings.PacketStructure = pf
    '                    LineReceivedStr(str, Interfaces(0).GetInterfaceSettings, "", "")


    '                    ' If mappoint = True Then interface_.WriteMappoint(frame.GPSCoordinates, 5, 2, 0.5)
    '                End If
    '            End While

    '        Catch ex As Exception
    '            MsgBox("File cannot be read")
    '            ErrorMessages = ErrorMessages & "File Read Error - " & ex.Message & vbCrLf

    '            If Not interStatus Is Nothing Then interStatus.Messages = ErrorMessages
    '        End Try

    '    End Sub

    '    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '        Dim pf As New PacketStructure
    '        pf.PacketType = PacketFormats.UKHAS
    '        pf.LoadXML("C:\apexi.xml")
    '        Dim fr As Frame = New Frame("$$APEX,0013,12:34:12,5114.4253,-00014.5264,00167,34,06,27.12,31.20,A34,545,53,58,B4,2,62,15,MOOO_LOL", pf)



    '    End Sub

    '    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '        If interStatus Is Nothing Then
    '            interStatus = New InterfaceStatus(Interfaces)
    '            interStatus.Show()
    '        Else
    '            If interStatus.Visible = False Then

    '                interStatus = New InterfaceStatus(Interfaces)
    '                interStatus.Show()
    '            End If
    '        End If



    '    End Sub

    '#End Region

#Region "update functions"

    Private Sub UpdateForm()


        For Each t As TabPage In tabData.TabPages
            If Not (ContainsInterface(t.Name) Or (t.Name = "All Data")) Then tabData.TabPages.Remove(t)
        Next



        Dim tabpg As Windows.Forms.TabPage

        Dim rtb As RichTextBox

        If tabData.TabPages.Count = 0 Then

            tabpg = New Windows.Forms.TabPage("All Data")
            rtb = New RichTextBox
            rtb.WordWrap = False
            tabpg.Name = "All Data"
            rtb.Dock = System.Windows.Forms.DockStyle.Fill
            tabpg.Controls.Add(rtb)
            tabpg.UseVisualStyleBackColor = True
            tabData.TabPages.Add(tabpg)
        End If

        For Each i As InterfaceParent In Interfaces
            If Not tabData.TabPages.ContainsKey(i.InterfaceName) Then
                tabpg = New Windows.Forms.TabPage(i.InterfaceName)
                rtb = New RichTextBox
                rtb.Name = "rtb" & i.InterfaceName
                rtb.WordWrap = False
                tabpg.Name = i.InterfaceName

                rtb.Dock = System.Windows.Forms.DockStyle.Fill
                ' rtb.Size = New Drawing.Point(60, 60)
                tabpg.Controls.Add(rtb)
                'tabpg.Container.Add(New Windows.Forms.RichTextBox())
                'tabpg.Padding = New System.Windows.Forms.Padding(3)
                'tabpg.Size = New System.Drawing.Size(429, 206)
                tabpg.UseVisualStyleBackColor = True

                tabData.TabPages.Add(tabpg)
                '   tabData.TabPages.Add("ewd"
            End If
        Next

    

    End Sub

    Private Sub AddToRTB(ByVal text As String, ByVal colour As System.Drawing.Color, ByVal tabpagename As String)

        Try
            Dim obj As Object
            Dim i As Integer = 0
            If tabpagename <> "" Then
                If tabData.TabPages.ContainsKey(tabpagename) = True Then
                    obj = tabData.TabPages(tabpagename).Controls(0)
                    i = obj.TextLength
                    obj.SelectionStart = i
                    obj.SelectionColor = colour
                    obj.appendtext(text)
                End If
            Else

                obj = tabData.TabPages(0).Controls(0)
                i = obj.TextLength
                obj.SelectionStart = i
                obj.SelectionColor = colour
                obj.appendtext(text)
            End If
        Catch ex As Exception
            ErrorMessages = ErrorMessages & "Internal Error - " & ex.Message & vbCrLf
            If Not interStatus Is Nothing Then interStatus.Messages = ErrorMessages
        End Try

    End Sub

    Private Sub UpdateInterfaces()
        'updates interfaces list and adds events
        Dim removeflag As Boolean = False

        Do
            For i As Integer = 0 To Interfaces.Count - 1
                If Not ((GlobalSettings_.ContainsInterface(Interfaces(i).InterfaceName)) Or (Interfaces(i).InterfaceName = "Manual")) Then
                    Interfaces.RemoveAt(i)
                    removeflag = True
                    Exit For
                End If
                removeflag = False
            Next

        Loop While removeflag

   

        For Each i As InterfaceSettings In GlobalSettings_.Interfaces   'add new interfaces
            If Not ContainsInterface(i.InterfaceName) Then
                Interfaces.Add(New InterfaceParent(i))
                ' AddHandler Interfaces(Interfaces.Count - 1).LineRecievedbyte, AddressOf LineReceivedByte
                AddHandler Interfaces(Interfaces.Count - 1).LineRecievedStr, AddressOf LineReceivedStr
                AddHandler Interfaces(Interfaces.Count - 1).InterfaceStatusChange, AddressOf iStatusChange
            End If
        Next

        UpdateStatus()


    End Sub

#End Region



#Region "packet recieved"

    'Private Sub popgraph(ByVal frame As Frame)
    '    If datahandler.AddFrame(frame) Then
    '        Chart2.Series("Altitude").Points.Clear()
    '        For Each kv As KeyValuePair(Of DateTime, Double) In datahandler.Altitudes
    '            Chart2.Series("Altitude").Points.AddXY(kv.Key, kv.Value)
    '        Next
    '    End If
    'End Sub


    Private Sub LineReceivedStr(ByVal output As String, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
        ' Debug.WriteLine(output)

        'DoRecieved(output, InterfaceDetails, ToCall, FromCall)
        '  Try



        Dim frame As New Frame(output, InterfaceDetails.PacketStructure)
        Frames.Add(frame)

        ' If datahandler Is Nothing Then datahandler = New DataHandler(InterfaceDetails.PacketStructure)
        datahandler.AddFrame(frame)

        If Not graphs Is Nothing Then graphs.DisplayData(datahandler)


        Dim lineendp As String = ""
        Dim lineendr As String = ""

        If Not (frame.ProcessedString.EndsWith(vbCrLf) Or frame.ProcessedString.EndsWith(vbLf) Or frame.ProcessedString.EndsWith(vbCr)) Then
            lineendp = vbCrLf
        End If
        If Not (frame.RawString.EndsWith(vbCrLf) Or frame.RawString.EndsWith(vbLf) Or frame.RawString.EndsWith(vbCr)) Then
            lineendr = vbCrLf
        End If






        For Each j As InterfaceParent In Interfaces
            If j.InterfaceName = InterfaceDetails.InterfaceName Then
                If j.StoreFrame(frame) Then

                    AddToFile(RunningDir & "\" & InterfaceDetails.InterfaceName + ".txt", output)

                    HuD_UC1.AddFrame(frame)

                    If frame.CheckSum = True Then
                        AddToRTBTh(frame.ProcessedString & lineendp, Color.Black, InterfaceDetails.InterfaceName)
                        AddToRTBTh(frame.RawString & lineendr, Color.Black, "")
                    Else
                        AddToRTBTh(frame.ProcessedString & lineendp, Color.Red, InterfaceDetails.InterfaceName)
                        AddToRTBTh(frame.RawString & lineendr, Color.Red, "")
                    End If

                    For Each i As InterfaceParent In Interfaces
                        If i.InterfaceName <> InterfaceDetails.InterfaceName Then
                            If i.CanWrite = True Then
                                If i.Write(frame, InterfaceDetails) = True Then
                                    If frame.CheckSum = True Then
                                        AddToRTBTh(frame.ProcessedString & lineendp, Color.Black, i.InterfaceName)
                                        AddToRTBTh(frame.RawString & lineendr, Color.Black, "")
                                    Else
                                        AddToRTBTh(frame.ProcessedString & lineendp, Color.Red, i.InterfaceName)
                                        AddToRTBTh(frame.RawString & lineendr, Color.Red, "")
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next
        ' Catch ex As Exception
        '     ErrorMessages = ErrorMessages & ex.Message & vbCrLf
        '     If Not interStatus Is Nothing Then interStatus.Messages = ErrorMessages
        ' End Try


    End Sub
    'Private Sub LineReceivedByte(ByVal output() As Byte, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
    '    Debug.WriteLine(output.ToString)


    '    For Each b As Byte In output
    '        Debug.Write(b.ToString & ", ")
    '    Next

    '    Debug.WriteLine("")
    'End Sub

#End Region



    Private Sub MainFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As New InterfaceSettings
        i.InterfaceName = "Manual"
        i.InterfaceType = InterfaceTypes.BLANK
        Interfaces.Add(New InterfaceParent(i))

        Try

            If System.IO.File.Exists(RunningDir & "\settings.xml") Then
                Dim ser As New System.Xml.Serialization.XmlSerializer(GetType(GlobalSettings))
                Dim reader As New System.IO.StreamReader(RunningDir + "\settings.xml")

                GlobalSettings_ = ser.Deserialize(reader)

                reader.Close()
            End If

        Catch ex As Exception

            ErrorMessages = ErrorMessages & "File Load Error" & vbCrLf

        End Try

        UpdateInterfaces()
        UpdateForm()


        For Each i_ As InterfaceSettings In GlobalSettings_.Interfaces
            i_.PacketStructure.LoadXML(i.XMLStructurePath)
        Next
    End Sub




    Private Sub iStatusChange(ByVal NewStatus As InterfaceParent.InterfaceStatus, ByVal Message As String, ByVal InterfaceDetails As InterfaceSettings)
        '   Debug.WriteLine("I STATUS CHANGE")
        UpdateStatus()

    End Sub


#Region "toolbar"
    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim dialog As New settingsFrm
        dialog.Settings = GlobalSettings_
        dialog.ShowDialog()

        If dialog.DialogResult = Windows.Forms.DialogResult.OK Then
            GlobalSettings_ = dialog.Settings
            UpdateInterfaces()
        End If
        UpdateForm()

        GlobalSettings_.SaveToDisk(RunningDir & "\settings.xml")
    End Sub

    Private Sub UplinkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UplinkToolStripMenuItem.Click
        Dim uplink As New UplinkFrm(GlobalSettings_)
        uplink.ShowDialog()
        If uplink.DialogResult = Windows.Forms.DialogResult.OK Then
            For Each i As InterfaceParent In Interfaces
                If i.InterfaceName = uplink.MsgInterface Then
                    i.Write(uplink.MessageSent)
                    AddToRTB(Date.UtcNow.ToShortTimeString, Color.Purple, uplink.MsgInterface)
                    AddToRTB("  " & uplink.MessageSent & vbCrLf, Color.Black, uplink.MsgInterface)

                End If
            Next
        End If
    End Sub


    Private Sub LoadFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadFileToolStripMenuItem.Click
        Dim selector As New OpenFileDialog()
        With selector
            .Multiselect = False
            .Title = "Select File to Load"
            .Filter = "Text Files (*.txt)|*.txt"
            .CheckFileExists = True
            .CheckPathExists = True
            .ShowDialog()
        End With

        Dim datapath As String = selector.FileName
        selector = New OpenFileDialog()

        With selector
            .Multiselect = False
            .Title = "Select XML string format file"
            .Filter = "XML Files (*.xml)|*.xml"
            .CheckFileExists = True
            .CheckPathExists = True
            .ShowDialog()
        End With

        Dim xmlpath As String = selector.FileName
        If System.IO.File.Exists(xmlpath) = False Then Exit Sub

        Dim interface_ As InterfaceParent
        Dim mappoint As Boolean = False
        'find mappoint interface
        For Each i As InterfaceParent In Interfaces
            If i.GetInterfaceSettings.InterfaceType = InterfaceTypes.MAPPOINT Then
                interface_ = i
                mappoint = True
                Exit For
            End If
        Next


        Dim str As String = ""

        Dim pf As New PacketStructure
        pf.PacketType = PacketFormats.UKHAS
        pf.LoadXML(xmlpath)


        Try
            If System.IO.File.Exists(datapath) = False Then Exit Sub

            Dim reader As New System.IO.StreamReader(datapath)

            While Not reader.EndOfStream


                str = reader.ReadLine()
                If str <> "" Then
                    ' Dim frame As New Frame(str, pf)

                    Interfaces(0).GetInterfaceSettings.PacketStructure = pf
                    LineReceivedStr(str, Interfaces(0).GetInterfaceSettings, "", "")


                    ' If mappoint = True Then interface_.WriteMappoint(frame.GPSCoordinates, 5, 2, 0.5)
                End If
            End While

        Catch ex As Exception
            MsgBox("File cannot be read")
            ErrorMessages = ErrorMessages & "File Read Error - " & ex.Message & vbCrLf

            If Not interStatus Is Nothing Then interStatus.Messages = ErrorMessages
        End Try

    End Sub


    Private Sub AddPacketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPacketToolStripMenuItem.Click
        'Dim pf As New PacketStructure
        'pf.PacketType = PacketFormats.APRS
        'HuD_UC1.FrameToDisplay = New Frame("@124840h5121.89N/00011.43W085/000/A=000000AVDATA-IT768OT679PP168A1453 SGSBALLOON", pf)
        Dim pf As New PacketStructure
        pf.PacketType = PacketFormats.UKHAS

        If testingXMLPath = "" Then
            Dim selector As New OpenFileDialog()

            With selector
                .Multiselect = False
                .Title = "Select XML string format file"
                .Filter = "XML Files (*.xml)|*.xml"
                .CheckFileExists = True
                .CheckPathExists = True
                .ShowDialog()
            End With

            Dim xmlpath As String = selector.FileName
            testingXMLPath = xmlpath
        End If

        If System.IO.File.Exists(testingXMLPath) = False Then
            testingXMLPath = ""
            Exit Sub
        End If

        pf.LoadXML(testingXMLPath)

        'Dim frame As New Frame(InputBox("enter", , "$$APEX,0013,12:34:12,5114.4253,-00014.5264,00167,34,06,27.12,31.20,A34,545,53,58,B4,2,62,15,MOOO_LOL"), pf)
        'HuD_UC1.FrameToDisplay = frame
        'GoodFrames.Add(frame)
        'Dim isd As New InterfaceSettings()
        'isd.PacketStructure = pf
        'isd.InterfaceName = "Manual"
        Interfaces(0).GetInterfaceSettings.PacketStructure = pf
        LineReceivedStr(InputBox("enter", , "$$APEX,0013,12:34:12,5114.4253,-00014.5264,00167,34,06,27.12,31.20,A34,545,53,58,B4,2,62,15,MOOO_LOL"), Interfaces(0).GetInterfaceSettings, "", "")

    End Sub




    Private Sub StatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusToolStripMenuItem.Click
        If interStatus Is Nothing Then
            interStatus = New InterfaceStatus(Interfaces)


            interStatus.Show()
        Else
            If interStatus.Visible = False Then

                interStatus = New InterfaceStatus(Interfaces)

                interStatus.Show()
            End If
        End If
    End Sub
#End Region

    Private Sub ToolStripComboBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.Click
        Select Case ToolStripComboBox2.Text
            Case "'All'"
                HuD_UC1.DisplayAllPackets = True
            Case "'Only Valid'"
                HuD_UC1.DisplayAllPackets = False
                HuD_UC1.DisplayIfGPS = False
            Case "'Valid' and 'Failed with GPS'"
                HuD_UC1.DisplayAllPackets = False
                HuD_UC1.DisplayIfGPS = True
        End Select
    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        graphs = New Graphs
        graphs.Show()
    End Sub
End Class
