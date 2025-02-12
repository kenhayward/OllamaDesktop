<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Knowledge
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
        Me.lstKnowledge = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEditKnowledge = New System.Windows.Forms.Button()
        Me.btnDeleteKnowledge = New System.Windows.Forms.Button()
        Me.btnAddKnowledge = New System.Windows.Forms.Button()
        Me.MenuList.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstKnowledge
        '
        Me.lstKnowledge.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstKnowledge.ContextMenuStrip = Me.MenuList
        Me.lstKnowledge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstKnowledge.FullRowSelect = True
        Me.lstKnowledge.HideSelection = False
        Me.lstKnowledge.Location = New System.Drawing.Point(0, 0)
        Me.lstKnowledge.Name = "lstKnowledge"
        Me.lstKnowledge.Size = New System.Drawing.Size(1023, 1086)
        Me.lstKnowledge.TabIndex = 6
        Me.lstKnowledge.UseCompatibleStateImageBehavior = False
        Me.lstKnowledge.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Key"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 400
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Tokens"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 142
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Size"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 200
        '
        'MenuList
        '
        Me.MenuList.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit, Me.ToolStripSeparator2, Me.mnuAdd, Me.mnuSaveAll, Me.ToolStripSeparator1, Me.mnuDelete})
        Me.MenuList.Name = "MenuList"
        Me.MenuList.Size = New System.Drawing.Size(299, 168)
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(298, 38)
        Me.mnuEdit.Text = "Edit Knowledge"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(295, 6)
        '
        'mnuAdd
        '
        Me.mnuAdd.Name = "mnuAdd"
        Me.mnuAdd.Size = New System.Drawing.Size(298, 38)
        Me.mnuAdd.Text = "Add Knowledge"
        '
        'mnuSaveAll
        '
        Me.mnuSaveAll.Name = "mnuSaveAll"
        Me.mnuSaveAll.Size = New System.Drawing.Size(298, 38)
        Me.mnuSaveAll.Text = "Save All Knowledge"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(295, 6)
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(298, 38)
        Me.mnuDelete.Text = "Delete Knowledge"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnSave)
        Me.Panel5.Controls.Add(Me.btnEditKnowledge)
        Me.Panel5.Controls.Add(Me.btnDeleteKnowledge)
        Me.Panel5.Controls.Add(Me.btnAddKnowledge)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 1086)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1023, 57)
        Me.Panel5.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(333, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(158, 48)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnEditKnowledge
        '
        Me.btnEditKnowledge.Enabled = False
        Me.btnEditKnowledge.Location = New System.Drawing.Point(169, 3)
        Me.btnEditKnowledge.Name = "btnEditKnowledge"
        Me.btnEditKnowledge.Size = New System.Drawing.Size(158, 48)
        Me.btnEditKnowledge.TabIndex = 3
        Me.btnEditKnowledge.Text = "Edit "
        Me.btnEditKnowledge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditKnowledge.UseVisualStyleBackColor = True
        '
        'btnDeleteKnowledge
        '
        Me.btnDeleteKnowledge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteKnowledge.Enabled = False
        Me.btnDeleteKnowledge.Location = New System.Drawing.Point(862, 3)
        Me.btnDeleteKnowledge.Name = "btnDeleteKnowledge"
        Me.btnDeleteKnowledge.Size = New System.Drawing.Size(158, 48)
        Me.btnDeleteKnowledge.TabIndex = 2
        Me.btnDeleteKnowledge.Text = "Delete"
        Me.btnDeleteKnowledge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteKnowledge.UseVisualStyleBackColor = True
        '
        'btnAddKnowledge
        '
        Me.btnAddKnowledge.Location = New System.Drawing.Point(5, 3)
        Me.btnAddKnowledge.Name = "btnAddKnowledge"
        Me.btnAddKnowledge.Size = New System.Drawing.Size(158, 48)
        Me.btnAddKnowledge.TabIndex = 1
        Me.btnAddKnowledge.Text = "Add"
        Me.btnAddKnowledge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddKnowledge.UseVisualStyleBackColor = True
        '
        'Knowledge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lstKnowledge)
        Me.Controls.Add(Me.Panel5)
        Me.Name = "Knowledge"
        Me.Size = New System.Drawing.Size(1023, 1143)
        Me.MenuList.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstKnowledge As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnDeleteKnowledge As Button
    Friend WithEvents btnAddKnowledge As Button
    Friend WithEvents btnEditKnowledge As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents MenuList As ContextMenuStrip
    Friend WithEvents mnuEdit As ToolStripMenuItem
    Friend WithEvents mnuSaveAll As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuDelete As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuAdd As ToolStripMenuItem
End Class
