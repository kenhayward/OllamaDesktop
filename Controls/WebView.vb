Public Class WebView

    Public Async Sub Setup()
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
    Public Sub ShowText(Text As String)
        WebView21.CoreWebView2.NavigateToString(Text)
    End Sub

    Public Sub ShowPDFFile(Text As String)
        WebView21.CoreWebView2.Navigate("File:////" & Text.Replace("\", "/"))
    End Sub


End Class

