Imports System.Text
Imports Tiktoken
Imports UglyToad.PdfPig
Imports UglyToad.PdfPig.Content

Public Class frmKnowledge

    Public Property NewKnowledge As KnowledgeEntry

    Private DarkMode As DarkModeForms.DarkModeCS
    Private amUpdating As Boolean = False

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DarkMode = New DarkModeCS(Me, True, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}

    End Sub
    Private Sub frmKnowledge_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If NewKnowledge Is Nothing Then
            OpenFile()
        Else
            ShowKnowledge()
        End If
    End Sub

    Private Sub OpenFile() Handles btnOpenFile.Click
        OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            amUpdating = True
            Me.Cursor = Cursors.WaitCursor
            Dim FullFilename As String = OpenFileDialog1.FileName
            NewKnowledge = New KnowledgeEntry
            NewKnowledge.Name = FullFilename
            NewKnowledge.Key = Utils.FileNameOnly(FullFilename)
            NewKnowledge.Text = ReadPDFText(FullFilename)
            RecalculateTokens()
            amUpdating = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RecalculateTokens()
        NewKnowledge.Tokens = CountTokens(NewKnowledge.Text)
        ShowKnowledge()
    End Sub

    Private Sub ShowKnowledge()
        amUpdating = True
        Me.lblsize.Text = NewKnowledge.Size
        Me.lblTokens.Text = NewKnowledge.Tokens
        Me.txtKey.Text = NewKnowledge.Key
        Me.txtText.Text = NewKnowledge.Text
        Me.txtText.Enabled = True
        Me.txtKey.Enabled = True
        Me.btnRecalc.Enabled = True
        Me.txtFile.Text = NewKnowledge.Name
        amUpdating = False
    End Sub
    Private Function ReadPDFText(FileName As String) As String
        Dim DocumentText As New StringBuilder
        Using document As PdfDocument = PdfDocument.Open(FileName)
            For Each page In document.GetPages
                DocumentText.AppendLine(page.Text)
            Next
        End Using
        Return DocumentText.ToString()
    End Function

    Private Function CountTokens(Text As String) As Integer

        Dim Encoder = ModelToEncoder.For("gpt-4o")  '; // Or explicitly using New Encoder(New O200KBase())
        'Dim Tokens = Encoder.Encode(Text)
        'Dim NewText = Encoder.Decode(Tokens)
        Dim numberOfTokens = Encoder.CountTokens(Text)
        Return numberOfTokens
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If NewKnowledge.Key <> "" And NewKnowledge.Text <> "" Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Please enter a key and supply knowledge text", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Missing Data")
        End If
    End Sub

    Private Sub btnRecalc_Click(sender As Object, e As EventArgs) Handles btnRecalc.Click
        Me.Cursor = Cursors.WaitCursor
        RecalculateTokens()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtKey_TextChanged(sender As Object, e As EventArgs) Handles txtKey.TextChanged, txtText.TextChanged
        If amUpdating Then Exit Sub
        NewKnowledge.Key = txtKey.Text
        NewKnowledge.Text = txtText.Text

    End Sub


End Class