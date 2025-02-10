Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Web
Imports Microsoft.Web.WebView2
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json.Linq

Public Class Ollama

    Public Property Server As OllamaServer
    Private Model As LLMmodel

    Public Property API_ModelList As String = "tags"
    Public Property API_Chat As String = "generate"
    Public ShowCOT As Boolean
    Private ChatMessage As String
    Public Property WView As WebView2
    Private WithEvents ChatWorker As BackgroundWorker
    Private Function GenerateURL(CTail As String) As String
        If Server Is Nothing Then
            Server = Utils.OllamaServers.CurrentServer
        End If
        Dim Result = $"{Server.Protocol}{Server.Server}:{Server.Port}/api/{CTail}"
        Return Result
    End Function
    Public Sub New(SelectedServer As OllamaServer)
        Me.Server = SelectedServer
    End Sub
    Public Sub New(SelectedServer As OllamaServer, SelectedModel As LLMmodel)
        Me.Server = SelectedServer
        Me.Model = SelectedModel
    End Sub
    Public Function VerifyConnection() As Boolean
        Try
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(GenerateURL(API_ModelList)), HttpWebRequest)
            With myHttpWebRequest
                .Method = "GET"
                .ContentType = "application/json"
                .Accept = "application/json"
                .MediaType = "jsonp"
            End With
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Return True
        Catch
            Return False
        End Try
    End Function


    Private Function GenerateRequest(Prompt As String, UseModel As String, Optional StreamResponse As Boolean = True) As HttpWebRequest
        Dim Request As HttpWebRequest = CType(WebRequest.Create(GenerateURL(API_Chat)), HttpWebRequest)
        With Request
            .Method = "POST"
            .Accept = "application/json"
            .ContentType = "application/json"
            .Accept = "application/json"
            .MediaType = "jsonp"
            .Timeout = 60 * 10 * 1000
        End With
        Dim Content = New JObject From {{"model", UseModel.ToString},
                                                {"prompt", Prompt},
                                                {"keep_alive", 300},
                                                {"stream", StreamResponse}}
        Dim myJson = Content.ToString()
        Dim data As Byte() = Encoding.UTF8.GetBytes(myJson)
        Request.ContentLength = data.Length
        Dim stream As Stream = Request.GetRequestStream()
        stream.Write(data, 0, data.Length)
        stream.Close()
        Return Request
    End Function
    Public Enum HTMLState As Integer
        Thinking = 0
        ThinkingNoShow = 1
        Response = 2
    End Enum
    Public Sub GetChatResponse()


        Dim Request As HttpWebRequest = GenerateRequest("", Model.Name)
        ChatWorker.ReportProgress(0, "Awaiting Model Response")
        Try
            Dim Response As HttpWebResponse = CType(Request.GetResponse(), HttpWebResponse)
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(Response.GetResponseStream())
            Dim Markd As String = ""
            Dim isThinking As Boolean = False
            While Not sr.EndOfStream
                Dim Models As String = sr.ReadLine
                Dim jsonResulttodict = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(Models)
                Dim Fragment = jsonResulttodict.Item("response")

                If Fragment.Equals("<think>") Then
                    ' Start of thinking process
                    isThinking = True
                    If ShowCOT Then
                        Markd = "<b>Thinking...</b>"
                        Markd &= "<hr style=""height: 3px; border: none; background-color: #000;"">"
                        ChatWorker.ReportProgress(0, Markd)
                    Else
                        Dim Spinner = My.Resources.spin
                        ChatWorker.ReportProgress(0, Spinner)
                        Markd = ""
                    End If
                ElseIf Fragment.Equals("</think>") Then
                    ' End of thinking process
                    isThinking = False
                    If ShowCOT Then
                        Markd &= "<hr style=""height: 3px; border: none; background-color: #000;"">"
                        SendToBrowser(Markd)
                    Else
                        Markd = ""
                    End If
                Else
                    If isThinking Then
                        If ShowCOT Then
                            Markd &= Fragment
                            SendToBrowser(Markd)
                        End If
                    Else
                        Markd &= Fragment
                        SendToBrowser(Markd)
                    End If
                End If
            End While
        Catch ex As Exception
            ChatWorker.ReportProgress(0, "Chat request failed: " & ex.Message)
        End Try
    End Sub
    Private Sub SendToBrowser(Markd As String)
        Const HTMLPrefix As String = "<!DOCTYPE html><html><head>
   <script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>
   <script>
      $(document).ready(function(){window.scrollTo(0,  document.body.scrollHeight);});
   </script>
   </head>
   <body>" & vbCrLf

        Const HTMLSUffix As String = "</body></html>"
        Dim OutHTML As String = HTMLPrefix & Markdown.Parse(Markd) & vbCrLf & vbCrLf & HTMLSUffix
        ChatWorker.ReportProgress(0, OutHTML)

    End Sub

    Public Function GetModels() As LLMmodels
        Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(GenerateURL(API_ModelList)), HttpWebRequest)
        With myHttpWebRequest
            .Method = "GET"
            .ContentType = "application/json"
            .Accept = "application/json"
            .MediaType = "jsonp"
        End With
        Dim Response As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(Response.GetResponseStream())
        Dim Models As String = sr.ReadToEnd
        Dim jsonResulttodict = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(Models)
        Dim firstItem = jsonResulttodict.Item("models")
        Dim Modellist As New LLMmodels
        For Each item In firstItem
            Dim MyModel As New LLMmodel
            MyModel.Name = item.item("name")
            MyModel.Size = item.item("size")
            MyModel.ParameterSize = item.item("details").item("parameter_size")
            MyModel.Quantization = item.item("details").item("quantization_level")
            Modellist.Add(MyModel)
        Next
        Return Modellist
    End Function


    Private _Loading As Boolean = False


    Public Sub SendChat(Prompt As String, SelectedModel As LLMmodel)
        If Prompt.Trim.Length > 0 Then
            Dim StartTime = DateTime.Now
            ChatWorker = New BackgroundWorker
            ChatWorker.WorkerReportsProgress = True
            ChatMessage = Prompt
            Model = SelectedModel
            ChatWorker.RunWorkerAsync()
        End If
    End Sub


    Private Sub MyWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles ChatWorker.RunWorkerCompleted

    End Sub

    Private Sub MyWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles ChatWorker.DoWork
        Me.GetChatResponse()
    End Sub

    Private Sub MyWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles ChatWorker.ProgressChanged
        'WebView1.Visible = True
        'Me.WebView1.ShowText(e.UserState)
        'Me.WebView1.Refresh()
        'Me.WebView1.VerticalScroll.Value = Me.WebView1.VerticalScroll.Maximum
    End Sub

End Class
