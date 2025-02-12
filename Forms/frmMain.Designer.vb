<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.FlatTabControl1 = New DarkModeForms.FlatTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.MenuStripTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClearHistory = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCollapse = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbServer = New System.Windows.Forms.ComboBox()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblHistTitle = New System.Windows.Forms.Label()
        Me.lblHistModel = New System.Windows.Forms.Label()
        Me.lblHistDated = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnExpand = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblExpansions = New System.Windows.Forms.Label()
        Me.txtPrompt = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.chkShowCOT = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipGeneral = New System.Windows.Forms.ToolTip(Me.components)
        Me.TreeHistory = New OllamaDesktop.TreeViewDraggableNodes()
        Me.Knowledge1 = New OllamaDesktop.Knowledge()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.FlatTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.MenuStripTree.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetails.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FlatTabControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1MinSize = 26
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebView21)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDetails)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(2394, 1189)
        Me.SplitContainer1.SplitterDistance = 998
        Me.SplitContainer1.SplitterWidth = 10
        Me.SplitContainer1.TabIndex = 2
        '
        'FlatTabControl1
        '
        Me.FlatTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.FlatTabControl1.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.FlatTabControl1.Controls.Add(Me.TabPage1)
        Me.FlatTabControl1.Controls.Add(Me.TabPage2)
        Me.FlatTabControl1.Controls.Add(Me.TabPage3)
        Me.FlatTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlatTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.FlatTabControl1.ItemSize = New System.Drawing.Size(192, 35)
        Me.FlatTabControl1.LineColor = System.Drawing.SystemColors.Highlight
        Me.FlatTabControl1.Location = New System.Drawing.Point(0, 107)
        Me.FlatTabControl1.Name = "FlatTabControl1"
        Me.FlatTabControl1.SelectedForeColor = System.Drawing.SystemColors.HighlightText
        Me.FlatTabControl1.SelectedIndex = 0
        Me.FlatTabControl1.SelectTabColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FlatTabControl1.ShowTabCloseButton = True
        Me.FlatTabControl1.Size = New System.Drawing.Size(998, 1082)
        Me.FlatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.FlatTabControl1.TabCloseColor = System.Drawing.SystemColors.ControlText
        Me.FlatTabControl1.TabColor = System.Drawing.SystemColors.ControlLight
        Me.FlatTabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage1.Controls.Add(Me.TreeHistory)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 39)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(990, 1039)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Chat History"
        '
        'MenuStripTree
        '
        Me.MenuStripTree.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStripTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRename, Me.mnuCreateGroup, Me.ToolStripSeparator1, Me.mnuDelete, Me.mnuClear})
        Me.MenuStripTree.Name = "MenuStripTree"
        Me.MenuStripTree.Size = New System.Drawing.Size(296, 162)
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnDelete)
        Me.Panel3.Controls.Add(Me.btnClearHistory)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 979)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 57)
        Me.Panel3.TabIndex = 2
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(848, 4)
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
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage2.Location = New System.Drawing.Point(4, 39)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(990, 1039)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Prompt Library"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage3.Controls.Add(Me.Knowledge1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 39)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(990, 1039)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Knowledge"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCollapse)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbServer)
        Me.Panel1.Controls.Add(Me.cmbModel)
        Me.Panel1.Controls.Add(Me.btnSettings)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(998, 107)
        Me.Panel1.TabIndex = 1
        '
        'btnCollapse
        '
        Me.btnCollapse.BackColor = System.Drawing.Color.Transparent
        Me.btnCollapse.Location = New System.Drawing.Point(3, 7)
        Me.btnCollapse.Name = "btnCollapse"
        Me.btnCollapse.Size = New System.Drawing.Size(26, 87)
        Me.btnCollapse.TabIndex = 12
        Me.btnCollapse.Text = "<"
        Me.btnCollapse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCollapse.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 31)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Models"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 31)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Servers"
        '
        'cmbServer
        '
        Me.cmbServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServer.FormattingEnabled = True
        Me.cmbServer.Location = New System.Drawing.Point(221, 10)
        Me.cmbServer.Name = "cmbServer"
        Me.cmbServer.Size = New System.Drawing.Size(774, 39)
        Me.cmbServer.TabIndex = 2
        '
        'cmbModel
        '
        Me.cmbModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModel.FormattingEnabled = True
        Me.cmbModel.Location = New System.Drawing.Point(221, 55)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(774, 39)
        Me.cmbModel.TabIndex = 1
        '
        'btnSettings
        '
        Me.btnSettings.Image = Global.OllamaDesktop.My.Resources.Resources.server_network
        Me.btnSettings.Location = New System.Drawing.Point(35, 6)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(56, 89)
        Me.btnSettings.TabIndex = 0
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView21.Location = New System.Drawing.Point(43, 95)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(1343, 826)
        Me.WebView21.TabIndex = 9
        Me.WebView21.ZoomFactor = 1.0R
        '
        'pnlDetails
        '
        Me.pnlDetails.Controls.Add(Me.lblHistTitle)
        Me.pnlDetails.Controls.Add(Me.lblHistModel)
        Me.pnlDetails.Controls.Add(Me.lblHistDated)
        Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetails.Location = New System.Drawing.Point(43, 0)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(1343, 95)
        Me.pnlDetails.TabIndex = 15
        Me.pnlDetails.Visible = False
        '
        'lblHistTitle
        '
        Me.lblHistTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHistTitle.Font = New System.Drawing.Font("Gadugi", 13.875!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblHistTitle.Name = "lblHistTitle"
        Me.lblHistTitle.Size = New System.Drawing.Size(1343, 35)
        Me.lblHistTitle.TabIndex = 6
        Me.lblHistTitle.Text = "24th Jan 2025 13:28 - Rise of rome"
        Me.lblHistTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHistModel
        '
        Me.lblHistModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHistModel.AutoSize = True
        Me.lblHistModel.Font = New System.Drawing.Font("Gadugi", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistModel.Location = New System.Drawing.Point(6, 55)
        Me.lblHistModel.Name = "lblHistModel"
        Me.lblHistModel.Size = New System.Drawing.Size(375, 28)
        Me.lblHistModel.TabIndex = 5
        Me.lblHistModel.Text = "Server: Ryzen, Model: LLama3.1"
        Me.lblHistModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHistDated
        '
        Me.lblHistDated.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHistDated.Font = New System.Drawing.Font("Gadugi", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistDated.Location = New System.Drawing.Point(993, 55)
        Me.lblHistDated.Name = "lblHistDated"
        Me.lblHistDated.Size = New System.Drawing.Size(338, 37)
        Me.lblHistDated.TabIndex = 4
        Me.lblHistDated.Text = "24th Jan 2025 13:28"
        Me.lblHistDated.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnExpand)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(43, 921)
        Me.Panel4.TabIndex = 16
        '
        'btnExpand
        '
        Me.btnExpand.BackColor = System.Drawing.Color.Transparent
        Me.btnExpand.Location = New System.Drawing.Point(3, 3)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(26, 87)
        Me.btnExpand.TabIndex = 13
        Me.btnExpand.Text = ">"
        Me.btnExpand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExpand.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblExpansions)
        Me.Panel2.Controls.Add(Me.txtPrompt)
        Me.Panel2.Controls.Add(Me.btnSend)
        Me.Panel2.Controls.Add(Me.btnCopy)
        Me.Panel2.Controls.Add(Me.chkShowCOT)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 921)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1386, 268)
        Me.Panel2.TabIndex = 14
        '
        'lblExpansions
        '
        Me.lblExpansions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExpansions.Location = New System.Drawing.Point(206, 75)
        Me.lblExpansions.Name = "lblExpansions"
        Me.lblExpansions.Size = New System.Drawing.Size(1168, 43)
        Me.lblExpansions.TabIndex = 12
        Me.lblExpansions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrompt
        '
        Me.txtPrompt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrompt.Font = New System.Drawing.Font("Gadugi", 10.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrompt.Location = New System.Drawing.Point(195, 112)
        Me.txtPrompt.Multiline = True
        Me.txtPrompt.Name = "txtPrompt"
        Me.txtPrompt.Size = New System.Drawing.Size(1179, 143)
        Me.txtPrompt.TabIndex = 5
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSend.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btnSend.BackgroundImage = Global.OllamaDesktop.My.Resources.Resources.app
        Me.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSend.Font = New System.Drawing.Font("Gadugi", 10.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.Location = New System.Drawing.Point(28, 110)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(172, 145)
        Me.btnSend.TabIndex = 8
        Me.btnSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.BackColor = System.Drawing.Color.Transparent
        Me.btnCopy.Image = Global.OllamaDesktop.My.Resources.Resources.I_Copy32x
        Me.btnCopy.Location = New System.Drawing.Point(1310, 18)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(64, 64)
        Me.btnCopy.TabIndex = 11
        Me.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipGeneral.SetToolTip(Me.btnCopy, "Copy this response to the clipboard in markdown format")
        Me.btnCopy.UseVisualStyleBackColor = False
        '
        'chkShowCOT
        '
        Me.chkShowCOT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowCOT.AutoSize = True
        Me.chkShowCOT.BackColor = System.Drawing.Color.Gray
        Me.chkShowCOT.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chkShowCOT.Location = New System.Drawing.Point(939, 34)
        Me.chkShowCOT.Name = "chkShowCOT"
        Me.chkShowCOT.Size = New System.Drawing.Size(324, 35)
        Me.chkShowCOT.TabIndex = 10
        Me.chkShowCOT.Text = "Show Chain of Thought"
        Me.chkShowCOT.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(561, 56)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Hi There, How can I help?"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "Expand Panel"
        '
        'ToolTip2
        '
        Me.ToolTip2.ToolTipTitle = "Collapse"
        '
        'ToolTip3
        '
        Me.ToolTip3.ToolTipTitle = "Server Settings"
        '
        'ToolTipGeneral
        '
        Me.ToolTipGeneral.ToolTipTitle = "Ollama Desktop Chat"
        '
        'TreeHistory
        '
        Me.TreeHistory.ContextMenuStrip = Me.MenuStripTree
        Me.TreeHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeHistory.Location = New System.Drawing.Point(3, 3)
        Me.TreeHistory.Name = "TreeHistory"
        Me.TreeHistory.Size = New System.Drawing.Size(984, 976)
        Me.TreeHistory.TabIndex = 0
        '
        'Knowledge1
        '
        Me.Knowledge1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Knowledge1.Location = New System.Drawing.Point(3, 3)
        Me.Knowledge1.Name = "Knowledge1"
        Me.Knowledge1.Size = New System.Drawing.Size(984, 1033)
        Me.Knowledge1.TabIndex = 0
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(2394, 1189)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Gadugi", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Ollama Desktop"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.FlatTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.MenuStripTree.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TreeHistory As TreeViewDraggableNodes
    Friend WithEvents txtPrompt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSend As Button
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSettings As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbServer As ComboBox
    Friend WithEvents cmbModel As ComboBox
    Friend WithEvents chkShowCOT As CheckBox
    Friend WithEvents btnCopy As Button
    Friend WithEvents btnCollapse As Button
    Friend WithEvents btnExpand As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents ToolTip3 As ToolTip
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClearHistory As Button
    Friend WithEvents MenuStripTree As ContextMenuStrip
    Friend WithEvents mnuRename As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuDelete As ToolStripMenuItem
    Friend WithEvents mnuClear As ToolStripMenuItem
    Friend WithEvents mnuCreateGroup As ToolStripMenuItem
    Friend WithEvents pnlDetails As Panel
    Friend WithEvents lblHistModel As Label
    Friend WithEvents lblHistDated As Label
    Friend WithEvents ToolTipGeneral As ToolTip
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblHistTitle As Label
    Friend WithEvents FlatTabControl1 As FlatTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Knowledge1 As Knowledge
    Friend WithEvents lblExpansions As Label
End Class
