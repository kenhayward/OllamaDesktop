Imports System.ComponentModel

Public Class TreeViewDraggableNodes
    Inherits TreeView

#Region "Events"

    Public Event NodeMovedByDrag As EventHandler(Of NodeMovedByDragEventArgs)

    Protected Overridable Sub OnNodeMovedByDrag(ByVal e As NodeMovedByDragEventArgs)
        RaiseEvent NodeMovedByDrag(Me, e)
    End Sub

    Public Event NodeMovingByDrag As EventHandler(Of NodeMovingByDragEventArgs)

    Protected Overridable Sub OnNodeMovingByDrag(ByVal e As NodeMovingByDragEventArgs)
        RaiseEvent NodeMovingByDrag(Me, e)
    End Sub

    Public Event NodeDraggingOver As EventHandler(Of NodeDraggingOverEventArgs)

    Protected Overridable Sub OnNodeDraggingOver(ByVal e As NodeDraggingOverEventArgs)
        RaiseEvent NodeDraggingOver(Me, e)
    End Sub

#End Region

    Sub New()
        MyBase.AllowDrop = True
        'MyBase.DrawMode = TreeViewDrawMode.OwnerDrawAll
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows ReadOnly Property DrawMode() As System.Windows.Forms.TreeViewDrawMode
        Get
            Return (MyBase.DrawMode)
        End Get
    End Property

    '<DefaultValue(True)> _
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows ReadOnly Property AllowDrop() As Boolean
        Get
            Return (MyBase.AllowDrop)
        End Get
    End Property

    Protected Overrides Sub OnItemDrag(ByVal e As System.Windows.Forms.ItemDragEventArgs)
        MyBase.DoDragDrop(e.Item, DragDropEffects.Move)
        MyBase.OnItemDrag(e)
    End Sub

    Protected Overrides Sub OnDragOver(ByVal drgevent As System.Windows.Forms.DragEventArgs)
        'Get the node we are currently over
        'while dragging another node
        Dim targetNode As TreeNode = MyBase.GetNodeAt(MyBase.PointToClient(New Point(drgevent.X, drgevent.Y)))

        'Get the node being dragged
        Dim dragNode As TreeNode = FindNodeInDataObject(drgevent.Data)

        Dim eaDraggingOver As New NodeDraggingOverEventArgs(dragNode, targetNode)
        OnNodeDraggingOver(eaDraggingOver)

        If eaDraggingOver.DropIsLegal = False Then
            drgevent.Effect = DragDropEffects.None
            Return
        End If

        'If we are not currently dragging over
        'a node...
        If targetNode Is Nothing Then
            'Let no node be selected
            MyBase.SelectedNode = Nothing

            'Allow the move because its valid
            'to drag a node over the TreeView itself
            'the drop will place the node being dragged
            'in the root

            drgevent.Effect = DragDropEffects.Move

            'Get out
            Return
        End If

        'This would only be nothing if something is being
        'dragged over the TreeView that isn't a node
        If dragNode IsNot Nothing Then

            'Illegal to drop nodes inside their descendants
            'Its not logical
            If targetNode Is dragNode OrElse IsNodeDescendant(targetNode, dragNode) Then
                'Prevents a drop
                drgevent.Effect = DragDropEffects.None
            Else
                'Allows a drop
                drgevent.Effect = DragDropEffects.Move
                MyBase.SelectedNode = targetNode
            End If

        End If

        MyBase.OnDragOver(drgevent)

    End Sub

    Private WithEvents cms As New ContextMenuStrip
    Dim choice As String = ""

    Protected Overrides Sub OnDragDrop(ByVal drgevent As System.Windows.Forms.DragEventArgs)
        Dim dragNode As TreeNode = FindNodeInDataObject(drgevent.Data)

        If dragNode IsNot Nothing Then
            'Dim dragNode As TreeNode = DirectCast(drgevent.Data.GetData(GetType(TreeNode)), TreeNode)
            'Get the parent of the node before moving

            If cms.Items.Count = 0 Then
                cms.Items.Add("Child", Nothing, AddressOf childClicked)
                'cms.Items.Add("Sibling", Nothing, AddressOf siblingClicked)
                cms.Tag = drgevent
                'cms.Show(drgevent.X, drgevent.Y)
                'Return
            Else
                cms.Items.Clear()
            End If
            choice = "child"

            Dim prevParent As TreeNode = dragNode.Parent
            Dim parentToBe As TreeNode = If(MyBase.SelectedNode Is Nothing, Nothing, If(choice = "child", MyBase.SelectedNode, If(choice = "sibling", MyBase.SelectedNode.Parent, Nothing)))
            Dim eaNodeMoving As New NodeMovingByDragEventArgs(dragNode, prevParent, parentToBe)

            choice = ""

            OnNodeMovingByDrag(eaNodeMoving)
            If eaNodeMoving.CancelMove = False Then

                dragNode.Remove()
                If parentToBe IsNot Nothing Then
                    parentToBe.Nodes.Add(dragNode)
                Else
                    MyBase.Nodes.Add(dragNode)
                End If

                OnNodeMovedByDrag(New NodeMovedByDragEventArgs(dragNode, prevParent))
            End If

        End If
        MyBase.OnDragDrop(drgevent)

    End Sub

    Private Sub childClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        choice = "child"
        OnDragDrop(DirectCast(cms.Tag, DragEventArgs))
    End Sub

    Private Sub siblingClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        choice = "sibling"
        OnDragDrop(DirectCast(cms.Tag, DragEventArgs))
    End Sub

    Private Function IsNodeDescendant(ByVal node As TreeNode, ByVal potentialElder As TreeNode) As Boolean
        Dim n As TreeNode
        If node Is Nothing OrElse potentialElder Is Nothing Then Return False
        Do
            n = node.Parent
            If n IsNot Nothing Then
                If n Is potentialElder Then
                    Return (True)
                Else
                    node = n
                End If

            End If

        Loop Until n Is Nothing

        Return (False)

    End Function

    Private Function FindNodeInDataObject(ByVal dataObject As IDataObject) As TreeNode

        For Each format As String In dataObject.GetFormats
            Dim data As Object = dataObject.GetData(format)

            If GetType(TreeNode).IsAssignableFrom(data.GetType) Then
                Return (DirectCast(data, TreeNode))
            End If
        Next

        Return (Nothing)

    End Function

End Class

Public Class NodeDraggingOverEventArgs
    Inherits EventArgs

    Private _DropLegal As Boolean
    Private _MovingNode As TreeNode
    Private _TargetNode As TreeNode

    Public Sub New(ByVal movingNode As TreeNode, ByVal targetNode As TreeNode)
        _DropLegal = True
        _MovingNode = movingNode
        _TargetNode = targetNode
    End Sub

    Public ReadOnly Property TargetNode() As TreeNode
        Get
            Return (_TargetNode)
        End Get
    End Property

    Public ReadOnly Property MovingNode() As TreeNode
        Get
            Return (_MovingNode)
        End Get
    End Property

    'Use this to disallow a drop

    Public Property DropIsLegal() As Boolean
        Get
            Return _DropLegal
        End Get
        Set(ByVal value As Boolean)
            _DropLegal = value
        End Set
    End Property

End Class

Public Class NodeMovingByDragEventArgs
    Inherits EventArgs

    Private _MovingNode As TreeNode
    Private _CurParent As TreeNode
    Private _ParentToBe As TreeNode
    Private _CancelMove As Boolean

    Public Sub New(ByVal nodeMoving As TreeNode, ByVal prevParent As TreeNode, ByVal parentToBe As TreeNode)
        _MovingNode = nodeMoving
        _CurParent = prevParent
        _ParentToBe = parentToBe
    End Sub

    Public Property CancelMove() As Boolean
        Get
            Return _CancelMove
        End Get
        Set(ByVal value As Boolean)
            _CancelMove = value
        End Set
    End Property

    Public ReadOnly Property MovingNode() As TreeNode
        Get
            Return _MovingNode
        End Get

    End Property

    Public ReadOnly Property CurrentParent() As TreeNode
        Get
            Return _CurParent
        End Get
    End Property

    Public ReadOnly Property ParentToBe() As TreeNode
        Get
            Return _ParentToBe
        End Get
    End Property

End Class

Public Class NodeMovedByDragEventArgs
    Inherits EventArgs

    Private _MovedNode As TreeNode
    Private _PreviousParent As TreeNode

    Public Sub New(ByVal nodeMoved As TreeNode, ByVal prevParent As TreeNode)
        _MovedNode = nodeMoved
        _PreviousParent = prevParent
    End Sub

    Public ReadOnly Property MovedNode() As TreeNode
        Get
            Return _MovedNode
        End Get
    End Property

    Public ReadOnly Property PreviousParent() As TreeNode
        Get
            Return _PreviousParent
        End Get
    End Property

End Class


