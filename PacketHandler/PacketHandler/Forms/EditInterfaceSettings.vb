Imports System.Windows.Forms

Public Class EditInterfaceSettings
    Private settings_ As New InterfaceSettings      'object to hold settings about the interface and pass them back to the calling form
    

#Region "Properties"
    'to allow private variables to be accessed publically
    Public Property Settings() As InterfaceSettings
        Get
            Return settings_
        End Get
        Set(ByVal value As InterfaceSettings)
            settings_ = value
        End Set
    End Property

#End Region

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        'update settings with whats been entered in boxes
        settings_.XMLStructurePath = txtXMLpacket.Text
        settings_.PacketStructure.PacketType = StrToEnumPacketFormat(cmbDataFormat.SelectedItem)
        settings_.InterfaceDirection = StrToEnumInterfaceDirection(cmbDirection.SelectedItem)
        settings_.InterfaceType = StrToEnumInterfaceTypes(cmbInterfaceTypes.SelectedItem)
        settings_.InterfaceName = txtName.Text
        settings_.Enabled = chkEnabled.Checked
        settings_.Filters.Clear()
        If chkFilter.Checked = True Then
            For Each s As String In lstFilter.Items
                settings_.Filters.Add(s)
            Next
        End If


        'If genericUC.GetType.Name <> "Panel" Then   'if interface specific settings window isnt blank
        '    settings_.InterfaceTypeSpecificSettings = genericUC.Settings    'put the settings from the speific user control into the general settings
        'End If

        settings_.sPort = cmbsPort.Text
        settings_.sBaud = Val(txtsBaud.Text)
        settings_.sDatabits = Val(txtDataBits.Text)
        settings_.sParity = cmbsParity.SelectedIndex
        settings_.sStopbits = cmbsStop.SelectedIndex

        settings_.TCPHost = txtTCPHost.Text
        settings_.TCPPort = txtTCPPort.Text

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub EditInterfaceSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'create a blank user control to use as the defualt for the specific part of the form
        Dim tempPanel = New System.Windows.Forms.Panel
        tempPanel.Size = New Drawing.Size(1, 1)
        ' genericUC = tempPanel
        If settings_.InterfaceName <> "" Then txtName.Enabled = False
        UpdateFields()


    End Sub

    Private Sub cmbDirection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDirection.SelectedIndexChanged
        UpdatePacketFormats()
    End Sub

    Private Sub UpdateFields()
        'updates the interface using any settings in the settings_ variable
        cmbInterfaceTypes.Items.Clear()
        cmbDirection.Items.Clear()
        cmbDataFormat.Items.Clear()
        txtName.Text = settings_.InterfaceName

        txtTimer.Text = settings_.Timer.ToString

        txtXMLpacket.Text = settings_.XMLStructurePath


        For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
            cmbsPort.Items.Add(My.Computer.Ports.SerialPortNames(i))
        Next
        cmbsPort.SelectedText = settings_.sPort
        cmbsParity.SelectedIndex = settings_.sParity
        cmbsStop.SelectedIndex = settings_.sStopbits
        txtsBaud.Text = settings_.sBaud.ToString
        txtDataBits.Text = settings_.sDatabits.ToString

        txtTCPHost.Text = settings_.TCPHost
        txtTCPPort.Text = Settings.TCPPort


        For i As Integer = 0 To InterfaceTypes.Length - 1
            cmbInterfaceTypes.Items.Add(EnumToStr(CType(i, InterfaceTypes)))
        Next

        For i As Integer = 0 To InterfaceDirections.Length - 1
            cmbDirection.Items.Add(EnumToStr(CType(i, InterfaceDirections)))
        Next

        cmbInterfaceTypes.SelectedItem = EnumToStr(settings_.InterfaceType)
        cmbDirection.SelectedItem = EnumToStr(settings_.InterfaceDirection)
        UpdatePacketFormats()
        cmbDataFormat.SelectedItem = EnumToStr(settings_.PacketStructure.PacketType)

        If settings_.Filters.Count > 0 Then
            chkFilter.Checked = True
            pnlFilter.Enabled = True
            For Each s As String In settings_.Filters
                lstFilter.Items.Add(s)
            Next
        Else
            chkFilter.Checked = False
            pnlFilter.Enabled = False
        End If



    End Sub

    Private Sub UpdatePacketFormats()
        'updates which packet formats are valid for hte chosen interface/direction
        cmbDataFormat.Items.Clear()
        If (cmbDirection.Items.Count > 0) And (cmbDirection.SelectedIndex <> -1) Then
            For Each i As PacketFormats In InterfaceSettings.AllowableFormats(StrToEnumInterfaceDirection(cmbDirection.SelectedItem.ToString()))
                cmbDataFormat.Items.Add(EnumToStr(i))
            Next
        End If
    End Sub

    Private Sub cmbInterfaceTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInterfaceTypes.SelectedIndexChanged
        ' update the interface specific part of the form
        Select Case StrToEnumInterfaceTypes(cmbInterfaceTypes.SelectedItem)
            Case InterfaceTypes.SERIALMODEM
                gpSerial.Enabled = True
                gpTCP.Enabled = False
                gpXML.Enabled = False
                'AddToPanel(New SerialPortSettings, New SerialPortSettingsUC)
            Case InterfaceTypes.FLDIGI
                'AddToPanel(New FLDigiSettings, New FLDigiSettingsUC)
                gpSerial.Enabled = False
                gpTCP.Enabled = True
                gpXML.Enabled = True
            Case InterfaceTypes.AGWPE
                gpSerial.Enabled = False
                gpTCP.Enabled = True
                gpXML.Enabled = True
                'AddToPanel(New AGWPESettings, New AGWPESettingsUC)
            Case InterfaceTypes.MAPPOINT
                gpSerial.Enabled = False
                gpTCP.Enabled = False
                gpXML.Enabled = False
                'AddToPanel(New MappointSettings, New MappointSettingsUC)
            Case InterfaceTypes.GOOGLEEARTH
                gpSerial.Enabled = False
                gpTCP.Enabled = True
                gpXML.Enabled = False
                'AddToPanel(New GoogleEarthSettings, New GoogleEarthsettingsUC)
            Case InterfaceTypes.DLINTERNET
                gpSerial.Enabled = False
                gpTCP.Enabled = True
                gpXML.Enabled = True
            Case Else
                gpSerial.Enabled = False
                gpTCP.Enabled = False
                gpXML.Enabled = False
                'Panel1.Controls.Remove(genericUC)
                'Dim tempPanel = New System.Windows.Forms.Panel
                'tempPanel.Size = New Drawing.Size(1, 1)
                'genericUC = tempPanel
                'Panel1.Controls.Add(genericUC)
        End Select





    End Sub
    'Private Sub AddToPanel(ByVal Settings As Object, ByVal Control As Windows.Forms.Control)
    '    'adds a user control to the panel
    '    Panel1.Controls.Remove(genericUC)
    '    genericUC = Control
    '    If UCase(settings_.InterfaceTypeSpecificSettings.GetType.Name) = UCase(Settings.GetType.Name) Then
    '        genericUC.settings = settings_.InterfaceTypeSpecificSettings
    '    End If
    '    Panel1.Controls.Add(genericUC)
    'End Sub

    Private Sub chkFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFilter.CheckedChanged
        pnlFilter.Enabled = chkFilter.Checked
    End Sub

    Private Sub btnAddFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFilter.Click
        lstFilter.Items.Add(UCase(txtFilterAdd.Text))
        txtFilterAdd.Text = ""
    End Sub

    Private Sub btnRemoveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFilter.Click
        If lstFilter.SelectedIndex >= 0 And lstFilter.SelectedIndex < lstFilter.Items.Count Then
            lstFilter.Items.RemoveAt(lstFilter.SelectedIndex)

        End If
    End Sub

    Private Sub btnFindXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindXML.Click

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



        If System.IO.File.Exists(xmlpath) = False Then Exit Sub

        txtXMLpacket.Text = xmlpath

    End Sub
End Class
