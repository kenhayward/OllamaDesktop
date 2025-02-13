<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKnowledge
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblsize = New System.Windows.Forms.Label()
        Me.lblTokens = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.btnRecalc = New System.Windows.Forms.Button()
        Me.TabControlMain = New DarkModeForms.FlatTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lstTables = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControlMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtFile
        '
        Me.txtFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFile.Location = New System.Drawing.Point(176, 20)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(1341, 43)
        Me.txtFile.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Source File:"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenFile.Location = New System.Drawing.Point(1523, 16)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(146, 47)
        Me.btnOpenFile.TabIndex = 2
        Me.btnOpenFile.Text = "Browse"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'txtText
        '
        Me.txtText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtText.Enabled = False
        Me.txtText.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New System.Drawing.Point(3, 3)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtText.Size = New System.Drawing.Size(1636, 487)
        Me.txtText.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(1523, 722)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(145, 57)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(1372, 722)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 57)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 735)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 31)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Text Size:"
        '
        'lblsize
        '
        Me.lblsize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblsize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsize.Location = New System.Drawing.Point(281, 735)
        Me.lblsize.Name = "lblsize"
        Me.lblsize.Size = New System.Drawing.Size(145, 31)
        Me.lblsize.TabIndex = 8
        Me.lblsize.Text = "0"
        '
        'lblTokens
        '
        Me.lblTokens.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTokens.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTokens.Location = New System.Drawing.Point(769, 735)
        Me.lblTokens.Name = "lblTokens"
        Me.lblTokens.Size = New System.Drawing.Size(116, 31)
        Me.lblTokens.TabIndex = 10
        Me.lblTokens.Text = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(432, 735)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(331, 31)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Approximate Token Count:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(12, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 31)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Context Key:"
        '
        'txtKey
        '
        Me.txtKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKey.Enabled = False
        Me.txtKey.Location = New System.Drawing.Point(176, 83)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(1341, 43)
        Me.txtKey.TabIndex = 11
        '
        'btnRecalc
        '
        Me.btnRecalc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRecalc.Enabled = False
        Me.btnRecalc.Location = New System.Drawing.Point(17, 722)
        Me.btnRecalc.Name = "btnRecalc"
        Me.btnRecalc.Size = New System.Drawing.Size(115, 56)
        Me.btnRecalc.TabIndex = 13
        Me.btnRecalc.Text = "Recalc"
        Me.btnRecalc.UseVisualStyleBackColor = True
        '
        'TabControlMain
        '
        Me.TabControlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControlMain.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.TabControlMain.Controls.Add(Me.TabPage1)
        Me.TabControlMain.Controls.Add(Me.TabPage2)
        Me.TabControlMain.Controls.Add(Me.TabPage3)
        Me.TabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControlMain.ItemSize = New System.Drawing.Size(192, 35)
        Me.TabControlMain.LineColor = System.Drawing.SystemColors.Highlight
        Me.TabControlMain.Location = New System.Drawing.Point(18, 148)
        Me.TabControlMain.Multiline = True
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedForeColor = System.Drawing.SystemColors.HighlightText
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.SelectTabColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TabControlMain.ShowTabCloseButton = False
        Me.TabControlMain.Size = New System.Drawing.Size(1650, 536)
        Me.TabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMain.TabCloseColor = System.Drawing.SystemColors.ControlText
        Me.TabControlMain.TabColor = System.Drawing.SystemColors.ControlLight
        Me.TabControlMain.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage1.Controls.Add(Me.txtText)
        Me.TabPage1.Location = New System.Drawing.Point(4, 39)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1642, 493)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Extracted Text"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage2.Controls.Add(Me.WebView21)
        Me.TabPage2.Location = New System.Drawing.Point(4, 39)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1642, 493)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Original PDF"
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView21.Location = New System.Drawing.Point(3, 3)
        Me.WebView21.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(1636, 487)
        Me.WebView21.Source = New System.Uri("https://www.google.com", System.UriKind.Absolute)
        Me.WebView21.TabIndex = 1
        Me.WebView21.ZoomFactor = 1.0R
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage3.Controls.Add(Me.SplitContainer1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 39)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1642, 493)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Potential Tables"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstTables)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1636, 487)
        Me.SplitContainer1.SplitterDistance = 632
        Me.SplitContainer1.SplitterWidth = 10
        Me.SplitContainer1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 82
        Me.DataGridView1.RowTemplate.Height = 40
        Me.DataGridView1.Size = New System.Drawing.Size(994, 487)
        Me.DataGridView1.TabIndex = 0
        '
        'lstTables
        '
        Me.lstTables.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstTables.HideSelection = False
        Me.lstTables.Location = New System.Drawing.Point(0, 0)
        Me.lstTables.Name = "lstTables"
        Me.lstTables.Size = New System.Drawing.Size(632, 487)
        Me.lstTables.TabIndex = 0
        Me.lstTables.UseCompatibleStateImageBehavior = False
        Me.lstTables.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Page"
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Rows"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 135
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Columns"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 164
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Key"
        Me.ColumnHeader4.Width = 165
        '
        'frmKnowledge
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(15.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1680, 791)
        Me.Controls.Add(Me.TabControlMain)
        Me.Controls.Add(Me.btnRecalc)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.lblTokens)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblsize)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFile)
        Me.Font = New System.Drawing.Font("Gadugi", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeBox = False
        Me.Name = "frmKnowledge"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Knowledge"
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtFile As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOpenFile As Button
    Friend WithEvents txtText As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblsize As Label
    Friend WithEvents lblTokens As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtKey As TextBox
    Friend WithEvents btnRecalc As Button
    Friend WithEvents TabControlMain As FlatTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lstTables As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
End Class
