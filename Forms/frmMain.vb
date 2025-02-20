Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO.Pipes
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.Web.WebView2.Core

Public Class frmMain
    Private DarkMode As DarkModeForms.DarkModeCS
    Public Property AddTitle As Boolean = False

    Private Async Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SplitContainer1.Panel1Collapsed = True
        Do While Utils.OllamaServers.Count = 0
            frmServers.ShowDialog(Me)
            If Utils.OllamaServers.Count = 0 Then
                If MsgBox("You must specify at least one Ollama Server for the application to run, try again? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Ollama Chat") = MsgBoxResult.No Then
                    End
                End If
            End If
        Loop

        ChatHistoryView1.LoadHistory()


        Dim CacheDirectory = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\OllamaChat\Cache"
        Dim env = Await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder:=CacheDirectory)
        Await WebView21.EnsureCoreWebView2Async(env)
        ToolTip1.SetToolTip(btnExpand, "Show Settings, Chat History and Prompt Library")
        ToolTip2.SetToolTip(btnCollapse, "Hide Side Panel")
        ToolTip3.SetToolTip(btnSettings, "Establish connection to servers and set defaults")

        LoadServers()

        WebView21.NavigateToString("<html><body><div id=""MainContent""><h1> </h1></div></body></html>")
        Me.Cursor = DefaultCursor
        Me.txtPrompt.Focus()
    End Sub


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DarkMode = Utils.GetColorMode(Me)

    End Sub

    Private Sub LoadServers()
        Me.cmbModel.Items.Clear()
        Me.cmbServer.Items.Clear()
        For Each Server In Utils.OllamaServers
            Me.cmbServer.Items.Add(Server)
            If Server.isCurrent Then
                cmbServer.SelectedItem = Server
                Me.GetModels()
            End If
        Next
    End Sub

    Private Sub ServerClick(sender As Object, e As EventArgs) Handles cmbServer.SelectedIndexChanged
        Dim Myserver As OllamaServer = cmbServer.SelectedItem
        Utils.OllamaServers.CurrentServer = Myserver
        Me.GetModels()
    End Sub

    Private Sub GetModels()
        Dim MyServer As OllamaServer = Utils.OllamaServers.CurrentServer
        If MyServer IsNot Nothing Then
            Me.cmbModel.Items.Clear()
            If MyServer.Models.Count = 0 Then
                Dim MyS = New OllamaAccess(MyServer)
                MyS.GetModels()
            End If
            For Each model In MyServer.Models
                Me.cmbModel.Items.Add(model)
                If MyServer.DefaultModel.Equals(model) Then
                    Me.cmbModel.SelectedItem = model
                End If
            Next
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        ' Send the Query
        If txtPrompt.Text.Trim <> "" And cmbModel.SelectedItem IsNot Nothing And cmbServer.SelectedItem IsNot Nothing Then
            Dim PromptText As String = txtPrompt.Text
            ' Check for expansions
            If ContextEntries.Count > 0 Then
                Dim PStr As New StringBuilder
                Dim PromptLen As Integer = PromptText.Length
                Dim Index As Integer = 0
                ' find the expansions
                While PromptText.IndexOf("{", Index) > 0
                    Dim bPos = PromptText.IndexOf("{", Index)
                    PStr.Append(PromptText, Index, bPos - Index)
                    Dim ePOs = PromptText.IndexOf("}", bPos)
                    Dim entry = PromptText.Substring(bPos + 1, ePOs - bPos - 1)
                    Dim Target = Utils.Knowledge.GetEntry(entry)
                    If Target IsNot Nothing Then
                        PStr.Append(Target.Text)
                    End If
                    Index = ePOs + 1
                End While
                PStr.Append(PromptText.Substring(Index))  ' The Tail
                Dim TempPrompt = PStr.ToString
                PromptText = PStr.ToString
            End If
            Me.Cursor = Cursors.WaitCursor
            pnlDetails.Visible = False
            Dim StartTime = DateTime.Now
            Me.btnSend.Enabled = False
            Me.txtPrompt.Enabled = False
            Dim OllamaServer As New OllamaAccess(Utils.OllamaServers.CurrentServer, cmbModel.SelectedItem)
            OllamaServer.ShowCOT = chkShowCOT.Checked
            AddHandler OllamaServer.ChatUpdate, AddressOf ChatUpdate
            AddHandler OllamaServer.ChatComplete, AddressOf ChatComplete
            OllamaServer.SendChat(PromptText)
            Me.Cursor = Cursors.Default
        Else
            MsgBox("Please ensure you have selected a server and a model and provided a chat prompt", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Ollama Chat")
        End If
    End Sub

    Private ChatResponse As ChatResponseMessage
    Private Locker As Boolean = False
    Private Async Sub ChatUpdate(CR As ChatResponseMessage)
        If Locker Then Exit Sub
        Locker = True
        If CR.FirstPacket Then
            WebView21.CoreWebView2.NavigateToString(CR.HTML)
        Else
            If CR.FullHTML Then
                WebView21.CoreWebView2.NavigateToString(CR.HTML)
            Else
                If CR.FullHTML Then
                    WebView21.CoreWebView2.NavigateToString(CR.HTML)
                Else
                    Await UpdateElementAsync("MainContent", "innerHTML", CR.JustDiv)
                End If
            End If
        End If
        'Await WebView21.CoreWebView2.ExecuteScriptAsync("window.scrollTo(0,  document.body.scrollHeight)")
        ChatResponse = CR
        Locker = False
    End Sub
    Private Sub ChatComplete()
        Me.Cursor = Cursors.WaitCursor
        btnSend.Enabled = True
        txtPrompt.Enabled = True
        btnCopy.Visible = True
        WebView21.CoreWebView2.NavigateToString(ChatResponse.HTML)
        ' Add to history here
        Dim Hist As New ChatHistoryItem
        Hist.Markdown = ChatResponse.Markdown
        Hist.Prompt = txtPrompt.Text
        Hist.HTML = ChatResponse.HTML
        Hist.Server = cmbServer.SelectedItem.ToString
        Hist.Model = cmbModel.SelectedItem.ToString
        Hist.Timed = Now
        Utils.OllamaServers.ChatHistory.Add(Hist)
        If Me.AddTitle Then
            Hist.GetTitle(cmbModel.SelectedItem)
        End If
        ChatHistoryView1.AddToHistoryNode(Hist)
        ShowDetailsPanel(Hist)
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Function UpdateElementAsync(ByVal elementID As String, ByVal [property] As String, ByVal value As String) As Task
        Try
            value = value.Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\'").Replace(":", "\:").Replace("+", "\+")
            Await Me.WebView21.CoreWebView2.ExecuteScriptAsync("document.getElementById('" & elementID & "')." & [property] & " = '" & value & "'")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim MyForm As New frmServers
        MyForm.ShowDialog(Me)
        LoadServers()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Clipboard.SetText(ChatResponse.Markdown)
        ' Copy the markdown to the clipboard
        MsgBox("The response has been copied to the clipboard", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Copy Chat Response")

    End Sub
    Private Sub ShowHistororicalChat(Hist As ChatHistoryItem) Handles ChatHistoryView1.ShowHistoryDetail
        ShowDetailsPanel(Hist)
        WebView21.CoreWebView2.NavigateToString(Hist.HTML)
        Me.txtPrompt.Text = Hist.Prompt
    End Sub
    Private Sub ShowDetailsPanel(Hist As ChatHistoryItem)
        Me.lblHistModel.Text = $"Server: {Hist.Server}, Model: {Hist.Model}"
        Me.lblHistDated.Text = Hist.Timed.ToString("ddd d MMM yyyy HH:mm")
        Me.lblHistTitle.Text = Hist.Title
        Me.pnlDetails.Visible = True
    End Sub

    Private ContextEntries As New KnowledgeSet
    Private Sub txtPrompt_TextChanged(sender As Object, e As EventArgs) Handles txtPrompt.TextChanged
        ' Look for expansions 
        If txtPrompt.Text <> "" Then
            If txtPrompt.Text.EndsWith("}") Then
                ' Expansion
                Dim Startpos = txtPrompt.Text.LastIndexOf("{")
                Dim EndPos = (txtPrompt.Text.Length - 1) - Startpos
                If Startpos < 0 Then Exit Sub
                Dim Key As String = txtPrompt.Text.Substring(Startpos + 1, EndPos - 1)
                Key = Key.Trim
                Dim Target = ContextEntries.GetEntry(Key)
                If Target IsNot Nothing Then
                    txtPrompt.Text = txtPrompt.Text.ReplaceAt(Startpos + 1, EndPos - 1, Target.Key)
                    Exit Sub
                Else
                    Target = Utils.Knowledge.GetEntry(Key)
                    If Target IsNot Nothing Then
                        ContextEntries.Add(Target)
                        txtPrompt.Text = txtPrompt.Text.ReplaceAt(Startpos + 1, EndPos - 1, Target.Key)
                        If lblExpansions.Text.Length = 0 Then lblExpansions.Text = "Including Context Knowledge: "
                        Me.lblExpansions.Text &= Target.Key & " "
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub btnCollapse_Click(sender As Object, e As EventArgs) Handles btnCollapse.Click
        If Not SplitContainer1.Panel1Collapsed Then
            SplitContainer1.Panel1Collapsed = True
            btnExpand.Visible = True
        End If
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
        If SplitContainer1.Panel1Collapsed Then
            SplitContainer1.Panel1Collapsed = False
            btnExpand.Visible = False
        End If
    End Sub
End Class
