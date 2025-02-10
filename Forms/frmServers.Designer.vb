<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServers
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServers))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lstServers = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.grpServer = New System.Windows.Forms.GroupBox()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.lblModelDetails = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.txtPort = New System.Windows.Forms.NumericUpDown()
        Me.txtProtocol = New System.Windows.Forms.TextBox()
        Me.lblProtocol = New System.Windows.Forms.Label()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSetDefault = New System.Windows.Forms.Button()
        Me.grpServer.SuspendLayout()
        CType(Me.txtPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(135, 45)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(556, 38)
        Me.txtName.TabIndex = 1
        '
        'lstServers
        '
        Me.lstServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstServers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstServers.FullRowSelect = True
        Me.lstServers.HideSelection = False
        Me.lstServers.Location = New System.Drawing.Point(12, 12)
        Me.lstServers.Name = "lstServers"
        Me.lstServers.Size = New System.Drawing.Size(566, 523)
        Me.lstServers.SmallImageList = Me.ImageList1
        Me.lstServers.TabIndex = 2
        Me.lstServers.UseCompatibleStateImageBehavior = False
        Me.lstServers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Server"
        Me.ColumnHeader2.Width = 327
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Default")
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(174, 541)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(156, 50)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add New"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(12, 541)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(156, 50)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'grpServer
        '
        Me.grpServer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpServer.Controls.Add(Me.btnReload)
        Me.grpServer.Controls.Add(Me.btnVerify)
        Me.grpServer.Controls.Add(Me.lblModelDetails)
        Me.grpServer.Controls.Add(Me.lblModel)
        Me.grpServer.Controls.Add(Me.cmbModel)
        Me.grpServer.Controls.Add(Me.txtPort)
        Me.grpServer.Controls.Add(Me.txtProtocol)
        Me.grpServer.Controls.Add(Me.lblProtocol)
        Me.grpServer.Controls.Add(Me.lblPort)
        Me.grpServer.Controls.Add(Me.txtServer)
        Me.grpServer.Controls.Add(Me.lblServer)
        Me.grpServer.Controls.Add(Me.txtName)
        Me.grpServer.Controls.Add(Me.Label1)
        Me.grpServer.Enabled = False
        Me.grpServer.Location = New System.Drawing.Point(593, 12)
        Me.grpServer.Name = "grpServer"
        Me.grpServer.Size = New System.Drawing.Size(853, 523)
        Me.grpServer.TabIndex = 5
        Me.grpServer.TabStop = False
        Me.grpServer.Text = "Server"
        '
        'btnReload
        '
        Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReload.Location = New System.Drawing.Point(669, 219)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(172, 39)
        Me.btnReload.TabIndex = 13
        Me.btnReload.Text = "Refresh"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'btnVerify
        '
        Me.btnVerify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVerify.Location = New System.Drawing.Point(697, 45)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(144, 38)
        Me.btnVerify.TabIndex = 9
        Me.btnVerify.Text = "Verify"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'lblModelDetails
        '
        Me.lblModelDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModelDetails.Location = New System.Drawing.Point(26, 282)
        Me.lblModelDetails.Name = "lblModelDetails"
        Me.lblModelDetails.Size = New System.Drawing.Size(815, 219)
        Me.lblModelDetails.TabIndex = 12
        Me.lblModelDetails.Text = "Model Details"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(20, 172)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(181, 31)
        Me.lblModel.TabIndex = 11
        Me.lblModel.Text = "Default Model"
        '
        'cmbModel
        '
        Me.cmbModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModel.FormattingEnabled = True
        Me.cmbModel.Location = New System.Drawing.Point(26, 219)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(625, 39)
        Me.cmbModel.TabIndex = 10
        '
        'txtPort
        '
        Me.txtPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPort.Location = New System.Drawing.Point(442, 102)
        Me.txtPort.Maximum = New Decimal(New Integer() {32768, 0, 0, 0})
        Me.txtPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(129, 38)
        Me.txtPort.TabIndex = 8
        Me.txtPort.Value = New Decimal(New Integer() {11434, 0, 0, 0})
        '
        'txtProtocol
        '
        Me.txtProtocol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProtocol.Location = New System.Drawing.Point(709, 105)
        Me.txtProtocol.Name = "txtProtocol"
        Me.txtProtocol.Size = New System.Drawing.Size(132, 38)
        Me.txtProtocol.TabIndex = 7
        '
        'lblProtocol
        '
        Me.lblProtocol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProtocol.AutoSize = True
        Me.lblProtocol.Location = New System.Drawing.Point(589, 105)
        Me.lblProtocol.Name = "lblProtocol"
        Me.lblProtocol.Size = New System.Drawing.Size(114, 31)
        Me.lblProtocol.TabIndex = 6
        Me.lblProtocol.Text = "Protocol"
        '
        'lblPort
        '
        Me.lblPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(360, 104)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(64, 31)
        Me.lblPort.TabIndex = 4
        Me.lblPort.Text = "Port"
        '
        'txtServer
        '
        Me.txtServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServer.Location = New System.Drawing.Point(135, 102)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(210, 38)
        Me.txtServer.TabIndex = 3
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(20, 104)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(94, 31)
        Me.lblServer.TabIndex = 2
        Me.lblServer.Text = "Server"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(1128, 541)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(156, 50)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1290, 541)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(156, 50)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSetDefault
        '
        Me.btnSetDefault.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSetDefault.Enabled = False
        Me.btnSetDefault.Location = New System.Drawing.Point(336, 541)
        Me.btnSetDefault.Name = "btnSetDefault"
        Me.btnSetDefault.Size = New System.Drawing.Size(196, 50)
        Me.btnSetDefault.TabIndex = 8
        Me.btnSetDefault.Text = "Set Default"
        Me.btnSetDefault.UseVisualStyleBackColor = True
        '
        'frmServers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1458, 603)
        Me.Controls.Add(Me.btnSetDefault)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpServer)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstServers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ollama Servers"
        Me.grpServer.ResumeLayout(False)
        Me.grpServer.PerformLayout()
        CType(Me.txtPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lstServers As ListView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents grpServer As GroupBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtProtocol As TextBox
    Friend WithEvents lblProtocol As Label
    Friend WithEvents lblPort As Label
    Friend WithEvents txtServer As TextBox
    Friend WithEvents lblServer As Label
    Friend WithEvents btnVerify As Button
    Friend WithEvents txtPort As NumericUpDown
    Friend WithEvents lblModelDetails As Label
    Friend WithEvents lblModel As Label
    Friend WithEvents cmbModel As ComboBox
    Friend WithEvents btnSetDefault As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnReload As Button
End Class
