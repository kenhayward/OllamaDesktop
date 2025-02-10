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
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Prompt Library", New System.Windows.Forms.TreeNode() {TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("History")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbServer = New System.Windows.Forms.ComboBox()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrompt = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PromptEntry1 = New OllamaDesktop.PromptEntry()
        Me.btnSend = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebView21)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtPrompt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PromptEntry1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSend)
        Me.SplitContainer1.Size = New System.Drawing.Size(1674, 1189)
        Me.SplitContainer1.SplitterDistance = 517
        Me.SplitContainer1.SplitterWidth = 10
        Me.SplitContainer1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbServer)
        Me.Panel1.Controls.Add(Me.cmbModel)
        Me.Panel1.Controls.Add(Me.btnSettings)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(517, 95)
        Me.Panel1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 31)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Models"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 31)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Servers"
        '
        'cmbServer
        '
        Me.cmbServer.FormattingEnabled = True
        Me.cmbServer.Location = New System.Drawing.Point(289, 8)
        Me.cmbServer.Name = "cmbServer"
        Me.cmbServer.Size = New System.Drawing.Size(222, 39)
        Me.cmbServer.TabIndex = 2
        '
        'cmbModel
        '
        Me.cmbModel.FormattingEnabled = True
        Me.cmbModel.Location = New System.Drawing.Point(289, 53)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(222, 39)
        Me.cmbModel.TabIndex = 1
        '
        'btnSettings
        '
        Me.btnSettings.Image = Global.OllamaDesktop.My.Resources.Resources.server_network
        Me.btnSettings.Location = New System.Drawing.Point(3, 3)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(160, 89)
        Me.btnSettings.TabIndex = 0
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 95)
        Me.TreeView1.Name = "TreeView1"
        TreeNode4.Name = "Node2"
        TreeNode4.Text = "Node2"
        TreeNode5.Name = "Node0"
        TreeNode5.Text = "Prompt Library"
        TreeNode6.Name = "Node1"
        TreeNode6.Text = "History"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6})
        Me.TreeView1.Size = New System.Drawing.Size(517, 1094)
        Me.TreeView1.TabIndex = 0
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView21.Location = New System.Drawing.Point(0, 0)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(1147, 915)
        Me.WebView21.TabIndex = 9
        Me.WebView21.ZoomFactor = 1.0R
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 937)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(561, 56)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Hi There, How can I help?"
        '
        'txtPrompt
        '
        Me.txtPrompt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrompt.Location = New System.Drawing.Point(173, 1020)
        Me.txtPrompt.Multiline = True
        Me.txtPrompt.Name = "txtPrompt"
        Me.txtPrompt.Size = New System.Drawing.Size(905, 145)
        Me.txtPrompt.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Gray
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(21, 1012)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(136, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PromptEntry1
        '
        Me.PromptEntry1.BackColor = System.Drawing.Color.Transparent
        Me.PromptEntry1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PromptEntry1.Location = New System.Drawing.Point(0, 915)
        Me.PromptEntry1.Name = "PromptEntry1"
        Me.PromptEntry1.Size = New System.Drawing.Size(1147, 274)
        Me.PromptEntry1.TabIndex = 3
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(926, 965)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(172, 49)
        Me.btnSend.TabIndex = 8
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1674, 1189)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Ollama Desktop"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        DarkMode = New DarkModeCS(Me, False, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents PromptEntry1 As PromptEntry
    Friend WithEvents PictureBox1 As PictureBox
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
End Class
