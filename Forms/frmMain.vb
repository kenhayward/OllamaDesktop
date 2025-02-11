
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Microsoft.Web.WebView2.Core

Public Class frmMain
    Private DarkMode As DarkModeForms.DarkModeCS
    '        DarkMode = New DarkModeCS(Me, False, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}
    'https://stackoverflow.com/questions/66991516/webview2-update-innerhtml-using-htmltextwriter

    Private Async Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Await WebView21.EnsureCoreWebView2Async()
        LoadServers()
        WebView21.NavigateToString("<html><body><div id=""MainContent""><h1> </h1></div></body></html>")
        Me.Cursor = DefaultCursor
    End Sub

    Private Sub LoadServers()
        Me.cmbModel.Items.Clear()
        Me.cmbServer.Items.Clear()
        For Each Server In Utils.OllamaServers
            Me.cmbServer.Items.Add(Server)
            If Server.isCurrent Then
                cmbServer.SelectedItem = Server
                Me.GetModels()
            End If
        Next
    End Sub

    Private Sub ServerClick(sender As Object, e As EventArgs) Handles cmbServer.SelectedIndexChanged
        Dim Myserver As OllamaServer = cmbServer.SelectedItem
        Utils.OllamaServers.CurrentServer = Myserver
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
    Private HTML As String
    Private Async Sub ChatUpdate(CR As ChatResponseMessage)
        If CR.FirstPacket Then
            WebView21.CoreWebView2.NavigateToString(CR.HTML)

        Else
            If CR.FullHTML Then
                WebView21.CoreWebView2.NavigateToString(CR.HTML)
            Else
                Await UpdateElementAsync("MainContent", "innerHTML", CR.JustDiv)
            End If
        End If
        WebView21.Refresh()
        HTML = Text
    End Sub
    Private Sub ChatComplete()
        'WebView21.CoreWebView2.NavigateToString(HTML)
        btnSend.Enabled = True
        txtPrompt.Enabled = True
    End Sub

    Private Async Function UpdateElementAsync(ByVal elementID As String, ByVal [property] As String, ByVal value As String) As Task
        Try
            Await Me.WebView21.CoreWebView2.ExecuteScriptAsync("document.getElementById('" & elementID & "')." & [property] & " = '" & value & "'")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim MyForm As New frmServers
        MyForm.ShowDialog(Me)
        LoadServers()
    End Sub
End Class
