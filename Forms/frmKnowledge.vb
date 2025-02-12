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
        DarkMode = New DarkModeCS(Me, True, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}
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
        ExtractTables(FileName)
        Return DocumentText.ToString()
    End Function
    Private Sub ExtractTables(Filename As String)
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
                        Debug.Print("---------------------------------------------------------------------------------")
                        Debug.Print($"TABLE: Page {page.PageNumber} Rows:{table.RowCount} Columns: {table.ColumnCount}")
                        Debug.Print("---------------------------------------------------------------------------------")
                        For Each row In table.Rows
                            Dim Str As String = ""
                            For Each cell In row
                                Str &= cell.GetText() & Space(10)
                            Next
                            Debug.Print(Str)
                        Next
                    Next
                Next
            End While
        End Using
    End Sub

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


    Public Async Sub WebViewSetup()
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

    Public Sub ShowPDFFile(Text As String)
        WebView21.Source = New Uri("file:////" & Text.Replace("\", "/"))
    End Sub


End Class