Public Class InterfaceStatus

    Private Interfaces_ As List(Of InterfaceParent)      'copy byref from main form
    Private Messages_ As String

    '#Region "threading"

    '    Delegate Sub SetRTBd(ByVal text As String, ByVal BoxToChange As RichTextBox)
    '    Delegate Sub SetLBd(ByVal text As String, ByVal LabelToChange As Label)
    '    Delegate Sub SetTXTd(ByVal text As String, ByVal TextToChange As TextBox)
    '    Delegate Sub SetListd(ByVal text As String, ByVal ListToChange As ListBox)
    '    Delegate Sub Updated()
    '    Private Sub SetRTB(ByVal value As String, ByVal BoxToChange As RichTextBox)
    '        Dim a(1) As Object
    '        If BoxToChange.InvokeRequired Then
    '            Dim del As New SetRTBd(AddressOf SetRTB)
    '            a(0) = value
    '            a(1) = BoxToChange
    '            Me.Invoke(del, a)
    '        Else
    '            BoxToChange.Text = BoxToChange.Text & value
    '            ' BoxToChange.SelectionStart = BoxToChange.Find(value)
    '            'BoxToChange.SelectionColor = Color.Yellow
    '        End If
    '    End Sub

    '    Private Sub SetList(ByVal value As String, ByVal ListToChange As ListBox)
    '        Dim a(1) As Object
    '        If ListToChange.InvokeRequired Then
    '            Dim del As New SetListd(AddressOf SetList)
    '            a(0) = value
    '            a(1) = ListToChange
    '            Me.Invoke(del, a)
    '        Else
    '            ListToChange.Items.Add(value)
    '        End If
    '    End Sub

    '    Private Sub SetLB(ByVal value As String, ByVal LabelToChange As Label)
    '        Dim a(1) As Object
    '        If LabelToChange.InvokeRequired Then
    '            Dim del As New SetLBd(AddressOf SetLB)
    '            a(0) = value
    '            a(1) = LabelToChange
    '            Me.Invoke(del, a)
    '        Else
    '            LabelToChange.Text = value
    '        End If
    '    End Sub

    '    Private Sub SetTXT(ByVal value As String, ByVal TextToChange As TextBox)
    '        Dim a(1) As Object
    '        If TextToChange.InvokeRequired Then
    '            Dim del As New SetTXTd(AddressOf SetTXT)
    '            a(0) = value
    '            a(1) = TextToChange
    '            Me.Invoke(del, a)
    '        Else
    '            TextToChange.Text = value
    '        End If
    '    End Sub

    '    'Private Sub ReadSDL(Optional ByVal doGPS As Boolean = True, Optional ByVal doData As Boolean = True)
    '    '    Dim a(1) As Object
    '    '    If lbBV.InvokeRequired Then
    '    '        Dim del As New readsetdDL(AddressOf ReadSDL)
    '    '        a(0) = doGPS
    '    '        a(1) = doData
    '    '        Me.Invoke(del, a)
    '    '    Else
    '    '        ReadAndSetDL(doGPS, doData)
    '    '    End If
    '    'End Sub
    '#End Region

    Public Property Interfaces As List(Of InterfaceParent)
        Get
            Return Interfaces_
        End Get
        Set(ByVal value As List(Of InterfaceParent))
            Interfaces_ = value
        End Set
    End Property

    Public Property Messages As String
        Get
            Return Messages_
        End Get
        Set(ByVal value As String)
            Messages_ = value
            txtMessages.Text = Messages_
        End Set
    End Property

  

    Public Sub UpdateForm()
        Dim pos As Integer = 2

        If pnlStatuses.Controls.Count > 0 Then
            pos = pnlStatuses.Controls(0).Location.Y
        End If

        For Each c As InterfaceStatusUC In pnlStatuses.Controls
            If Not ContainsInterface(c.Name) Then
                pnlStatuses.Controls.Remove(c)

            End If
        Next


        Dim uc As InterfaceStatusUC
        For Each i As InterfaceParent In Interfaces_
            If Not pnlStatuses.Controls.ContainsKey(i.InterfaceName) Then
                uc = New InterfaceStatusUC
                uc.Location = New System.Drawing.Point(2, pos)
                uc.Name = i.InterfaceName
                uc.ToDisplay = i


                pnlStatuses.Controls.Add(uc)
                pos = pos + 155
            Else
                pnlStatuses.Controls(i.InterfaceName).Location = New System.Drawing.Point(2, pos)
                pos = pos + 155
            End If
        Next

        txtMessages.Text = Messages_
        'SetTXT(Messages_, txtMessages)
        For Each c As InterfaceStatusUC In pnlStatuses.Controls
            c.UpdateUC()
        Next

        Me.Update()
    End Sub




    Public Sub New(ByVal Interfaces As List(Of InterfaceParent))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Interfaces_ = Interfaces

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub InterfaceStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateForm()

    End Sub
    Private Function ContainsInterface(ByVal input As String) As Boolean
        For i As Integer = 0 To Interfaces.Count - 1
            If Interfaces(i).InterfaceName = input Then Return True
        Next
        Return False
    End Function
End Class