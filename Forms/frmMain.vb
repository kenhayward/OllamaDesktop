
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Microsoft.Web.WebView2.Core

Public Class frmMain
    Private DarkMode As DarkModeForms.DarkModeCS
    '        DarkMode = New DarkModeCS(Me, False, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}


    Private Async Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Await WebView21.EnsureCoreWebView2Async()
        LoadServers()
        WebView21.NavigateToString("<html><body><h1> </h1></body></html>")
        Me.Cursor = DefaultCursor
    End Sub


    Private Sub btnServers_Click(sender As Object, e As EventArgs) Handles btnServers.Click
        Dim MyForm As New frmServers
        MyForm.ShowDialog(Me)
        LoadServers()
    End Sub


    Private Sub LoadServers()
        Me.cmbModel.Items.Clear()
        Me.mnuServers.DropDownItems.Clear()
        For Each Server In Utils.OllamaServers
            Dim MyItem As New ToolStripMenuItem
            MyItem.Text = Server.Name
            MyItem.Tag = Server
            If Server.isCurrent Then
                Me.mnuServers.Text = "Server: " & Server.Name
                Me.GetModels()
            End If
            AddHandler MyItem.Click, AddressOf ServerClick
            Me.mnuServers.DropDownItems.Add(MyItem)
        Next
    End Sub

    Private Sub ServerClick(sender As Object, e As EventArgs)
        Dim MyItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim MyServer As OllamaServer = CType(MyItem.Tag, OllamaServer)
        Utils.OllamaServers.CurrentServer = MyServer
        Me.mnuServers.Text = "Server: " & MyServer.Name
        Me.GetModels()
    End Sub

    Private Sub GetModels()
        Dim MyServer As OllamaServer = Utils.OllamaServers.CurrentServer
        If MyServer IsNot Nothing Then
            Me.cmbModel.Items.Clear()
            If MyServer.Models.Count = 0 Then
                Dim MyS = New Ollama(MyServer)
                MyS.GetModels()
            End If
            For Each model In MyServer.Models
                Me.cmbModel.Items.Add(model)
                If MyServer.DefaultModel.Equals(model) Then
                    Me.cmbModel.SelectedItem = model
                End If
            Next
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        ' Send the Query
        If txtPrompt.Text.Trim <> "" Then
            Me.Cursor = Cursors.WaitCursor
            Dim StartTime = DateTime.Now
            Me.btnSend.Enabled = False
            Me.txtPrompt.Enabled = False
            Dim OllamaServer As New Ollama(Utils.OllamaServers.CurrentServer, cmbModel.SelectedItem)
            AddHandler OllamaServer.ChatUpdate, AddressOf ChatUpdate
            AddHandler OllamaServer.ChatComplete, AddressOf ChatComplete
            OllamaServer.SendChat(txtPrompt.Text)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ChatUpdate(Text As String)
        WebView21.CoreWebView2.NavigateToString(Text)
    End Sub
    Private Sub ChatComplete()
        btnSend.Enabled = True
        txtPrompt.Enabled = True
    End Sub

End Class
