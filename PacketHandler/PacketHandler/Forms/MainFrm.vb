Public Class MainFrm


    Private GlobalSettings_ As New GlobalSettings
    ' Private Interfaces As New Collection()      'used to hold interfaceParents
    Private Interfaces As New List(Of InterfaceParent)

    Private Function ContainsInterface(ByVal input As String) As Boolean
        For i As Integer = 0 To Interfaces.Count - 1
            If Interfaces(i).InterfaceName = input Then Return True
        Next
        Return False
    End Function

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

    Private Sub UpdateForm()

        'HuD_UC1.SensorDataParameters = GlobalSettings_.SensorDataParameters
        HuD_UC1.SetSensorDataParameter(GlobalSettings_.SensorDataParameters)
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

        For Each i As InterfaceSettings In GlobalSettings_.Interfaces
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

    Private Sub UpdateInterfaces()
        'updates interfaces list and adds events

        For i As Integer = 0 To Interfaces.Count - 1
            If Not GlobalSettings_.ContainsInterface(Interfaces(i).InterfaceName) Then
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

    Private Sub LineReceivedStr(ByVal output As String, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
        Debug.WriteLine(output)
    End Sub
    Private Sub LineReceivedByte(ByVal output() As Byte, ByVal InterfaceDetails As InterfaceSettings, ByVal ToCall As String, ByVal FromCall As String)
        Debug.WriteLine(output.ToString)


        For Each b As Byte In output
            Debug.Write(b.ToString & ", ")
        Next

        Debug.WriteLine("")
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
        HuD_UC1.FrameToDisplay = New Frame("@124840h5121.89N/00011.43W085/000/A=000000AVDATA-IT768OT679PP168A1453 SGSBALLOON", PacketFormats.APRS, GPSFormats.DDDMMmm)
    End Sub

 

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GlobalSettings_.SaveToDisk("TEST.xml")
    End Sub
End Class
