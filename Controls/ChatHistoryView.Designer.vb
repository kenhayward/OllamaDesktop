<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatHistoryView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TreeHistory = New OllamaDesktop.TreeViewDraggableNodes()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClearHistory = New System.Windows.Forms.Button()
        Me.MenuStripTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCollapse = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuexpandall = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3.SuspendLayout()
        Me.MenuStripTree.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeHistory
        '
        Me.TreeHistory.ContextMenuStrip = Me.MenuStripTree
        Me.TreeHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeHistory.Location = New System.Drawing.Point(0, 0)
        Me.TreeHistory.Name = "TreeHistory"
        Me.TreeHistory.Size = New System.Drawing.Size(1086, 1208)
        Me.TreeHistory.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnDelete)
        Me.Panel3.Controls.Add(Me.btnClearHistory)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 1208)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1086, 57)
        Me.Panel3.TabIndex = 4
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(950, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(133, 48)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClearHistory
        '
        Me.btnClearHistory.Enabled = False
        Me.btnClearHistory.Location = New System.Drawing.Point(5, 3)
        Me.btnClearHistory.Name = "btnClearHistory"
        Me.btnClearHistory.Size = New System.Drawing.Size(203, 48)
        Me.btnClearHistory.TabIndex = 1
        Me.btnClearHistory.Text = "Clear History"
        Me.btnClearHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClearHistory.UseVisualStyleBackColor = True
        '
        'MenuStripTree
        '
        Me.MenuStripTree.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStripTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRename, Me.mnuCreateGroup, Me.ToolStripSeparator1, Me.mnuCollapse, Me.mnuexpandall, Me.ToolStripSeparator2, Me.mnuDelete, Me.mnuClear})
        Me.MenuStripTree.Name = "MenuStripTree"
        Me.MenuStripTree.Size = New System.Drawing.Size(296, 244)
        '
        'mnuRename
        '
        Me.mnuRename.Name = "mnuRename"
        Me.mnuRename.Size = New System.Drawing.Size(295, 38)
        Me.mnuRename.Text = "Rename"
        '
        'mnuCreateGroup
        '
        Me.mnuCreateGroup.Name = "mnuCreateGroup"
        Me.mnuCreateGroup.Size = New System.Drawing.Size(295, 38)
        Me.mnuCreateGroup.Text = "Create Chat Group"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(292, 6)
        '
        'mnuCollapse
        '
        Me.mnuCollapse.Name = "mnuCollapse"
        Me.mnuCollapse.Size = New System.Drawing.Size(295, 38)
        Me.mnuCollapse.Text = "Collapse All"
        '
        'mnuexpandall
        '
        Me.mnuexpandall.Name = "mnuexpandall"
        Me.mnuexpandall.Size = New System.Drawing.Size(295, 38)
        Me.mnuexpandall.Text = "Expand All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(292, 6)
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(295, 38)
        Me.mnuDelete.Text = "Delete History Item"
        '
        'mnuClear
        '
        Me.mnuClear.Name = "mnuClear"
        Me.mnuClear.Size = New System.Drawing.Size(295, 38)
        Me.mnuClear.Text = "Clear History"
        '
        'ChatHistoryView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TreeHistory)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "ChatHistoryView"
        Me.Size = New System.Drawing.Size(1086, 1265)
        Me.Panel3.ResumeLayout(False)
        Me.MenuStripTree.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeHistory As TreeViewDraggableNodes
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClearHistory As Button
    Friend WithEvents MenuStripTree As ContextMenuStrip
    Friend WithEvents mnuRename As ToolStripMenuItem
    Friend WithEvents mnuCreateGroup As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuCollapse As ToolStripMenuItem
    Friend WithEvents mnuexpandall As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuDelete As ToolStripMenuItem
    Friend WithEvents mnuClear As ToolStripMenuItem
End Class
