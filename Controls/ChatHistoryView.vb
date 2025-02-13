Public Class ChatHistoryView

    Private lastDragDestination As TreeNode = Nothing
    Private lastDragDestinationTime As DateTime
    Private HistoryNode As TreeNode
    'Private PromptLibraryNode As TreeNode

    Public Event ShowHistoryDetail(Hist As ChatHistoryItem)

    Private Sub btnClearHistory_Click(sender As Object, e As EventArgs) Handles btnClearHistory.Click, mnuClear.Click
        If MsgBox("Clear chat history? This cannot be undone", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Ollama Chat") = MsgBoxResult.Yes Then
            ClearHistory()
            btnClearHistory.Enabled = False
            mnuClear.Enabled = False
        End If
    End Sub

#Region "Tree Handling"
    Private Sub TreeHistory_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeHistory.AfterSelect
        Dim EnableDelete As Boolean = False
        If TreeHistory.SelectedNode IsNot Nothing Then
            Dim MyNode As TreeNode = TreeHistory.SelectedNode
            If MyNode.Tag IsNot Nothing Then
                If TypeOf MyNode.Tag Is ChatHistoryItem Then
                    Dim Hist As ChatHistoryItem = MyNode.Tag
                    RaiseEvent ShowHistoryDetail(Hist)

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
    Public Sub LoadHistory()
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


    Private Sub mnuCreateGroup_Click(sender As Object, e As EventArgs) Handles mnuCreateGroup.Click
        Dim NewName As String = InputBox("Enter a name for the new chat group", "Create Chat Group", "")
        If NewName.Trim <> "" Then
            Dim MyNode As New TreeNode
            MyNode.Text = NewName
            MyNode.Tag = "Group"
            HistoryNode.Nodes.Insert(0, MyNode)
        End If
    End Sub
    Private Sub ClearHistory()
        Utils.OllamaServers.ChatHistory.Clear()
        OllamaServers.Save(Utils.OllamaServers)
        LoadHistory()
    End Sub

    Private Sub mnuCollapse_Click(sender As Object, e As EventArgs) Handles mnuCollapse.Click
        Me.TreeHistory.CollapseAll()
    End Sub

    Private Sub mnuexpandall_Click(sender As Object, e As EventArgs) Handles mnuexpandall.Click
        Me.TreeHistory.ExpandAll()
    End Sub



End Class
