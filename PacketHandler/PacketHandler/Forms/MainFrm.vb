Imports MapPoint
Public Class MainFrm

    Dim app As Application
    Private GlobalSettings_ As New GlobalSettings
    ' Private Interfaces As New Collection()      'used to hold interfaceParents
    Private Interfaces As New List(Of InterfaceParent)
    Private Frames As New Collection()      'stores for the purpose of what order frames arrived in
    Private testingXMLPath = ""


    Private Function ContainsInterface(ByVal input As String) As Boolean
        For i As Integer = 0 To Interfaces.Count - 1
            If Interfaces(i).InterfaceName = input Then Return True
        Next
        Return False
    End Function
    Private Sub AddToFile(ByVal file As String, ByVal data As String)

        ' Try
        Dim writer As New System.IO.StreamWriter(file, True)

        writer.WriteLine(data)

        writer.Close()
        ' Catch
        'End Try
    End Sub

#Region "Button events"

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        Dim dialog As New settingsFrm
        dialog.Settings = GlobalSettings_
        dialog.ShowDialog()

        If dialog.DialogResult = Windows.Forms.DialogResult.OK Then
            GlobalSettings_ = dialog.Settings
            UpdateInterfaces()
        End If
        UpdateForm()

    End Sub


    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    UpdateForm()
    'End Sub

    Private Sub btnBalloonUplink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBalloonUplink.Click
        Dim uplink As New UplinkFrm(GlobalSettings_)
        uplink.ShowDialog()
        If uplink.DialogResult = Windows.Forms.DialogResult.OK Then
            If ContainsInterface(uplink.MsgInterface) Then
                Interfaces(uplink.MsgInterface).Write(uplink.MessageSent)
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GlobalSettings_.SaveToDisk("TEST.xml")
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click



    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
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


        '  Try
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

        ' Catch
        ' MsgBox("File cannot be read")
        '  End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim pf As New PacketStructure
        pf.PacketType = PacketFormats.UKHAS
        pf.LoadXML("C:\apexi.xml")
        Dim fr As Frame = New Frame("$$APEX,0013,12:34:12,5114.4253,-00014.5264,00167,34,06,27.12,31.20,A34,545,53,58,B4,2,62,15,MOOO_LOL", pf)



    End Sub

#End Region

#Region "update functions"

    Private Sub UpdateForm()

        For i As Integer = 0 To tabData.TabPages.Count - 1
            tabData.TabPages.Remove(tabData.TabPages(0))
        Next

        Dim tabpg As Windows.Forms.TabPage

        Dim rtb As RichTextBox

        tabpg = New Windows.Forms.TabPage("All Data")
        rtb = New RichTextBox
        tabpg.Name = "All Data"
        rtb.Dock = System.Windows.Forms.DockStyle.Fill
        tabpg.Controls.Add(rtb)
        tabpg.UseVisualStyleBackColor = True
        tabData.TabPages.Add(tabpg)

        For Each i As InterfaceParent In Interfaces
            tabpg = New Windows.Forms.TabPage(i.InterfaceName)
            rtb = New RichTextBox
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
        Next
    End Sub

    Private Sub AddToRTB(ByVal text As String, ByVal colour As System.Drawing.Color, ByVal tabpagename As String)
        If tabData.TabPages.ContainsKey(tabpagename) = True Then
            Try
                Dim i As Integer = 0
                Dim obj As Object = tabData.TabPages(tabpagename).Controls(0)
                i = obj.TextLength
                obj.SelectionStart = i
                obj.SelectionColor = colour
                obj.appendtext(text)

                obj = tabData.TabPages(0).Controls(0)
                i = obj.TextLength
                obj.SelectionStart = i
                obj.SelectionColor = colour
                obj.appendtext(text)

            Catch
            End Try
        End If
    End Sub

    Private Sub UpdateInterfaces()
        'updates interfaces list and adds events

        For i As Integer = 0 To Interfaces.Count - 1
            If Not ((GlobalSettings_.ContainsInterface(Interfaces(i).InterfaceName)) Or (Interfaces(i).InterfaceName = "Manual")) Then
                Interfaces.RemoveAt(i)
            End If
        Next


        For Each i As InterfaceSettings In GlobalSettings_.Interfaces   'add new interfaces
            If Not ContainsInterface(i.InterfaceName) Then
                Interfaces.Add(New InterfaceParent(i))
                AddHandler Interfaces(Interfaces.Count - 1).LineRecievedbyte, AddressOf LineReceivedByte
                AddHandler Interfaces(Interfaces.Count - 1).LineRecievedStr, AddressOf LineReceivedStr
            End If
        Next


    End Sub

#End Region

#Region "packet recieved"

    Private Sub LineReceivedStr(ByVal output As String, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
        ' Debug.WriteLine(output)
        Dim frame As New Frame(output, InterfaceDetails.PacketStructure)
        Frames.Add(frame)
        HuD_UC1.FrameToDisplay = frame

        If frame.CheckSum = True Then
            AddToRTB(frame.RawString, Color.Black, InterfaceDetails.InterfaceName)
        Else
            AddToRTB(frame.RawString, Color.Red, InterfaceDetails.InterfaceName)
        End If


        AddToFile(InterfaceDetails.InterfaceName + ".txt", output)

        For Each i As InterfaceParent In Interfaces
            If i.InterfaceName <> InterfaceDetails.InterfaceName Then
                If i.CanWrite = True Then
                    If i.Write(frame, InterfaceDetails) = True Then
                        If frame.CheckSum = True Then
                            AddToRTB(frame.RawString, Color.Black, i.InterfaceName)
                        Else
                            AddToRTB(frame.RawString, Color.Red, i.InterfaceName)
                        End If
                    End If
                End If
            Else
                i.StoreFrame(frame)
            End If
        Next

    End Sub
    Private Sub LineReceivedByte(ByVal output() As Byte, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
        Debug.WriteLine(output.ToString)


        For Each b As Byte In output
            Debug.Write(b.ToString & ", ")
        Next

        Debug.WriteLine("")
    End Sub

#End Region


    Private Sub MainFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As New InterfaceSettings
        i.InterfaceName = "Manual"
        i.InterfaceType = InterfaceTypes.BLANK
        Interfaces.Add(New InterfaceParent(i))
        UpdateForm()

    End Sub
End Class
