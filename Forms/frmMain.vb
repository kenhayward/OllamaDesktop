
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Microsoft.Web.WebView2.Core

Public Class frmMain
    Private DarkMode As DarkModeForms.DarkModeCS
    Private HistoryNode As TreeNode
    'Private PromptLibraryNode As TreeNode

    Private Async Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SplitContainer1.Panel1Collapsed = True
        Do While Utils.OllamaServers.Count = 0
            frmServers.ShowDialog(Me)
            If Utils.OllamaServers.Count = 0 Then
                If MsgBox("You must specify at least one Ollama Server for the application to run, try again? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Ollama Chat") = MsgBoxResult.No Then
                    End
                End If
            End If
        Loop
        'PromptLibraryNode = New TreeNode("Prompt Library")
        'PromptLibraryNode.Tag = "Prompt Library"

        'Me.TreeHistory.Nodes.Add(PromptLibraryNode)
        LoadHistory()

        Dim CacheDirectory = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\OllamaChat\Cache"
        Dim env = Await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder:=CacheDirectory)
        Await WebView21.EnsureCoreWebView2Async(env)
        ToolTip1.SetToolTip(btnExpand, "Show Settings, Chat History and Prompt Library")
        ToolTip2.SetToolTip(btnCollapse, "Hide Side Panel")
        ToolTip3.SetToolTip(btnSettings, "Establish connection to servers and set defaults")

        LoadServers()

        WebView21.NavigateToString("<html><body><div id=""MainContent""><h1> </h1></div></body></html>")
        Me.Cursor = DefaultCursor
        Me.txtPrompt.Focus()
    End Sub
    Private Sub ClearHistory()
        Utils.OllamaServers.ChatHistory.Clear()
        OllamaServers.Save(Utils.OllamaServers)
        LoadHistory()
    End Sub
    Private Function isGroupNode(Node As TreeNode) As Boolean
        If Node.Tag IsNot Nothing Then
            If TypeOf Node.Tag Is String Then
                If Node.Tag = "Group" Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
    Private Sub LoadHistory()
        If HistoryNode IsNot Nothing Then
            HistoryNode.Nodes.Clear()
            TreeHistory.Nodes.Remove(HistoryNode)
        End If
        HistoryNode = New TreeNode("Chat History")
        HistoryNode.Tag = "Chat History"
        Me.TreeHistory.Nodes.Insert(0, HistoryNode)

        For Each Hist In Utils.OllamaServers.ChatHistory
            If Hist.Group = "" Then
                AddToHistoryNode(Hist)
            Else
                ' Need to find the full path of the object, split inot an array and recurse over it
                Dim PathArray() As String = Hist.Group.Split("\")
                Dim RootNode = HistoryNode
                If PathArray.Count > 2 Then
                    Debug.Print("here")
                End If
                For x As Integer = 1 To PathArray.Count - 1
                    Dim NodeText As String = PathArray(x)
                    Dim FoundNode As Boolean = False
                    For Each node In RootNode.Nodes
                        If isGroupNode(node) Then
                            If node.Text = NodeText Then
                                FoundNode = True
                                RootNode = node
                                If x = PathArray.Count - 1 Then
                                    AddToHistoryNode(Hist, RootNode)
                                Else
                                    RootNode = node
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                    ' Next Iteration
                    If Not FoundNode Then
                        RootNode = AddGroupNode(NodeText, RootNode)
                        ' If at the leaf node we didnt find it so need to add here
                        If x = PathArray.Count - 1 Then
                            AddToHistoryNode(Hist, RootNode)
                        End If
                    End If
                Next

            End If
        Next
        HistoryNode.ExpandAll()

    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DarkMode = New DarkModeCS(Me, True, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}

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
        If txtPrompt.Text.Trim <> "" And cmbModel.SelectedItem IsNot Nothing And cmbServer.SelectedItem IsNot Nothing Then
            Me.Cursor = Cursors.WaitCursor
            pnlDetails.Visible = False
            Dim StartTime = DateTime.Now
            Me.btnSend.Enabled = False
            Me.txtPrompt.Enabled = False
            Dim OllamaServer As New Ollama(Utils.OllamaServers.CurrentServer, cmbModel.SelectedItem)
            OllamaServer.ShowCOT = chkShowCOT.Checked
            AddHandler OllamaServer.ChatUpdate, AddressOf ChatUpdate
            AddHandler OllamaServer.ChatComplete, AddressOf ChatComplete
            OllamaServer.SendChat(txtPrompt.Text)
            Me.Cursor = Cursors.Default
        Else
            MsgBox("Please ensure you have selected a server and a model and provided a chat prompt", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Ollama Chat")
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
        Hist.GetTitle(cmbModel.SelectedItem)
        AddToHistoryNode(Hist)
        ShowDetailsPanel(Hist)
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub AddToHistoryNode(Hist As ChatHistoryItem, Optional ParentNode As TreeNode = Nothing)
        Dim MyNode As New TreeNode
        MyNode.Text = Hist.Title
        MyNode.Tag = Hist
        If ParentNode Is Nothing Then
            HistoryNode.Nodes.Add(MyNode)
        Else
            ParentNode.Nodes.Add(MyNode)
        End If
        btnClearHistory.Enabled = True
        mnuClear.Enabled = True
    End Sub
    Public Function AddGroupNode(Name As String, Parent As TreeNode)
        Dim MyNode As New TreeNode
        MyNode.Text = Name
        MyNode.Tag = "Group"
        Parent.Nodes.Add(MyNode)
        Return MyNode
    End Function

    Private Async Function UpdateElementAsync(ByVal elementID As String, ByVal [property] As String, ByVal value As String) As Task
        Try
            value = value.Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\'").Replace(":", "\:").Replace("+", "\+")
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
        If MsgBox("Clear chat history? This cannot be undone", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Ollama Chat") = MsgBoxResult.Yes Then
            ClearHistory()
            btnClearHistory.Enabled = False
            mnuClear.Enabled = False
        End If
    End Sub
    Private Sub ShowDetailsPanel(Hist As ChatHistoryItem)
        Me.lblHistModel.Text = $"Server: {Hist.Server}, Model: {Hist.Model}"
        Me.lblHistDated.Text = Hist.Timed.ToString("ddd d MMM yyyy HH:mm")
        Me.lblHistTitle.Text = Hist.Title
        Me.pnlDetails.Visible = True
    End Sub

#Region "Tree Handling"
    Private Sub TreeHistory_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeHistory.AfterSelect
        Dim EnableDelete As Boolean = False
        If TreeHistory.SelectedNode IsNot Nothing Then
            Dim MyNode As TreeNode = TreeHistory.SelectedNode
            If MyNode.Tag IsNot Nothing Then
                If TypeOf MyNode.Tag Is ChatHistoryItem Then
                    Dim Hist As ChatHistoryItem = MyNode.Tag
                    ShowDetailsPanel(Hist)
                    WebView21.CoreWebView2.NavigateToString(Hist.HTML)
                    Me.txtPrompt.Text = Hist.Prompt
                    EnableDelete = True
                ElseIf TypeOf MyNode.Tag Is String Then
                    If MyNode.Tag = "Group" Then
                        If MyNode.Nodes.Count = 0 Then
                            EnableDelete = True
                        End If
                    End If
                End If
            End If
        End If
        btnDelete.Enabled = EnableDelete
        mnuDelete.Enabled = EnableDelete
        mnuRename.Enabled = EnableDelete
    End Sub


    Private lastDragDestination As TreeNode = Nothing
    Private lastDragDestinationTime As DateTime

    Private Function IsLegalMove(SourceNode As TreeNode, TargetNode As TreeNode)

        ' Legal Moves are
        ' - ChatHistory onto Group 
        ' - Group onto Group

        Dim isLegal As Boolean = False
        If SourceNode.Tag IsNot Nothing Then
            If TypeOf SourceNode.Tag Is ChatHistoryItem Then
                If TargetNode IsNot Nothing Then
                    If TargetNode.Tag IsNot Nothing Then
                        If TypeOf TargetNode.Tag Is String Then
                            If TargetNode.Tag = "Group" Then
                                isLegal = True
                            End If
                            If TargetNode.Tag = "Chat History" Then
                                isLegal = True
                            End If
                        End If
                    End If
                End If
            ElseIf TypeOf SourceNode.Tag Is String Then
                If SourceNode.Tag = "Group" Then
                    If TargetNode IsNot Nothing Then
                        If TargetNode.Tag IsNot Nothing Then
                            If TypeOf TargetNode.Tag Is String Then
                                If TargetNode.Tag = "Group" Then
                                    isLegal = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return isLegal
    End Function

    Private Sub TreeHistory_NodeMovedByDrag(sender As Object, e As NodeMovedByDragEventArgs) Handles TreeHistory.NodeMovedByDrag
        If e.MovedNode.Tag IsNot Nothing Then
            If TypeOf e.MovedNode.Tag Is ChatHistoryItem Then
                Dim Hist As ChatHistoryItem = e.MovedNode.Tag
                If e.MovedNode.Parent.Tag = "Chat History" Then
                    Hist.Group = ""
                ElseIf e.MovedNode.Parent.Tag = "Group" Then
                    Hist.Group = e.MovedNode.Parent.FullPath
                End If
            End If
            SaveOllamas()
        End If
    End Sub

    Private Sub TreeHistory_NodeDraggingOver(sender As Object, e As NodeDraggingOverEventArgs) Handles TreeHistory.NodeDraggingOver
        e.DropIsLegal = IsLegalMove(e.MovingNode, e.TargetNode)
    End Sub
    Private Sub TreeHistory_NodeMovingByDrag(sender As Object, e As NodeMovingByDragEventArgs) Handles TreeHistory.NodeMovingByDrag
        e.CancelMove = Not IsLegalMove(e.MovingNode, e.ParentToBe)
    End Sub
    Private Sub SaveOllamas()
        ' Update the Paths of the Chat History Items
        UpdateNodePaths(HistoryNode)
        OllamaServers.Save(Utils.OllamaServers)
    End Sub
    Private Sub UpdateNodePaths(MyNode As TreeNode)
        If MyNode.Tag IsNot Nothing Then
            If TypeOf MyNode.Tag Is ChatHistoryItem Then
                Dim Hist As ChatHistoryItem = MyNode.Tag
                If MyNode.Parent.Tag = "Chat History" Then
                    Hist.Group = ""
                ElseIf MyNode.Parent.Tag = "Group" Then
                    Hist.Group = MyNode.Parent.FullPath
                End If
            End If
        End If
        For Each node In MyNode.Nodes
            UpdateNodePaths(node)
        Next
    End Sub
#End Region

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, mnuDelete.Click
        If TreeHistory.SelectedNode IsNot Nothing Then
            Dim MyNode As TreeNode = TreeHistory.SelectedNode
            If MyNode.Tag IsNot Nothing Then
                If TypeOf MyNode.Tag Is ChatHistoryItem Then
                    ' Delete it 
                    MyNode.Parent.Nodes.Remove(MyNode)
                    Utils.OllamaServers.ChatHistory.Remove(MyNode.Tag)
                    OllamaServers.Save(Utils.OllamaServers)
                ElseIf TypeOf MyNode.Tag Is String Then
                    If MyNode.Tag = "Group" Then
                        If MyNode.Nodes.Count = 0 Then
                            MyNode.Parent.Nodes.Remove(MyNode)
                        End If
                    End If
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

    Private Sub mnuCreateGroup_Click(sender As Object, e As EventArgs) Handles mnuCreateGroup.Click
        Dim NewName As String = InputBox("Enter a name for the new chat group", "Create Chat Group", "")
        If NewName.Trim <> "" Then
            Dim MyNode As New TreeNode
            MyNode.Text = NewName
            MyNode.Tag = "Group"
            HistoryNode.Nodes.Insert(0, MyNode)
        End If
    End Sub

    Private Sub btnAddKnowledge_Click(sender As Object, e As EventArgs)

    End Sub
End Class
