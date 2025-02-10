<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnServers = New System.Windows.Forms.ToolStripButton()
        Me.cmbModel = New System.Windows.Forms.ToolStripComboBox()
        Me.lblModelDetails = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnServers, Me.cmbModel, Me.lblModelDetails})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1134, 50)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnServers
        '
        Me.btnServers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnServers.Image = CType(resources.GetObject("btnServers.Image"), System.Drawing.Image)
        Me.btnServers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnServers.Name = "btnServers"
        Me.btnServers.Size = New System.Drawing.Size(46, 44)
        Me.btnServers.Text = "Ollama Network Settings"
        '
        'cmbModel
        '
        Me.cmbModel.AutoSize = False
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(200, 40)
        '
        'lblModelDetails
        '
        Me.lblModelDetails.Name = "lblModelDetails"
        Me.lblModelDetails.Size = New System.Drawing.Size(299, 44)
        Me.lblModelDetails.Text = "Parameters: 8b, Size: 23MB"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1134, 1031)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Ollama Desktop"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnServers As ToolStripButton
    Friend WithEvents cmbModel As ToolStripComboBox
    Friend WithEvents lblModelDetails As ToolStripLabel
End Class
