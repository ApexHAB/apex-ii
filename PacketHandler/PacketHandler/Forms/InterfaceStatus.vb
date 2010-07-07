Public Class InterfaceStatus

    Private Interfaces_ As List(Of InterfaceParent)      'copy byref from main form
    Private Messages_ As String


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