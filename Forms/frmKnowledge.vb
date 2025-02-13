Imports System.Text
Imports Tabula
Imports Tabula.Detectors
Imports Tabula.Extractors
Imports Tiktoken
Imports UglyToad.PdfPig
Imports UglyToad.PdfPig.Content
Imports UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor

Public Class frmKnowledge

    Public Property NewKnowledge As KnowledgeEntry

    Private DarkMode As DarkModeForms.DarkModeCS
    Private amUpdating As Boolean = False

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        DarkMode = Utils.GetColorMode(Me)
    End Sub
    Private Sub frmKnowledge_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        WebViewSetup()
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
            NewKnowledge.Tables = ExtractTables(FullFilename)
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
        Me.lblsize.Text = Utils.FormatFileSize(NewKnowledge.Size)
        Me.lblTokens.Text = NewKnowledge.Tokens.ToString("###,###,##0")
        Me.txtKey.Text = NewKnowledge.Key
        Me.txtText.Text = NewKnowledge.Text
        Me.txtText.Enabled = True
        Me.txtKey.Enabled = True
        Me.btnRecalc.Enabled = True
        Me.txtFile.Text = NewKnowledge.Name
        ShowPDFFile(NewKnowledge.Name)
        ShowTables(NewKnowledge.Tables)
        amUpdating = False
    End Sub
    Private Function ReadPDFText(FileName As String) As String
        Dim DocumentText As New StringBuilder
        Using document As PdfDocument = PdfDocument.Open(FileName)
            For Each page In document.GetPages
                DocumentText.Append(ContentOrderTextExtractor.GetText(page))
                Dim Mytext = DocumentText.ToString
                Debug.Print("")
            Next
        End Using
        Return DocumentText.ToString()
    End Function
    Private Function ExtractTables(Filename As String) As PDFTables
        Dim MyTables As New PDFTables

        Using document = PdfDocument.Open(Filename, New ParsingOptions() With {.ClipPaths = True})
            Dim Pages = Tabula.ObjectExtractor.Extract(document)
            While Pages.MoveNext()
                Dim page = Pages.Current
                Dim Detector = New SimpleNurminenDetectionAlgorithm()
                Dim regions = Detector.Detect(page)
                Dim ea As IExtractionAlgorithm = New BasicExtractionAlgorithm()
                For x As Integer = 0 To regions.Count - 1
                    Dim region = regions(x)
                    Dim tables = ea.Extract(page.GetArea(region.BoundingBox))
                    For Each table As Table In tables
                        Dim MyTable As New PDFTable
                        MyTables.Add(MyTable)
                        MyTable.Page = page.PageNumber
                        MyTable.RowCount = table.RowCount
                        MyTable.ColumnCount = table.ColumnCount
                        MyTable.DocumentName = Filename

                        For Each row In table.Rows
                            Dim MyRow As New PDFRow
                            MyTable.Rows.Add(MyRow)

                            For Each cell In row
                                If cell.IsSpanning Or cell.IsPlaceholder Then
                                    Debug.Print("")
                                End If
                                MyRow.Cells.Add(cell.GetText())
                            Next
                        Next
                    Next
                Next
            End While
        End Using
        Return MyTables
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
            If Utils.Knowledge.GetEntry(NewKnowledge.Key.Trim) IsNot Nothing Then
                MsgBox($"The Knowledge entry for Key '{NewKnowledge.Key} already exists - please provide another key ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Knowledge Management")
                Exit Sub
            End If
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


    Private Async Sub WebViewSetup()
        If WebView21.CoreWebView2 Is Nothing Then
            Dim CacheDirectory = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\OllamaChat\Cache"
            Dim env = Await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder:=CacheDirectory)
            Try
                Await WebView21.EnsureCoreWebView2Async(env)
            Catch ex As Exception
                Debug.Print($"CoreWebView2 threw an error {ex.Message}")
            End Try
        End If
    End Sub

    Private Sub ShowPDFFile(Text As String)
        WebView21.Source = New Uri("file:////" & Text.Replace("\", "/"))
    End Sub

    Private Sub ShowTables(Tables As PDFTables)
        Me.lstTables.Items.Clear()
        Dim x As Integer = 0
        For Each table In Tables
            x += 1
            Dim MyNode As New ListViewItem
            MyNode.Text = x.ToString
            MyNode.SubItems.Add(table.Page)
            MyNode.SubItems.Add(table.RowCount)
            MyNode.SubItems.Add(table.ColumnCount)
            MyNode.Tag = table
            Me.lstTables.Items.Add(MyNode)
        Next
    End Sub

    Private Sub lstTables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTables.SelectedIndexChanged
        If lstTables.SelectedItems.Count = 1 Then
            Dim MyTable As PDFTable = lstTables.SelectedItems(0).Tag
            Me.DataGridView1.Rows.Clear()
            Me.DataGridView1.Columns.Clear()
            For x = 0 To MyTable.ColumnCount - 1
                Me.DataGridView1.Columns.Add($"TableCol{x}", x.ToString)
            Next
            For Each row In MyTable.Rows
                Dim MyRow = New DataGridViewRow
                MyRow.CreateCells(Me.DataGridView1)
                For x As Integer = 1 To row.Cells.Count
                    Dim Cell = row.Cells(x - 1)
                    MyRow.Cells(x - 1).Value = Cell
                Next
                Me.DataGridView1.Rows.Add(MyRow)
            Next
        End If
    End Sub
End Class