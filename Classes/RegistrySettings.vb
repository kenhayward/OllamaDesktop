Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Microsoft.SqlServer
Imports Microsoft.Win32

<Serializable()> Public Class OllamaServers
    Inherits List(Of OllamaServer)
    Public Property CurrentServer As OllamaServer

    Private _ChatHistory As ChatHistoryList
    Public ReadOnly Property ChatHistory As ChatHistoryList
        Get
            If _ChatHistory Is Nothing Then
                _ChatHistory = New ChatHistoryList
            End If
            Return _ChatHistory
        End Get
    End Property

    Public Function isCurrentServer(Server As OllamaServer) As Boolean
        Dim isCurrent As Boolean = False
        If CurrentServer IsNot Nothing Then
            If Utils.OllamaServers.CurrentServer.Equals(Server) Then
                isCurrent = True
            End If
        End If
        Return isCurrent
    End Function
    Public Function AddServer() As OllamaServer
        Dim MyModel As New OllamaServer
        MyModel.Protocol = "http://"
        MyModel.Port = 11434
        MyModel.Server = "127.0.0.1"
        MyModel.Name = "Ollama " & (Utils.OllamaServers.Count + 1).ToString
        Me.Add(MyModel)
        Return MyModel
    End Function

    Public Shared Sub Save(servers As OllamaServers)
        Dim formatter As New BinaryFormatter()
        Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim filePath As String = Path.Combine(documentsPath, "OllamaServers.bin")

        Using stream As New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)
            formatter.Serialize(stream, servers)
        End Using
    End Sub
    Public Shared Function Load() As OllamaServers
        Try

            Dim formatter As New BinaryFormatter()
            Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim filePath As String = Path.Combine(documentsPath, "OllamaServers.bin")

            Using stream As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None)
                Return CType(formatter.Deserialize(stream), OllamaServers)
            End Using
        Catch ex As Exception
            Return New OllamaServers
        End Try
    End Function

End Class

<Serializable()> Public Class OllamaServer

    Public Property Name As String
    Public Property Server As String
    Public Property Port As Integer
    Public Property Models As New LLMmodels
    Public Property DefaultModel As LLMmodel
    Public Property Protocol As String

    Public Function isCurrent() As Boolean
        Return Utils.OllamaServers.isCurrentServer(Me)
    End Function

    Public ReadOnly Property ServerString As String
        Get
            Return Protocol & Server
        End Get
    End Property
    Public ReadOnly Property FullString As String
        Get
            Return $"{Protocol}{Server}:{Port}/"
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.Name
    End Function

End Class

<Serializable()> Public Class ChatHistoryList
    Inherits List(Of ChatHistoryItem)
End Class
<Serializable()> Public Class ChatHistoryItem
    Public Property Title As String
    Public Property Prompt As String
    Public Property HTML As String
    Public Property Markdown As String
    Public Property Server As String
    Public Property Model As String

    Public Property Timed As Date

    Public Event NewTitle(Hist As ChatHistoryItem)
    Private TitleResponse As ChatResponseMessage
    Public Sub GetTitle(theModel As LLMmodel)
        Dim OllamaServer As New Ollama(Utils.OllamaServers.CurrentServer, theModel)
        OllamaServer.ShowCOT = False
        AddHandler OllamaServer.ChatComplete, AddressOf HistoryComplete
        AddHandler OllamaServer.ChatUpdate, AddressOf UpdateHistory
        OllamaServer.SendChat($"Create a single 2 to 5 word title for this prompt without using any quotes: {Prompt}")
    End Sub
    Private Sub HistoryComplete()

        Title = TitleResponse.Markdown
        Title = Title.Trim.Replace(vbLf, "")
        Title = Title.Replace(vbCr, "")
        Title = Title.Replace("""", "")
        OllamaServers.Save(Utils.OllamaServers)
        RaiseEvent NewTitle(Me)
    End Sub
    Private Sub UpdateHistory(ChatResponse As ChatResponseMessage)
        TitleResponse = ChatResponse
    End Sub
End Class

<Serializable()> Public Class ChatResponseMessage
    Public Property FullHTML As Boolean = False
    Public Property FirstPacket As Boolean = False
    Public Property HTML As String
    Public Property JustDiv As String
    Public Property Markdown As String
End Class
