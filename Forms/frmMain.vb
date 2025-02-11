﻿
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Microsoft.Web.WebView2.Core

Public Class frmMain
    Private DarkMode As DarkModeForms.DarkModeCS
    Private HistoryNode As TreeNode
    Private PromptLibraryNode As TreeNode

    'https://stackoverflow.com/questions/66991516/webview2-update-innerhtml-using-htmltextwriter

    Private Async Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        PromptLibraryNode = New TreeNode("Prompt Library")
        LoadHistory()


        Me.TreeHistory.Nodes.Add(PromptLibraryNode)

        Await WebView21.EnsureCoreWebView2Async()
        ToolTip1.SetToolTip(btnExpand, "Show Settings, Chat History and Prompt Library")
        ToolTip2.SetToolTip(btnCollapse, "Hide Side Panel")
        ToolTip3.SetToolTip(btnSettings, "Establish connection to servers and set defaults")

        LoadServers()
        WebView21.NavigateToString("<html><body><div id=""MainContent""><h1> </h1></div></body></html>")
        Me.Cursor = DefaultCursor
    End Sub
    Private Sub ClearHistory()
        Utils.OllamaServers.ChatHistory.Clear()
        OllamaServers.Save(Utils.OllamaServers)
        LoadHistory()
    End Sub

    Private Sub LoadHistory()
        If HistoryNode IsNot Nothing Then
            HistoryNode.Nodes.Clear()
            TreeHistory.Nodes.Remove(HistoryNode)
        End If
        HistoryNode = New TreeNode("Chat History")
        Me.TreeHistory.Nodes.Insert(0, HistoryNode)
        For Each Hist In Utils.OllamaServers.ChatHistory
            AddToHistoryNode(Hist)
        Next
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DarkMode = New DarkModeCS(Me, False, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}
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
            OllamaServer.ShowCOT = chkShowCOT.Checked
            AddHandler OllamaServer.ChatUpdate, AddressOf ChatUpdate
            AddHandler OllamaServer.ChatComplete, AddressOf ChatComplete
            OllamaServer.SendChat(txtPrompt.Text)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private ChatResponse As ChatResponseMessage
    Private Locker As Boolean = False
    Private Async Sub ChatUpdate(CR As ChatResponseMessage)
        If Locker Then Exit Sub
        Locker = True
        If CR.FirstPacket Then
                WebView21.CoreWebView2.NavigateToString(CR.HTML)
            Else
                If CR.FullHTML Then
                    WebView21.CoreWebView2.NavigateToString(CR.HTML)
                Else
                    Await UpdateElementAsync("MainContent", "innerHTML", CR.JustDiv)
                End If
            End If
        'Await WebView21.CoreWebView2.ExecuteScriptAsync("window.scrollTo(0,  document.body.scrollHeight)")
        ChatResponse = CR
        Locker = False
    End Sub
    Private Sub ChatComplete()
        Me.Cursor = Cursors.WaitCursor
        btnSend.Enabled = True
        txtPrompt.Enabled = True
        btnCopy.Visible = True
        WebView21.CoreWebView2.NavigateToString(ChatResponse.HTML)
        ' Add to history here
        Dim Hist As New ChatHistoryItem
        Hist.Markdown = ChatResponse.Markdown
        Hist.Prompt = txtPrompt.Text
        Hist.HTML = ChatResponse.HTML
        Hist.Server = cmbServer.SelectedItem.ToString
        Hist.Model = cmbModel.SelectedItem.ToString
        Hist.Timed = Now
        Utils.OllamaServers.ChatHistory.Add(Hist)
        HistoryToAdd = Hist
        Dim OllamaServer As New Ollama(Utils.OllamaServers.CurrentServer, cmbModel.SelectedItem)
        OllamaServer.ShowCOT = False
        AddHandler OllamaServer.ChatComplete, AddressOf HistoryComplete
        AddHandler OllamaServer.ChatUpdate, AddressOf UpdateHistory

        OllamaServer.SendChat($"Create a single 2 to 5 word title for this prompt without using any quotes: {txtPrompt.Text}")

    End Sub
    Private TitleResponse As ChatResponseMessage
    Private HistoryToAdd As ChatHistoryItem
    Private Sub HistoryComplete()
        HistoryToAdd.Title = TitleResponse.Markdown
        HistoryToAdd.Title = HistoryToAdd.Title.Trim.Replace(vbLf, "")
        HistoryToAdd.Title = HistoryToAdd.Title.Replace(vbCr, "")
        HistoryToAdd.Title = HistoryToAdd.Title.Replace("""", "")

        AddToHistoryNode(HistoryToAdd)
        OllamaServers.Save(Utils.OllamaServers)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub UpdateHistory(ChatResponse As ChatResponseMessage)
        TitleResponse = ChatResponse
    End Sub

    Public Sub AddToHistoryNode(Hist As ChatHistoryItem)
        Dim MyNode As New TreeNode
        MyNode.Text = Hist.Title
        MyNode.Tag = Hist
        HistoryNode.Nodes.Add(MyNode)
        btnClearHistory.Enabled = True
        mnuClear.Enabled = True
    End Sub


    Private Async Function UpdateElementAsync(ByVal elementID As String, ByVal [property] As String, ByVal value As String) As Task
        Try
            value = value.Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\'")
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

    Private Sub btnCollapse_Click(sender As Object, e As EventArgs) Handles btnCollapse.Click
        If Not SplitContainer1.Panel1Collapsed Then
            SplitContainer1.Panel1Collapsed = True
            btnExpand.Visible = True
        End If
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
        If SplitContainer1.Panel1Collapsed Then
            SplitContainer1.Panel1Collapsed = False
            btnExpand.Visible = False
        End If
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Clipboard.SetText(ChatResponse.Markdown)
        ' Copy the markdown to the clipboard
        MsgBox("The response has been copied to the clipboard", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Copy Chat Response")

    End Sub

    Private Sub btnClearHistory_Click(sender As Object, e As EventArgs) Handles btnClearHistory.Click, mnuClear.Click
        ClearHistory()
        btnClearHistory.Enabled = False
        mnuClear.Enabled = False
    End Sub

    Private Sub TreeHistory_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeHistory.AfterSelect
        Dim EnableDelete As Boolean = False
        If TreeHistory.SelectedNode IsNot Nothing Then
            Dim MyNode As TreeNode = TreeHistory.SelectedNode
            If MyNode.Tag IsNot Nothing Then
                If TypeOf MyNode.Tag Is ChatHistoryItem Then
                    Dim Hist As ChatHistoryItem = MyNode.Tag
                    WebView21.CoreWebView2.NavigateToString(Hist.HTML)
                    Me.txtPrompt.Text = Hist.Prompt
                    EnableDelete = True
                End If
            End If
        End If
        btnDelete.Enabled = EnableDelete
        mnuDelete.Enabled = EnableDelete
        mnuRename.Enabled = EnableDelete
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, mnuDelete.Click
        If TreeHistory.SelectedNode IsNot Nothing Then
            Dim MyNode As TreeNode = TreeHistory.SelectedNode
            If MyNode.Tag IsNot Nothing Then
                If TypeOf MyNode.Tag Is ChatHistoryItem Then
                    ' Delete it 
                    MyNode.Parent.Nodes.Remove(MyNode)
                    Utils.OllamaServers.ChatHistory.Remove(MyNode.Tag)
                    OllamaServers.Save(Utils.OllamaServers)
                End If
            End If
        End If

    End Sub

    Private Sub mnuRename_Click(sender As Object, e As EventArgs) Handles mnuRename.Click
        If TreeHistory.SelectedNode IsNot Nothing Then
            Dim MyNode As TreeNode = TreeHistory.SelectedNode
            If MyNode.Tag IsNot Nothing Then
                If TypeOf MyNode.Tag Is ChatHistoryItem Then
                    ' Delete it 
                    Dim MyChat As ChatHistoryItem = MyNode.Tag
                    Dim NewValue = InputBox("Enter a new title for this prompt", "Rename Prompt", MyChat.Title)
                    MyChat.Title = NewValue
                    TreeHistory.SelectedNode.Text = NewValue
                    OllamaServers.Save(Utils.OllamaServers)
                End If
            End If
        End If

    End Sub
End Class
